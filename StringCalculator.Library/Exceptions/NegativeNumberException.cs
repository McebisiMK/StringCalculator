using System;
using System.Collections.Generic;

namespace StringCalculator_Library.Exceptions
{
    public class NegativeNumberException : Exception
    {
        static string message = $"Negative numbers are not allowed:";
        public NegativeNumberException(IEnumerable<double> negatives):base($"{message} ({string.Join(", " , negatives)})")
        {
        }
    }
}