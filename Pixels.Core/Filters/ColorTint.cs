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
        Random rnd = new Random();
        public ColorTint()
        {
        }
        public void Load(Bitmap btemp)
        {
            Bitmap = btemp;
        }
        public List<string> FiltersList()
        {
            var filters =  "lemon,coral,frontward,vintage,perfume,serenity,pink_aura,haze,mellow,solange_dark," +
                "zapt,neue,eon,aeon,rosetint,slate,purplescale,radio,twenties,ocean,redgreyscale,greengreyscale,warmth,crimson" +
                "phase,grime,evening,sunset,wood,lix_conv,ryo_conv,blue_greyscale,solange,solange_grey,cool_twilight,blues,red_effect";
            return filters.Split(',').ToList();
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
                    pPixel->red = CheckByte(pPixel->red + 80);
                    pPixel->green = CheckByte(pPixel->green + 40);
                    pPixel->blue = CheckByte(pPixel->blue + 120);

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
                    pPixel->red = CheckByte(pPixel->red + 10);
                    pPixel->green = CheckByte(pPixel->green + 40);
                    pPixel->blue = CheckByte(pPixel->blue + 90);

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
                    pPixel->red = CheckByte(pPixel->red + 90);
                    pPixel->green = CheckByte(pPixel->green + 10);
                    pPixel->blue = CheckByte(pPixel->blue + 90);

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
                    pPixel->red = CheckByte(pPixel->red + 90);
                    pPixel->green = CheckByte(pPixel->green + 90);
                    pPixel->blue = CheckByte(pPixel->blue + 10);

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
                    pPixel->blue = CheckByte(120 - pPixel->blue);

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
                    pPixel->green = CheckByte(255 - pPixel->green);
                    pPixel->blue = CheckByte(255 - pPixel->blue);

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
                    //pPixel->red = CheckByte(pPixel->red + 120);
                    pPixel->green = CheckByte(255 - pPixel->green);
                    //pPixel->blue = CheckByte(pPixel->blue + 13);

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
                    pPixel->red = CheckByte(pPixel->red + 20);
                    pPixel->blue = CheckByte(255 - pPixel->blue);

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
                    pPixel->green = CheckByte(120 - pPixel->green);
                    pPixel->blue = CheckByte(100 - pPixel->blue);

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
                    pPixel->green = CheckByte(60 - pPixel->green);
                    pPixel->blue = CheckByte(100 - pPixel->blue);

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
                    var avg = (pPixel->red + pPixel->green + pPixel->blue) / 3;
                    pPixel->red = CheckByte(avg + 80);
                    pPixel->green = CheckByte(avg + 20);
                    pPixel->blue = CheckByte(avg + 31);

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
                    var avg = (pPixel->red + pPixel->green + pPixel->blue) / 3;
                    pPixel->red = CheckByte(avg + 4);
                    pPixel->green = CheckByte(avg + 3);
                    pPixel->blue = CheckByte(avg + 12);

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
                    var avg = (pPixel->red + pPixel->green + pPixel->blue) / 3;
                    pPixel->red = CheckByte(avg + 90);
                    pPixel->green = CheckByte(avg + 40);
                    pPixel->blue = CheckByte(avg + 80);

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
                    var avg = (pPixel->red + pPixel->green + pPixel->blue) / 3;
                    pPixel->red = CheckByte(avg + 5);
                    pPixel->green = CheckByte(avg + 40);
                    pPixel->blue = CheckByte(avg + 20);

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
                    var avg = (pPixel->red + pPixel->green + pPixel->blue) / 3;
                    pPixel->red = CheckByte(avg + 18);
                    pPixel->green = CheckByte(avg + 12);
                    pPixel->blue = CheckByte(avg + 20);

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
                    var avg = (pPixel->red + pPixel->green + pPixel->blue) / 3;
                    pPixel->red = CheckByte(avg);
                    pPixel->green = CheckByte(avg);
                    pPixel->blue = CheckByte(avg);

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
                    var avg = (pPixel->red + pPixel->green + pPixel->blue) / 3;
                    pPixel->red = CheckByte(avg + 100);
                    pPixel->green = CheckByte(avg + 40);
                    pPixel->blue = CheckByte(avg + 20);

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
                    var avg = (pPixel->red + pPixel->green + pPixel->blue) / 3;
                    pPixel->red = CheckByte(avg + 20);
                    pPixel->green = CheckByte(avg + 70);
                    pPixel->blue = CheckByte(avg + 20);

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
                    pPixel->red = CheckByte(pPixel->red + 10);
                    pPixel->green = CheckByte(pPixel->green + 18);
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
                    pPixel->red = CheckByte(pPixel->red + 20);
                    pPixel->green = CheckByte(pPixel->green + 20);

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
                    pPixel->red = CheckByte(pPixel->red + rnd.Next(10, 20));
                    pPixel->green = CheckByte(pPixel->green + rnd.Next(10, 20));
                    pPixel->blue = CheckByte(pPixel->blue + rnd.Next(10, 20));

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
                    pPixel->red = CheckByte(pPixel->red + 1);
                    pPixel->green = CheckByte(pPixel->green + 5);

                    pPixel++;
                }
            }

            /*
                for (i = 0; i < imgData.data.length; i += 4) {
                    imgData.data[i] = imgData.data[i] + 1;
                    imgData.data[i + 1] = imgData.data[i] + 5;
                }
            */
        }
        public void evening()
        {
            var sat_adj = 60;
            Point size = PixelSize;
            for (int y = 0; y < size.Y; y++)
            {
                PixelData* pPixel = PixelAt(0, y);
                for (int x = 0; x < size.X; x++)
                {
                    pPixel->red = CheckByte(pPixel->red - sat_adj);
                    pPixel->green = CheckByte(pPixel->green - sat_adj);
                    pPixel->blue = CheckByte(pPixel->blue - sat_adj);

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
                    pPixel->green = CheckByte(pPixel->green + 50);
                    pPixel->blue = CheckByte(pPixel->blue + 12);

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
                    pPixel->red = CheckByte(pPixel->red + 30);
                    pPixel->green = CheckByte(pPixel->green + 12);

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
                    pPixel->red = CheckByte(255 - pPixel->red);
                    pPixel->green = CheckByte(255 - pPixel->green);

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
                    pPixel->red = CheckByte(255 - pPixel->red);
                    pPixel->blue = CheckByte(255 - pPixel->blue);

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

                    var avg = (pPixel->red + pPixel->green + pPixel->blue) / 3;
                    pPixel->red = CheckByte(avg + 20);
                    pPixel->green = CheckByte(avg + 30);
                    pPixel->blue = CheckByte(avg + 60);

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
                    pPixel->red = CheckByte(255 - pPixel->red);

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
                    pPixel->red = pPixel->blue;
                    pPixel->green = pPixel->green;
                    pPixel->blue = pPixel->red;

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
                    pPixel->green = CheckByte(255-pPixel->green);
                    pPixel->blue = CheckByte(pPixel->blue + 70);
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
                    pPixel->blue = CheckByte(255-pPixel->blue);

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
                    pPixel->red = CheckByte(pPixel->red + 200);
                    pPixel->green = CheckByte(pPixel->green -50);
                    pPixel->blue = CheckByte(pPixel->blue *0.5);

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