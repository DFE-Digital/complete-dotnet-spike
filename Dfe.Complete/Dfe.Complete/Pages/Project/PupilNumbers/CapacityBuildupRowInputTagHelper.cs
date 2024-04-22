using Dfe.ManageFreeSchoolProjects.API.Contracts.Project.PupilNumbers;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Threading.Tasks;

namespace Dfe.ManageFreeSchoolProjects.Pages.Project.PupilNumbers
{
    [HtmlTargetElement("govuk-capacity-buildup-row-input", TagStructure = TagStructure.WithoutEndTag)]
    public class CapacityBuildupRowInputTagHelper : TagHelper
    {
        [HtmlAttributeName("asp-for")]
        public ModelExpression For { get; set; }

        [HtmlAttributeName("school-year")]
        public string SchoolYear { get; set; }

        [ViewContext]
        public ViewContext ViewContext { get; set; }

        private readonly IHtmlHelper _htmlHelper;

        public CapacityBuildupRowInputTagHelper(
            IHtmlHelper htmlHelper)
        {
            _htmlHelper = htmlHelper;
        }

        public async override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            if (_htmlHelper is IViewContextAware viewContextAware)
            {
                viewContextAware.Contextualize(ViewContext);
            }

            var model = new CapacityRowBuildupInputViewModel()
            {
                SchoolYear = SchoolYear,
                CapacityBuildupRow = For.Model as CapacityBuildupRowModel
            };

            var content = await _htmlHelper.PartialAsync("_CapacityBuildupRowInput", model);

            output.TagName = null;
            output.PostContent.AppendHtml(content);
        }
    }

    public class CapacityRowBuildupInputViewModel
    {
        public string SchoolYear { get; set; }

        public CapacityBuildupRowModel CapacityBuildupRow { get; set; }
    }
}
