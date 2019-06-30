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

namespace Medic.Tools.Kit.UI.Controls.WatermarkTextBox
{
    /// <summary>
    /// Логика взаимодействия для WatermarkTextBox.xaml
    /// </summary>
    public partial class WatermarkTextBox : UserControl
    {
        public WatermarkTextBox()
        {
            InitializeComponent();
            //Binding binding = new Binding();
            //binding.ElementName = "WatermarkTextBox";
            //binding.Path = new PropertyPath("WatermarkTextColor");
            //WMTextBl.SetBinding(TextBlock.ForegroundProperty, binding);

        }



        public string WatermarkText
        {
            get { return (string)GetValue(WatermarkTextProperty); }
            set { SetValue(WatermarkTextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for WatermarkText.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty WatermarkTextProperty =
            DependencyProperty.Register("WatermarkText", typeof(string), typeof(WatermarkTextBox), new PropertyMetadata(String.Empty));




        public Brush WatermarkTextColor
        {
            get { return (Brush)GetValue(WatermarkTextColorProperty); }
            set { SetValue(WatermarkTextColorProperty, value); }
        }

        // Using a DependencyProperty as the backing store for WatermarkTextColor.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty WatermarkTextColorProperty =
            DependencyProperty.Register("WatermarkTextColor", typeof(Brush), typeof(WatermarkTextBox), new FrameworkPropertyMetadata((object)null, new PropertyChangedCallback(OnWatermarkTextColorChanged)));

        private static void OnWatermarkTextColorChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            UserControl userControl = (UserControl)d;
            userControl.Foreground = (Brush)e.NewValue;
            //throw new NotImplementedException();
        }

        private void WMTextBl_GotFocus(object sender, RoutedEventArgs e)
        {
            WMTextBl.Visibility = Visibility.Hidden;
        }

        private void Grid_LostFocus(object sender, RoutedEventArgs e)
        {
            if(WMTextBx.Text.Length >0 ) WMTextBl.Visibility = Visibility.Hidden;
            else WMTextBl.Visibility = Visibility.Visible;
        }
    }
}
