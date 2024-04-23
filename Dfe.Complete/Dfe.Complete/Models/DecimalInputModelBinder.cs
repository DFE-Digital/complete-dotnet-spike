using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Microsoft.Extensions.Logging;
using System;
using System.Globalization;
using System.Threading.Tasks;

namespace Dfe.Complete.Models
{
	public class DecimalInputModelBinder : IModelBinder
	{
		private readonly ILoggerFactory _loggerFactory;

		public DecimalInputModelBinder(ILoggerFactory loggerFactory)
		{
			_loggerFactory = loggerFactory;
		}

		public Task BindModelAsync(ModelBindingContext bindingContext)
		{
			if (bindingContext == null)
			{
				throw new ArgumentNullException(nameof(bindingContext));
			}

			var modelType = bindingContext.ModelType;
			if (modelType != typeof(decimal) && modelType != typeof(decimal?))
			{
				throw new InvalidOperationException($"Cannot bind {modelType.Name}.");
			}

			var decimalResult = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);

			if (modelType == typeof(decimal?) && decimalResult.FirstValue == string.Empty)
			{
				bindingContext.Result = ModelBindingResult.Success(null);
				return Task.CompletedTask;
			}

            if (modelType == typeof(decimal) && decimalResult.FirstValue == string.Empty)
            {
                bindingContext.Result = ModelBindingResult.Success(0.0m);
                return Task.CompletedTask;
            }

            (new DecimalModelBinder(NumberStyles.Any, _loggerFactory)).BindModelAsync(bindingContext);

			if (bindingContext.ModelState.TryGetValue(bindingContext.ModelName, out var entry) && entry.Errors.Count > 0)
			{
				var displayName = bindingContext.ModelMetadata.DisplayName ?? bindingContext.ModelName;
				entry.Errors.Add($"{displayName} must be a number");
			}

			return Task.CompletedTask;
		}
	}
}
