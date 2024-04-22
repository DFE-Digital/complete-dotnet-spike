using Dfe.ManageFreeSchoolProjects.API.Contracts.Project.PupilNumbers;
using DocumentFormat.OpenXml.EMMA;
using DocumentFormat.OpenXml.Office2010.Excel;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Threading.Tasks;

namespace Dfe.ManageFreeSchoolProjects.Pages.Project.PupilNumbers
{
    [HtmlTargetElement("govuk-capacity-buildup-row", TagStructure = TagStructure.WithoutEndTag)]
    public class CapacityBuildupRowTagHelper : TagHelper
    {
        [HtmlAttributeName("label")]
        public string Label { get; set; }

        [HtmlAttributeName("bold-label")]
        public bool BoldLabel { get; set; }

        [HtmlAttributeName("asp-for")]
        public CapacityBuildupEntry For { get; set; }

        [HtmlAttributeName("id-prefix")]
        public string IdPrefix { get;set; }

        [ViewContext]
        public ViewContext ViewContext { get; set; }

        private readonly IHtmlHelper _htmlHelper;

        public CapacityBuildupRowTagHelper(IHtmlHelper htmlHelper)
        {
            _htmlHelper = htmlHelper;
        }

        public async override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            if (_htmlHelper is IViewContextAware viewContextAware)
            {
                viewContextAware.Contextualize(ViewContext);
            }

            var model = new CapacityBuildupRowViewModel()
            {
                Label = Label,
                CapacityBuildupEntry = For,
                BoldLabel = BoldLabel,
                IdPrefix = GetIdPrefix()
            };

            var content = await _htmlHelper.PartialAsync("_CapacityBuildupRow", model);

            output.TagName = null;
            output.PostContent.AppendHtml(content);
        }

        private string GetIdPrefix()
        {
            if (!string.IsNullOrEmpty(IdPrefix))
            {
                return IdPrefix;
            }

            return Label.ToLower().Replace(" ", string.Empty);
        }
    }

    public class CapacityBuildupRowViewModel
    {
        public string Label { get; set; }

        public string IdPrefix { get; set; }

        public bool BoldLabel { get; set; }

        public CapacityBuildupEntry CapacityBuildupEntry { get; set; }
    }
}
