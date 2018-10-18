using System;
using System.ComponentModel.DataAnnotations;

namespace Census.Contracts.Validation.Attributes
{
    public class NotEmpty : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var guid = (Guid?) value;

            if (!guid.HasValue) return new ValidationResult("A value is required.");
            if (guid.Value == Guid.Empty) return new ValidationResult("A non-default value is required.");
            return null;
        }
    }
}