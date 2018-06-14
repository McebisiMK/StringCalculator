using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace StringCalculatorKata
{
    public class StringCalculator
    {
        public int Add(string number)
        {
            var result = 0;
            number = number.Trim();

            if (EmptyString(number))
            {
                return 0;
            }

            if (number.Length == 1)
            {
                if (int.Parse(number) > 1000)
                {
                    return 0;
                }
                return int.Parse(number);
            }
            return GetSumOfDelimeteredString(number, result); ;
        }

        private int GetSumOfDelimeteredString(string number, int result)
        {

            var firstTwoCharacters = number.Substring(0, 2);
            if (firstTwoCharacters == "//")
            {
                number = DelimiterIsGiven(number);
            }
            var delimiter = new List<char> { ',', '\n' };
            var numbers = number.Split(delimiter.ToArray());
            HandleExceptions(numbers);
            foreach (var num in numbers)
            {
                if (Int32.Parse(num) > 1000)
                {
                    continue;
                }
                result += Int32.Parse(num);
            }

            return result;
        }

        private string DelimiterIsGiven(string number)
        {
            var numbers = number.Substring(3).Trim();
            var haveDelimeter = number[2].ToString();
            if (haveDelimeter.Equals("["))
            {
                var length = numbers.LastIndexOf("]");
                var delimiters = numbers.Substring(0, length);
                var splittedDelimiters = (delimiters.Replace("][", "/").Trim()).Split('/');
                foreach (var item in splittedDelimiters)
                {
                    number = (number.Substring(number.LastIndexOf("]") + 1).Trim()).Replace(item, ",");
                }
            }
            else
            {
                var delimiter = Char.Parse(number.Substring(2, 1));
                number = numbers.Replace(delimiter, ',');
            }

            return number;
        }

        private static void HandleExceptions(IEnumerable<string> numbers)
        {
            var listOfStringNumbers = new List<string>(numbers);
            var negetiveNumbers = listOfStringNumbers.Where(number => int.Parse(number) < 0);

            if (negetiveNumbers.Any())
            {
                var negetives = string.Join(" ", negetiveNumbers.ToArray());
                throw new Exception($"Negatives not allowed {negetives}");
            }
        }

        private static bool EmptyString(string number)
        {
            return number.Equals(string.Empty);
        }

    }
}