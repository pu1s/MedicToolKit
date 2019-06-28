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
using MTK = Medic.Tools.Kit;
namespace MedicToolKit
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {


        public int WinTitle
        {
            get { return (int)GetValue(WinTitleProperty); }
            set { SetValue(WinTitleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for WinTitle.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty WinTitleProperty =
            DependencyProperty.Register("WinTitle", typeof(int), typeof(MainWindow), new PropertyMetadata(0));


        //private string _WindowTitle { get => "Медицинский калькулятор"};
        private MTK.Limits limits;

        public MainWindow()
        {

            InitializeComponent();
            limits = new MTK.Limits(1.0d, 1.2d);
            var s = limits.Range;
            var t = 1.1f;
            var p = MTK.BasicUtils.VerifyArgumentLimits(t, limits);
        }
    }
}
