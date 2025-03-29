using System;

namespace Cwiczenia2.Inheritance
{
    public class OverfillException : Exception
    {
        public OverfillException(string message) : base(message)
        {
        }
    }
}