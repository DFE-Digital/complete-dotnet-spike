using Dfe.Complete.Services;
using Dfe.Complete.ViewModels;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Dfe.Complete.TagHelpers
{
    [HtmlTargetElement("govuk-year-start-end", TagStructure = TagStructure.WithoutEndTag)]
    public class StartEndYearTagHelper : InputTagHelperBase
    {
        public bool HeadingLabel { get; set; }

        private readonly ErrorService _errorService;

        public StartEndYearTagHelper(IHtmlHelper htmlHelper, ErrorService errorService) : base(htmlHelper)
        {
            _errorService = errorService;
        }

        protected override async Task<IHtmlContent> RenderContentAsync()
        {
            StartEndViewModel model = ValidateRequest();

            return await _htmlHelper.PartialAsync("_StartEndYear", model);
        }

        private StartEndViewModel ValidateRequest()
        {
            if (For.ModelExplorer.ModelType != typeof(string))
            {
                throw new ArgumentException("ModelType is not a string");
            }

            var startEnd = For.Model as string;
            var model = new StartEndViewModel
            {
                Id = Id,
                Name = Name,
                Label = Label,
                HeadingLabel = HeadingLabel,
                Hint = Hint
            };

           
            var error = _errorService.GetError(Name);
            if (error != null)
            {
                model.ErrorMessage = error.Message;
                model.StartInvalid = error.InvalidInputs.Contains($"{Name}-startyear");
                if (ViewContext.HttpContext.Request.Form.TryGetValue($"{Name}-startyear", out var dayValue))
                {
                    model.StartYear = dayValue;
                }
                model.EndInvalid = error.InvalidInputs.Contains($"{Name}-endyear");
                if (ViewContext.HttpContext.Request.Form.TryGetValue($"{Name}-endyear", out var monthValue))
                {
                    model.EndYear = monthValue;
                }

                if (!model.StartInvalid && !model.EndInvalid)
                {
                    model.StartInvalid = model.EndInvalid = true;
                }
            }
			else
			{
                if (!string.IsNullOrEmpty(startEnd) && Regex.Match(startEnd, "20\\d\\d/\\d\\d", RegexOptions.None, TimeSpan.FromSeconds(5)).Success)
                {
                    model.StartYear = "20" + startEnd.Substring(2, 2);
                    model.EndYear = "20" + startEnd.Substring(5, 2);
                }
			}

			return model;
        }
    }
}
