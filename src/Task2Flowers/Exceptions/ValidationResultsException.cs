using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Task2Flowers.Exceptions
{
    public class ValidationResultsException : ValidationException
    {
        public IReadOnlyCollection<ValidationResult> ValidationResults { get; }
        public ValidationResultsException(IEnumerable<ValidationResult> validationResults) : base()
        {
            ValidationResults = validationResults.ToList();
        }
    }

}
