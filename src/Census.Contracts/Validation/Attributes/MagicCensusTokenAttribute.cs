using System.ComponentModel.DataAnnotations;

namespace Census.Contracts.Validation.Attributes
{
    public sealed class MagicCensusTokenAttribute : ValidationAttribute
    {
        private static readonly AccessCodeCalculator _accessCodeCalculator = new AccessCodeCalculator();

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (!(value is string accessCode)) return null;

            if (_accessCodeCalculator.IsValid(accessCode)) return null;

            return new ValidationResult("Access code is not valid.");
        }
    }
}