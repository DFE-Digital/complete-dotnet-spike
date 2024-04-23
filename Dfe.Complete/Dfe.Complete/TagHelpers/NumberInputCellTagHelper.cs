using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Threading.Tasks;

namespace Dfe.Complete.TagHelpers
{
    /// <summary>
    /// This tag helper is to be used on table cells that contain number inputs.
    /// </summary>
    [HtmlTargetElement("govuk-number-input-cell", TagStructure = TagStructure.WithoutEndTag)]
    public class NumberInputCellTagHelper : InputTagHelperBase
    {
        public NumberInputCellTagHelper(IHtmlHelper htmlHelper) : base(htmlHelper) { }

        protected override async Task<IHtmlContent> RenderContentAsync()
        {
            if (string.IsNullOrEmpty(Id))
            {
                Id = For.Name;
            }

            if (string.IsNullOrEmpty(Name))
            {
                Name = For.Name;
            }

            var model = new NumberInputCellViewModel
            {
                Id = Id,
                TestId = TestId,
                Name = Name,
                Value = For.Model?.ToString(),
                Label = Label
            };

            if (ViewContext.ModelState.TryGetValue(Name, out var entry) && entry.Errors.Count > 0)
            {
                model.ErrorMessage = entry.Errors[0].ErrorMessage;
            }

            return await _htmlHelper.PartialAsync("_NumberInputCell", model);
        }
    }

    public class NumberInputCellViewModel
    {
        public string Id { get; set; }
        public string TestId { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public string ErrorMessage { get; set; }
        public string Label { get; set; }
    }
}
