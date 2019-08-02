using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using StringCalculator_Library.Exceptions;
using StringCalculator_Library.IValidations;
using StringCalculator_Library.Validations;

namespace StringCalculator_Library
{
    public class StringCalculator
    {
        private readonly IValidator _validator;

        public StringCalculator() : this(new Validator())
        {
        }

        public StringCalculator(IValidator validator)
        {
            _validator = validator;
        }

        public double Add(string input)
        {
                if (string.IsNullOrWhiteSpace(input))
                    throw new InvalidInputException();

                var stringNumbers = GetNumbers(input);  
                var numbers = _validator.Validate(stringNumbers);

                return numbers.Sum();
        }

        private IEnumerable<string> GetNumbers(string input)
        {
            var regexNumbers = Regex.Matches(input, @"-?[0-9]*\.?[0-9]+");

            return regexNumbers.Cast<Match>().Select(match => match.Value) ;
        }
    }
}