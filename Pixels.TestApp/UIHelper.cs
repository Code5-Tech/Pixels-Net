
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Pixels.TestApp
{
    public class UIHelper
    {
        #region Attributes
        //public static bool ValidToLoad { get; set; }
        private static object ImageLock = new object();
        #endregion
        
        public static ImageSource BitmapFromUri(Uri source)
        {
            try
            {
                var bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = source;
                bitmap.CacheOption = BitmapCacheOption.OnLoad;
                bitmap.EndInit();
                return bitmap;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        public static System.Drawing.Bitmap GetBitmap(string path)
        {
            try
            {
                return new System.Drawing.Bitmap(path);
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        public static BitmapImage ToWpfBitmap(Bitmap bitmap)
        {
            lock (ImageLock)
            {
                if (bitmap == null)
                    return null;
                using (MemoryStream stream = new MemoryStream())
                {
                    bitmap.Save(stream, ImageFormat.Png);
                    stream.Position = 0;
                    BitmapImage result = new BitmapImage();
                    result.BeginInit();
                    // According to MSDN, "The default OnDemand cache option retains access to the stream until the image is needed."
                    // Force the bitmap to load right now so we can dispose the stream.
                    result.CacheOption = BitmapCacheOption.OnLoad;
                    result.StreamSource = stream;
                    result.EndInit();
                    result.Freeze();
                    return result;
                }
            }
            
        }
        

    }
}
