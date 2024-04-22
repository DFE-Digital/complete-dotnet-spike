using Dfe.ManageFreeSchoolProjects.API.Contracts.Project.Risk;
using Dfe.ManageFreeSchoolProjects.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Threading.Tasks;

namespace Dfe.ManageFreeSchoolProjects.TagHelpers
{
    [HtmlTargetElement("govuk-risk-rating-label", TagStructure = TagStructure.WithoutEndTag)]
    public class RiskRatingLabelTagHelper : TagHelper
    {
        private readonly IHtmlHelper _htmlHelper;

        [HtmlAttributeName("risk-rating")]
        public ProjectRiskRating? RiskRating { get; set; }

        [ViewContext]
        public ViewContext ViewContext { get; set; }

        public RiskRatingLabelTagHelper(IHtmlHelper htmlHelper)
        {
            _htmlHelper = htmlHelper;
        }

        public async override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            if (_htmlHelper is IViewContextAware viewContextAware)
            {
                viewContextAware.Contextualize(ViewContext);
            }

            var model = new RiskRatingLabelViewModel()
            {
                RiskRating = RiskRating
            };

            var content = await _htmlHelper.PartialAsync("_RiskRatingLabel", model);

            output.TagName = null;
            output.PostContent.AppendHtml(content);
        }
    }
}
