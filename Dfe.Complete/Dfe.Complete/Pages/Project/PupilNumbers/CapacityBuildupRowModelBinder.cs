using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Dfe.ManageFreeSchoolProjects.Pages.Project.PupilNumbers
{
    public class CapacityBuildupRowModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            ValidateBindingContext(bindingContext);

            // adding -field stops it clashing with the date model binder logic in error service
            var displayName = bindingContext.ModelMetadata.DisplayName;
            var currentCapacityBindingName = $"{bindingContext.ModelName}-current-capacity-field";
            var firstYearBindingName = $"{bindingContext.ModelName}-first-year-field";
            var secondYearBindingName = $"{bindingContext.ModelName}-second-year-field";
            var thirdYearBindingName = $"{bindingContext.ModelName}-third-year-field";
            var fourthYearBindingName = $"{bindingContext.ModelName}-fourth-year-field";
            var fifthYearBindingName = $"{bindingContext.ModelName}-fifth-year-field";
            var sixthYearBindingName = $"{bindingContext.ModelName}-sixth-year-field";
            var seventhYearBindingName = $"{bindingContext.ModelName}-seventh-year-field";

            var currentCapacityResult = bindingContext.ValueProvider.GetValue(currentCapacityBindingName);
            var firstYearResult = bindingContext.ValueProvider.GetValue(firstYearBindingName);
            var secondYearResult = bindingContext.ValueProvider.GetValue(secondYearBindingName);
            var thirdYearResult = bindingContext.ValueProvider.GetValue(thirdYearBindingName);
            var fourthYearResult = bindingContext.ValueProvider.GetValue(fourthYearBindingName);
            var fifthYearResult = bindingContext.ValueProvider.GetValue(fifthYearBindingName);
            var sixthYearResult = bindingContext.ValueProvider.GetValue(sixthYearBindingName);
            var seventhYearResult = bindingContext.ValueProvider.GetValue(seventhYearBindingName);

            Validate(bindingContext, currentCapacityResult, currentCapacityBindingName, $"{displayName} current capacity");
            Validate(bindingContext, firstYearResult, firstYearBindingName, $"{displayName} first year");
            Validate(bindingContext, secondYearResult, secondYearBindingName, $"{displayName} second year");
            Validate(bindingContext, thirdYearResult, thirdYearBindingName, $"{displayName} third year");
            Validate(bindingContext, fourthYearResult, fourthYearBindingName, $"{displayName} fourth year");
            Validate(bindingContext, fifthYearResult, fifthYearBindingName, $"{displayName} fifth year");
            Validate(bindingContext, sixthYearResult, sixthYearBindingName, $"{displayName} sixth year");
            Validate(bindingContext, seventhYearResult, seventhYearBindingName, $"{displayName} seventh year");

            var model = new CapacityBuildupRowModel()
            {
                CurrentCapacity = currentCapacityResult.FirstValue,
                FirstYear = firstYearResult.FirstValue,
                SecondYear = secondYearResult.FirstValue,
                ThirdYear = thirdYearResult.FirstValue,
                FourthYear = fourthYearResult.FirstValue,
                FifthYear = fifthYearResult.FirstValue,
                SixthYear = sixthYearResult.FirstValue,
                SeventhYear = seventhYearResult.FirstValue
            };

            bindingContext.Result = ModelBindingResult.Success(model);

            return Task.CompletedTask;
        }

        private static void ValidateBindingContext(ModelBindingContext bindingContext)
        {
            ArgumentNullException.ThrowIfNull(bindingContext);

            var modelType = bindingContext.ModelType;

            if (modelType != typeof(CapacityBuildupRowModel))
            {
                throw new InvalidOperationException($"Cannot bind {modelType.Name}.");
            }
        }

        private static void Validate(
            ModelBindingContext bindingContext,
            ValueProviderResult valueProviderResult,
            string bindingName,
            string displayName)
        {
            var validator = new ValidNumberForPupilNumbersAttribute();
            var validationContext = new ValidationContext(new CapacityBuildupRowModel())
            {
                DisplayName = displayName
            };

            var validationResult = validator.GetValidationResult(valueProviderResult.FirstValue, validationContext);

            if (validationResult != ValidationResult.Success)
            {
                bindingContext.ModelState.AddModelError(bindingName, $"{validationResult.ErrorMessage}");
            }
        }
    }
}
