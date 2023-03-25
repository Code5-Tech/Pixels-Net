using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Pixels.Core
{
    public unsafe class PixelsProcessor
    {
        #region internal classes
        public struct PixelData
        {
            public byte blue;
            public byte green;
            public byte red;
            public byte alpha;
        }

        public struct HSLData
        {
            public float Hue;
            public float Saturation;
            public float Luminance;
        }

        public class FRange
        {
            public float Min;
            public float Max;

            public FRange()
            {
            }
        }

        public class HSLRange
        {
            public FRange Zrange1;
            public FRange Zrange2;

            public HSLRange()
            {
                Zrange1 = new FRange();
                Zrange2 = new FRange();
            }

            public FRange Range1
            {
                get { return Zrange1; }
                set { Zrange1 = value; }
            }

            public FRange Range2
            {
                get { return Zrange2; }
                set { Zrange2 = value; }
            }

            public bool Contains(float Value)
            {
                if (Value >= Range1.Min && Value <= Range1.Max)
                {
                    return true;
                }

                if (Value >= Range2.Min && Value <= Range2.Max)
                {
                    return true;
                }

                return false;
            }
        }
        #endregion

        private Bitmap bitmap;

        private int width = 0;

        private BitmapData bitmapData = null;
        private byte* pBase = null;
        protected byte[] pixelsList = null;
        protected PixelsProcessor(Bitmap bitmap)
        {
            this.bitmap = bitmap;
        }
        protected PixelsProcessor(byte[] bytesArray)
        {
            MemoryStream ms = new MemoryStream(bytesArray);
            var btemp = new Bitmap(ms);
            bitmap = btemp.Clone(new Rectangle(0, 0, btemp.Width, btemp.Height), PixelFormat.Format32bppArgb);
        }
        protected PixelsProcessor(string bitmapPath)
        {
            bitmap = new Bitmap(bitmapPath);
        }
        protected PixelsProcessor()
        {
        }

        protected void Save(string filename, string type = "png")
        {
            if (type == "png")
                bitmap.Save(filename, ImageFormat.Png);
            else
            {
                bitmap.Save(filename, ImageFormat.Jpeg);
            }
        }

        protected void Dispose()
        {
            if (bitmapData != null)
            {
                UnlockBitmap();
            }
        }

        protected Bitmap Bitmap
        {
            get
            {
                return (bitmap);
            }
            set
            {
                bitmap = value;
            }
        }

         protected byte CheckByte(double value)
        {
            if (value < 0) return 0;
            return (byte)Math.Min(value, 255);
        }

        protected Point PixelSize
        {
            get
            {
                GraphicsUnit unit = GraphicsUnit.Pixel;
                RectangleF bounds = bitmap.GetBounds(ref unit);

                return new Point((int)bounds.Width, (int)bounds.Height);
            }
        }
        
        protected HSLData RGBtoHSL(int Red, int Green, int Blue)
        {
            HSLData hsl = new HSLData();

            Color c = Color.FromArgb(255, Red, Green, Blue);
            hsl.Hue = c.GetHue();
            hsl.Saturation = c.GetSaturation();
            hsl.Luminance = c.GetBrightness();

            return hsl;
        }

        //see http://www.mpa-garching.mpg.de/MPA-GRAPHICS/hsl-rgb.html
        protected PixelData HSLtoRGB(double H, double S, double L)
        {
            double Temp1 = 0.0, Temp2 = 0.0;
            double r = 0.0, g = 0.0, b = 0.0;

            if (S == 0)
            {
                r = L;
                g = L;
                b = L;
            }
            else
            {
                if (L < 0.5)
                {
                    Temp2 = L * (1.0 + S);
                }
                else
                {
                    Temp2 = (L + S) - (S * L);
                }

                Temp1 = 2.0 * L - Temp2;

                //bischen Spaghetti hier, evtl. in eigene Funktion auslagern

                double hTmp = H / 360.0;
                double rTmp, gTmp, bTmp;

                rTmp = hTmp + (1.0 / 3.0);
                gTmp = hTmp;
                bTmp = hTmp - (1.0 / 3.0);

                if (rTmp < 0.0)
                {
                    rTmp += 1.0;
                }

                if (gTmp < 0.0)
                {
                    gTmp += 1.0;
                }

                if (bTmp < 0.0)
                {
                    bTmp += 1.0;
                }

                if (rTmp > 1.0)
                {
                    rTmp -= 1.0;
                }

                if (gTmp > 1.0)
                {
                    gTmp -= 1.0;
                }

                if (bTmp > 1.0)
                {
                    bTmp -= 1.0;
                }

                if (6.0 * rTmp < 1.0)
                {
                    r = Temp1 + (Temp2 - Temp1) * 6.0 * rTmp;
                }
                else if (2.0 * rTmp < 1.0)
                {
                    r = Temp2;
                }
                else if (3.0 * rTmp < 2.0)
                {
                    r = Temp1 + (Temp2 - Temp1) * ((2.0 / 3.0) - rTmp) * 6.0;
                }
                else
                {
                    r = Temp1;
                }

                if (6.0 * gTmp < 1.0)
                {
                    g = Temp1 + (Temp2 - Temp1) * 6.0 * gTmp;
                }
                else if (2.0 * gTmp < 1.0)
                {
                    g = Temp2;
                }
                else if (3.0 * gTmp < 2.0)
                {
                    g = Temp1 + (Temp2 - Temp1) * ((2.0 / 3.0) - gTmp) * 6.0;
                }
                else
                {
                    g = Temp1;
                }

                if (6.0 * bTmp < 1.0)
                {
                    b = Temp1 + (Temp2 - Temp1) * 6.0 * bTmp;
                }
                else if (2.0 * bTmp < 1.0)
                {
                    b = Temp2;
                }
                else if (3.0 * bTmp < 2.0)
                {
                    b = Temp1 + (Temp2 - Temp1) * ((2.0 / 3.0) - bTmp) * 6.0;
                }
                else
                {
                    b = Temp1;
                }
            }

            PixelData RGB = new PixelData();

            r *= 255.0;
            g *= 255.0;
            b *= 255.0;

            RGB.red = (byte)((int)r);
            RGB.green = (byte)((int)g);
            RGB.blue = (byte)((int)b);

            return RGB;
        }

        protected void LockBitmap()
        {
            GraphicsUnit unit = GraphicsUnit.Pixel;
            RectangleF boundsF = bitmap.GetBounds(ref unit);
            Rectangle bounds = new Rectangle((int)boundsF.X,
                (int)boundsF.Y,
                (int)boundsF.Width,
                (int)boundsF.Height);

            // Figure out the number of bytes in a row
            // This is rounded up to be a multiple of 4
            // bytes, since a scan line in an image must always be a multiple of 4 bytes
            // in length.
            width = (int)boundsF.Width * sizeof(PixelData);
            if (width % 4 != 0)
            {
                width = 4 * (width / 4 + 1);
            }

            bitmapData = bitmap.LockBits(bounds, ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            
            pBase = (Byte*)bitmapData.Scan0.ToPointer();
        }
        protected void LoadPixels()
        {
            IntPtr ptr = bitmapData.Scan0;
            pixelsList = new byte[bitmapData.Stride * bitmap.Height];
            Marshal.Copy(ptr, pixelsList, 0, pixelsList.Length);
        }
        protected void SetPixels()
        {
            IntPtr ptr = bitmapData.Scan0;
            Marshal.Copy(pixelsList, 0, ptr, pixelsList.Length);
        }
        protected PixelData* PixelAt(int x, int y)
        {
            return (PixelData*)(pBase + y * width + x * sizeof(PixelData));
        }

        protected void UnlockBitmap()
        {
            bitmap.UnlockBits(bitmapData);
            bitmapData = null;
            pBase = null;
        }

        protected void Invert()
        {
            Point size = PixelSize;

            LockBitmap();

            for (int y = 0; y < size.Y; y++)
            {
                PixelData* pPixel = PixelAt(0, y);
                for (int x = 0; x < size.X; x++)
                {
                    byte value = (byte)(255 - pPixel->red);
                    pPixel->red = value;
                    value = (byte)(255 - pPixel->green);
                    pPixel->green = value;
                    value = (byte)(255 - pPixel->blue);
                    pPixel->blue = value;
                    pPixel++;
                }
            }
            UnlockBitmap();
        }

        protected void drawOneColor(int nAlpha, int nRed, int nGreen, int nBlue)
        {
            Point size = PixelSize;

            LockBitmap();

            for (int y = 0; y < size.Y; y++)
            {
                PixelData* pPixel = PixelAt(0, y);
                for (int x = 0; x < size.X; x++)
                {
                    int value = nAlpha;
                    if (value < 0)
                    {
                        value = 0;
                    }

                    if (value > 255)
                    {
                        value = 255;
                    }

                    pPixel->alpha = (byte)value;
                    int value2 = nRed;
                    if (value2 < 0)
                    {
                        value2 = 0;
                    }

                    if (value2 > 255)
                    {
                        value2 = 255;
                    }

                    pPixel->red = (byte)value2;
                    int value3 = nGreen;
                    if (value3 < 0)
                    {
                        value3 = 0;
                    }

                    if (value3 > 255)
                    {
                        value3 = 255;
                    }

                    pPixel->green = (byte)value3;
                    int value4 = nBlue;
                    if (value4 < 0)
                    {
                        value4 = 0;
                    }

                    if (value4 > 255)
                    {
                        value4 = 255;
                    }

                    pPixel->blue = (byte)value4;
                    pPixel++;
                }
            }
            UnlockBitmap();
        }

        protected void replaceColors(int nAlpha, int nRed, int nGreen, int nBlue, int tolerance, int zAlpha, int zRed, int zGreen, int zBlue)
        {
            Point size = PixelSize;

            LockBitmap();

            for (int y = 0; y < size.Y; y++)
            {
                PixelData* pPixel = PixelAt(0, y);
                for (int x = 0; x < size.X; x++)
                {
                    if ((pPixel->alpha == 0 && zAlpha == 0) ||
                         ((pPixel->alpha > (zAlpha - tolerance)) && (pPixel->alpha < (zAlpha + tolerance))
                         && (pPixel->red > (zRed - tolerance)) && (pPixel->red < (zRed + tolerance))
                         && (pPixel->green > (zGreen - tolerance)) && (pPixel->green < (zGreen + tolerance))
                         && (pPixel->blue > (zBlue - tolerance)) && (pPixel->blue < (zBlue + tolerance))))
                    {
                        int value = nAlpha + (pPixel->alpha - zAlpha);
                        if (value < 0)
                        {
                            value = 0;
                        }

                        if (value > 255)
                        {
                            value = 255;
                        }

                        pPixel->alpha = (byte)value;
                        int value2 = nRed + (pPixel->red - zRed);
                        if (value2 < 0)
                        {
                            value2 = 0;
                        }

                        if (value2 > 255)
                        {
                            value2 = 255;
                        }

                        pPixel->red = (byte)value2;
                        int value3 = nGreen + (pPixel->green - zGreen);
                        if (value3 < 0)
                        {
                            value3 = 0;
                        }

                        if (value3 > 255)
                        {
                            value3 = 255;
                        }

                        pPixel->green = (byte)value3;
                        int value4 = nBlue + (pPixel->blue - zBlue);
                        if (value4 < 0)
                        {
                            value4 = 0;
                        }

                        if (value4 > 255)
                        {
                            value4 = 255;
                        }

                        pPixel->blue = (byte)value4;
                    }
                    pPixel++;
                }
            }
            UnlockBitmap();
        }

        protected void Contrast(int nContrast)
        {
            if (nContrast < -100)
            {
                return;
            }

            if (nContrast > 100)
            {
                return;
            }

            double fpixel = 0, contrast = (100.0 + nContrast) / 100.0;

            contrast *= contrast;

            Point size = PixelSize;

            LockBitmap();

            for (int y = 0; y < size.Y; y++)
            {
                PixelData* pPixel = PixelAt(0, y);
                for (int x = 0; x < size.X; x++)
                {
                    double red = (double)(pPixel->red);

                    fpixel = red / 255.0;
                    fpixel -= 0.5;
                    fpixel *= contrast;
                    fpixel += 0.5;
                    fpixel *= 255;
                    if (fpixel < 0)
                    {
                        fpixel = 0;
                    }

                    if (fpixel > 255)
                    {
                        fpixel = 255;
                    }

                    pPixel->red = (byte)fpixel;

                    double green = (double)(pPixel->green);

                    fpixel = green / 255.0;
                    fpixel -= 0.5;
                    fpixel *= contrast;
                    fpixel += 0.5;
                    fpixel *= 255;
                    if (fpixel < 0)
                    {
                        fpixel = 0;
                    }

                    if (fpixel > 255)
                    {
                        fpixel = 255;
                    }

                    pPixel->green = (byte)fpixel;

                    double blue = (double)(pPixel->blue);

                    fpixel = blue / 255.0;
                    fpixel -= 0.5;
                    fpixel *= contrast;
                    fpixel += 0.5;
                    fpixel *= 255;
                    if (fpixel < 0)
                    {
                        fpixel = 0;
                    }

                    if (fpixel > 255)
                    {
                        fpixel = 255;
                    }

                    pPixel->blue = (byte)fpixel;
                    pPixel++;
                }
            }
            UnlockBitmap();
        }

        /// <summary>
        /// Made by Anis
        /// </summary>
        /// <param name="softenGreen"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="alphaLower"></param>
        /// <param name="alphaUpper"></param>
        protected void ChromaKey(int softenGreen, int alphaLower, int alphaUpper)
        {

            int width = bitmap.Width;
            int height = bitmap.Height;

            Point size = PixelSize;
            LockBitmap();
            byte[] alphaMap = null;
            if (alphaMap == null)
            {
                alphaMap = new byte[0x3fd];
                if (alphaUpper < alphaLower)
                {
                    alphaUpper = alphaLower;
                }
                for (int i = 0; i < alphaLower; i++)
                {
                    alphaMap[i] = 0xff;
                }
                for (int j = alphaUpper; j < 0x3fc; j++)
                {
                    alphaMap[j] = 0;
                }
                for (int k = alphaLower; k < alphaUpper; k++)
                {
                    alphaMap[k] = (byte)(0xff - ((((k - alphaLower) + 1) * 0xff) / (alphaUpper - alphaLower)));
                }
            }
            byte num2 = 0;

            for (int j = 0; j < height; j++)
            {
                for (int k = 0; k < width; k++)
                {
                    PixelData* pPixel = PixelAt(k, j);
                    num2 = alphaMap[(((pPixel->green << 1) - pPixel->red) - pPixel->blue) + 510];
                    if (pPixel->alpha > num2)
                    {
                        pPixel->alpha = num2;
                        if (num2 < 0xff)
                        {
                            pPixel->green = (byte)(pPixel->green - ((pPixel->green * ((0xff - pPixel->alpha) * softenGreen)) / 0xfe01));
                        }
                    }

                    // assign pPixel
                    pPixel++;
                }
            }

            UnlockBitmap();
        }

    }
}
