using System;

namespace MedicalToolsKit
{
    public class Limits<T>
    {
        private T _lower;
        private T _upper;

        private Limits()
        {
            _lower = default;
            _upper = default;
        }

        public Limits(T lower, T upper)
        {
            _lower = lower;
            _upper = upper;
        }

        public bool IsTryLimits { get; }
        public class LimitsRangeOutException : Exception
        {
            public LimitsRangeOutException(string message) : base(message)
            {
            }
        }
    }
}
