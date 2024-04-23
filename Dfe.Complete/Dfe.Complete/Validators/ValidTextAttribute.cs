using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using Dfe.Complete.Constants;
namespace Dfe.Complete.Validators;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter,
    AllowMultiple = false)]
public class ValidTextAttribute : ValidationAttribute
{
    private const string AllowSpecialCharactersPattern = @"[^a-zA-Z0-9'(),\s]";
    private readonly int _maxLength;

    public ValidTextAttribute(int maxLength)
    {
        _maxLength = maxLength;
    }

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value is null)
            return ValidationResult.Success;
        
        var valueAsString = (string) value;

        if(valueAsString.Length > _maxLength)
            return new ValidationResult(string.Format(ValidationConstants.TextValidationMessage, validationContext.DisplayName.ToLower(), _maxLength));

        var specialCharactersRegex = new Regex(AllowSpecialCharactersPattern, RegexOptions.None, TimeSpan.FromSeconds(30));
        var match = specialCharactersRegex.Match(valueAsString);
        
        return match.Success
            ? new ValidationResult($"{validationContext.DisplayName} must not include special characters other than , ( ) '")
            : ValidationResult.Success; 
    }
}