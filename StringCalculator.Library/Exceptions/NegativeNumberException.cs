using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace StringCalculator_Library.Exceptions
{
    public class NegativeNumberException : Exception
    {
        static string message = $"Negative numbers are not allowed:";
        public NegativeNumberException(IEnumerable<double> negatives)
                : base($"{message} ({string.Join(", ", negatives.Select(number => number.ToString(CultureInfo.CreateSpecificCulture("en-US"))))})")
        {
        }
    }
}