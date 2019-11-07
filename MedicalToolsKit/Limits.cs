using System;
using System.Collections.Generic;


namespace MedicalToolsKit
{
   public struct Limit
    { 
        public float Lower { get; set; }
        public float Upper { get; set; }
    }

    //public struct Limit<T> 
    //{
    //    public T Lower { get; set; }
    //    public T Upper { get; set; }
    //}

    public class LimitsDictionary
    {
        private readonly Dictionary<string, Limit> Limits;

        private LimitsDictionary()
        {
            Limits = new Dictionary<string, Limit>();
        }
        public LimitsDictionary(string keyName, float lower, float upper) :this()
        {
            if (string.IsNullOrEmpty(keyName)) throw new LimitsDictionaryException(LimitsDictionaryException.ERROR_KEY_IS_EMPTY);
            if (lower > upper) throw new LimitsDictionaryException(LimitsDictionaryException.ERROR_LVAL_GR_UVAL);
            Limit lim = CreateNewLimit(lower, upper);
            Add(keyName, lim);
        }

        internal static Limit CreateNewLimit(float lower, float upper)
        {
            return new Limit
            {
                Lower = lower,
                Upper = upper
            };
        }

        internal void Add(string keyName, Limit lim)
        {
            Limits.Add(keyName, lim);
        }
    }

    public class LimitsDictionaryException : Exception
    {
        public const string ERROR_KEY_IS_EMPTY = @"Key name is empty!";
        public const string ERROR_LVAL_GR_UVAL = @"Lower value cannot be greater than upper value!";
        private readonly string _message;

        public new string Message => _message;

        private LimitsDictionaryException()
        {
            _message = string.Empty;
        }

        public LimitsDictionaryException(string message) : base(message)
        {
            _message = message;
        }
    }


    //public class LimitsDictionary<T>
    //{
    //    private Dictionary<string, Limit<T>> Limits;

    //    private LimitsDictionary()
    //    {
    //        Limits = new Dictionary<string, Limit<T>>();
    //    }
    //    public LimitsDictionary(string keyName, T lower, T upper) : this()
    //    {

    //        Limit<T> lim = new Limit<T>
    //        {
    //            Lower = lower,
    //            Upper = upper
    //        };
    //        Limits.Add(keyName, lim);
    //    }
    //}
}
