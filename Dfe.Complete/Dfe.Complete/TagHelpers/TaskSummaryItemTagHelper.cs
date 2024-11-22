using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Dfe.Complete.TagHelpers
{
    [HtmlTargetElement("govuk-task-summary-item", TagStructure = TagStructure.WithoutEndTag)]
    public class TaskSummaryItemTagHelper : TagHelper
    {
        private readonly IHtmlHelper _htmlHelper;

        [HtmlAttributeName("asp-for")]
        public ModelExpression For { get; set; }

        [HtmlAttributeName("href")]
        public string Href { get; set; }

        [HtmlAttributeName("label")]
        public string Label { get; set; }

        [ViewContext]
        public ViewContext ViewContext { get; set; }

        public TaskSummaryItemTagHelper(IHtmlHelper htmlHelper)
        {
            _htmlHelper = htmlHelper;
        }

        public async override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (_htmlHelper is IViewContextAware viewContextAware)
            {
                viewContextAware.Contextualize(ViewContext);
            }

            var model = new TaskSummaryItemViewModel()
            {
            //    TaskSummary = For.Model as TaskSummaryResponse,
                Href = Href,
                Label = Label
            };

            var content = await _htmlHelper.PartialAsync("_TaskSummaryItem", model);

            output.TagName = null;
            output.PostContent.AppendHtml(content);
        }
    }

    public record TaskSummaryItemViewModel
    {
   //     public TaskSummaryResponse TaskSummary { get; set; }

        public string Href { get; set; }

        public string Label { get; set; }
    }
}
