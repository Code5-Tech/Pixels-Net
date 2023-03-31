﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Pixels.Core.Filters
{
    public unsafe class OffsetFilter : PixelsProcessor
    {
        public List<int> parameters { get; set; }
        public void Load(Bitmap btemp)
        {
            Bitmap = btemp;
        }
        public List<string> FiltersList()
        {
            return "offset_red,offset_green,offset_blue,extreme_offset_red,extra_offset_red,extreme_offset_green,extra_offset_green,extreme_offset_blue,extra_offset_blue,rgb_split".Split(',').ToList();
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

        public void offset_red()
        {
            var offset = 5; 
            if (parameters.Count>0)
            {
                offset = parameters[0];
            }
            LoadPixels();
            for (int i = 0; i < pixelsList.Length; i += 4)
            {
                pixelsList[i+2] = ((i + 4 * offset * offset) > pixelsList.Length) ? (byte)0 : pixelsList[i + 4 * offset];
            }
            SetPixels();
        }

        public void extreme_offset_red()
        {
            var offset = 35;
            if (parameters.Count > 0)
            {
                offset = parameters[0];
            }
            LoadPixels();
            for (int i = 0; i < pixelsList.Length; i += 4)
            {
                pixelsList[i] = ((i + 4 * offset * offset) > pixelsList.Length) ? (byte)0 : pixelsList[i + 4 * offset];
            }
            SetPixels();
        }
        public void extra_offset_red()
        {
            var offset = 15;
            if (parameters.Count > 0)
            {
                offset = parameters[0];
            }
            LoadPixels();
            for (int i = 0; i < pixelsList.Length; i += 4)
            {
                pixelsList[i + 2] = ((i + 4 * offset * offset) > pixelsList.Length) ? (byte)0 : pixelsList[i + 4 * offset];
            }
            SetPixels();
        }
        public void offset_green()
        {
            var offset = 5;
            if (parameters.Count > 0)
            {
                offset = parameters[0];
            }
            LoadPixels();
            for (int i = 0; i < pixelsList.Length; i += 4)
            {
                pixelsList[i+1] = ((i + 4 * offset * offset) > pixelsList.Length) ? (byte)0 : pixelsList[i + 4 * offset];
            }
            SetPixels();
        }
        public void extreme_offset_green()
        {
            var offset = 35;
            if (parameters.Count > 0)
            {
                offset = parameters[0];
            }
            LoadPixels();
            for (int i = 0; i < pixelsList.Length; i += 4)
            {
                pixelsList[i + 1] = ((i + 4 * offset * offset) > pixelsList.Length) ? (byte)0 : pixelsList[i + 4 * offset];
            }
            SetPixels();
        }
        public void extra_offset_green()
        {
            var offset = 15;
            if (parameters.Count > 0)
            {
                offset = parameters[0];
            }
            LoadPixels();
            for (int i = 0; i < pixelsList.Length; i += 4)
            {
                pixelsList[i + 1] = ((i + 4 * offset * offset) > pixelsList.Length) ? (byte)0 : pixelsList[i + 4 * offset];
            }
            SetPixels();
        }
        public void offset_blue()
        {
            var offset = 5;
            if (parameters.Count > 0)
            {
                offset = parameters[0];
            }
            LoadPixels();
            for (int i = 0; i < pixelsList.Length; i += 4)
            {
                pixelsList[i] = ((i + 4 * offset * offset) > pixelsList.Length) ? (byte)0 : pixelsList[i + 4 * offset];
            }
            SetPixels();
        }
        public void extreme_offset_blue()
        {
            var offset = 35;
            if (parameters.Count > 0)
            {
                offset = parameters[0];
            }
            LoadPixels();
            for (int i = 0; i < pixelsList.Length; i += 4)
            {
                pixelsList[i] = ((i + 4 * offset * offset) > pixelsList.Length) ? (byte)0 : pixelsList[i + 4 * offset];
            }
            SetPixels();
        }
        public void extra_offset_blue()
        {
            var offset = 15;
            if (parameters.Count > 0)
            {
                offset = parameters[0];
            }
            LoadPixels();
            for (int i = 0; i < pixelsList.Length; i += 4)
            {
                pixelsList[i] = ((i + 4 * offset * offset) > pixelsList.Length) ? (byte)0 : pixelsList[i + 4 * offset];
            }
            SetPixels();
        }

        public void rgb_split()
        {
            int rDiff = 148,gDiff = 498,bDiff = 298;
            if (parameters.Count==3)
            {
                rDiff = parameters[0];
                gDiff = parameters[1];
                bDiff = parameters[2];
            }
            LoadPixels();
            for (int i = 0; i < pixelsList.Length; i += 4)
            {
                int r = i - rDiff;
                int g = i + gDiff;
                int b = i - bDiff;
                if (r>=0)
                    pixelsList[r] = pixelsList[i+2];
                if(g<pixelsList.Length-4) 
                    pixelsList[g] = pixelsList[i + 1];
                if(b>=0)
                    pixelsList[b] = pixelsList[i];
            }
            SetPixels();
        }
    }
}

/*
 const extreme_offset_blue = (imgData) => {
    for (i = 0; i < imgData.data.length; i += 4) {
        var offset = 35;
        imgData.data[i + 2] = imgData.data[i + 4 * offset * offset] == undefined ? 0 : imgData.data[i + 4 * offset];
    }
    return imgData;
}

const extra_offset_blue = (imgData) => {
    for (i = 0; i < imgData.data.length; i += 4) {
        var offset = 15;
        imgData.data[i + 2] = imgData.data[i + 4 * offset * offset] == undefined ? 0 : imgData.data[i + 4 * offset];
    }
    return imgData;
}

const extreme_offset_green = (imgData) => {
    for (i = 0; i < imgData.data.length; i += 4) {
        var offset = 35;
        imgData.data[i + 1] = imgData.data[i + 4 * offset * offset] == undefined ? 0 : imgData.data[i + 4 * offset];
    }
    return imgData;
}

const extra_offset_green = (imgData) => {
    for (i = 0; i < imgData.data.length; i += 4) {
        var offset = 15;
        imgData.data[i + 1] = imgData.data[i + 4 * offset * offset] == undefined ? 0 : imgData.data[i + 4 * offset];
    }
    return imgData;
}

const extreme_offset_red = (imgData) => {
    for (i = 0; i < imgData.data.length; i += 4) {
        var offset = 35;
        imgData.data[i] = imgData.data[i + 4 * offset * offset] == undefined ? 0 : imgData.data[i + 4 * offset];
    }
    return imgData;
}

const extra_offset_red = (imgData) => {
    for (i = 0; i < imgData.data.length; i += 4) {
        var offset = 15;
        imgData.data[i] = imgData.data[i + 4 * offset * offset] == undefined ? 0 : imgData.data[i + 4 * offset];
    }
    return imgData;
}

const offset = (imgData) => {
    for (let i = 0; i < imgData.data.length; i += 4) {
        var offset = 5;
        imgData.data[i] = imgData.data[i + 4 * offset * offset] == undefined ? 0 : imgData.data[i + 4 * offset];
    }
    return imgData;
}

const offset_green_imgdata = (imgData) => {
    for (i = 0; i < imgData.data.length; i += 4) {
        var offset = 5;
        imgData.data[i + 1] = imgData.data[i + 4 * offset * offset] == undefined ? 0 : imgData.data[i + 4 * offset];
    }
    return imgData;
}

const offset_blue_imgdata = (imgData) => {
    for (i = 0; i < imgData.data.length; i += 4) {
        var offset = 5;
        imgData.data[i + 2] = imgData.data[i + 4 * offset * offset] == undefined ? 0 : imgData.data[i + 4 * offset];
    }
    return imgData;
}

const rgb_split = (imgData) => {
    for (i = 0; i < imgData.data.length; i += 4) {
      imgData.data[i - 150] = imgData.data[i + 0]; 
      imgData.data[i + 500] = imgData.data[i + 1]; 
      imgData.data[i - 300] = imgData.data[i + 2]; 
    }
    return imgData;
}
 */