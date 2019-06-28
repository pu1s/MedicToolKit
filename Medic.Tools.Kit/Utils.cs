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

    #region Basic Utils
    /// <summary>
    /// 
    /// </summary>
    public static class BasicUtils
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="arg"></param>
        /// <param name="limits"></param>
        /// <returns></returns>
        public static bool VerifyArgumentLimits(System.Object arg, Limits limits)
        {
            return (float)arg >= limits.Lower && (float)arg <= limits.Upper ? true : false;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="arg"></param>
        /// <param name="limits"></param>
        /// <param name="callbackAction"></param>
        /// <returns></returns>
        public static bool VerifyArgumentLimits(System.Object arg, Limits limits, Action callbackAction)
        {
            bool result;
            if (!VerifyArgumentLimits(arg, limits))
            {
                result = false;
            }
            else
            {
                callbackAction.Invoke();
                result = true;
            }
            return result;
        }

    }
    #endregion //Basic Utils

    #region Basic Exception
    
    #endregion // Basic Exception
}
