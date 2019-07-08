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

namespace MedicTools.UI.Controls.LabelTextBox
{
    /// <summary>
    /// Логика взаимодействия для LabeltextBox.xaml
    /// </summary>
    public partial class LabeltextBox : UserControl
    {
        Binding binding = null;
        public LabeltextBox()
        {
            InitializeComponent();

        }
        public LabeltextBox(double min_value, double max_value) : base()
        {
            ControlMinValue = min_value;
            ControlMaxValue = max_value;
        }
        public double ControlMinValue
        {
            get { return (double)GetValue(ControlMinValueProperty); }
            set { SetValue(ControlMinValueProperty, value); }
        }

        public static readonly DependencyProperty ControlMinValueProperty =
            DependencyProperty.Register("ControlMinValue", typeof(double), typeof(LabeltextBox), new PropertyMetadata(default(double)));

        public double ControlMaxValue
        {
            get { return (double)GetValue(ControlMaxValueProperty); }
            set { SetValue(ControlMaxValueProperty, value); }
        }

        public static readonly DependencyProperty ControlMaxValueProperty =
            DependencyProperty.Register("ControlMaxValue", typeof(double), typeof(LabeltextBox), new PropertyMetadata(default(double)));

        public string ControlText
        {
            get { return (string)GetValue(ControlTextProperty); }
            set { SetValue(ControlTextProperty, value); }
        }

        public static readonly DependencyProperty ControlTextProperty =
            DependencyProperty.Register("ControlText", typeof(string), typeof(LabeltextBox), new PropertyMetadata(string.Empty));

        public double ControlValue
        {
            get { return (double)GetValue(ControlValueProperty); }
            set { SetValue(ControlValueProperty, value); }
        }

        public static readonly DependencyProperty ControlValueProperty =
            DependencyProperty.Register("ControlValue", typeof(double), typeof(LabeltextBox), new PropertyMetadata(default(double)));

        private bool EvaluateLimitCondition(double min_value, double max_value)
        {
            if (min_value > max_value) return false;
            else if (min_value == max_value) return false;
            else if (double.IsNaN(min_value) && double.IsNaN(max_value)) return false;
            else return true;
        }

        public bool IsLimitsConditions => EvaluateLimitCondition(ControlMinValue, ControlMaxValue);

        private bool EvaluateParametersCondition(double param)
        {
            if (param < ControlMinValue && param > ControlMaxValue) return false;
            else return true;
        }

        public bool IsParametersCondition => EvaluateParametersCondition(ControlValue);
        
    }

   
}
