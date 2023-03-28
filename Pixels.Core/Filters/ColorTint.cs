using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Pixels.Core.Filters
{
    public unsafe class ColorTint : PixelsProcessor
    {
        public ColorTint()
        {
        }
        public void Load(Bitmap btemp)
        {
            Bitmap = btemp;
        }
        public List<string> FiltersList()
        {
            return "lemon,coral,frontward,vintage".Split(',').ToList();
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

        public void lemon()
        {
            LoadPixels();
            for (int i = 0; i < pixelsList.Length; i += 4)
            {
                pixelsList[i + 1] = CheckByte(pixelsList[i + 2] + 50);
            }
            SetPixels();

            /*
              for (i = 0; i < imgData.data.length; i += 4) {
                    imgData.data[i + 1] = imgData.data[i] + 50;
                }
             */

        }
        public void coral()
        {            
            LoadPixels();
            for (int i = 0; i < pixelsList.Length; i += 4)
            {
                pixelsList[i + 2] = CheckByte(pixelsList[i + 2] + 50);
            }
            SetPixels();

            /*
               for (i = 0; i < imgData.data.length; i += 4) {
                    imgData.data[i + 2] = imgData.data[i + 1] + 50;
                }
             */
        }
        public void frontward()
        {
            Point size = PixelSize;
            for (int y = 0; y < size.Y; y++)
            {
                PixelData* pPixel = PixelAt(0, y);
                for (int x = 0; x < size.X; x++)
                {
                    pPixel->red = pPixel->blue;
                    pPixel->blue = (byte)(CheckByte(pPixel->green + 50));

                    pPixel++;
                }
            }

            /*
               for (i = 0; i < imgData.data.length; i += 4) {
                    imgData.data[i] = imgData.data[i + 2];
                    imgData.data[i + 2] = imgData.data[i + 1] + 50;
                }
             */
        }
        public void vintage()
        {
            Point size = PixelSize;
            for (int y = 0; y < size.Y; y++)
            {
                PixelData* pPixel = PixelAt(0, y);
                for (int x = 0; x < size.X; x++)
                {
                    pPixel->red = CheckByte(pPixel->red + 120);
                    pPixel->green = CheckByte(pPixel->green + 70);
                    pPixel->blue = CheckByte(pPixel->blue + 13);

                    pPixel++;
                }
            }

            /*
             for (i = 0; i < imgData.data.length; i += 4) {
                imgData.data[i] += 120
                imgData.data[i + 1] += 70
                imgData.data[i + 2] += 13
            }
             */
        }
        public void perfume()
        {
            Point size = PixelSize;
            for (int y = 0; y < size.Y; y++)
            {
                PixelData* pPixel = PixelAt(0, y);
                for (int x = 0; x < size.X; x++)
                {
                    pPixel->red = CheckByte(pPixel->red + 120);
                    pPixel->green = CheckByte(pPixel->green + 70);
                    pPixel->blue = CheckByte(pPixel->blue + 13);

                    pPixel++;
                }
            }

            /*
                for (i = 0; i < imgData.data.length; i += 4) {
                    imgData.data[i] += 80
                    imgData.data[i + 1] += 40
                    imgData.data[i + 2] += 120
                }
            */
        }
        public void serenity()
        {
            Point size = PixelSize;
            for (int y = 0; y < size.Y; y++)
            {
                PixelData* pPixel = PixelAt(0, y);
                for (int x = 0; x < size.X; x++)
                {
                    pPixel->red = CheckByte(pPixel->red + 120);
                    pPixel->green = CheckByte(pPixel->green + 70);
                    pPixel->blue = CheckByte(pPixel->blue + 13);

                    pPixel++;
                }
            }

            /*
                for (i = 0; i < imgData.data.length; i += 4) {
                    imgData.data[i] += 10
                    imgData.data[i + 1] += 40
                    imgData.data[i + 2] += 90
                }
            */
        }
        public void pink_aura()
        {
            Point size = PixelSize;
            for (int y = 0; y < size.Y; y++)
            {
                PixelData* pPixel = PixelAt(0, y);
                for (int x = 0; x < size.X; x++)
                {
                    pPixel->red = CheckByte(pPixel->red + 120);
                    pPixel->green = CheckByte(pPixel->green + 70);
                    pPixel->blue = CheckByte(pPixel->blue + 13);

                    pPixel++;
                }
            }

            /*
               for (i = 0; i < imgData.data.length; i += 4) {
                    imgData.data[i] += 90
                    imgData.data[i + 1] += 10
                    imgData.data[i + 2] += 90
                }
            */
        }
        public void haze()
        {
            Point size = PixelSize;
            for (int y = 0; y < size.Y; y++)
            {
                PixelData* pPixel = PixelAt(0, y);
                for (int x = 0; x < size.X; x++)
                {
                    pPixel->red = CheckByte(pPixel->red + 120);
                    pPixel->green = CheckByte(pPixel->green + 70);
                    pPixel->blue = CheckByte(pPixel->blue + 13);

                    pPixel++;
                }
            }

            /*
                for (i = 0; i < imgData.data.length; i += 4) {
                    imgData.data[i] += 90
                    imgData.data[i + 1] += 90
                    imgData.data[i + 2] += 10
                }
            */
        }
        public void mellow()
        {
            Point size = PixelSize;
            for (int y = 0; y < size.Y; y++)
            {
                PixelData* pPixel = PixelAt(0, y);
                for (int x = 0; x < size.X; x++)
                {
                    pPixel->red = CheckByte(pPixel->red + 120);
                    pPixel->green = CheckByte(pPixel->green + 70);
                    pPixel->blue = CheckByte(pPixel->blue + 13);

                    pPixel++;
                }
            }

            /*
               for (i = 0; i < imgData.data.length; i += 4) {
                    imgData.data[i + 2] = 120 - imgData.data[i + 2];
                }
            */
        }
        public void solange_dark()
        {
            Point size = PixelSize;
            for (int y = 0; y < size.Y; y++)
            {
                PixelData* pPixel = PixelAt(0, y);
                for (int x = 0; x < size.X; x++)
                {
                    pPixel->red = CheckByte(pPixel->red + 120);
                    pPixel->green = CheckByte(pPixel->green + 70);
                    pPixel->blue = CheckByte(pPixel->blue + 13);

                    pPixel++;
                }
            }

            /*
                for (i = 0; i < imgData.data.length; i += 4) {
                    imgData.data[i] = 200 - imgData.data[i];

                    // imgData.data[i + 1] = 255 - imgData.data[i + 1];
                    // imgData.data[i + 2] = 255 - imgData.data[i + 2];
                }
            */
        }
        public void zapt()
        {
            Point size = PixelSize;
            for (int y = 0; y < size.Y; y++)
            {
                PixelData* pPixel = PixelAt(0, y);
                for (int x = 0; x < size.X; x++)
                {
                    pPixel->red = CheckByte(pPixel->red + 120);
                    pPixel->green = CheckByte(pPixel->green + 70);
                    pPixel->blue = CheckByte(pPixel->blue + 13);

                    pPixel++;
                }
            }

            /*
               for (i = 0; i < imgData.data.length; i += 4) {
                    // imgData.data[i] = 255 - imgData.data[i];
                    imgData.data[i + 1] = 255 - imgData.data[i + 1];
                    // imgData.data[i + 2] = 255 - imgData.data[i + 2];
                }
            */
        }
        public void neue()
        {
            Point size = PixelSize;
            for (int y = 0; y < size.Y; y++)
            {
                PixelData* pPixel = PixelAt(0, y);
                for (int x = 0; x < size.X; x++)
                {
                    pPixel->red = CheckByte(pPixel->red + 120);
                    pPixel->green = CheckByte(pPixel->green + 70);
                    pPixel->blue = CheckByte(pPixel->blue + 13);

                    pPixel++;
                }
            }

            /*
                for (i = 0; i < imgData.data.length; i += 4) {
                    imgData.data[i + 2] = 255 - imgData.data[i + 2];
                    imgData.data[i] = imgData.data[i] + 20;

                }
            */
        }
        public void eon()
        {
            Point size = PixelSize;
            for (int y = 0; y < size.Y; y++)
            {
                PixelData* pPixel = PixelAt(0, y);
                for (int x = 0; x < size.X; x++)
                {
                    pPixel->red = CheckByte(pPixel->red + 120);
                    pPixel->green = CheckByte(pPixel->green + 70);
                    pPixel->blue = CheckByte(pPixel->blue + 13);

                    pPixel++;
                }
            }

            /*
                for (i = 0; i < imgData.data.length; i += 4) {
                    imgData.data[i + 1] = 120 - imgData.data[i + 1];
                    imgData.data[i + 2] = 100 - imgData.data[i + 2];
                }
            */
        }
        public void aeon()
        {
            Point size = PixelSize;
            for (int y = 0; y < size.Y; y++)
            {
                PixelData* pPixel = PixelAt(0, y);
                for (int x = 0; x < size.X; x++)
                {
                    pPixel->red = CheckByte(pPixel->red + 120);
                    pPixel->green = CheckByte(pPixel->green + 70);
                    pPixel->blue = CheckByte(pPixel->blue + 13);

                    pPixel++;
                }
            }

            /*
                for (i = 0; i < imgData.data.length; i += 4) {
                    imgData.data[i + 1] = 60 - imgData.data[i + 1];
                    imgData.data[i + 2] = 100 - imgData.data[i + 2];
                }
            */
        }
        public void rosetint()
        {
            Point size = PixelSize;
            for (int y = 0; y < size.Y; y++)
            {
                PixelData* pPixel = PixelAt(0, y);
                for (int x = 0; x < size.X; x++)
                {
                    pPixel->red = CheckByte(pPixel->red + 120);
                    pPixel->green = CheckByte(pPixel->green + 70);
                    pPixel->blue = CheckByte(pPixel->blue + 13);

                    pPixel++;
                }
            }

            /*
                 for (i = 0; i < imgData.data.length; i += 4) {
                    let avg = (imgData.data[i] + imgData.data[i + 1] + imgData.data[i + 2]) / 3
                    imgData.data[i] = avg + 80
                    imgData.data[i + 1] = avg + 20
                    imgData.data[i + 2] = avg + 31
                }
            */
        }
        public void slate()
        {
            Point size = PixelSize;
            for (int y = 0; y < size.Y; y++)
            {
                PixelData* pPixel = PixelAt(0, y);
                for (int x = 0; x < size.X; x++)
                {
                    pPixel->red = CheckByte(pPixel->red + 120);
                    pPixel->green = CheckByte(pPixel->green + 70);
                    pPixel->blue = CheckByte(pPixel->blue + 13);

                    pPixel++;
                }
            }

            /*
                
                for (i = 0; i < imgData.data.length; i += 4) {
                    let avg = (imgData.data[i] + imgData.data[i + 1] + imgData.data[i + 2]) / 3
                    imgData.data[i] = avg + 4
                    imgData.data[i + 1] = avg + 3
                    imgData.data[i + 2] = avg + 12
                }
            */
        }
        public void purplescale()
        {
            Point size = PixelSize;
            for (int y = 0; y < size.Y; y++)
            {
                PixelData* pPixel = PixelAt(0, y);
                for (int x = 0; x < size.X; x++)
                {
                    pPixel->red = CheckByte(pPixel->red + 120);
                    pPixel->green = CheckByte(pPixel->green + 70);
                    pPixel->blue = CheckByte(pPixel->blue + 13);

                    pPixel++;
                }
            }

            /*
                for (i = 0; i < imgData.data.length; i += 4) {
                    let avg = (imgData.data[i] + imgData.data[i + 1] + imgData.data[i + 2]) / 3
                    imgData.data[i] = avg + 90
                    imgData.data[i + 1] = avg + 40
                    imgData.data[i + 2] = avg + 80
                }
            */
        }
        public void radio()
        {
            Point size = PixelSize;
            for (int y = 0; y < size.Y; y++)
            {
                PixelData* pPixel = PixelAt(0, y);
                for (int x = 0; x < size.X; x++)
                {
                    pPixel->red = CheckByte(pPixel->red + 120);
                    pPixel->green = CheckByte(pPixel->green + 70);
                    pPixel->blue = CheckByte(pPixel->blue + 13);

                    pPixel++;
                }
            }

            /*
                
                for (i = 0; i < imgData.data.length; i += 4) {
                    let avg = (imgData.data[i] + imgData.data[i + 1] + imgData.data[i + 2]) / 3
                    imgData.data[i] = avg + 5
                    imgData.data[i + 1] = avg + 40
                    imgData.data[i + 2] = avg + 20
                }
            */
        }
        public void twenties()
        {
            Point size = PixelSize;
            for (int y = 0; y < size.Y; y++)
            {
                PixelData* pPixel = PixelAt(0, y);
                for (int x = 0; x < size.X; x++)
                {
                    pPixel->red = CheckByte(pPixel->red + 120);
                    pPixel->green = CheckByte(pPixel->green + 70);
                    pPixel->blue = CheckByte(pPixel->blue + 13);

                    pPixel++;
                }
            }

            /*
                 for (i = 0; i < imgData.data.length; i += 4) {
                    let avg = (imgData.data[i] + imgData.data[i + 1] + imgData.data[i + 2]) / 3
                    imgData.data[i] = avg + 18
                    imgData.data[i + 1] = avg + 12
                    imgData.data[i + 2] = avg + 20
                }
            */
        }
        public void ocean()
        {
            Point size = PixelSize;
            for (int y = 0; y < size.Y; y++)
            {
                PixelData* pPixel = PixelAt(0, y);
                for (int x = 0; x < size.X; x++)
                {
                    pPixel->red = CheckByte(pPixel->red + 120);
                    pPixel->green = CheckByte(pPixel->green + 70);
                    pPixel->blue = CheckByte(pPixel->blue + 13);

                    pPixel++;
                }
            }

            /*
             for (i = 0; i < imgData.data.length; i += 4) {
                    var avg = (imgData.data[i] + imgData.data[i + 1] + imgData.data[i + 2]) / 3
                    imgData.data[i] = avg
                    imgData.data[i + 1] = avg
                    imgData.data[i + 2] = avg
                }
            */
        }
        public void redgreyscale()
        {
            Point size = PixelSize;
            for (int y = 0; y < size.Y; y++)
            {
                PixelData* pPixel = PixelAt(0, y);
                for (int x = 0; x < size.X; x++)
                {
                    pPixel->red = CheckByte(pPixel->red + 120);
                    pPixel->green = CheckByte(pPixel->green + 70);
                    pPixel->blue = CheckByte(pPixel->blue + 13);

                    pPixel++;
                }
            }

            /*
                 for (i = 0; i < imgData.data.length; i += 4) {
                    let avg = (imgData.data[i] + imgData.data[i + 1] + imgData.data[i + 2]) / 3
                    imgData.data[i] = avg + 100
                    imgData.data[i + 1] = avg + 40
                    imgData.data[i + 2] = avg + 20
                }
            */
        }
        public void greengreyscale()
        {
            Point size = PixelSize;
            for (int y = 0; y < size.Y; y++)
            {
                PixelData* pPixel = PixelAt(0, y);
                for (int x = 0; x < size.X; x++)
                {
                    pPixel->red = CheckByte(pPixel->red + 120);
                    pPixel->green = CheckByte(pPixel->green + 70);
                    pPixel->blue = CheckByte(pPixel->blue + 13);

                    pPixel++;
                }
            }

            /*
              for (i = 0; i < imgData.data.length; i += 4) {
                    let avg = (imgData.data[i] + imgData.data[i + 1] + imgData.data[i + 2]) / 3
                    imgData.data[i] = avg + 20
                    imgData.data[i + 1] = avg + 70
                    imgData.data[i + 2] = avg + 20
                }
            */
        }
        public void warmth()
        {
            Point size = PixelSize;
            for (int y = 0; y < size.Y; y++)
            {
                PixelData* pPixel = PixelAt(0, y);
                for (int x = 0; x < size.X; x++)
                {
                    pPixel->red = CheckByte(pPixel->red + 120);
                    pPixel->green = CheckByte(pPixel->green + 70);
                    pPixel->blue = CheckByte(pPixel->blue + 13);

                    pPixel++;
                }
            }

            /*
                for (i = 0; i < imgData.data.length; i += 4) {
                    imgData.data[i] = imgData.data[i] + 10
                    imgData.data[i + 1] = imgData.data[i + 1] + 18
                }
            */
        }
        public void crimson()
        {
            Point size = PixelSize;
            for (int y = 0; y < size.Y; y++)
            {
                PixelData* pPixel = PixelAt(0, y);
                for (int x = 0; x < size.X; x++)
                {
                    pPixel->red = CheckByte(pPixel->red + 120);
                    pPixel->green = CheckByte(pPixel->green + 70);
                    pPixel->blue = CheckByte(pPixel->blue + 13);

                    pPixel++;
                }
            }

            /*
                for (i = 0; i < imgData.data.length; i += 4) {
                    imgData.data[i] = imgData.data[i] + 20
                    imgData.data[i + 1] = imgData.data[i + 2] + 20
                }
            */
        }
        public void phase()
        {
            Point size = PixelSize;
            for (int y = 0; y < size.Y; y++)
            {
                PixelData* pPixel = PixelAt(0, y);
                for (int x = 0; x < size.X; x++)
                {
                    pPixel->red = CheckByte(pPixel->red + 120);
                    pPixel->green = CheckByte(pPixel->green + 70);
                    pPixel->blue = CheckByte(pPixel->blue + 13);

                    pPixel++;
                }
            }

            /*
                for (i = 0; i < imgData.data.length; i += 4) {
                    imgData.data[i] = imgData.data[i] + getRandomNumber(10, 20)
                    imgData.data[i + 1] = imgData.data[i + 2] + getRandomNumber(10, 20)

                    imgData.data[i + 2] = imgData.data[i + 2] + getRandomNumber(10, 20)
                }
            */
        }
        public void grime()
        {
            Point size = PixelSize;
            for (int y = 0; y < size.Y; y++)
            {
                PixelData* pPixel = PixelAt(0, y);
                for (int x = 0; x < size.X; x++)
                {
                    pPixel->red = CheckByte(pPixel->red + 120);
                    pPixel->green = CheckByte(pPixel->green + 70);
                    pPixel->blue = CheckByte(pPixel->blue + 13);

                    pPixel++;
                }
            }

            /*
                for (i = 0; i < imgData.data.length; i += 4) {
                    imgData.data[i + 1] = imgData.data[i] + 5;
                    imgData.data[i] = imgData.data[i] + 1;
                }
            */
        }
        public void evening()
        {
            Point size = PixelSize;
            for (int y = 0; y < size.Y; y++)
            {
                PixelData* pPixel = PixelAt(0, y);
                for (int x = 0; x < size.X; x++)
                {
                    pPixel->red = CheckByte(pPixel->red + 120);
                    pPixel->green = CheckByte(pPixel->green + 70);
                    pPixel->blue = CheckByte(pPixel->blue + 13);

                    pPixel++;
                }
            }

            /*
               let SAT_ADJ = 60;
                for (i = 0; i < imgData.data.length; i += 4) {
                    imgData.data[i] -= SAT_ADJ
                    imgData.data[i + 1] -= SAT_ADJ
                    imgData.data[i + 2] -= SAT_ADJ
                }
            */
        }
        public void sunset()
        {
            Point size = PixelSize;
            for (int y = 0; y < size.Y; y++)
            {
                PixelData* pPixel = PixelAt(0, y);
                for (int x = 0; x < size.X; x++)
                {
                    pPixel->red = CheckByte(pPixel->red + 120);
                    pPixel->green = CheckByte(pPixel->green + 70);
                    pPixel->blue = CheckByte(pPixel->blue + 13);

                    pPixel++;
                }
            }

            /*
                for (i = 0; i < imgData.data.length; i += 4) {
                    imgData.data[i + 1] = imgData.data[i] + 50;
                    imgData.data[i + 2] = imgData.data[i + 2] + 12;
                }
            */
        }
        public void wood()
        {
            Point size = PixelSize;
            for (int y = 0; y < size.Y; y++)
            {
                PixelData* pPixel = PixelAt(0, y);
                for (int x = 0; x < size.X; x++)
                {
                    pPixel->red = CheckByte(pPixel->red + 120);
                    pPixel->green = CheckByte(pPixel->green + 70);
                    pPixel->blue = CheckByte(pPixel->blue + 13);

                    pPixel++;
                }
            }

            /*
                    for (i = 0; i < imgData.data.length; i += 4) {
                    imgData.data[i] = imgData.data[i] + 30
                    imgData.data[i + 1] = imgData.data[i + 1] + 12;
                }
            */
        }
        public void lix_conv()
        {
            Point size = PixelSize;
            for (int y = 0; y < size.Y; y++)
            {
                PixelData* pPixel = PixelAt(0, y);
                for (int x = 0; x < size.X; x++)
                {
                    pPixel->red = CheckByte(pPixel->red + 120);
                    pPixel->green = CheckByte(pPixel->green + 70);
                    pPixel->blue = CheckByte(pPixel->blue + 13);

                    pPixel++;
                }
            }

            /*
                for (i = 0; i < imgData.data.length; i += 4) {
                    imgData.data[i] = 255 - imgData.data[i];
                    imgData.data[i + 1] = 255 - imgData.data[i + 1];
                }
            */
        }
        public void ryo_conv()
        {
            Point size = PixelSize;
            for (int y = 0; y < size.Y; y++)
            {
                PixelData* pPixel = PixelAt(0, y);
                for (int x = 0; x < size.X; x++)
                {
                    pPixel->red = CheckByte(pPixel->red + 120);
                    pPixel->green = CheckByte(pPixel->green + 70);
                    pPixel->blue = CheckByte(pPixel->blue + 13);

                    pPixel++;
                }
            }

            /*
                 for (i = 0; i < imgData.data.length; i += 4) {
                    imgData.data[i] = 255 - imgData.data[i];
                    imgData.data[i + 2] = 255 - imgData.data[i + 2];
                }
            */
        }
        public void blue_greyscale()
        {
            Point size = PixelSize;
            for (int y = 0; y < size.Y; y++)
            {
                PixelData* pPixel = PixelAt(0, y);
                for (int x = 0; x < size.X; x++)
                {
                    pPixel->red = CheckByte(pPixel->red + 120);
                    pPixel->green = CheckByte(pPixel->green + 70);
                    pPixel->blue = CheckByte(pPixel->blue + 13);

                    pPixel++;
                }
            }

            /*
                for (i = 0; i < imgData.data.length; i += 4) {
                    let avg = (imgData.data[i] + imgData.data[i + 1] + imgData.data[i + 2]) / 3
                    imgData.data[i] = avg + 20
                    imgData.data[i + 1] = avg + 30
                    imgData.data[i + 2] = avg + 60
                }
            */
        }
        public void solange()
        {
            Point size = PixelSize;
            for (int y = 0; y < size.Y; y++)
            {
                PixelData* pPixel = PixelAt(0, y);
                for (int x = 0; x < size.X; x++)
                {
                    pPixel->red = CheckByte(pPixel->red + 120);
                    pPixel->green = CheckByte(pPixel->green + 70);
                    pPixel->blue = CheckByte(pPixel->blue + 13);

                    pPixel++;
                }
            }

            /*
                for (i = 0; i < imgData.data.length; i += 4) {
                    imgData.data[i] = 255 - imgData.data[i];
                }
            */
        }
        public void solange_grey()
        {
            Point size = PixelSize;
            for (int y = 0; y < size.Y; y++)
            {
                PixelData* pPixel = PixelAt(0, y);
                for (int x = 0; x < size.X; x++)
                {
                    pPixel->red = CheckByte(pPixel->red + 120);
                    pPixel->green = CheckByte(pPixel->green + 70);
                    pPixel->blue = CheckByte(pPixel->blue + 13);

                    pPixel++;
                }
            }

            /*
                 for (i = 0; i < imgData.data.length; i += 4) {
                    imgData.data[i] = imgData.data[i + 2];
                    imgData.data[i + 1] = imgData.data[i + 1]
                    imgData.data[i + 2] = imgData.data[i]

                }
            */
        }  
        public void cool_twilight()
        {
            Point size = PixelSize;
            for (int y = 0; y < size.Y; y++)
            {
                PixelData* pPixel = PixelAt(0, y);
                for (int x = 0; x < size.X; x++)
                {
                    pPixel->red = CheckByte(pPixel->red + 120);
                    pPixel->green = CheckByte(pPixel->green + 70);
                    pPixel->blue = CheckByte(pPixel->blue + 13);

                    pPixel++;
                }
            }

            /*
                for (i = 0; i < imgData.data.length; i += 4) {
                    imgData.data[i + 1] = 255 - imgData.data[i + 1];
                    imgData.data[i + 2] = imgData.data[i + 2] + 70;

                }
            */
        }
        public void blues()
        {
            Point size = PixelSize;
            for (int y = 0; y < size.Y; y++)
            {
                PixelData* pPixel = PixelAt(0, y);
                for (int x = 0; x < size.X; x++)
                {
                    pPixel->red = CheckByte(pPixel->red + 120);
                    pPixel->green = CheckByte(pPixel->green + 70);
                    pPixel->blue = CheckByte(pPixel->blue + 13);

                    pPixel++;
                }
            }

            /*
                for (i = 0; i < imgData.data.length; i += 4) {
                    imgData.data[i + 2] = 255 - imgData.data[i + 2];
                }
            */
        }
        public void red_effect()
        {
            Point size = PixelSize;
            for (int y = 0; y < size.Y; y++)
            {
                PixelData* pPixel = PixelAt(0, y);
                for (int x = 0; x < size.X; x++)
                {
                    pPixel->red = CheckByte(pPixel->red + 120);
                    pPixel->green = CheckByte(pPixel->green + 70);
                    pPixel->blue = CheckByte(pPixel->blue + 13);

                    pPixel++;
                }
            }

            /*
                 for (i = 0; i < imgData.data.length; i += 4) {
                    imgData.data[i] = imgData.data[i] + 200;
                    imgData.data[i + 1] = imgData.data[i + 1] - 50;
                    imgData.data[i + 2] = imgData.data[i + 2] * 0.5;
                }
            */
        }
        
    }
}

/*
 * [i] -> red
 * [i+1] -> green
 * [i+2] -> blue


const red_effect = (imgData) => {
   
    return imgData;
}
 * */