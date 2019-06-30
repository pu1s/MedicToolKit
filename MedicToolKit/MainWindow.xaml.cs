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

namespace MedicToolKit
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //private string _WindowTitle { get => "Медицинский калькулятор"};
        //private MTK.Limits limits;

        public MainWindow()
        {

            InitializeComponent();
            //limits = new MTK.Limits(1.0d, 1.2d);
            //var s = limits.Range;
            //var t = 1.1f;
            //var p = MTK.BasicUtils.VerifyArgumentLimits(t, limits);
        }
    }
}
