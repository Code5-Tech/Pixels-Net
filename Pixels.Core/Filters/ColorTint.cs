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
            var filters = "horizon, blues, cool_twilight, blue_greyscale, aeon, solange_grey, solange, ryo_conv, lix_conv, wood, sunset, lemon, coral, frontward, greyscale, perfume, vintage, serenity, slate, warmth, redgreyscale, grime, phase, crimson, greengreyscale, ocean, radio, neue, eon, zapt, solange_dark, pink_aura, haze,mellow, evening, twenties, rosetint, purplescale, red_effect".Split(',').Select(x=>x.Trim()).OrderBy(x=>x).ToList();
            return filters;
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
                pixelsList[i + 1] = CheckByte(pixelsList[i + 2] + 20);
                //pixelsList[i + 1] = (byte)(pixelsList[i] + 20);
            }
            SetPixels();
        }
        public void coral()
        {
            LoadPixels(); 
            for (int i = 0; i < pixelsList.Length; i += 4)
            {
                pixelsList[i] = CheckByte(pixelsList[i + 1] + 20);
            }
            SetPixels();
        }
        public void frontward()
        {
            LoadPixels(); 
            for (int i = 0; i < pixelsList.Length; i += 4)
            {
                pixelsList[i + 2] = pixelsList[i];
                pixelsList[i] = CheckByte(pixelsList[i + 1] + 50);
            }
            SetPixels();
        }
        public void vintage()
        {
            LoadPixels(); 
            for (int i = 0; i < pixelsList.Length; i += 4)
            {
                pixelsList[i + 2] = CheckByte(pixelsList[i + 2] + 120);
                pixelsList[i + 1] = CheckByte(pixelsList[i + 1] + 70);
                pixelsList[i] = CheckByte(pixelsList[i] + 13);
            }
            SetPixels();
        }
        public void perfume()
        {
            LoadPixels(); 
            for (int i = 0; i < pixelsList.Length; i += 4)
            {
                pixelsList[i] = CheckByte(pixelsList[i] + 120);
                pixelsList[i + 1] = CheckByte(pixelsList[i + 1] + 40);
                pixelsList[i + 2] = CheckByte(pixelsList[i + 2] + 80);
            }
            SetPixels();
        }
        public void serenity()
        {
            LoadPixels(); 
            for (int i = 0; i < pixelsList.Length; i += 4)
            {
                pixelsList[i] = CheckByte(pixelsList[i] + 90);
                pixelsList[i + 1] = CheckByte(pixelsList[i + 1] + 40);
                pixelsList[i + 2] = CheckByte(pixelsList[i + 2] + 10);
            }
            SetPixels();
        }
        public void pink_aura()
        {
            LoadPixels(); 
            for (int i = 0; i < pixelsList.Length; i += 4)
            {
                pixelsList[i] = CheckByte(pixelsList[i] + 90);
                pixelsList[i + 1] = CheckByte(pixelsList[i + 1] + 10);
                pixelsList[i + 2] = CheckByte(pixelsList[i + 2] + 90);
            }
            SetPixels();
        }
        public void haze()
        {
            LoadPixels(); 
            for (int i = 0; i < pixelsList.Length; i += 4)
            {
                pixelsList[i] = CheckByte(pixelsList[i] + 10);
                pixelsList[i + 1] = CheckByte(pixelsList[i + 1] + 90);
                pixelsList[i + 2] = CheckByte(pixelsList[i + 2] + 90);
            }
            SetPixels();
        }
        public void mellow()
        {
            LoadPixels(); 
            for (int i = 0; i < pixelsList.Length; i += 4)
            {
                pixelsList[i] = CheckByte(120 - pixelsList[i]);
            }
            SetPixels();
        }

        public void solange()
        {
            //for (i = 0; i < imgData.data.length; i += 4)
            //{
            //    imgData.data[i] = 200 - imgData.data[i];
            //}
            LoadPixels(); 
            for (int i = 0; i < pixelsList.Length; i += 4)
            {
                pixelsList[i+2] = CheckByte(200 - pixelsList[i+2]);
            }
            SetPixels();
        }
        public void zapt()
        {
            //for (i = 0; i < imgData.data.length; i += 4)
            //{
            //    imgData.data[i + 1] = 255 - imgData.data[i + 1];
            //}
            LoadPixels(); 
            for (int i = 0; i < pixelsList.Length; i += 4)
            {
                pixelsList[i+1] = CheckByte(255 - pixelsList[i+1]);
            }
            SetPixels();
        }
        public void neue()
        {
            //for (i = 0; i < imgData.data.length; i += 4)
            //{
            //    imgData.data[i + 2] = 255 - imgData.data[i + 2];
            //    imgData.data[i] = imgData.data[i] + 20;

            //}
            LoadPixels(); 
            for (int i = 0; i < pixelsList.Length; i += 4)
            {
                pixelsList[i] = CheckByte(255 - pixelsList[i]);
                pixelsList[i + 2] = CheckByte(pixelsList[i + 2] + 20);
            }
            SetPixels();
        }
        public void eon()
        {
            //for (i = 0; i < imgData.data.length; i += 4)
            //{
            //    imgData.data[i + 1] = 120 - imgData.data[i + 1];
            //    imgData.data[i + 2] = 100 - imgData.data[i + 2];
            //}
            LoadPixels(); 
            for (int i = 0; i < pixelsList.Length; i += 4)
            {
                pixelsList[i+1] = CheckByte(120 - pixelsList[i+ 1]);
                pixelsList[i] = CheckByte(100 - pixelsList[i]);
            }
            SetPixels();
        }
        public void aeon()
        {
            //for (i = 0; i < imgData.data.length; i += 4)
            //{
            //    imgData.data[i + 1] = 60 - imgData.data[i + 1];
            //    imgData.data[i + 2] = 100 - imgData.data[i + 2];
            //}
            LoadPixels(); 
            for (int i = 0; i < pixelsList.Length; i += 4)
            {
                pixelsList[i + 1] = CheckByte(60 - pixelsList[i + 1]);
                pixelsList[i] = CheckByte(60 - pixelsList[i]);
            }
            SetPixels();
        }
        public void rosetint()
        {
            // for (i = 0; i < imgData.data.length; i += 4)
            // {
            //    let avg = (imgData.data[i] + imgData.data[i + 1] + imgData.data[i + 2]) / 3
            //    imgData.data[i] = avg + 80
            //    imgData.data[i + 1] = avg + 20
            //    imgData.data[i + 2] = avg + 31
            //}
            LoadPixels(); 
            for (int i = 0; i < pixelsList.Length; i += 4)
            {
                int avg = (pixelsList[i] + pixelsList[i + 1] + pixelsList[i + 2]) / 3;
                pixelsList[i+2] = CheckByte(avg+80);
                pixelsList[i+1] = CheckByte(avg + 20);
                pixelsList[i] = CheckByte(avg + 31);
            }
            SetPixels();
        }
        public void slate()
        {
            //for (i = 0; i < imgData.data.length; i += 4)
            //{
            //    let avg = (imgData.data[i] + imgData.data[i + 1] + imgData.data[i + 2]) / 3
            //    imgData.data[i] = avg + 4
            //    imgData.data[i + 1] = avg + 3
            //    imgData.data[i + 2] = avg + 12
            //}
            LoadPixels(); 
            for (int i = 0; i < pixelsList.Length; i += 4)
            {
                int avg = (pixelsList[i] + pixelsList[i + 1] + pixelsList[i + 2]) / 3;
                pixelsList[i + 2] = CheckByte(avg + 4);
                pixelsList[i + 1] = CheckByte(avg + 3);
                pixelsList[i] = CheckByte(avg + 12);
            }
            SetPixels();
        }
        public void purplescale()
        {
            //for (i = 0; i < imgData.data.length; i += 4)
            //{
            //    let avg = (imgData.data[i] + imgData.data[i + 1] + imgData.data[i + 2]) / 3
            //    imgData.data[i] = avg + 90
            //    imgData.data[i + 1] = avg + 40
            //    imgData.data[i + 2] = avg + 80
            //}
            LoadPixels(); 
            for (int i = 0; i < pixelsList.Length; i += 4)
            {
                int avg = (pixelsList[i] + pixelsList[i + 1] + pixelsList[i + 2]) / 3;
                pixelsList[i + 2] = CheckByte(avg + 90);
                pixelsList[i + 1] = CheckByte(avg + 40);
                pixelsList[i] = CheckByte(avg + 80);
            }
            SetPixels();
        }
        public void radio()
        {
            //for (i = 0; i < imgData.data.length; i += 4)
            //{
            //    let avg = (imgData.data[i] + imgData.data[i + 1] + imgData.data[i + 2]) / 3
            //    imgData.data[i] = avg + 5
            //    imgData.data[i + 1] = avg + 40
            //    imgData.data[i + 2] = avg + 20
            //}
            LoadPixels(); 
            for (int i = 0; i < pixelsList.Length; i += 4)
            {
                int avg = (pixelsList[i] + pixelsList[i + 1] + pixelsList[i + 2]) / 3;
                pixelsList[i + 2] = CheckByte(avg + 5);
                pixelsList[i + 1] = CheckByte(avg + 40);
                pixelsList[i] = CheckByte(avg + 20);
            }
            SetPixels();
        }
        public void twenties()
        {
            //for (i = 0; i < imgData.data.length; i += 4)
            //{
            //    let avg = (imgData.data[i] + imgData.data[i + 1] + imgData.data[i + 2]) / 3
            //    imgData.data[i] = avg + 18
            //    imgData.data[i + 1] = avg + 12
            //    imgData.data[i + 2] = avg + 20
            //}
            LoadPixels(); 
            for (int i = 0; i < pixelsList.Length; i += 4)
            {
                int avg = (pixelsList[i] + pixelsList[i + 1] + pixelsList[i + 2]) / 3;
                pixelsList[i + 2] = CheckByte(avg + 18);
                pixelsList[i + 1] = CheckByte(avg + 12);
                pixelsList[i] = CheckByte(avg + 20);
            }
            SetPixels();
        }


        public void ocean()
        {
            LoadPixels(); 
            //for (i = 0; i < imgData.data.length; i += 4)
            //{
            //    imgData.data[i] += 10
            //    imgData.data[i + 1] += 20
            //    imgData.data[i + 2] += 90
            //}
            for (int i = 0; i < pixelsList.Length; i += 4)
            {
                pixelsList[i + 2] = CheckByte(pixelsList[i + 2] + 10);
                pixelsList[i + 1] = CheckByte(pixelsList[i + 1] + 20);
                pixelsList[i] = CheckByte(pixelsList[i] + 90);
            }
            SetPixels();
        }

        public void greyscale()
        {
            LoadPixels(); 
            //for (i = 0; i < imgData.data.length; i += 4)
            //{
            //    var avg = (imgData.data[i] + imgData.data[i + 1] + imgData.data[i + 2]) / 3
            //    imgData.data[i] = avg
            //    imgData.data[i + 1] = avg
            //    imgData.data[i + 2] = avg
            //}
            for (int i = 0; i < pixelsList.Length; i += 4)
            {
                var gray = (byte)(0.299 * pixelsList[i + 2]   // Red
                + 0.587 * pixelsList[i + 1]   // Green
                + 0.114 * pixelsList[i]);
                pixelsList[i + 2] = gray;
                pixelsList[i + 1] = gray;
                pixelsList[i] = gray;
            }
            SetPixels();
        }

        public void redgreyscale()
        {
            LoadPixels(); 
            //for (i = 0; i < imgData.data.length; i += 4)
            //{
            //    let avg = (imgData.data[i] + imgData.data[i + 1] + imgData.data[i + 2]) / 3
            //    imgData.data[i] = avg + 100
            //    imgData.data[i + 1] = avg + 40
            //    imgData.data[i + 2] = avg + 20
            //}
            for (int i = 0; i < pixelsList.Length; i += 4)
            {
                int avg = (pixelsList[i] + pixelsList[i + 1] + pixelsList[i + 2]) / 3;
                pixelsList[i + 2] = CheckByte(avg+100);
                pixelsList[i + 1] = CheckByte(avg+40);
                pixelsList[i] = CheckByte(avg+20);
            }
            SetPixels();
        }

        public void greengreyscale()
        {
            LoadPixels(); 
            //for (i = 0; i < imgData.data.length; i += 4)
            //{
            //    let avg = (imgData.data[i] + imgData.data[i + 1] + imgData.data[i + 2]) / 3
            //    imgData.data[i] = avg + 20
            //    imgData.data[i + 1] = avg + 70
            //    imgData.data[i + 2] = avg + 20
            //}
            for (int i = 0; i < pixelsList.Length; i += 4)
            {
                int avg = (pixelsList[i] + pixelsList[i + 1] + pixelsList[i + 2]) / 3;
                pixelsList[i + 2] = CheckByte(avg + 20);
                pixelsList[i + 1] = CheckByte(avg + 70);
                pixelsList[i] = CheckByte(avg + 20);
            }
            SetPixels();
        }



        public void warmth()
        {
            //for (i = 0; i < imgData.data.length; i += 4)
            //{
            //    imgData.data[i] = imgData.data[i] + 10
            //    imgData.data[i + 1] = imgData.data[i + 1] + 18
            //}
            LoadPixels(); 
            for (int i = 0; i < pixelsList.Length; i += 4)
            {
                pixelsList[i + 2] = CheckByte(pixelsList[i + 2] + 10);
                pixelsList[i + 1] = CheckByte(pixelsList[i + 1] + 18);
            }
            SetPixels();
        }

        public void crimson()
        {
            //for (i = 0; i < imgData.data.length; i += 4)
            //{
            //    imgData.data[i] = imgData.data[i] + 20
            //    imgData.data[i + 1] = imgData.data[i + 2] + 20
            //}
            LoadPixels(); 
            for (int i = 0; i < pixelsList.Length; i += 4)
            {
                pixelsList[i + 2] = CheckByte(pixelsList[i + 2] + 20);
                pixelsList[i + 1] = CheckByte(pixelsList[i + 1] + 20);
            }
            SetPixels();
        }

        public void phase()
        {
            LoadPixels(); 
            //    for (i = 0; i < imgData.data.length; i += 4)
            //    {
            //        imgData.data[i] = imgData.data[i] + getRandomNumber(10, 20)
            //        imgData.data[i + 1] = imgData.data[i + 2] + getRandomNumber(10, 20)
            //imgData.data[i + 2] = imgData.data[i + 2] + getRandomNumber(10, 20)
            //    }
            for (int i = 0; i < pixelsList.Length; i += 4)
            {
                pixelsList[i] = CheckByte(pixelsList[i] + getRandomNumber(10, 20));
                pixelsList[i + 2] = CheckByte(pixelsList[i + 2] + getRandomNumber(10, 20));
                pixelsList[i + 1] = CheckByte(pixelsList[i] + getRandomNumber(10, 20));
            }
            SetPixels();
        }

        public void grime()
        {
            LoadPixels(); 
            //for (i = 0; i < imgData.data.length; i += 4)
            //{
            //    imgData.data[i + 1] = imgData.data[i] + 5;
            //    imgData.data[i] = imgData.data[i] + 1;
            //}
            for (int i = 0; i < pixelsList.Length; i += 4)
            {
                pixelsList[i + 1] = CheckByte(pixelsList[i+2] + 5);
                pixelsList[i + 2] = CheckByte(pixelsList[i+2] + 1);
            }
            SetPixels();
        }

        public void evening()
        {
            LoadPixels(); 
            //let SAT_ADJ = 60;
            //for (i = 0; i < imgData.data.length; i += 4)
            //{
            //    imgData.data[i] -= SAT_ADJ
            //    imgData.data[i + 1] -= SAT_ADJ
            //    imgData.data[i + 2] -= SAT_ADJ
            //}
            var SAT_ADJ = 60;
            for (int i = 0; i < pixelsList.Length; i += 4)
            {
                pixelsList[i + 2] = CheckByte(pixelsList[i + 2] - SAT_ADJ);
                pixelsList[i + 1] = CheckByte(pixelsList[i + 1] - SAT_ADJ);
                pixelsList[i] = CheckByte(pixelsList[i] - SAT_ADJ);
            }
            SetPixels();
        }
           public void horizon()
        {
            LoadPixels();
            //let SAT_ADJ = 150;
            //for (i = 0; i < imgData.data.length; i += 4)
            //{
            //    imgData.data[i] -= SAT_ADJ
            //    imgData.data[i + 1] -= SAT_ADJ
            //    imgData.data[i + 2] -= SAT_ADJ
            //}
            var SAT_ADJ = 100;
            for (int i = 0; i < pixelsList.Length; i += 4)
            {
                pixelsList[i + 2] = CheckByte(pixelsList[i + 2] - SAT_ADJ);
                pixelsList[i + 1] = CheckByte(pixelsList[i + 1] - SAT_ADJ);
                pixelsList[i] = CheckByte(pixelsList[i] - SAT_ADJ);
            }
            SetPixels();
        }
        public void sunset()
        {
            LoadPixels(); 
            //for (i = 0; i < imgData.data.length; i += 4)
            //{
            //    imgData.data[i + 1] = imgData.data[i] + 50;
            //    imgData.data[i + 2] = imgData.data[i + 2] + 12;
            //}
            for (int i = 0; i < pixelsList.Length; i += 4)
            {
                pixelsList[i + 1] = CheckByte(pixelsList[i + 2] +50);
                pixelsList[i] = CheckByte(pixelsList[i] + 12);
            }
            SetPixels();
        }

        public void wood()
        {
            LoadPixels(); 
            //for (i = 0; i < imgData.data.length; i += 4)
            //{
            //    imgData.data[i] = imgData.data[i] + 30
            //    imgData.data[i + 1] = imgData.data[i + 1] + 12;
            //}
            for (int i = 0; i < pixelsList.Length; i += 4)
            {
                pixelsList[i + 2] = CheckByte(pixelsList[i + 2] + 30);
                pixelsList[i+1] = CheckByte(pixelsList[i + 1] + 12);
            }
            SetPixels();
        }


        public void lix_conv()
        {
            LoadPixels();
            //for (i = 0; i < imgData.data.length; i += 4)
            //{
            //    imgData.data[i] = 255 - imgData.data[i];
            //    imgData.data[i + 1] = 255 - imgData.data[i + 1];
            //}
            for (int i = 0; i < pixelsList.Length; i += 4)
            {
                pixelsList[i + 2] = CheckByte(255 - pixelsList[i + 2]);
                pixelsList[i+1] = CheckByte(255 - pixelsList[i+1]);
            }
            SetPixels();
        }

        public void ryo_conv()
        {
            LoadPixels(); 
            //for (i = 0; i < imgData.data.length; i += 4)
            //{
            //    imgData.data[i] = 255 - imgData.data[i];
            //    imgData.data[i + 2] = 255 - imgData.data[i + 2];
            //}
            for (int i = 0; i < pixelsList.Length; i += 4)
            {
                pixelsList[i + 2] = CheckByte(255 - pixelsList[i + 2]);
                pixelsList[i] = CheckByte(255- pixelsList[i]);
            }
            SetPixels();
        }

        public void blue_greyscale()
        {
            LoadPixels(); 
            //for (i = 0; i < imgData.data.length; i += 4)
            //{
            //    let avg = (imgData.data[i] + imgData.data[i + 1] + imgData.data[i + 2]) / 3
            //    imgData.data[i] = avg + 20
            //    imgData.data[i + 1] = avg + 30
            //    imgData.data[i + 2] = avg + 60
            //}
            for (int i = 0; i < pixelsList.Length; i += 4)
            {
                int avg = (pixelsList[i] + pixelsList[i + 1] + pixelsList[i + 2]) / 3;
                pixelsList[i + 2] = CheckByte(avg + 20);
                pixelsList[i+1] = CheckByte(avg + 30);
                pixelsList[i] = CheckByte(avg + 60);
            }
            SetPixels();
        }


        public void solange_2()
        {
            LoadPixels(); 
            //for (i = 0; i < imgData.data.length; i += 4)
            //{
            //    imgData.data[i] = 255 - imgData.data[i];
            //}
            for (int i = 0; i < pixelsList.Length; i += 4)
            {
                pixelsList[i+2] = CheckByte(255- pixelsList[i + 2]);
            }
            SetPixels();
        }

        public void solange_grey()
        {
            LoadPixels(); 
            //for (i = 0; i < imgData.data.length; i += 4)
            //{
            //    imgData.data[i] = imgData.data[i + 2];
            //    imgData.data[i + 1] = imgData.data[i + 1]
            //    imgData.data[i + 2] = imgData.data[i]
            //}
            for (int i = 0; i < pixelsList.Length; i += 4)
            {
                pixelsList[i + 2] = pixelsList[i];
                pixelsList[i + 1] = pixelsList[i+1];
                pixelsList[i] = pixelsList[i+2];
            }
            SetPixels();
        }



        public void cool_twilight()
        {
            LoadPixels(); 
            //for (i = 0; i < imgData.data.length; i += 4)
            //{
            //    imgData.data[i + 1] = 255 - imgData.data[i + 1];
            //    imgData.data[i + 2] = imgData.data[i + 2] + 70;

            //}
            for (int i = 0; i < pixelsList.Length; i += 4)
            {
                pixelsList[i + 1] = CheckByte(255 - pixelsList[i + 1]);
                pixelsList[i] = CheckByte(70 + pixelsList[i]);
            }
            SetPixels();
        }

        public void blues()
        {
            LoadPixels(); 
            //for (i = 0; i < imgData.data.length; i += 4)
            //{
            //    imgData.data[i + 2] = 255 - imgData.data[i + 2];
            //}
            for (int i = 0; i < pixelsList.Length; i += 4)
            {
                pixelsList[i ] = CheckByte(255 - pixelsList[i]);
            }
            SetPixels();
        }

        public void red_effect()
        {
            LoadPixels(); 
            //for (i = 0; i < imgData.data.length; i += 4)
            //{
            //    imgData.data[i] = imgData.data[i] + 200;
            //    imgData.data[i + 1] = imgData.data[i + 1] - 50;
            //    imgData.data[i + 2] = imgData.data[i + 2] * 0.5;
            //}
            for (int i = 0; i < pixelsList.Length; i += 4)
            {
                pixelsList[i + 2] = CheckByte(pixelsList[i + 2] + 200);
                pixelsList[i + 1] = CheckByte(pixelsList[i + 1] - 50);
                pixelsList[i] = CheckByte(pixelsList[i]/2);
            }
            SetPixels();
        }
    }
}

/*
 * [i] -> red
 * [i+1] -> green
 * [i+2] -> blue

 * */