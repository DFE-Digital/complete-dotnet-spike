using Dfe.ManageFreeSchoolProjects.Services;
using Dfe.ManageFreeSchoolProjects.ViewModels;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Text.RegularExpressions;
using System;
using System.Threading.Tasks;
using Dfe.ManageFreeSchoolProjects.Services.Tasks;

namespace Dfe.ManageFreeSchoolProjects.TagHelpers
{
    [HtmlTargetElement("govuk-number-range", TagStructure = TagStructure.WithoutEndTag)]
    public class NumberRangeTagHelper : InputTagHelperBase
    {
        public bool HeadingLabel { get; set; }
        [HtmlAttributeName("heading-medium-label")]
        public bool HeadingLabelMedium { get; set; }


        private readonly ErrorService _errorService;
        private readonly IAgeRangeCleanerService _ageRangeCleanerService;

        public NumberRangeTagHelper(IHtmlHelper htmlHelper, IAgeRangeCleanerService ageRangeCleanerService, ErrorService errorService) : base(htmlHelper)
        {
            _errorService = errorService;
            _ageRangeCleanerService = ageRangeCleanerService;
        }

        protected override async Task<IHtmlContent> RenderContentAsync()
        {
            NumberRangeViewModel model = ValidateRequest();

            return await _htmlHelper.PartialAsync("_NumberRange", model);
        }

        private NumberRangeViewModel ValidateRequest()
        {
            if(For?.ModelExplorer?.ModelType == null)
            {
                return new NumberRangeViewModel();
			}


			if (For.ModelExplorer.ModelType != typeof(string))
            {
                throw new ArgumentException("ModelType is not a string");
            }

            var startEnd = For.Model as string;
            var model = new NumberRangeViewModel
            {
                Id = Id,
                Name = Name,
                Label = Label,
                HeadingLabel = HeadingLabel,
                HeadingLabelMedium = HeadingLabelMedium,
                Hint = Hint
            };

            var error = _errorService.GetError(Name);
            if (error != null)
            {
                model.ErrorMessage = error.Message;
                model.FromInvalid = error.InvalidInputs.Contains($"{Name}-from");
                if (ViewContext.HttpContext.Request.Form.TryGetValue($"{Name}-from", out var fromValue))
                {
                    model.From = fromValue;
                }
                model.ToInvalid = error.InvalidInputs.Contains($"{Name}-to");
                if (ViewContext.HttpContext.Request.Form.TryGetValue($"{Name}-to", out var toValue))
                {
                    model.To = toValue;
                }

                if (!model.FromInvalid && !model.ToInvalid)
                {
                    model.FromInvalid = model.ToInvalid = true;
                }
            }
            else
            {
                var ageRange = _ageRangeCleanerService.Clean(startEnd);
                if (!string.IsNullOrEmpty(ageRange))
                {
                    model.From = ageRange.Split("-")[0];
                    model.To = ageRange.Split("-")[1];
                }
            }

            return model;
        }
    }

}
