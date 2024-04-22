using Dfe.ManageFreeSchoolProjects.API.Contracts.Project.Risk;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Threading.Tasks;

namespace Dfe.ManageFreeSchoolProjects.TagHelpers
{
    [HtmlTargetElement("govuk-risk-rating-summary", TagStructure = TagStructure.WithoutEndTag)]
    public class RiskRatingSummaryComponentTagHelper : TagHelper
    {
        private readonly IHtmlHelper _htmlHelper;

        [HtmlAttributeName("project-id")]
        public string ProjectId { get; set; }

        [HtmlAttributeName("date")]
        public DateTime? Date { get; set; }

        [HtmlAttributeName("risk-rating")]
        public ProjectRiskRating? RiskRating { get; set; }

        [HtmlAttributeName("summary")]
        public string Summary { get; set; }

        [HtmlAttributeName("change-link-text")]
        public string ChangeLinkText { get; set; }

        [ViewContext]
        public ViewContext ViewContext { get; set; }

        public RiskRatingSummaryComponentTagHelper(IHtmlHelper htmlHelper)
        {
            _htmlHelper = htmlHelper;
        }

        public async override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            if (_htmlHelper is IViewContextAware viewContextAware)
            {
                viewContextAware.Contextualize(ViewContext);
            }

            var model = new RiskRatingSummaryComponentViewModel()
            {
                ProjectId = ProjectId,
                Date = Date,
                RiskRating = RiskRating,
                Summary = Summary,
                ChangeLinkText = ChangeLinkText
            };

            var content = await _htmlHelper.PartialAsync("_RiskRatingSummaryComponent", model);

            output.TagName = null;
            output.PostContent.AppendHtml(content);
        }
    }

    public class RiskRatingSummaryComponentViewModel
    {
        public DateTime? Date { get; set; }

        public ProjectRiskRating? RiskRating { get; set; }

        public string Summary { get; set; }

        public string ProjectId { get; set; }

        public string ChangeLinkText { get; set; }
    }
}
