using Dfe.Complete.ViewModels;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Threading.Tasks;

namespace Dfe.Complete.TagHelpers
{
	[HtmlTargetElement("govuk-text-input", TagStructure = TagStructure.WithoutEndTag)]
	public class TextInputTagHelper : InputTagHelperBase
	{
		[HtmlAttributeName("width")]
		public int Width { get; set; }
		
		public bool HeadingLabel { get; set; }

        public bool SmallLabel { get; set; }

        [HtmlAttributeName("add-margin")]
		public bool AddMargin { get; set; }

		[HtmlAttributeName("input-styles")]
		public string InputStyles { get; set; } = "";

		public TextInputTagHelper(IHtmlHelper htmlHelper) : base(htmlHelper) { }

		protected override async Task<IHtmlContent> RenderContentAsync()
		{
			var model = new TextInputViewModel
			{
				Id = Id,
				TestId = TestId,
				Name = Name,
				Label = Label,
				Value = For.Model?.ToString(),
				Width = Width,
				Hint = Hint,
				HeadingLabel = HeadingLabel,
                SmallLabel = SmallLabel,
                BoldLabel = BoldLabel,
				AddMargin = AddMargin,
				InputStyles = InputStyles
            };

			if (ViewContext.ModelState.TryGetValue(Name, out var entry) && entry.Errors.Count > 0)
			{
				model.ErrorMessage = entry.Errors[0].ErrorMessage;
			}

			return await _htmlHelper.PartialAsync("_TextInput", model);
		}
	}
}
