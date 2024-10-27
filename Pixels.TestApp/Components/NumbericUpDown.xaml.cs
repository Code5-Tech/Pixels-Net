using System;
using System.Collections.Generic;
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

namespace Pixels.TestApp.Components
{
    /// <summary>
    /// Interaction logic for NumbericUpDown.xaml
    /// </summary>
    public partial class NumbericUpDown : UserControl
    {
        public NumbericUpDown()
        {
            InitializeComponent();
        }
        public event EventHandler OnTextChange;

        private int _number=0;

        public int currentValue
        {
            get { return _number; }
            set { 
                _number = value;
                try
                {
                    tbxNumber.Text = _number.ToString("0");
                    sldrValue.Value = currentValue;
                }
                catch (Exception)
                {
                }
            }
        }

        bool isTouched = false;
        private void tbxNumber_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void tbxNumber_KeyUp(object sender, KeyEventArgs e)
        {
            if (isTouched)
            {
                int cc = 0;
                int.TryParse(tbxNumber.Text, out cc);
                currentValue = cc;
                sldrValue.Value = currentValue;
                isTouched= false;
            }

        }

        private void sldrValue_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            currentValue = (int)sldrValue.Value;
            tbxNumber.Text = currentValue.ToString();
            OnTextChange?.Invoke(currentValue, null);
            //OnTextChange?.Invoke(currentValue, null);
        }

        private void tbxNumber_GotFocus(object sender, RoutedEventArgs e)
        {
            isTouched = true;
        }
    }
}
