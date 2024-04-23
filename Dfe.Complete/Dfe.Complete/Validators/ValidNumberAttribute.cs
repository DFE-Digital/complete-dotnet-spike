using System;
using System.ComponentModel.DataAnnotations;
using Dfe.Complete.Constants;

namespace Dfe.Complete.Models;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter,
    AllowMultiple = false)]
public class ValidNumberAttribute : ValidationAttribute
{
    private readonly int _minValue;
    private readonly int _maxValue;

    public ValidNumberAttribute(int minValue, int maxValue)
    {
        _minValue = minValue;
        _maxValue = maxValue;
    }

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value is null)
            return ValidationResult.Success;

        var valueAsString = (string)value;

        if (string.IsNullOrWhiteSpace(valueAsString))
            return ValidationResult.Success;

        bool success = int.TryParse(valueAsString, out int valueAsInt);

        if (!success)
            return new ValidationResult($"{validationContext.DisplayName} must be a number, like 30");

        if (valueAsInt < _minValue || valueAsInt > _maxValue)
            return new ValidationResult(string.Format(ValidationConstants.NumberValidationMessage, validationContext.DisplayName, _minValue, _maxValue));

        return ValidationResult.Success;
    }
}