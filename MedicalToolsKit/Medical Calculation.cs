using System;

namespace MedicalToolsKit
{
    public class MedCalc
    {
        private static float BodyMassIndexCalc(float wieght, float hight)
        {

            return wieght / (hight * hight);
        }
    }
    public class MedicCalcException : Exception
    {

    }
}
