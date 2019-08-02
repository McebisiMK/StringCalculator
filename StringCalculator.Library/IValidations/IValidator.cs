using System.Collections.Generic;

namespace StringCalculator_Library.IValidations
{
    public interface IValidator
    {
        IEnumerable<double> Validate(IEnumerable<string> numbers);
    }
}