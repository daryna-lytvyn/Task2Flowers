using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Task2Flowers.Exceptions
{
    public class ValidationResultsException : ValidationException
    {
        public IReadOnlyCollection<ValidationResult> ValidationResults { get; }
        public ValidationResultsException(List<ValidationResult> validationResults) : base()
        {
            ValidationResults = validationResults;
        }
    }

}
