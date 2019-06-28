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
        private MTK.Limits limits;

        public MainWindow()
        {
            InitializeComponent();
            limits = new MTK.Limits(1.0d, 1.2d);
            var s = limits.Range;
            var t = MTK.BasicUtils.VerifyArgumentLimits(1.1, limits);
        }
    }
}
