using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medic.Tools.Kit
{
    public struct Limits    
    {
        private double _lower;
        private double _upper;

        public double Lower
        {
            get
            {
                return _lower;
            }
        }

        public double Upper
        {
            get
            {
                return _upper;
            }
        }
        public double Range
        {
            get
            {
                return _upper - _lower;
            }
        }
        public Limits(double lower, double upper)
        {
            _lower = lower;
            _upper = upper;
        }
        public Limits(int lower, int upper)
        {
            _lower = (double)lower;
            _upper = (double)upper;
        }
        public Limits(float lower, float upper)
        {
            _lower = (double)lower;
            _upper = (double)upper;
        }
    }
}
