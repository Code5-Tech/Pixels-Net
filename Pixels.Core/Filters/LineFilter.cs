using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Pixels.Core.Filters
{
    public unsafe class LineFilter : PixelsProcessor
    {

        public void Load(Bitmap btemp)
        {
            Bitmap = btemp;
        }
        public List<string> FiltersList()
        {
            return "add_horizontal_line,add_diagonal_lines,add_green_diagonal_lines".Split(',').ToList();
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

        public void add_horizontal_line()
        {
            Point size = PixelSize;
            int inc = 0;
            for (int y = 0; y < size.Y; y++)
            {
                PixelData* pPixel = PixelAt(0, y);
                for (int x = 0; x < size.X; x++)
                {
                    inc += 1;
                    if (inc > 255)
                    {
                        inc = 0;
                    }
                    var avg = (pPixel->red+ pPixel->green+ pPixel->blue) / 3;

                    pPixel->red = (byte)(avg + inc);
                    pPixel->green = (byte)(avg + 70);
                    pPixel->blue = (byte)(avg + 20);
                    pPixel++;
                }
            }
        }
        public void add_diagonal_lines()
        {
            Point size = PixelSize;
            int inc = 0;
            for (int y = 0; y < size.Y; y++)
            {
                PixelData* pPixel = PixelAt(0, y);
                for (int x = 0; x < size.X; x++)
                {
                    inc += 20;
                    if (inc > 255)
                    {
                        inc = 0;
                    }
                    var avg = (pPixel->red + pPixel->green + pPixel->blue) / 3;

                    pPixel->red = (byte)(avg + inc);
                    pPixel->green = (byte)(avg + 70);
                    pPixel->blue = (byte)(avg + 20);
                    pPixel++;
                }
            }
        }
        public void add_green_diagonal_lines()
        {
            Point size = PixelSize;
            int inc = 0;
            for (int y = 0; y < size.Y; y++)
            {
                PixelData* pPixel = PixelAt(0, y);
                for (int x = 0; x < size.X; x++)
                {
                    inc += 20;
                    if (inc > 255)
                    {
                        inc = 0;
                    }
                    var avg = (pPixel->red + pPixel->green + pPixel->blue) / 3;

                    pPixel->red = (byte)(avg + 5);
                    pPixel->green = (byte)(avg + inc);
                    pPixel->blue = (byte)(avg + 20);
                    pPixel++;
                }
            }
        }
    }
}

/*
 * 
 const add_horizontal_line_imgdata = (imgData) => {
    let inc = 0;
    for (i = 0; i < imgData.data.length; i += 4) {
        inc += 1;
        if (inc > 255) {
            inc = 0;
        }
        let avg = (imgData.data[i] + imgData.data[i + 1] + imgData.data[i + 2]) / 3
        imgData.data[i] = avg + inc;
        imgData.data[i + 1] = avg + 70
        imgData.data[i + 2] = avg + 20
    }
    return imgData;
}

const add_diagonal_lines_imgdata = (imgData) => {
    let inc = 0;
    for (i = 0; i < imgData.data.length; i += 4) {
        inc += 20;
        if (inc > 255) {
            inc = 0;
        }
        let avg = (imgData.data[i] + imgData.data[i + 1] + imgData.data[i + 2]) / 3
        imgData.data[i] = avg + inc;
        imgData.data[i + 1] = avg + 70
        imgData.data[i + 2] = avg + 20
    }
    return imgData;
}

const add_green_diagonal_lines_imgdata = (imgData) => {
    let inc = 0;
    for (i = 0; i < imgData.data.length; i += 4) {
        inc += 20;
        if (inc > 255) {
            inc = 0;
        }
        var avg = (imgData.data[i] + imgData.data[i + 1] + imgData.data[i + 2]) / 3
        imgData.data[i] = avg + 5;
        imgData.data[i + 1] = avg + inc;
        imgData.data[i + 2] = avg + 20
    }
    return imgData;
}
 */