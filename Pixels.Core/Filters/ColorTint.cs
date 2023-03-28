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
            for (int i = 0; i < pixelsList.Length; i+=4)
            {
                pixelsList[i + 1] = (byte)(pixelsList[i] + 50);
            }
            SetPixels();
        }
        public void coral()
        {            
            LoadPixels();
            for (int i = 0; i < pixelsList.Length; i += 4)
            {
                pixelsList[i + 2] = (byte)(pixelsList[i+1] + 50);
            }
            SetPixels();
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
                    pPixel->blue = (byte)(pPixel->green + 50);

                    pPixel++;
                }
            }
        }
        public void vintage()
        {
            Point size = PixelSize;
            for (int y = 0; y < size.Y; y++)
            {
                PixelData* pPixel = PixelAt(0, y);
                for (int x = 0; x < size.X; x++)
                {
                    pPixel->red += 120;
                    pPixel->green += 70;
                    pPixel->blue += 13;

                    pPixel++;
                }
            }
        }
    }
}

/*
 * [i] -> red
 * [i+1] -> green
 * [i+2] -> blue
 const lemon_imgdata = (imgData) => {
    for (i = 0; i < imgData.data.length; i += 4) {
        imgData.data[i + 1] = imgData.data[i] + 50;
    }
    return imgData;
}

const coral_imgdata = (imgData) => {
    for (i = 0; i < imgData.data.length; i += 4) {
        imgData.data[i + 2] = imgData.data[i + 1] + 50;
    }
    return imgData;
}

const frontward_imgdata = (imgData) => {
    for (i = 0; i < imgData.data.length; i += 4) {
        imgData.data[i] = imgData.data[i + 2];
        imgData.data[i + 2] = imgData.data[i + 1] + 50;
    }
    return imgData;
}

const vintage_imgdata = (imgData) => {
    for (i = 0; i < imgData.data.length; i += 4) {
        imgData.data[i] += 120
        imgData.data[i + 1] += 70
        imgData.data[i + 2] += 13
    }

    return imgData;
}

const perfume_imgdata = (imgData) => {

    for (i = 0; i < imgData.data.length; i += 4) {
        imgData.data[i] += 80
        imgData.data[i + 1] += 40
        imgData.data[i + 2] += 120
    }
    return imgData;
}

const serenity_imgdata = (imgData) => {

    for (i = 0; i < imgData.data.length; i += 4) {
        imgData.data[i] += 10
        imgData.data[i + 1] += 40
        imgData.data[i + 2] += 90
    }
    return imgData;
}

const pink_aura_imgdata = (imgData) => {
    for (i = 0; i < imgData.data.length; i += 4) {
        imgData.data[i] += 90
        imgData.data[i + 1] += 10
        imgData.data[i + 2] += 90
    }
    return imgData;
}

const haze_imgdata = (imgData) => {
    for (i = 0; i < imgData.data.length; i += 4) {
        imgData.data[i] += 90
        imgData.data[i + 1] += 90
        imgData.data[i + 2] += 10
    }
    return imgData;
}

const mellow_imgdata = (imgData) => {

    for (i = 0; i < imgData.data.length; i += 4) {
        imgData.data[i + 2] = 120 - imgData.data[i + 2];
    }
    return imgData;
}

const solange_dark_imgdata = (imgData) => {
    for (i = 0; i < imgData.data.length; i += 4) {
        imgData.data[i] = 200 - imgData.data[i];

        // imgData.data[i + 1] = 255 - imgData.data[i + 1];
        // imgData.data[i + 2] = 255 - imgData.data[i + 2];
    }
    return imgData;
}

const zapt_imgdata = (imgData) => {

    for (i = 0; i < imgData.data.length; i += 4) {
        // imgData.data[i] = 255 - imgData.data[i];
        imgData.data[i + 1] = 255 - imgData.data[i + 1];
        // imgData.data[i + 2] = 255 - imgData.data[i + 2];
    }
    return imgData;
}

const neue_imgdata = (imgData) => {

    for (i = 0; i < imgData.data.length; i += 4) {
        imgData.data[i + 2] = 255 - imgData.data[i + 2];
        imgData.data[i] = imgData.data[i] + 20;

    }
    return imgData;
}

const eon_imgdata = (imgData) => {

    for (i = 0; i < imgData.data.length; i += 4) {
        imgData.data[i + 1] = 120 - imgData.data[i + 1];
        imgData.data[i + 2] = 100 - imgData.data[i + 2];
    }
    return imgData;
}

const aeon_imgdata = (imgData) => {

    for (i = 0; i < imgData.data.length; i += 4) {
        imgData.data[i + 1] = 60 - imgData.data[i + 1];
        imgData.data[i + 2] = 100 - imgData.data[i + 2];
    }
    return imgData;
}

const rosetint_imgdata = (imgData) => {

    for (i = 0; i < imgData.data.length; i += 4) {
        let avg = (imgData.data[i] + imgData.data[i + 1] + imgData.data[i + 2]) / 3
        imgData.data[i] = avg + 80
        imgData.data[i + 1] = avg + 20
        imgData.data[i + 2] = avg + 31
    }
    return imgData;
}

const slate_imgdata = (imgData) => {

    for (i = 0; i < imgData.data.length; i += 4) {
        let avg = (imgData.data[i] + imgData.data[i + 1] + imgData.data[i + 2]) / 3
        imgData.data[i] = avg + 4
        imgData.data[i + 1] = avg + 3
        imgData.data[i + 2] = avg + 12
    }
    return imgData;
}

const purplescale_imgdata = (imgData) => {

    for (i = 0; i < imgData.data.length; i += 4) {
        let avg = (imgData.data[i] + imgData.data[i + 1] + imgData.data[i + 2]) / 3
        imgData.data[i] = avg + 90
        imgData.data[i + 1] = avg + 40
        imgData.data[i + 2] = avg + 80
    }
    return imgData;
}

const radio_imgdata = (imgData) => {

    for (i = 0; i < imgData.data.length; i += 4) {
        let avg = (imgData.data[i] + imgData.data[i + 1] + imgData.data[i + 2]) / 3
        imgData.data[i] = avg + 5
        imgData.data[i + 1] = avg + 40
        imgData.data[i + 2] = avg + 20
    }
    return imgData;
}

const twenties_imgdata = (imgData) => {

    for (i = 0; i < imgData.data.length; i += 4) {
        let avg = (imgData.data[i] + imgData.data[i + 1] + imgData.data[i + 2]) / 3
        imgData.data[i] = avg + 18
        imgData.data[i + 1] = avg + 12
        imgData.data[i + 2] = avg + 20
    }
    return imgData;
}

const ocean_imgdata = (imgData) => {
    for (i = 0; i < imgData.data.length; i += 4) {
        imgData.data[i] += 10
        imgData.data[i + 1] += 20
        imgData.data[i + 2] += 90
    }
    return imgData;
}

const greyscale_imgdata = (imgData) => {
    for (i = 0; i < imgData.data.length; i += 4) {
        var avg = (imgData.data[i] + imgData.data[i + 1] + imgData.data[i + 2]) / 3
        imgData.data[i] = avg
        imgData.data[i + 1] = avg
        imgData.data[i + 2] = avg
    }
    return imgData;
}

const redgreyscale_imgdata = (imgData) => {
    for (i = 0; i < imgData.data.length; i += 4) {
        let avg = (imgData.data[i] + imgData.data[i + 1] + imgData.data[i + 2]) / 3
        imgData.data[i] = avg + 100
        imgData.data[i + 1] = avg + 40
        imgData.data[i + 2] = avg + 20
    }
    return imgData;
}

const greengreyscale_imgdata = (imgData) => {
    for (i = 0; i < imgData.data.length; i += 4) {
        let avg = (imgData.data[i] + imgData.data[i + 1] + imgData.data[i + 2]) / 3
        imgData.data[i] = avg + 20
        imgData.data[i + 1] = avg + 70
        imgData.data[i + 2] = avg + 20
    }
    return imgData;
}



const warmth =  (imgData) => {
    for (i = 0; i < imgData.data.length; i += 4) {
        imgData.data[i] = imgData.data[i] + 10
        imgData.data[i + 1] = imgData.data[i + 1] + 18
    }
    return imgData;
}

const crimson = (imgData) => {
    for (i = 0; i < imgData.data.length; i += 4) {
        imgData.data[i] = imgData.data[i] + 20
        imgData.data[i + 1] = imgData.data[i + 2] + 20
    }
    return imgData;
}

const phase = (imgData) => {
    for (i = 0; i < imgData.data.length; i += 4) {
        imgData.data[i] = imgData.data[i] + getRandomNumber(10, 20)
        imgData.data[i + 1] = imgData.data[i + 2] + getRandomNumber(10, 20)

        imgData.data[i + 2] = imgData.data[i + 2] + getRandomNumber(10, 20)
    }
    return imgData;
}

const grime = (imgData) => {
    for (i = 0; i < imgData.data.length; i += 4) {
        imgData.data[i + 1] = imgData.data[i] + 5;
        imgData.data[i] = imgData.data[i] + 1;
    }
    return imgData;
}

const evening_imgdata = (imgData) => {
    let SAT_ADJ = 60;
    for (i = 0; i < imgData.data.length; i += 4) {
        imgData.data[i] -= SAT_ADJ
        imgData.data[i + 1] -= SAT_ADJ
        imgData.data[i + 2] -= SAT_ADJ
    }
    return imgData;
}

const sunset = (imgData) => {
    for (i = 0; i < imgData.data.length; i += 4) {
        imgData.data[i + 1] = imgData.data[i] + 50;
        imgData.data[i + 2] = imgData.data[i + 2] + 12;
    }
    return imgData;
}

const wood = (imgData) => {
    for (i = 0; i < imgData.data.length; i += 4) {
        imgData.data[i] = imgData.data[i] + 30
        imgData.data[i + 1] = imgData.data[i + 1] + 12;
    }
    return imgData;
}


const lix_conv = (imgData) => {
    for (i = 0; i < imgData.data.length; i += 4) {
        imgData.data[i] = 255 - imgData.data[i];
        imgData.data[i + 1] = 255 - imgData.data[i + 1];
    }
    return imgData;
}

const ryo_conv = (imgData) => {
    for (i = 0; i < imgData.data.length; i += 4) {
        imgData.data[i] = 255 - imgData.data[i];
        imgData.data[i + 2] = 255 - imgData.data[i + 2];
    }
    return imgData;
}

const blue_greyscale_imgdata = (imgData) => {
    for (i = 0; i < imgData.data.length; i += 4) {
        let avg = (imgData.data[i] + imgData.data[i + 1] + imgData.data[i + 2]) / 3
        imgData.data[i] = avg + 20
        imgData.data[i + 1] = avg + 30
        imgData.data[i + 2] = avg + 60
    }
    return imgData;
}


const solange_imgdata = (imgData) => {
    for (i = 0; i < imgData.data.length; i += 4) {
        imgData.data[i] = 255 - imgData.data[i];
    }
    return imgData;
}

const solange_grey_imgdata = (imgData) => {
    for (i = 0; i < imgData.data.length; i += 4) {
        imgData.data[i] = imgData.data[i + 2];
        imgData.data[i + 1] = imgData.data[i + 1]
        imgData.data[i + 2] = imgData.data[i]

    }
    return imgData;
}



const cool_twilight_imgdata = (imgData) => {
    for (i = 0; i < imgData.data.length; i += 4) {
        imgData.data[i + 1] = 255 - imgData.data[i + 1];
        imgData.data[i + 2] = imgData.data[i + 2] + 70;

    }
    return imgData;
}

const blues_imgdata = (imgData) => {
    for (i = 0; i < imgData.data.length; i += 4) {
        imgData.data[i + 2] = 255 - imgData.data[i + 2];
    }
    return imgData;
}

const red_effect = (imgData) => {
    for (i = 0; i < imgData.data.length; i += 4) {
        imgData.data[i] = imgData.data[i] + 200;
        imgData.data[i + 1] = imgData.data[i + 1] - 50;
        imgData.data[i + 2] = imgData.data[i + 2] * 0.5;
    }
    return imgData;
}
 * */