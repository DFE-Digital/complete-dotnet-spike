using Dfe.Complete.Services;
using Dfe.Complete.ViewModels;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Threading.Tasks;

namespace Dfe.Complete.TagHelpers
{
    [HtmlTargetElement("govuk-yesno-input", TagStructure = TagStructure.WithoutEndTag)]
	public class YesNoInputTagHelper : InputTagHelperBase
	{
		[HtmlAttributeName("leading-paragraph")]
		public string LeadingParagraph { get; set; }
		
		[HtmlAttributeName("heading-label")]
		public bool HeadingLabel { get; set; }

		private readonly ErrorService _errorService;

		public YesNoInputTagHelper(IHtmlHelper htmlHelper, ErrorService errorService) : base(htmlHelper) 
		{
            _errorService = errorService;
        }

		protected override async Task<IHtmlContent> RenderContentAsync()
		{
            var value = (bool?)For.Model;
            var model = new YesNoInputViewModel
			{
				Id = Id,
				Name = Name,
				Label = Label,
				Value = value,
				HeadingLabel = HeadingLabel,
				LeadingParagraph = LeadingParagraph,
            };

            var error = _errorService.GetError(Name);

			if (error != null)
			{
				model.ErrorMessage = error.Message;
			}

            return await _htmlHelper.PartialAsync("_YesNoInput", model);
		}
	}
}
