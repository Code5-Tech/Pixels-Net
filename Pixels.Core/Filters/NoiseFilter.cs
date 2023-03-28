using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Pixels.Core.Filters
{
    public unsafe class NoiseFilter : PixelsProcessor
    {
        Random rnd = null;
        public void Load(Bitmap btemp)
        {
            Bitmap = btemp;
            rnd = new Random();
        }
        public List<string> FiltersList()
        {
            return @"min_noise,matrix,matrix2,cosmic,teal_min_noise,purple_min_noise,dark_purple_min_noise,blue_min_noise,green_min_noise,red_min_noise,pink_min_noise,green_med_noise".Split(',').ToList();
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

        public void min_noise()
        {
            var rand = (0.5 - rnd.NextDouble()) * 53f;
            Point size = PixelSize;
            for (int y = 0; y < size.Y; y++)
            {
                PixelData* pPixel = PixelAt(0, y);
                for (int x = 0; x < size.X; x++)
                {
                    var randomColor1 = 0.6f + rnd.NextDouble() * 0.4f;
                    var randomColor2 = 0.6f + rnd.NextDouble() * 0.4f;
                    var randomColor3 = 0.6f + rnd.NextDouble() * 0.4f;

                    pPixel->red = CheckByte(pPixel->red * 0.99f * randomColor1);
                    pPixel->green = CheckByte(pPixel->green * 0.99f * randomColor2);
                    pPixel->blue = CheckByte(pPixel->blue * 0.99f * randomColor3);

                    pPixel++;
                }
            }
            /*
                let rand = (0.5 - Math.random()) * 53;
                for (i = 0; i < imgData.data.length; i += 4) {
                    let randomColor1 = 0.6 + Math.random() * 0.4;
                    let randomColor2 = 0.6 + Math.random() * 0.4;
                    let randomColor3 = 0.6 + Math.random() * 0.4;
                    imgData.data[i] = imgData.data[i] * 0.99 * randomColor1;
                    imgData.data[i + 1] = imgData.data[i + 1] * 0.99 * randomColor2;
                    imgData.data[i + 2] = imgData.data[i + 2] * 0.99 * randomColor3;
                }
             */
        }
        public void green_med_noise()
        {
            var rand = (0.5 - rnd.NextDouble()) * 9f;
            Point size = PixelSize;
            for (int y = 0; y < size.Y; y++)
            {
                PixelData* pPixel = PixelAt(0, y);
                for (int x = 0; x < size.X; x++)
                {
                    var randomColor1 = 0.6f + rnd.NextDouble() * 0.5f;
                    var randomColor2 = 0.6f + rnd.NextDouble() * 0.5f;
                    var randomColor3 = 0.6f + rnd.NextDouble() * 0.5f;
                    pPixel->red = CheckByte(pPixel->green * 0.5f * randomColor1);
                    pPixel->green = CheckByte(pPixel->blue * 0.99f * randomColor2);
                    pPixel->blue = CheckByte(pPixel->red * 0.99f * randomColor3);

                    pPixel++;
                }
            }

            /*
                let rand = (0.5 - Math.random()) * 9;
                for (i = 0; i < imgData.data.length; i += 4) {
                    let randomColor1 = 0.6 + Math.random() * 0.5;
                    let randomColor2 = 0.6 + Math.random() * 0.5;
                    let randomColor3 = 0.6 + Math.random() * 0.5;

                    imgData.data[i] = imgData.data[i + 1] * 0.5 * randomColor1;
                    imgData.data[i + 1] = imgData.data[i + 2] * 0.99 * randomColor2;
                    imgData.data[i + 2] = imgData.data[i] * 0.99 * randomColor3;
                }
             */
        }
        public void purple_min_noise()
        {
            var rand = (0.5 - rnd.NextDouble()) * 1f;
            Point size = PixelSize;
            for (int y = 0; y < size.Y; y++)
            {
                PixelData* pPixel = PixelAt(0, y);
                for (int x = 0; x < size.X; x++)
                {
                    var randomColor1 = 0.6f + rnd.NextDouble() * 0.5f;
                    var randomColor2 = 0.6f + rnd.NextDouble() * 0.2f;
                    var randomColor3 = 0.6f + rnd.NextDouble() * 0.8f;

                    pPixel->red = CheckByte(pPixel->red * 0.99f * randomColor1);
                    pPixel->green = CheckByte(pPixel->green * 0.99f * randomColor2);
                    pPixel->blue = CheckByte(pPixel->blue * 0.99f * randomColor3);

                    pPixel++;
                }
            }
            /*
                let rand = (0.5 - Math.random()) * 1;
                for (i = 0; i < imgData.data.length; i += 4) {
                    let randomColor1 = 0.6 + Math.random() * 0.5;
                    let randomColor2 = 0.6 + Math.random() * 0.2;
                    let randomColor3 = 0.6 + Math.random() * 0.8;
                    imgData.data[i] = imgData.data[i] * 0.99 * randomColor1;
                    imgData.data[i + 1] = imgData.data[i + 1] * 0.99 * randomColor2;
                    imgData.data[i + 2] = imgData.data[i + 2] * 0.99 * randomColor3;
                }
             */
        }
        public void dark_purple_min_noise()
        {
            var rand = (0.5 - rnd.NextDouble()) * 9f;
            Point size = PixelSize;
            for (int y = 0; y < size.Y; y++)
            {
                PixelData* pPixel = PixelAt(0, y);
                for (int x = 0; x < size.X; x++)
                {
                    var randomColor1 = 0.6f + rnd.NextDouble() * 0.5f;
                    var randomColor2 = 0.6f + rnd.NextDouble() * 0.5f;
                    var randomColor3 = 0.6f + rnd.NextDouble() * 0.5f;
                    pPixel->red = CheckByte(pPixel->red * 0.5f * randomColor1);
                    pPixel->green = CheckByte(pPixel->green * 0.3f * randomColor2);
                    pPixel->blue = CheckByte(pPixel->blue * 0.99f * randomColor3);

                    pPixel++;
                }
            }
            /*
                let rand = (0.5 - Math.random()) * 9;
                for (i = 0; i < imgData.data.length; i += 4) {
                    let randomColor1 = 0.6 + Math.random() * 0.5;
                    let randomColor2 = 0.6 + Math.random() * 0.5;
                    let randomColor3 = 0.6 + Math.random() * 0.5;

                    imgData.data[i] = imgData.data[i] * 0.5 * randomColor1;
                    imgData.data[i + 1] = imgData.data[i + 1] * 0.3 * randomColor2;
                    imgData.data[i + 2] = imgData.data[i + 2] * 0.99 * randomColor3;
                }
             */
        }
        public void teal_min_noise()
        {
            var rand = (0.5 - rnd.NextDouble()) * 1f;
            Point size = PixelSize;
            for (int y = 0; y < size.Y; y++)
            {
                PixelData* pPixel = PixelAt(0, y);
                for (int x = 0; x < size.X; x++)
                {
                    var randomColor1 = 0.6f + rnd.NextDouble() * 0.1f;
                    var randomColor2 = 0.6f + rnd.NextDouble() * 0.5f;
                    var randomColor3 = 0.6f + rnd.NextDouble() * 0.5f;

                    pPixel->red = CheckByte(pPixel->red * 0.99f * randomColor1);
                    pPixel->green = CheckByte(pPixel->green * 0.99f * randomColor2);
                    pPixel->blue = CheckByte(pPixel->blue * 0.99f * randomColor3);

                    pPixel++;
                }
            }
            /*
                let rand = (0.5 - Math.random()) * 1;
                for (i = 0; i < imgData.data.length; i += 4) {
                    let randomColor1 = 0.6 + Math.random() * 0.1;
                    let randomColor2 = 0.6 + Math.random() * 0.5;
                    let randomColor3 = 0.6 + Math.random() * 0.5;
                    imgData.data[i] = imgData.data[i] * 0.99 * randomColor1;
                    imgData.data[i + 1] = imgData.data[i + 1] * 0.99 * randomColor2;
                    imgData.data[i + 2] = imgData.data[i + 2] * 0.99 * randomColor3;
                }
             */
        }
        public void blue_min_noise()
        {
            var rand = (0.5 - rnd.NextDouble()) * 1f;
            Point size = PixelSize;
            for (int y = 0; y < size.Y; y++)
            {
                PixelData* pPixel = PixelAt(0, y);
                for (int x = 0; x < size.X; x++)
                {
                    var randomColor1 = 0.6f + rnd.NextDouble() * 0.1f;
                    var randomColor2 = 0.6f + rnd.NextDouble() * 0.2f;
                    var randomColor3 = 0.6f + rnd.NextDouble() * 0.7f;

                    pPixel->red = CheckByte(pPixel->red * 0.99f * randomColor1);
                    pPixel->green = CheckByte(pPixel->green * 0.99f * randomColor2);
                    pPixel->blue = CheckByte(pPixel->blue * 0.99f * randomColor3);

                    pPixel++;
                }
            }
            /*
                let rand = (0.5 - Math.random()) * 1;
                for (i = 0; i < imgData.data.length; i += 4) {
                    let randomColor1 = 0.6 + Math.random() * 0.1;
                    let randomColor2 = 0.6 + Math.random() * 0.2;
                    let randomColor3 = 0.6 + Math.random() * 0.7;
                    imgData.data[i] = imgData.data[i] * 0.99 * randomColor1;
                    imgData.data[i + 1] = imgData.data[i + 1] * 0.99 * randomColor2;
                    imgData.data[i + 2] = imgData.data[i + 2] * 0.99 * randomColor3;
                }
             */
        }
        public void green_min_noise()
        {
            var rand = (0.5 - rnd.NextDouble()) * 1f;
            Point size = PixelSize;
            for (int y = 0; y < size.Y; y++)
            {
                PixelData* pPixel = PixelAt(0, y);
                for (int x = 0; x < size.X; x++)
                {
                    var randomColor1 = 0.6f + rnd.NextDouble() * 0.1f;
                    var randomColor2 = 0.6f + rnd.NextDouble() * 0.5f;
                    var randomColor3 = 0.6f + rnd.NextDouble() * 0.4f;

                    pPixel->red = CheckByte(pPixel->red * 0.99f * randomColor1);
                    pPixel->green = CheckByte(pPixel->green * 0.99f * randomColor2);
                    pPixel->blue = CheckByte(pPixel->blue * 0.99f * randomColor3);

                    pPixel++;
                }
            }
            /*
                let rand = (0.5 - Math.random()) * 1;
                for (i = 0; i < imgData.data.length; i += 4) {
                    let randomColor1 = 0.6 + Math.random() * 0.1;
                    let randomColor2 = 0.6 + Math.random() * 0.5;
                    let randomColor3 = 0.6 + Math.random() * 0.4;
                    imgData.data[i] = imgData.data[i] * 0.99 * randomColor1;
                    imgData.data[i + 1] = imgData.data[i + 1] * 0.99 * randomColor2;
                    imgData.data[i + 2] = imgData.data[i + 2] * 0.99 * randomColor3;
                }
             */
        }
        public void red_min_noise()
        {
            var rand = (0.5 - rnd.NextDouble()) * 1f;
            Point size = PixelSize;
            for (int y = 0; y < size.Y; y++)
            {
                PixelData* pPixel = PixelAt(0, y);
                for (int x = 0; x < size.X; x++)
                {
                    var randomColor1 = 0.6f + rnd.NextDouble() * 0.6f;
                    var randomColor2 = 0.6f + rnd.NextDouble() * 0.4f;
                    var randomColor3 = 0.6f + rnd.NextDouble() * 0.4f;

                    pPixel->red = CheckByte(pPixel->red * 0.99f * randomColor1);
                    pPixel->green = CheckByte(pPixel->green * 0.99f * randomColor2);
                    pPixel->blue = CheckByte(pPixel->blue * 0.99f * randomColor3);

                    pPixel++;
                }
            }
            /*
                let rand = (0.5 - Math.random()) * 1;
                for (i = 0; i < imgData.data.length; i += 4) {
                    let randomColor1 = 0.6 + Math.random() * 0.6;
                    let randomColor2 = 0.6 + Math.random() * 0.4;
                    let randomColor3 = 0.6 + Math.random() * 0.4;
                    imgData.data[i] = imgData.data[i] * 0.99 * randomColor1;
                    imgData.data[i + 1] = imgData.data[i + 1] * 0.99 * randomColor2;
                    imgData.data[i + 2] = imgData.data[i + 2] * 0.99 * randomColor3;
                }
             */
        }
        public void pink_min_noise()
        {
            var rand = (0.5 - rnd.NextDouble()) * 1f;
            Point size = PixelSize;
            for (int y = 0; y < size.Y; y++)
            {
                PixelData* pPixel = PixelAt(0, y);
                for (int x = 0; x < size.X; x++)
                {
                    var randomColor1 = 0.6f + rnd.NextDouble() * 0.6f;
                    var randomColor2 = 0.6f + rnd.NextDouble() * 0.1f;
                    var randomColor3 = 0.6f + rnd.NextDouble() * 0.4f;

                    pPixel->red = CheckByte(pPixel->red * 0.99f * randomColor1);
                    pPixel->green = CheckByte(pPixel->green * 0.99f * randomColor2);
                    pPixel->blue = CheckByte(pPixel->blue * 0.99f * randomColor3);

                    pPixel++;
                }
            }
            /*
                let rand = (0.5 - Math.random()) * 1;
                for (i = 0; i < imgData.data.length; i += 4) {
                    let randomColor1 = 0.6 + Math.random() * 0.6;
                    let randomColor2 = 0.6 + Math.random() * 0.1;
                    let randomColor3 = 0.6 + Math.random() * 0.4;
                    imgData.data[i] = imgData.data[i] * 0.99 * randomColor1;
                    imgData.data[i + 1] = imgData.data[i + 1] * 0.99 * randomColor2;
                    imgData.data[i + 2] = imgData.data[i + 2] * 0.99 * randomColor3;
                }
             */
        }   
        public void matrix()
        {
            LoadPixels();
            int randomNumber = 0;
            for (int i = 0; i < pixelsList.Length; i+=4)
            {
                randomNumber = rnd.Next(0, 200);
                int addition1 = 0, addition2 = 0;
                if (randomNumber > 0 && randomNumber < 50)
                {
                    addition1 = 20;
                    addition2 = 30;
                }
                else if (randomNumber > 49 && randomNumber < 100)
                {
                    addition1 = 10;
                    addition2 = 90;
                }

                else
                {
                    addition1 = 30;
                    addition2 = 10;
                }

                if ((pixelsList[i] - (byte)addition1) > 255)
                {
                    pixelsList[i] = CheckByte(pixelsList[i] - (byte)addition1);
                }
                else
                {
                    pixelsList[i] += (byte)addition1;
                }

                if ((pixelsList[i + 1] + (byte)addition1) > 255)
                {
                    pixelsList[i + 1] = CheckByte(pixelsList[i + 1] - (byte)addition2);
                }
                else
                {
                    pixelsList[i + 1] = CheckByte(pixelsList[i + 1] + (byte)addition2);
                }
            }
            SetPixels();
            /*
                var randomNumber;

                for (i = 0; i < imgData.data.length; i += 4) {
                    randomNumber = getRandomNumber(0, 200);
                    var addition;
                    if (randomNumber > 0 && randomNumber < 50) {
                        addition1 = 20;
                        addition2 = 30;
                    }
                    else if (randomNumber > 49 && randomNumber < 100) {
                        addition1 = 10;
                        addition2 = 90;
                    }

                    else {
                        addition1 = 30;
                        addition2 = 10;
                    }

                    if (imgData.data[i] - addition > 255) {
                        imgData.data[i] -= addition
                    }
                    else {
                        imgData.data[i] += addition
                    }

                    if (imgData.data[i + 1] + addition > 255) {
                        imgData.data[i + 1] -= addition2;
                    } else {
                        imgData.data[i + 1] += addition2;
                    }
                }
             */
        }
        public void matrix2()
        {
            LoadPixels();
            int randomNumber = 0;
            for (int i = 0; i < pixelsList.Length; i+=4)
            {
                randomNumber = rnd.Next(0, 200);
                int addition1 = 0, addition2 = 0;
                if (randomNumber > 0 && randomNumber < 50)
                {
                    addition1 = 20;
                    addition2 = 30;
                }
                else if (randomNumber > 49 && randomNumber < 100)
                {
                    addition1 = 10;
                    addition2 = 90;
                }

                else
                {
                    addition1 = 70;
                    addition2 = 10;
                }

                if ((pixelsList[i] - (byte)addition1) > 255)
                {
                    pixelsList[i] = CheckByte(pixelsList[i] - (byte)addition1);
                }
                else
                {
                    pixelsList[i] = CheckByte(pixelsList[i]+(byte)addition1);
                }

                if ((pixelsList[i + 1] + (byte)addition1) > 255)
                {
                    pixelsList[i + 1] = CheckByte(pixelsList[i + 1] - (byte)addition2);
                }
                else
                {
                    pixelsList[i + 1] = CheckByte(pixelsList[i + 1] + (byte)addition2);
                }
            }
            SetPixels();
            /*
                var randomNumber;

                for (i = 0; i < imgData.data.length; i += 4) {
                    randomNumber = getRandomNumber(0, 200);
                    let addition = 0;
                    if (randomNumber > 0 && randomNumber < 50) {
                        addition1 = 20;
                        addition2 = 30;
                    }
                    else if (randomNumber > 49 && randomNumber < 100) {
                        addition1 = 10;
                        addition2 = 90;
                    }

                    else {
                        addition1 = 70;
                        addition2 = 10;
                    }

                    if (imgData.data[i] - addition > 255) {
                        imgData.data[i] -= addition
                    }
                    else {
                        imgData.data[i] += addition
                    }

                    if (imgData.data[i + 1] + addition > 255) {
                        imgData.data[i + 1] -= addition2;
                    } else {
                        imgData.data[i + 1] += addition2;
                    }
                }
             */
        }
        public void cosmic()
        {
            LoadPixels();
            int randomNumber = 0;
            for (int i = 0; i < pixelsList.Length; i += 4)
            {
                randomNumber = rnd.Next(0, 200);
                int addition1 = 0, addition2 = 0;
                if (randomNumber > 0 && randomNumber < 50)
                {
                    addition1 = 0;
                    addition2 = 30;
                }
                else if (randomNumber > 49 && randomNumber < 100)
                {
                    addition1 = 100;
                    addition2 = 90;
                }
                else
                {
                    addition1 = 70;
                    addition2 = 10;
                }

                if ((pixelsList[i] - (byte)addition1) > 255)
                {
                    pixelsList[i] = CheckByte(pixelsList[i] - (byte)addition1);
                }
                else
                {
                    pixelsList[i] = CheckByte(pixelsList[i] + (byte)addition1);
                }

                if ((pixelsList[i + 1] + (byte)addition1) > 255)
                {
                    pixelsList[i + 1] = CheckByte(pixelsList[i + 1] - (byte)addition2);
                }
                else
                {
                    pixelsList[i + 2] = CheckByte(pixelsList[i + 1] + (byte)addition2);
                }
            }
            SetPixels();
            /*
                var randomNumber;
                 
                for (i = 0; i < imgData.data.length; i += 4) {
                    randomNumber = getRandomNumber(0, 200);
                    if (randomNumber > 0 && randomNumber < 50) {
                        addition1 = 0;
                        addition2 = 30;
                    }
                    else if (randomNumber > 49 && randomNumber < 100) {
                        addition1 = 100;
                        addition2 = 90;
                    }

                    else {
                        addition1 = 70;
                        addition2 = 10;
                    }

                    if (imgData.data[i] - addition > 255) {
                        imgData.data[i] -= addition
                    }
                    else {
                        imgData.data[i] += addition
                    }

                    if (imgData.data[i + 1] + addition > 255) {
                        imgData.data[i + 1] -= addition2;
                    } else {
                        imgData.data[i + 2] += addition2;
                    }
                }
             */
        }
    }
}

/*
 *  [i] -> red
 * [i+1] -> green
 * [i+2] -> blue
 */