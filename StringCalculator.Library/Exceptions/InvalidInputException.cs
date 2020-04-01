using System;

namespace StringCalculator_Library.Exceptions
{
    public class InvalidInputException : Exception
    {
        static string message = "Given input does not contain any number!!";
        public InvalidInputException() : base(message)
        {
        }
    }
}