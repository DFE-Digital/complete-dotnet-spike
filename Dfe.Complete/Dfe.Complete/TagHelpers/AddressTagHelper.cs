using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Threading.Tasks;

namespace Dfe.ManageFreeSchoolProjects.TagHelpers
{
    [HtmlTargetElement("govuk-address", TagStructure = TagStructure.WithoutEndTag)]
    public class AddressTagHelper : TagHelper
    {
        private readonly IHtmlHelper _htmlHelper;

        [HtmlAttributeName("id-prefix")]
        public string IdPrefix { get; set; }

        [HtmlAttributeName("address-line1")]
        public string AddressLine1 { get; set; }

        [HtmlAttributeName("address-line2")]
        public string AddressLine2 { get; set; }

        [HtmlAttributeName("address-line3")]
        public string AddressLine3 { get; set; }

        [ViewContext]
        public ViewContext ViewContext { get; set; }

        public AddressTagHelper(IHtmlHelper htmlHelper)
        {
            _htmlHelper = htmlHelper;
        }

        public async override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            if (_htmlHelper is IViewContextAware viewContextAware)
            {
                viewContextAware.Contextualize(ViewContext);
            }

            var model = new AddressViewModel()
            {
                AddressLine1 = AddressLine1,
                AddressLine2 = AddressLine2,
                AddressLine3 = AddressLine3,
                IdPrefix = IdPrefix
            };

            var content = await _htmlHelper.PartialAsync("_Address", model);

            output.TagName = null;
            output.PostContent.AppendHtml(content);
        }
    }

    public class AddressViewModel
    {
        public string IdPrefix { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
    }
}
