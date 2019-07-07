using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Medic.Tools.Kit.UI.Controls.WatermarkTextBoxEx
{
}
namespace Medic.Tools.Kit.Utility
{
    [TypeConverter(typeof(LimitsConverter))]
    public struct Limits<T> where T : struct
    {
        public static readonly Limits<T> Empty; 
        static Limits()
        {
            Empty = new Limits<T>(new T(), new T());
            IsEmpty = true;
        }
        public Limits(T min_value, T max_value) : this()
        {
            
            min = min_value;
            max = max_value;
            try
            {
                if (IsError()) IsEmpty = true;
            }
            catch(LimitsErrorException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                IsEmpty = false;
            }
        }
        private T min;
        private T max;
        public static bool IsEmpty;
        public T Max { get => max; set => max = value; }
        public T Min { get => min; set => min = value; }

        private bool IsError(bool isGenerateException = false)
        {
            bool result;
            var a = Convert.ToDouble(min);
            var b = Convert.ToDouble(max);
            if (!isGenerateException)
            {
                if (a > b) result = true;
                else if (a == b) result = true;
                else if (a == double.NaN) result = true;
                else if (b == double.NaN) result = true;
                else result = false;
            }
           
            else if(isGenerateException)
            {
                if (a > b)
                {
                    throw new LimitsErrorException(@"Ошибка лимитов: минимальное значение больше максимального.");
                }
                else if (a == b)
                {
                    throw new LimitsErrorException(@"Ошибка лимитов: минимальное значение равно максимальному.");
                }
                else if (a == double.NaN)
                {
                    throw new LimitsErrorException(@"Ошибка лимитов: минимальное значение равно NAN.");
                }
                else if (b == double.NaN)
                {
                    throw new LimitsErrorException(@"Ошибка лимитов: Максимальное значение равно NAN.");
                }
                else result = false;
            }
            else result = false;
            return result;
        }
        
    }

    
    public class LimitsConverter : TypeConverter
    {
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {

            Limits<double> limits;
            string[] parms = ((string)value).Split(',');
            var min = Convert.ToDouble(parms[0]);
            var max = Convert.ToDouble(parms[1]);
            limits = new Limits<double>(min, max);
            return limits;
        }
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return sourceType == typeof(String);
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            
            return base.ConvertTo(context, culture, value, destinationType);
        }
    }
    
}
