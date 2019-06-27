using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedicTools = Medic.Tools.Library;

namespace Medic.Tools.Library
{
    public struct Limits<T>
    {
        public T LowerLimit { get; private set; }
        public T UpperLimit { get; private set; }
        public void Create(T lowerLimit, T upperLimit)
        {
            LowerLimit = lowerLimit;
            UpperLimit = upperLimit;
        }
           
    }
    
    public static class MedicUtils
    {
        /// <summary>
        /// Расчет индекса массы тела
        /// </summary>
        /// <remarks>Формула расчета ИМТ по Кегле: Масса тела (кг) разделить на Рост (м) в квадрате</remarks>
        /// <param name="PatientHeight">Рост пациента в см</param>
        /// <param name="PatientWeight">Вес пациента в кг</param>
        /// <returns>Индекс массы тела</returns>
        public static double BodyMassIndexCalc(ref double PatientHeight, ref double PatientWeight)
        {
            return Convert.ToDouble(PatientWeight / Math.Pow(PatientHeight, 2));
        }

    }
}
