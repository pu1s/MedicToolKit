using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;

namespace Medic.Tools.Kit.UI.Controls.WatermarkTextBox
{

    public partial class WatermarkTextBox : UserControl
    {

        public string WatermarkText
        {
            get { return (string)GetValue(WatermarkTextProperty); }
            set { SetValue(WatermarkTextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for WatermarkText.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty WatermarkTextProperty =
            DependencyProperty.Register("WatermarkText", typeof(string), typeof(WatermarkTextBox), new PropertyMetadata(String.Empty));


        public bool IsAdornerVizible { get; set; }
        public Limits Limits { get => limits; set => limits = value; }

        private AdornerLayer adornerLayer = null;
        private WatermarkTextBoxAdorner myAdorner = null;
        private AdornerDecorator adornerDecorator = null;
        private Limits limits;

        public class WatermarkTextBoxAdorner : Adorner
        {
            private string watermarkText;
            public WatermarkTextBoxAdorner(UIElement adornedElement) : base(adornedElement)
            {
            }

            public string WatermarkText { get => watermarkText; set => watermarkText = value; }

            protected override void OnRender(DrawingContext drawingContext)
            {
                base.OnRender(drawingContext);
                drawingContext.DrawText(new FormattedText("WatermarkText", CultureInfo.CurrentCulture, FlowDirection.LeftToRight, new Typeface("Arial"), 14.0, Brushes.Red, VisualTreeHelper.GetDpi(this).PixelsPerDip), new Point(2, 2));
            }
        }
        public WatermarkTextBox()
        {
            InitializeComponent();
            adornerDecorator = new AdornerDecorator
            {
                DataContext = new TextBox()
            };
            this.GotFocus += WatermarkTextBox_GotFocus;
            this.LostFocus += WatermarkTextBox_LostFocus;
            this.KeyUp += WatermarkTextBox_KeyUp;
            IsAdornerVizible = (PART_TextBox.Text.Length > 0) ? true : false;
            adornerLayer = AdornerLayer.GetAdornerLayer(PART_TextBox);
            myAdorner = new WatermarkTextBoxAdorner(this.PART_TextBox);
            myAdorner.WatermarkText = WatermarkText;
            UpdateAdorner();

        }

        private void WatermarkTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                VereficationData(this.PART_TextBox.Text, Limits, true);
            }
        }

        private void VereficationData(string text, Limits limits, bool v)
        {

        }

        private void WatermarkTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (PART_TextBox.Text.Length > 0)
            {
                IsAdornerVizible = false;
            }
            else
            {
                IsAdornerVizible = true;
            }
            UpdateAdorner();
        }

        private void WatermarkTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            IsAdornerVizible = false;
            UpdateAdorner();
        }

        private void UpdateAdorner()
        {

            if (IsAdornerVizible)
            {
                adornerLayer.Add(myAdorner);
            }
            else
            {
                adornerLayer.Remove(myAdorner);
            }
        }
    }
}
