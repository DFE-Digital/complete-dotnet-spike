using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Dfe.ManageFreeSchoolProjects.TagHelpers
{
    [HtmlTargetElement("govuk-summary-list", TagStructure = TagStructure.NormalOrSelfClosing)]
    public class SummaryListTagHelper : TagHelper
    {
        public bool? NoBorder { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "dl";

            if(NoBorder.HasValue && NoBorder.Value)
            {
                output.Attributes.SetAttribute("class", "govuk-summary-list govuk-summary-list--no-border");
                return;
            }
            output.Attributes.SetAttribute("class", "govuk-summary-list");
        }
    }
}
