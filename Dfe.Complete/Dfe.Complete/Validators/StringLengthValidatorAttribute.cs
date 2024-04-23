using System.ComponentModel.DataAnnotations;

namespace Dfe.Complete.Models;

public class StringLengthValidatorAttribute : ValidationAttribute
{
    private readonly int _maxLength;

    public StringLengthValidatorAttribute(int maxLength)
    {
        _maxLength = maxLength;
    }

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value is null)
            return ValidationResult.Success;

        var valueAsString = (string)value;
        
        return valueAsString.Trim().Length > _maxLength ? new ValidationResult(ErrorMessage) : ValidationResult.Success;
    }
}