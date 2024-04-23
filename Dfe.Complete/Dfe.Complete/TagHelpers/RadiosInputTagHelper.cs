using Dfe.Complete.Services;
using Dfe.Complete.ViewModels;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Threading.Tasks;

namespace Dfe.Complete.TagHelpers
{
    [HtmlTargetElement("govuk-radios-input", TagStructure = TagStructure.WithoutEndTag)]
	public class RadiosInputTagHelper : InputTagHelperBase
	{
		[HtmlAttributeName("leading-paragraph")]
		public string LeadingParagraph { get; set; }
		
		[HtmlAttributeName("medium-heading-label")]
		
		public bool MediumHeadingLabel { get; set; }
		
		[HtmlAttributeName("heading-label")]
		public bool HeadingLabel { get; set; }

		[HtmlAttributeName("xl-heading-label")]
		public bool XLHeadingLabel { get; set; }

		[HtmlAttributeName("values")]
		public string[] Values { get; set; } = new string[] { };

		[HtmlAttributeName("labels")]
		public string[] Labels { get; set; } = new string[] { };

		[HtmlAttributeName("html-labels")]
		public string[] HtmlLabels { get; set; } = new string[] { };

		[HtmlAttributeName("hints")]
		public string[] Hints { get; set; }

		[HtmlAttributeName("test-ids")]
		public string[] TestIds { get; set; } = new string[] { };

		private readonly ErrorService _errorService;

		public RadiosInputTagHelper(IHtmlHelper htmlHelper, ErrorService errorService) : base(htmlHelper) 
		{
            _errorService = errorService;
        }

		protected override async Task<IHtmlContent> RenderContentAsync()
		{
			var model = new RadiosInputViewModel
			{
				Id = Id,
				TestIds = TestIds,
				Name = Name,
				Label = Label,
				Value = For.Model?.ToString(),
				Values = Values,
				Labels = Labels,
				HtmlLabels = HtmlLabels,
				MediumHeadingLabel = MediumHeadingLabel,
				HeadingLabel = HeadingLabel,
				XLHeadingLabel = XLHeadingLabel,
				LeadingParagraph = LeadingParagraph,
                Hints = Hints
            };

            var error = _errorService.GetError(Name);

			if (error != null)
			{
				model.ErrorMessage = error.Message;
			}

            return await _htmlHelper.PartialAsync("_RadiosInput", model);
		}
	}
}
