using System;
using System.Collections.Generic;

namespace MedicalToolsKit
{
    public interface ITrueArgument { }

    public interface IUniqueKey<KeyType>
    {
        bool IsUnique(ArgumentLimitDictionary<KeyType> dic);
    }

    public class ArgumentLimitDictionary<T> : ITrueArgument, IUniqueKey<string>
    { 
        private Dictionary<string, ArgumentLimit<T>> keyValues;

        public ArgumentLimitDictionary()
        { 
            keyValues = new Dictionary<string, ArgumentLimit<T>>();
        }
        public ArgumentLimitDictionary(string key, T lowerValue, T upperValue) :this()
        {
            keyValues.Add(key, new ArgumentLimit<T>(lowerValue, upperValue));
        }

        public void Add(ArgumentLimitDictionary<T> dic)
        {
            keyValues = dic.keyValues;
        }
        public void Add(string key, T lowerValue, T upperValue)
        {
            keyValues.Add(key, new ArgumentLimit<T>(lowerValue, upperValue));
        }

        public bool IsUnique(ArgumentLimitDictionary<string> dic)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            const string LOWER = "Lower limit: ";
            const string UPPER = "Upper limit: ";
            const string V_SEP = "\n\r";
            const string LCOUNT = "Limits count: ";
            const string H_SEP = "======================";
            string result = string.Empty;
            //
            if (keyValues == null) throw new ArgumentNullException(nameof(keyValues));
            //
            result += LCOUNT + keyValues.ToString() + V_SEP;
            //
            result += H_SEP + V_SEP;
            //
            foreach (var item in keyValues)
            {
                result += item.Key.ToString();
                result += LOWER + item.Value.Lower; 
                result += UPPER + item.Value.Upper;
                result += V_SEP;
            }
            //
            result += H_SEP + V_SEP;
            return result;
        }

    }
    
}
