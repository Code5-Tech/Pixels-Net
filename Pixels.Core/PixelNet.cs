using Pixels.Core.Filters;
using Pixels.Core.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pixels.Core
{
    public class PixelNet
    {
        List<FilterInfo> allFilters = new List<FilterInfo>();
        Bitmap currentBmp = null;
        ColorTint colorTintFilter = null;
        GammaFilter gammaFilter = null;
        LineFilter lineFilter = null;
        NoiseFilter noiseFilter = null;
        OffsetFilter offsetFilter = null;
        public PixelNet()
        {
            colorTintFilter = new ColorTint();
            gammaFilter = new GammaFilter();
            lineFilter = new LineFilter();
            noiseFilter = new NoiseFilter();
            offsetFilter = new OffsetFilter();
            GetFilters();
        }
        public List<FilterInfo> GetFilters()
        {
            allFilters.Clear();
            // get filters for Color Tint filters
            colorTintFilter.FiltersList().ForEach((d) => { allFilters.Add(new FilterInfo() { Category = "TintColor", Name=d }); });
            gammaFilter.FiltersList().ForEach((d) => { allFilters.Add(new FilterInfo() { Category = "Gamma",Name=d }); });
            lineFilter.FiltersList().ForEach((d) => { allFilters.Add(new FilterInfo() { Category = "Line", Name = d }); });
            noiseFilter.FiltersList().ForEach((d) => { allFilters.Add(new FilterInfo() { Category = "Noise", Name = d }); });
            offsetFilter.FiltersList().ForEach((d) => { allFilters.Add(new FilterInfo() { Category = "Offset", Name = d }); });
            return allFilters;
        }
        public Bitmap Process(Bitmap temp, string filterName)
        {
            currentBmp = new Bitmap(temp);
            try
            {
                var filterInfo = allFilters.FirstOrDefault(x => x.Name == filterName);
                if(filterInfo!=null)
                {
                    if (filterInfo.Category == "TintColor")
                    {
                        colorTintFilter.Load(currentBmp);
                        colorTintFilter.Apply(filterName);
                    }
                    else if (filterInfo.Category == "Gamma")
                    {
                        gammaFilter.Load(currentBmp);
                        gammaFilter.Apply(filterName);
                    }
                    else if (filterInfo.Category == "Line")
                    {
                        lineFilter.Load(currentBmp);
                        lineFilter.Apply(filterName);
                    }
                    else if (filterInfo.Category == "Noise")
                    {
                        noiseFilter.Load(currentBmp);
                        noiseFilter.Apply(filterName);
                    }
                    else if (filterInfo.Category == "Offset")
                    {
                        offsetFilter.Load(currentBmp);
                        offsetFilter.Apply(filterName);
                    }

                }
            }
            catch (Exception)
            {
            }
            return currentBmp;
        }
    }
}
