using System.ComponentModel.DataAnnotations;

namespace MAS5.Models.CustomValidators.User
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public class CustomStringLength : ValidationAttribute
    {
        private readonly int _minimumLength;
        private readonly int _maximumLength;

        public CustomStringLength(int minimumLength, int maximumLength)
        {
            _minimumLength = minimumLength;
            _maximumLength = maximumLength;
        }

        protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return ValidationResult.Success!;
            }

            if (value is string strValue)
            {
                if (strValue.Length < _minimumLength || strValue.Length > _maximumLength)
                {
                    return new ValidationResult(ErrorMessage);
                }
            }

            return ValidationResult.Success!;
        }
    }
}
