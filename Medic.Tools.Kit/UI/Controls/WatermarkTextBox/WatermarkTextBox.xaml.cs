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

            public WatermarkTextBoxAdorner(UIElement adornedElement, string watermarkAdornerText) : base(adornedElement)
            {
                WatermarkAdornerText = watermarkAdornerText;
            }
            public string WatermarkAdornerText { get => watermarkText; set => watermarkText = value; }

            protected override void OnRender(DrawingContext drawingContext)
            {
                base.OnRender(drawingContext);
                drawingContext.DrawText(new FormattedText(watermarkText, CultureInfo.CurrentCulture, FlowDirection.LeftToRight, new Typeface("Arial"), 14.0, Brushes.Red, VisualTreeHelper.GetDpi(this).PixelsPerDip), new Point(2, 2));
            }
        }
        public WatermarkTextBox()
        {

            InitializeComponent();
           
            GotFocus += WatermarkTextBox_GotFocus;
            LostFocus += WatermarkTextBox_LostFocus;
            KeyUp += WatermarkTextBox_KeyUp;
            IsAdornerVizible = true;
            adornerLayer = AdornerLayer.GetAdornerLayer(PART_TextBox);
            myAdorner = new WatermarkTextBoxAdorner(PART_TextBox)
            {
                WatermarkAdornerText = "Watermark"
            };
            adornerDecorator = new AdornerDecorator();
            
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
            IsAdornerVizible = (PART_TextBox.Text.Length > 0) ? true : false;

            //if (IsAdornerVizible)
            //{
            //    adornerLayer.Add(myAdorner);
            //}
            //else
            //{
            //    adornerLayer.Remove(myAdorner);
            //}
        }
    }
}
