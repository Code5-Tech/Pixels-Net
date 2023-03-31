using Microsoft.Win32;
using Pixels.Core;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Pixels.TestApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        PixelNet pNet = new PixelNet();
        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            var filtersList = pNet.GetFilters().OrderBy(x=>x.Category).ToList();
            string category = "";
            foreach (var item in filtersList)
            {
                if(category!=item.Category)
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
            if (b!=null && b.Tag != null)
            {
                if(sourceBtm==null)
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
                currentFilter = b.Tag.ToString();
                applyFilter(currentFilter);
            }
        }

        void applyFilter(string filterName)
        {

            if (sourceBtm != null)
            {
                filterName = filterName.ToLower();
                pNet.parameters = new List<int>();
                pNet.parameters = paras;
                var result = pNet.Process(sourceBtm, filterName);
                imgResult.Source = UIHelper.ToWpfBitmap(result);
            }
        }

        string sourceImagePath;
        Bitmap sourceBtm = null;
        string currentFilter = "";
        List<int> paras = new List<int>();
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

        private void para1_OnTextChange(object sender, EventArgs e)
        {
            UpdateParameters();
            applyFilter(currentFilter);
        }

        private void para2_OnTextChange(object sender, EventArgs e)
        {
            UpdateParameters();
            applyFilter(currentFilter);
        }

        private void para3_OnTextChange(object sender, EventArgs e)
        {
            UpdateParameters();
            applyFilter(currentFilter);
        }

        void UpdateParameters()
        {
            paras = new List<int>();
            paras.Add(para1.currentValue);
            paras.Add(para2.currentValue);
            paras.Add(para3.currentValue);
        }
    }
}
