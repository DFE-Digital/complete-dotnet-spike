using Dfe.Complete.Extensions;
using Dfe.Complete.Services;
using Dfe.Complete.ViewModels;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Threading.Tasks;

namespace Dfe.Complete.TagHelpers
{
	[HtmlTargetElement("govuk-decimal-input", TagStructure = TagStructure.WithoutEndTag)]
	public class DecimalInputTagHelper : InputTagHelperBase
	{
		private readonly ErrorService _errorService;
		public bool HeadingLabel { get; set; }

		[HtmlAttributeName("isMonetary")]
		public bool IsMonetary { get; set; }

		public DecimalInputTagHelper(IHtmlHelper htmlHelper, ErrorService errorService) : base(htmlHelper)
		{
			_errorService = errorService;
		}

		protected override async Task<IHtmlContent> RenderContentAsync()
		{
			DecimalInputViewModel model = ValidateModel();

			return await _htmlHelper.PartialAsync("_DecimalInput", model);
		}

		private DecimalInputViewModel ValidateModel()
		{
			if (For.ModelExplorer.ModelType != typeof(decimal?) && For.ModelExplorer.ModelType != typeof(decimal))
			{
				throw new ArgumentException("For.ModelExplorer.ModelType is not a decimal");
			}

			var value = (decimal?)For.Model;
			var model = new DecimalInputViewModel
			{
				Id = Id,
				Name = Name,
				Label = Label,
				Suffix = Suffix,
				Hint = Hint,
				HeadingLabel = HeadingLabel,
				Value = IsMonetary ? value?.ToMoneyString() : value.ToSafeString(),
				IsMonetary = IsMonetary
			};

			var error = _errorService.GetError(Name);
			if (error != null)
			{
				model.ErrorMessage = error.Message;
				if (ViewContext.HttpContext.Request.Form.TryGetValue($"{Name}", out var invalidValue))
				{
					model.Value = invalidValue;
				}
			}

			return model;
		}
	}
}
