using System.ComponentModel.DataAnnotations;

namespace Dfe.Complete.Models
{
	public class SupportGrantValidatorAttribute : ValidationAttribute
	{
		protected override ValidationResult IsValid(object value, ValidationContext validationContext)
		{ 
			var reason = value as string;

			if (string.IsNullOrWhiteSpace(reason))
			{
				if (true)
				{
					return new ValidationResult("Give a reason why you have changed the support grant amount");
				}
			}
			return ValidationResult.Success;
		}
	}
}
