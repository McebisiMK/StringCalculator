using System;
using System.Collections.Generic;
using System.Linq;
using StringCalculator_Library.Exceptions;
using StringCalculator_Library.IValidations;
using System.Globalization;

namespace StringCalculator_Library.Validations
{
    public class Validator : IValidator
    {
        public IEnumerable<double> Validate(IEnumerable<string> stringNumbers)
        {
            var numbers = ConvertToNumber(stringNumbers);
            if (!numbers.Any())
                throw new InvalidInputException();

            var negatives = numbers.Where(number => number < 0).ToList();

            return negatives.Any() ?
                        throw new NegativeNumberException(negatives) : numbers;
        }

        private List<double> ConvertToNumber(IEnumerable<string> stringNumbers)
        {
            return stringNumbers
                    .Select(number => Double.Parse(number, CultureInfo.InvariantCulture))
                    .ToList();
        }
    }
}