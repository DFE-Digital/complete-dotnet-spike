using Dfe.Complete.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Threading.Tasks;

namespace Dfe.Complete.TagHelpers
{
    [HtmlTargetElement("govuk-display-value", TagStructure = TagStructure.WithoutEndTag)]
    public class DisplayValueTagHelper : TagHelper
    {
        private readonly IHtmlHelper _htmlHelper;

        [ViewContext]
        public ViewContext ViewContext { get; set; }

        [HtmlAttributeName("value")]
        public string Value { get; set; }

        public DisplayValueTagHelper(IHtmlHelper htmlHelper)
        {
            _htmlHelper = htmlHelper;
        }

        public async override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            if (_htmlHelper is IViewContextAware viewContextAware)
            {
                viewContextAware.Contextualize(ViewContext);
            }

            var model = new DisplayValueViewModel()
            {
                Value = Value
            };

            var content = await _htmlHelper.PartialAsync("_DisplayValue", model);

            output.TagName = null;
            output.PostContent.AppendHtml(content);
        }
    }
}