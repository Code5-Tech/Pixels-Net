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
            return "green_med_noise".Split(',').ToList();
        }
        public Bitmap Apply(string filterName)
        {
            Type type = this.GetType();
            MethodInfo filterMethod = type.GetMethod(filterName);
            if(filterMethod!=null)
            {
                LockBitmap();
                filterMethod.Invoke(this, null);
                UnlockBitmap();
            }
            return Bitmap;
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

                    pPixel->red = (byte)(pPixel->green * 0.5f * randomColor1);
                    pPixel->green = (byte)(pPixel->blue * 0.5f * randomColor2);
                    pPixel->blue = (byte)(pPixel->red * 0.5f * randomColor3);

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
 const green_med_noise_imgdata = (imgData) => {
    let rand = (0.5 - Math.random()) * 9;

    for (i = 0; i < imgData.data.length; i += 4) {
        let randomColor1 = 0.6 + Math.random() * 0.5;

        let randomColor2 = 0.6 + Math.random() * 0.5;

        let randomColor3 = 0.6 + Math.random() * 0.5;

        imgData.data[i] = imgData.data[i + 1] * 0.5 * randomColor1;
        imgData.data[i + 1] = imgData.data[i + 2] * 0.99 * randomColor2;

        imgData.data[i + 2] = imgData.data[i] * 0.99 * randomColor3;
    }
    return imgData;
}

const dark_purple_min_noise_imgdata = (imgData) => {
    let rand = (0.5 - Math.random()) * 9;

    for (i = 0; i < imgData.data.length; i += 4) {
        let randomColor1 = 0.6 + Math.random() * 0.5;

        let randomColor2 = 0.6 + Math.random() * 0.5;

        let randomColor3 = 0.6 + Math.random() * 0.5;

        imgData.data[i] = imgData.data[i] * 0.5 * randomColor1;
        imgData.data[i + 1] = imgData.data[i + 1] * 0.3 * randomColor2;

        imgData.data[i + 2] = imgData.data[i + 2] * 0.99 * randomColor3;
    }
    return imgData;
}

const teal_min_noise_imgdata = (imgData) => {
    let rand = (0.5 - Math.random()) * 1;

    for (i = 0; i < imgData.data.length; i += 4) {
        let randomColor1 = 0.6 + Math.random() * 0.1;

        let randomColor2 = 0.6 + Math.random() * 0.5;

        let randomColor3 = 0.6 + Math.random() * 0.5;

        imgData.data[i] = imgData.data[i] * 0.99 * randomColor1;
        imgData.data[i + 1] = imgData.data[i + 1] * 0.99 * randomColor2;

        imgData.data[i + 2] = imgData.data[i + 2] * 0.99 * randomColor3;
    }
    return imgData;
}

const purple_min_noise_imgdata = (imgData) => {
    let rand = (0.5 - Math.random()) * 1;

    for (i = 0; i < imgData.data.length; i += 4) {
        let randomColor1 = 0.6 + Math.random() * 0.5;

        let randomColor2 = 0.6 + Math.random() * 0.2;

        let randomColor3 = 0.6 + Math.random() * 0.8;

        imgData.data[i] = imgData.data[i] * 0.99 * randomColor1;
        imgData.data[i + 1] = imgData.data[i + 1] * 0.99 * randomColor2;

        imgData.data[i + 2] = imgData.data[i + 2] * 0.99 * randomColor3;
    }
    return imgData;
}

const blue_min_noise_imgdata = (imgData) => {
    let rand = (0.5 - Math.random()) * 1;

    for (i = 0; i < imgData.data.length; i += 4) {
        let randomColor1 = 0.6 + Math.random() * 0.1;

        let randomColor2 = 0.6 + Math.random() * 0.2;

        let randomColor3 = 0.6 + Math.random() * 0.7;

        imgData.data[i] = imgData.data[i] * 0.99 * randomColor1;
        imgData.data[i + 1] = imgData.data[i + 1] * 0.99 * randomColor2;

        imgData.data[i + 2] = imgData.data[i + 2] * 0.99 * randomColor3;
    }
    return imgData;
}

const green_min_noise_imgdata = (imgData) => {
    let rand = (0.5 - Math.random()) * 1;

    for (i = 0; i < imgData.data.length; i += 4) {
        let randomColor1 = 0.6 + Math.random() * 0.1;

        let randomColor2 = 0.6 + Math.random() * 0.5;

        let randomColor3 = 0.6 + Math.random() * 0.4;

        imgData.data[i] = imgData.data[i] * 0.99 * randomColor1;
        imgData.data[i + 1] = imgData.data[i + 1] * 0.99 * randomColor2;

        imgData.data[i + 2] = imgData.data[i + 2] * 0.99 * randomColor3;
    }
    return imgData;
}

const pink_min_noise_imgdata = (imgData) => {
    let rand = (0.5 - Math.random()) * 1;

    for (i = 0; i < imgData.data.length; i += 4) {
        let randomColor1 = 0.6 + Math.random() * 0.6;

        let randomColor2 = 0.6 + Math.random() * 0.1;

        let randomColor3 = 0.6 + Math.random() * 0.4;

        imgData.data[i] = imgData.data[i] * 0.99 * randomColor1;
        imgData.data[i + 1] = imgData.data[i + 1] * 0.99 * randomColor2;

        imgData.data[i + 2] = imgData.data[i + 2] * 0.99 * randomColor3;
    }
    return imgData;
}


const matrix_imgdata = (imgData) => {
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
    return imgData;
}

const matrix2 = (imgData) => {
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
    return imgData;
}

const cosmic_imgdata = (imgData) => {
    let randomNumber = 0;

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
    return imgData;
}


const min_noise_imgdata = (imgData) => {
    var rand = (0.5 - Math.random()) * 53;

    for (i = 0; i < imgData.data.length; i += 4) {
        let randomColor1 = 0.6 + Math.random() * 0.4;

        let randomColor2 = 0.6 + Math.random() * 0.4;

        let randomColor3 = 0.6 + Math.random() * 0.4;

        imgData.data[i] = imgData.data[i] * 0.99 * randomColor1;
        imgData.data[i + 1] = imgData.data[i + 1] * 0.99 * randomColor2;

        imgData.data[i + 2] = imgData.data[i + 2] * 0.99 * randomColor3;
    }
    return imgData;
}

const red_min_noise_imgdata = (imgData) => {
    var rand = (0.5 - Math.random()) * 1;

    for (i = 0; i < imgData.data.length; i += 4) {
        let randomColor1 = 0.6 + Math.random() * 0.6;

        let randomColor2 = 0.6 + Math.random() * 0.4;

        let randomColor3 = 0.6 + Math.random() * 0.4;

        imgData.data[i] = imgData.data[i] * 0.99 * randomColor1;
        imgData.data[i + 1] = imgData.data[i + 1] * 0.99 * randomColor2;

        imgData.data[i + 2] = imgData.data[i + 2] * 0.99 * randomColor3;
    }
    return imgData;
}
 */