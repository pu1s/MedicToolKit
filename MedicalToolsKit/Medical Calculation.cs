using System;

namespace MedicalToolsKit
{
    public class MedCalc
    {
        private static float BodyMassIndexCalc(float wieght, float hight)
        {
            if(wieght == 0 || hight == 0) throw new MedicCalcException(@"Argument is null!");
            return wieght / (hight * hight);
        }

    }

    public class MedCalcHelpers
    {

    }

    public class MedCalcArgsLimits
    {

    }


    #region Medical Calculator Exception

    public class MedicCalcException : Exception
    {
        public new string Message { get; }

        public MedicCalcException() :base()
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
