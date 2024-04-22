using Dfe.ManageFreeSchoolProjects.API.Contracts.Project.Sites;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Threading.Tasks;

namespace Dfe.ManageFreeSchoolProjects.Pages.Project.SiteInformation
{
    [HtmlTargetElement("govuk-site-details", TagStructure = TagStructure.NormalOrSelfClosing)]
    public class SiteDetailsTagHelper : TagHelper
    {
        private readonly IHtmlHelper _htmlHelper;

        [HtmlAttributeName("site")]
        public ProjectSite Site { get; set; }

        [HtmlAttributeName("site-type")]
        public string SiteType { get; set; }

        public string EditLink { get; set; }

        [ViewContext]
        public ViewContext ViewContext { get; set; }

        public SiteDetailsTagHelper(IHtmlHelper htmlHelper)
        {
            _htmlHelper = htmlHelper;
        }

        public async override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            if (_htmlHelper is IViewContextAware viewContextAware)
            {
                viewContextAware.Contextualize(ViewContext);
            }

            var model = new SiteDetailsViewModel()
            {
                Site = Site,
                IdPrefix = SiteType?.ToLower(),
                SiteType = SiteType,
                EditLink = EditLink
            };

            var content = await _htmlHelper.PartialAsync("_SiteDetails", model);

            output.TagName = null;
            output.PostContent.AppendHtml(content);
        }
    }

    public class SiteDetailsViewModel
    {
        public ProjectSite Site { get; set; }
        public string IdPrefix { get; set; }
        public string SiteType { get; set; }
        public string EditLink { get; set; }
    }
}
