using System;
using System.Runtime.Serialization;

namespace POO_NumarComplex
{
    [Serializable]
    internal class DenominatorIsZero : Exception
    {
        private int real;
        private double real1;

        public DenominatorIsZero()
        {
        }

        public DenominatorIsZero(int real)
        {
            this.real = real;
        }

        public DenominatorIsZero(string message) : base(message)
        {
        }

        public DenominatorIsZero(double real1)
        {
            this.real1 = real1;
        }

        public DenominatorIsZero(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected DenominatorIsZero(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}