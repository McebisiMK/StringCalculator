using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using StringCalculator_Library.Exceptions;
using StringCalculator_Library.IValidations;

namespace StringCalculator_Library
{
    public class StringCalculator : IStringCalculator
    {
        private readonly IValidator _validator;

        public StringCalculator(IValidator validator)
        {
            _validator = validator;
        }

        public double Add(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                throw new InvalidInputException();

            var stringNumbers = SplitNumbers(input);
            var numbers = _validator.Validate(stringNumbers);

            return numbers
                    .Where(number => number <= 1000)
                    .Sum();
        }

        private List<string> SplitNumbers(string input)
        {
            var stringNumbers = Regex.Matches(input, @"-?[0-9]*\.?[0-9]+");

            return stringNumbers
                    .Cast<Match>()
                    .Select(match => match.Value)
                    .ToList();
        }
    }
}