using Dfe.Complete.Constants;
using System;
using System.ComponentModel.DataAnnotations;

namespace Dfe.Complete.Validators
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter,
        AllowMultiple = false)]
    public class ValidMoneyAttribute : ValidationAttribute
    {
        private readonly int _minValue;
        private readonly int _maxValue;

        public ValidMoneyAttribute(int minValue, int maxValue)
        {
            _minValue = minValue;
            _maxValue = maxValue;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is null)
                return ValidationResult.Success;

            var valueAsDec = (decimal)value;

            if (valueAsDec < _minValue || valueAsDec > _maxValue)
                return new ValidationResult(string.Format(ValidationConstants.NumberValidationMessage, validationContext.DisplayName, _minValue, _maxValue));

            if (Math.Round(valueAsDec, 2) != valueAsDec)
            {
                return new ValidationResult($"{validationContext.DisplayName} must be two decimal places");
            }

            return ValidationResult.Success;
        }
    }
}
