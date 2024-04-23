using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Threading.Tasks;

namespace Dfe.Complete.Models
{
    public class NumberRangeModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            Type modelType = ValidateBindingContext(bindingContext);

            var fromModelName = $"{bindingContext.ModelName}-from";
            var toModelName = $"{bindingContext.ModelName}-to";

            var fromProviderResult = bindingContext.ValueProvider.GetValue(fromModelName);
            var toProviderResult = bindingContext.ValueProvider.GetValue(toModelName);

            if (IsOptionalOrFieldTypeMismatch(bindingContext, fromProviderResult, toProviderResult))
            {
                if (modelType == typeof(string))
                {
                    if (IsEmpty(fromProviderResult, toProviderResult))
                    {
                        bindingContext.Result = ModelBindingResult.Success("");
                    }
                    else
                    {
                        bindingContext.Result = ModelBindingResult.Success(null);
                    }
                }
                else
                {
                    bindingContext.Result = ModelBindingResult.Failed();
                }

                return Task.CompletedTask;
            }

            if(bindingContext.ModelMetadata.IsRequired 
                && IsEmpty(fromProviderResult, toProviderResult))
            {
					bindingContext.Result = ModelBindingResult.Success("");
					return Task.CompletedTask;
			}

            if (FieldsAreValid(bindingContext, fromModelName, toModelName, fromProviderResult, toProviderResult))
            {
                string fromResult = fromProviderResult.FirstValue;
                string toResult = toProviderResult.FirstValue;
                bindingContext.Result = ModelBindingResult.Success($"{fromResult}-{toResult}");
            }

            return Task.CompletedTask;
        }

        private static bool FieldsAreValid(ModelBindingContext bindingContext, string fromModelName, string toModelName, ValueProviderResult fromProviderResult, ValueProviderResult toProviderResult)
        {
            var displayName = bindingContext.ModelMetadata.DisplayName;

            string fromResult = fromProviderResult.FirstValue;
            string toResult = toProviderResult.FirstValue;

            if(bindingContext.ModelMetadata.IsRequired && string.IsNullOrEmpty(fromResult))
            {
				string ErrorMessage = $"Enter a 'from' {displayName.ToLower()}";
				AddError(bindingContext, fromModelName, toModelName, fromProviderResult, toProviderResult, ErrorMessage);
				return false;
			}

			if (bindingContext.ModelMetadata.IsRequired && string.IsNullOrEmpty(toResult))
			{
				string ErrorMessage = $"Enter a 'to' {displayName.ToLower()}";
				AddError(bindingContext, fromModelName, toModelName, fromProviderResult, toProviderResult, ErrorMessage);
				return false;
			}

			if (fromResult.Length > 2)
            {
                string ErrorMessage = $"'From' {displayName.ToLower()} must be 2 characters or less";
                AddError(bindingContext, fromModelName, toModelName, fromProviderResult, toProviderResult, ErrorMessage);
                return false;
            }

			if (toResult.Length > 2)
			{
				string ErrorMessage = $"'To' {displayName.ToLower()} must be 2 characters or less";
				AddError(bindingContext, fromModelName, toModelName, fromProviderResult, toProviderResult, ErrorMessage);
				return false;
			}

			int from;
            int to;

            if (!int.TryParse(fromResult, out from) || !int.TryParse(toResult, out to))
            {
                string ErrorMessage = $"The {displayName.ToLower()} must be numbers, like 2 and 5";
                AddError(bindingContext, fromModelName, toModelName, fromProviderResult, toProviderResult, ErrorMessage);
                return false;
            }

            if(to < 5)
            {
				string ErrorMessage = $"'To' {displayName.ToLower()} must be 5 or above";
				AddError(bindingContext, fromModelName, toModelName, fromProviderResult, toProviderResult, ErrorMessage);
				return false;
			}

            if (from < 2)
            {
                var ErrorMessage = $"'From' {displayName.ToLower()} must be 2 or above";
                AddError(bindingContext, fromModelName, toModelName, fromProviderResult, toProviderResult, ErrorMessage);
                return false;
            }

			if (from >= to)
			{
				var ErrorMessage = $"'From' {displayName.ToLower()} must be less than 'to' {displayName.ToLower()}";
				AddError(bindingContext, fromModelName, toModelName, fromProviderResult, toProviderResult, ErrorMessage);
				return false;
			}

			return true;
        }

        private static void AddError(ModelBindingContext bindingContext, string fromModelName, string toModelName, ValueProviderResult fromProviderResult, ValueProviderResult toProviderResult, string ErrorMessage)
        {
            bindingContext.ModelState.TryAddModelError(bindingContext.ModelName, ErrorMessage);
            bindingContext.ModelState.SetModelValue(fromModelName, fromProviderResult);
            bindingContext.ModelState.SetModelValue(toModelName, toProviderResult);
            bindingContext.Result = ModelBindingResult.Failed();
        }

        private static Type ValidateBindingContext(ModelBindingContext bindingContext)
        {
            ArgumentNullException.ThrowIfNull(bindingContext, nameof(bindingContext));
            
            var modelType = bindingContext.ModelType;
            if (modelType != typeof(string))
            {
                throw new InvalidOperationException($"Cannot bind {modelType.Name}.");
            }

            return modelType;
        }

        private static bool IsEmpty(ValueProviderResult startValueProviderResult, ValueProviderResult endValueProviderResult)
        {
            return startValueProviderResult.FirstValue == string.Empty
                   && endValueProviderResult.FirstValue == string.Empty;
        }

        private static bool IsOptionalOrFieldTypeMismatch(ModelBindingContext bindingContext, ValueProviderResult startValueProviderResult, ValueProviderResult endValueProviderResult)
        {
            return string.IsNullOrWhiteSpace(startValueProviderResult.FirstValue)
                   && string.IsNullOrWhiteSpace(endValueProviderResult.FirstValue)
                   && !bindingContext.ModelMetadata.IsRequired
                   || startValueProviderResult == ValueProviderResult.None
                   && endValueProviderResult == ValueProviderResult.None;
        }
    }
}
