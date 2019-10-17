using System;
using System.Collections.Generic;

namespace MedicalToolsKit
{
    public class MedCalc
    {
        private static float BodyMassIndexCalc(float wieght, float hight)
        {
            if (wieght == 0 || hight == 0) throw new MedicCalcException(@"Argument is null!");
            return wieght / (hight * hight);
        }

    }

    public class MedCalcHelpers
    {

    }

    public struct MedCalcArgsLimit<T>
    {
        private T _lower;
        private T _upper;

        public MedCalcArgsLimit(T lower, T upper)
        {
            _lower = lower;
            _upper = upper;
        }

        public T Upper => _upper;
        public T Lower => _lower;
    }

    public struct MedCalcArgsLimitList<T>
    {
        private readonly List<MedCalcArgsLimit<T>> _limitsList;

        public MedCalcArgsLimitList(List<MedCalcArgsLimit<T>> limitsList)
        {
            _limitsList = limitsList ?? throw new ArgumentNullException(nameof(limitsList));
        }

        public List<MedCalcArgsLimit<T>> LimitsList => _limitsList;

        public override string ToString()
        {
			const string LOWER          = "Lower limit: ";
			const string UPPER          = "Upper limit: ";
			const string V_SEP          = "\n\r";
			const string LCOUNT         = "Limits count: ";
			const string H_SEP          = "======================";
			string result               = string.Empty;
            //
            if(_limitsList == null) throw new ArgumentNullException(nameof(_limitsList));
            //
            result += LCOUNT + _limitsList.ToString() + V_SEP;
            //
            result += H_SEP + V_SEP;
            //
            foreach(var item in _limitsList)
            {
                result += LOWER + item.Lower;
                result += UPPER + item.Upper;
                result += V_SEP;
            }
            //
            result += H_SEP + V_SEP;
            return result;
        }
    }

    #region 
    //TODO: Do Not Impl
    public class MedCalcArgsLimit : Exception
    {

    }
    #endregion

    #region Medical Calculator Exception

    public class MedicCalcException : Exception
    {
        public new string Message { get; }

        public MedicCalcException() : base()
        {
            Message = string.Empty;
        }

        public MedicCalcException(string message)
        {
            Message = message;
        }
    }
    #endregion


}
