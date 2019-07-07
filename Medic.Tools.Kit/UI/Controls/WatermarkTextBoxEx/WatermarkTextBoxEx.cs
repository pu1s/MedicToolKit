using System;
using System.Windows;
using System.Windows.Controls;

namespace Medic.Tools.Kit.UI.Controls.WatermarkTextBoxEx
{
    /// <summary>
    /// Логика взаимодействия для WatermarkTextBoxEx.xaml
    /// </summary>
    public partial class WatermarkTextBoxEx : UserControl
    {
        public WatermarkTextBoxEx()
        {
            InitializeComponent();
        }



        public Medic.Tools.Kit.Utility.Limits<double> Limits
        {
            get { return (Medic.Tools.Kit.Utility.Limits<double>)GetValue(LimitsProperty); }
            set { SetValue(LimitsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Limits.  This enables animation, styling, binding, etc...
        public static readonly System.Windows.DependencyProperty LimitsProperty =
            DependencyProperty.Register("Limits", typeof(Medic.Tools.Kit.Utility.Limits<double>), typeof(WatermarkTextBoxEx), new PropertyMetadata(new Medic.Tools.Kit.Utility.Limits<double>(0.0, 0.0)));



        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value);  }
        }

        
        // Using a DependencyProperty as the backing store for Text.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(WatermarkTextBoxEx), new PropertyMetadata(string.Empty));



        public string LabelText
        {
            get { return (string)GetValue(LabelTextProperty); }
            set { SetValue(LabelTextProperty, value);  }
        }

        // Using a DependencyProperty as the backing store for LabelText.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LabelTextProperty =
            DependencyProperty.Register("LabelText", typeof(string), typeof(WatermarkTextBoxEx), new PropertyMetadata(string.Empty));



        public string CommentText
        {
            get { return (string)GetValue(CommentTextProperty); }
            set { SetValue(CommentTextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CommentText.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CommentTextProperty =
            DependencyProperty.Register("CommentText", typeof(string), typeof(WatermarkTextBoxEx), new PropertyMetadata(string.Empty));


        public void TextUpdate()
        {
            PART_TexBox.Text = this.Text;
            PART_Label.Text = this.LabelText;
            PART_Comments.Text = this.CommentText;
        }
        
    }
}
