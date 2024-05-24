﻿using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Dfe.Complete.Validators
{
    public class SharePointLinkAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            // Fetch the display name if it is provided
            var property = validationContext.ObjectType.GetProperty(validationContext.MemberName);
            var displayAttribute = property?.GetCustomAttribute<DisplayAttribute>();
            var displayName = displayAttribute?.GetName() ?? validationContext.DisplayName;

            var link = value as string;

            if (string.IsNullOrEmpty(link))
            {
                return ValidationResult.Success;
            }

            if (!link.StartsWith("https://"))
            {
                var errorMessage = $"The {displayName} must have the https scheme";

                return new ValidationResult(errorMessage);
            }

            if (!link.StartsWith("https://educationgovuk.sharepoint.com"))
            {
                var errorMessage = $"Enter {displayName} in the correct format. SharePoint links start with 'https://educationgovuk.sharepoint.com' or 'https://educationgovuk-my.sharepoint.com/'";
                return new ValidationResult(errorMessage);
            }

            // If valid, return success
            return ValidationResult.Success;
        }
    }
}
