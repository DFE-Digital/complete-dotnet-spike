using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Dfe.Complete.TagHelpers
{
    [HtmlTargetElement("govuk-trust-details", TagStructure = TagStructure.NormalOrSelfClosing)]
    public class TrustDetailsTagHelper : TagHelper
    {
        private readonly IHtmlHelper _htmlHelper;

        [HtmlAttributeName("id")]
        public string Id { get; set; }

        [HtmlAttributeName("label")]
        public string Label { get; set; }

        [HtmlAttributeName("asp-for")]
        public ModelExpression For { get; set; }

        [HtmlAttributeName("href")]
        public string Href { get; set; } 

        [ViewContext]
        public ViewContext ViewContext { get; set; }

        public TrustDetailsTagHelper(IHtmlHelper htmlHelper)
        {
            _htmlHelper = htmlHelper;
        }

        public async override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (_htmlHelper is IViewContextAware viewContextAware)
            {
                viewContextAware.Contextualize(ViewContext);
            }

          //  var trustDetails = For.Model as TrustDetails;

            var model = new TrustDetailsViewModel()
            {
                Id = Id,
                Label = Label,
                Href = Href,
           //     TrustDetails = trustDetails
            };
            var content = await _htmlHelper.PartialAsync("_TrustDetails", model);

            output.TagName = null;
            output.PostContent.AppendHtml(content);
        }
    }

    public record TrustDetailsViewModel
    {
        public string Id { get; set; }

        public string Label { get; set; }

        public string Href { get; set; }

   //     public TrustDetails TrustDetails { get; set; }
    }
}
