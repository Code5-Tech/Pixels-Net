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

        private int _number;

        public int currentValue
        {
            get { return _number; }
            set { _number = value;
                try
                {
                    tbxNumber.Text = _number.ToString("0");
                }
                catch (Exception)
                {

                }
            }
        }

        bool isTouched = false;
        private void tbxNumber_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(tbxNumber.IsFocused && isTouched)
            {
                isTouched = false;
                   currentValue++;
                OnTextChange?.Invoke(currentValue, null);
            }
        }

        private void tbxNumber_KeyUp(object sender, KeyEventArgs e)
        {
            isTouched = false;
            if (e.Key == Key.Up)
            {
                currentValue++;
            }
            else if (e.Key == Key.Down)
            {
                currentValue--;
            }
            OnTextChange?.Invoke(currentValue, null);
        }

        private void btnUp_Click(object sender, RoutedEventArgs e)
        {
            isTouched = false;
            currentValue++;
            OnTextChange?.Invoke(currentValue, null);
        }

        private void btnDown_Click(object sender, RoutedEventArgs e)
        {
            isTouched = false;
            currentValue--;
            OnTextChange?.Invoke(currentValue, null);
        }
    }
}
