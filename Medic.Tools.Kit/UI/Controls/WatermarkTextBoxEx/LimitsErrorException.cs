using System;
namespace Medic.Tools.Kit.Utility
{
    public class LimitsErrorException : Exception
    {
        private LimitsErrorException()
        {
        }

        public LimitsErrorException(string message) : base(message)
        {
        }

        private string message;

        public new string Message { get => message; private set => message = value; }
    }

}
