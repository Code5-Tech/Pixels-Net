using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Pixels.Core.Filters
{
    public unsafe class GammaFilter : PixelsProcessor
    {

        public void Load(Bitmap btemp)
        {
            Bitmap = btemp;
        }
        public List<string> FiltersList()
        {
            return "gamma,teal_gamma,purple_gamma,yellow_gamma,bluered_gamma,green_gamma,red_gamma".Split(',').ToList();
        }
        public Bitmap Apply(string filterName)
        {
            Type type = this.GetType();
            MethodInfo filterMethod = type.GetMethod(filterName);
            if (filterMethod != null)
            {
                LockBitmap();
                filterMethod.Invoke(this, null);
                UnlockBitmap();
            }
            return Bitmap;
        }

        public void gamma()
        {
            Point size = PixelSize;
            for (int y = 0; y < size.Y; y++)
            {
                PixelData* pPixel = PixelAt(0, y);
                for (int x = 0; x < size.X; x++)
                {
                    pPixel->red = CheckByte(Math.Pow(pPixel->red / 255, 5) * 255);
                    pPixel->green = CheckByte(Math.Pow(pPixel->green / 255, 5) * 255);
                    pPixel->blue = CheckByte(Math.Pow(pPixel->blue / 255, 5) * 255);

                    pPixel++;
                }
            }
        }
        public void teal_gamma()
        {
            Point size = PixelSize;
            for (int y = 0; y < size.Y; y++)
            {
                PixelData* pPixel = PixelAt(0, y);
                for (int x = 0; x < size.X; x++)
                {
                    pPixel->red = CheckByte(Math.Pow(pPixel->red / 255, 5) * 255);
                    pPixel++;
                }
            }
        }
        public void purple_gamma()
        {
            Point size = PixelSize;
            for (int y = 0; y < size.Y; y++)
            {
                PixelData* pPixel = PixelAt(0, y);
                for (int x = 0; x < size.X; x++)
                {
                    pPixel->green = CheckByte(Math.Pow(pPixel->green / 255, 5) * 255);
                    pPixel++;
                }
            }
        } 
        
        public void yellow_gamma()
        {
            Point size = PixelSize;
            for (int y = 0; y < size.Y; y++)
            {
                PixelData* pPixel = PixelAt(0, y);
                for (int x = 0; x < size.X; x++)
                {
                    pPixel->blue = CheckByte(Math.Pow(pPixel->blue / 255, 5) * 255);
                    pPixel++;
                }
            }
        }
        public void bluered_gamma()
        {
            Point size = PixelSize;
            for (int y = 0; y < size.Y; y++)
            {
                PixelData* pPixel = PixelAt(0, y);
                for (int x = 0; x < size.X; x++)
                {
                    pPixel->red = CheckByte(Math.Pow(pPixel->red / 255, 5) * 255);
                    pPixel->green = CheckByte(Math.Pow(pPixel->green / 255, 5) * 255);
                    pPixel++;
                }
            }
        }
        public void green_gamma()
        {
            Point size = PixelSize;
            for (int y = 0; y < size.Y; y++)
            {
                PixelData* pPixel = PixelAt(0, y);
                for (int x = 0; x < size.X; x++)
                {
                    pPixel->red = CheckByte(Math.Pow(pPixel->red / 255, 5) * 255);
                    pPixel->blue = CheckByte(Math.Pow(pPixel->blue / 255, 5) * 255);
                    pPixel++;
                }
            }
        }
        public void red_gamma()
        {
            Point size = PixelSize;
            for (int y = 0; y < size.Y; y++)
            {
                PixelData* pPixel = PixelAt(0, y);
                for (int x = 0; x < size.X; x++)
                {
                    pPixel->green = CheckByte(Math.Pow(pPixel->green / 255, 5) * 255);
                    pPixel->blue = CheckByte(Math.Pow(pPixel->blue / 255, 5) * 255);
                    pPixel++;
                }
            }
        }
    }
}

/*
 *  [i] -> red
 * [i+1] -> green
 * [i+2] -> blue
 const gamma = (imgData) => {
    for (i = 0; i < imgData.data.length; i += 4) {
        imgData.data[i] = Math.pow(imgData.data[i] / 255, 5) * 255;
        imgData.data[i + 1] = Math.pow(imgData.data[i + 1] / 255, 5) * 255;
        imgData.data[i + 2] = Math.pow(imgData.data[i + 2] / 255, 5) * 255;
    }
    return imgData;
}

const teal_gamma = (imgData) => {
    for (i = 0; i < imgData.data.length; i += 4) {
        imgData.data[i] = Math.pow(imgData.data[i] / 255, 5) * 255;
    }
    return imgData;
}

const purple_gamma = (imgData) => {
    for (i = 0; i < imgData.data.length; i += 4) {
        imgData.data[i + 1] = Math.pow(imgData.data[i + 1] / 255, 5) * 255;
    }
    return imgData;
}

const yellow_gamma = (imgData) => {
    for (i = 0; i < imgData.data.length; i += 4) {
        imgData.data[i + 2] = Math.pow(imgData.data[i + 2] / 255, 5) * 255;
    }
    return imgData;
}

const bluered_gamma = (imgData) => {
    for (i = 0; i < imgData.data.length; i += 4) {
        imgData.data[i] = Math.pow(imgData.data[i] / 255, 5) * 255;
        imgData.data[i + 1] = Math.pow(imgData.data[i + 1] / 255, 5) * 255;
    }
    return imgData;
}

const green_gamma = (imgData) => {
    for (i = 0; i < imgData.data.length; i += 4) {
        imgData.data[i] = Math.pow(imgData.data[i] / 255, 5) * 255;
        imgData.data[i + 2] = Math.pow(imgData.data[i + 2] / 255, 5) * 255;
    }
    return imgData;
}

const red_gamma = (imgData) => {
    for (i = 0; i < imgData.data.length; i += 4) {
        imgData.data[i + 1] = Math.pow(imgData.data[i + 1] / 255, 5) * 255;
        imgData.data[i + 2] = Math.pow(imgData.data[i + 2] / 255, 5) * 255;
    }
    return imgData;
}

export {gamma, teal_gamma, purple_gamma, yellow_gamma, bluered_gamma, green_gamma, red_gamma}
 */
