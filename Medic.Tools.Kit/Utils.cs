using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medic.Tools.Kit
{
    #region Limits
    public struct Limits    
    {
        private float _lower;
        private float _upper;

        public float Lower
        {
            get
            {
                return _lower;
            }
        }

        public float Upper
        {
            get
            {
                return _upper;
            }
        }
        public float Range
        {
            get
            {
                return _upper - _lower;
            }
        }
        public Limits(float lower, float upper)
        {
            _lower = lower;
            _upper = upper;
        }
        public Limits(int lower, int upper)
        {
            _lower = (float)lower;
            _upper = (float)upper;
        }
        public Limits(double lower, double upper)
        {
            _lower = (float)lower;
            _upper = (float)upper;
        }
    }
    #endregion //Limits

    public static class BasicUtils
    {
        public static bool VerifyArgumentLimits(System.Object arg, Limits limits)
        {
            //return (float)arg > limits.Lower && (float)arg < limits.Upper ? true : false;
        }
    }
}
