using Dfe.Complete.Services;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Threading.Tasks;

namespace Dfe.Complete.TagHelpers
{
	[HtmlTargetElement("govuk-checkbox-list", TagStructure = TagStructure.WithoutEndTag)]
	public class CheckboxListTagHelper : InputTagHelperBase
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
		public string[] Values { get; set; } = [];

		[HtmlAttributeName("labels")]
		public string[] Labels { get; set; } = [];

		[HtmlAttributeName("html-labels")]
		public string[] HtmlLabels { get; set; } = [];

		[HtmlAttributeName("hints")]
		public string[] Hints { get; set; } = [];

		[HtmlAttributeName("test-ids")]
		public string[] TestIds { get; set; } = [];

		private readonly ErrorService _errorService;

		public CheckboxListTagHelper(IHtmlHelper htmlHelper, ErrorService errorService) : base(htmlHelper)
		{
			_errorService = errorService;
		}

		protected override async Task<IHtmlContent> RenderContentAsync()
		{
			var model = new CheckboxListViewModel()
			{
				Id = Id,
				TestIds = TestIds,
				Name = Name,
				Label = Label,
				SelectedValues = (string[])For.Model,
				CheckboxValues = Values,
				CheckboxLabels = Labels,
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

			return await _htmlHelper.PartialAsync("_CheckboxList", model);
		}
	}

	public class CheckboxListViewModel
	{
		public string Id { get; set; }
		public string Name { get; set; }
		public string[] SelectedValues { get; set; }
		public string[] CheckboxValues { get; set; }
		public string Label { get; set; }
		public bool MediumHeadingLabel { get; set; }
		public bool HeadingLabel { get; set; }
		public bool XLHeadingLabel { get; set; }
		public string[] CheckboxLabels { get; set; }
		public string[] HtmlLabels { get; set; }
		public string ErrorMessage { get; set; }
		public string LeadingParagraph { get; set; }
		public string[] Hints { get; set; }
		public string[] TestIds { get; set; }
	}
}
