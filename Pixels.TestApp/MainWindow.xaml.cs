using Microsoft.Win32;
using Pixels.Core;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;

namespace Pixels.TestApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        PixelNet pNet = new PixelNet();
        Bitmap currentResult = null;
        string currentFilter = "";

        string sourceImagePath;
        Bitmap sourceBtm = null;
        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            var filtersList = pNet.GetFilters().OrderBy(x => x.Category).ToList();
            string category = "";
            foreach (var item in filtersList)
            {
                if (category != item.Category)
                {
                    category = item.Category;
                    Label head = new Label();
                    head.Height = 40;
                    head.FontWeight = FontWeights.Bold;
                    head.VerticalContentAlignment = VerticalAlignment.Center;
                    head.HorizontalContentAlignment = HorizontalAlignment.Left;
                    head.Content = item.Category.ToString() + " FILTERS";
                    head.Background = new SolidColorBrush(Colors.DarkGray);
                    head.Foreground = new SolidColorBrush(Colors.White);
                    pnlFiltersList.Children.Add(head);
                }
                TextBlock fl = new TextBlock();
                fl.Margin = new Thickness(2);
                fl.Text = item.Name;
                fl.Padding = new Thickness(5);
                fl.Tag = item.Name.ToLower();
                fl.Cursor = Cursors.Hand;
                fl.MouseDown += Fl_MouseDown;
                pnlFiltersList.Children.Add(fl);
            }
        }

        private void Fl_MouseDown(object sender, MouseButtonEventArgs e)
        {
            TextBlock b = sender as TextBlock;
            if (b != null && b.Tag != null)
            {
                if (sourceBtm == null)
                {
                    OpenFileDialog dlg = new OpenFileDialog();
                    dlg.Title = "Select Image (.jpg | .png)";
                    var res = dlg.ShowDialog();
                    if (res == true)
                    {
                        sourceImagePath = dlg.FileName;
                        sourceBtm = new Bitmap(sourceImagePath);
                        imgSource.Source = UIHelper.BitmapFromUri(new Uri(sourceImagePath));
                    }
                }

                if (sourceBtm != null)
                {
                    currentFilter = b.Tag.ToString().ToLower();
                    currentResult = pNet.Process(sourceBtm, currentFilter);
                    imgResult.Source = UIHelper.ToWpfBitmap(currentResult);
                }
            }
        }
        private void btnBrowse_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Title = "Select Image (.jpg | .png)";
            var res = dlg.ShowDialog();
            if (res == true)
            {
                sourceImagePath = dlg.FileName;
                sourceBtm = new Bitmap(sourceImagePath);
                imgSource.Source = UIHelper.BitmapFromUri(new Uri(sourceImagePath));
            }
        }

        private async void btnSaveFilter_Click(object sender, RoutedEventArgs e)
        {
            string exportPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"exports");
            if(!Directory.Exists(exportPath))
            {
                Directory.CreateDirectory(exportPath);
            }
            string targetPath = Path.Combine(exportPath, currentFilter + ".jpg");
            if (currentResult != null)
            {
                currentResult.Save(targetPath, System.Drawing.Imaging.ImageFormat.Jpeg);
                lblMsg.Content = "Image saved";
                await Task.Delay(3000);
                lblMsg.Content = "";
            }
        }
    }
}
