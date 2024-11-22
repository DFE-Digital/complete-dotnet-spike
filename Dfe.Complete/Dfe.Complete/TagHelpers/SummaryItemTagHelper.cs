using Dfe.Complete.Constants;
using Dfe.Complete.Extensions;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Globalization;

namespace Dfe.Complete.TagHelpers
{
    [HtmlTargetElement("govuk-summary-item", TagStructure = TagStructure.NormalOrSelfClosing)]
    public class SummaryItemTagHelper : TagHelper
    {
        const string empty = HtmlTagConstants.Empty;

        [HtmlAttributeName("label")]
        public string Label { get; set; }
        
        [HtmlAttributeName("id")]
        
        public string Id { get; set; }

        [HtmlAttributeName("asp-for")]
        public ModelExpression For { get; set; }

        [HtmlAttributeName("href")]
        public string Href { get; set; }

        [HtmlAttributeName("render-link")]
        public bool RenderLink { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            output.Attributes.SetAttribute("class", "govuk-summary-list__row");

            output.Content.SetHtmlContent(
               $@"<dt class=""govuk-summary-list__key"">
                    {Label}
               </dt>
               <dd class=""govuk-summary-list__value"" data-testid=""projectid"">
                    {RenderValue()}
               </dd>
               {GetChangeLink()}
            ");

            output.TagMode = TagMode.StartTagAndEndTag;
        }

        private string RenderValue()
        {
            var value = GetValue();

            if(value != empty && RenderLink)
            {
                return $@"<a class=""govuk-link"" href=""{For.Model}"">{value}</a>";
            }

            return value;
        }

        private string GetValue()
        {
            var result = SummaryItemValueBuilder.Execute(For.Model, For.ModelExplorer.ModelType);

            return result;
        }

        private string GetChangeLink()
        {
            if (string.IsNullOrEmpty(Href))
            {
                return string.Empty;
            }

            if (Id is not null)
            {
                return $@"<dd class=""govuk-summary-list__actions"">
                        <a class=""govuk-link"" href={Href} Id={Id + "-changelink"}>
                            Change<span class=""govuk-visually-hidden"">{Label}</span>
                        </a>                   
                     </dd>";
            }
            
            return $@"<dd class=""govuk-summary-list__actions"">
                        <a class=""govuk-link"" href={Href}>
                            Change<span class=""govuk-visually-hidden"">{Label}</span>
                        </a>                   
                     </dd>";
        }
    }

    public class SummaryItemValueBuilder
    {
        public static string Execute(object model, Type type)
        {
            if (model == null)
            {
                return HtmlTagConstants.Empty;
            }

            if (type == typeof(bool) || type == typeof(bool?))
            {
                return ((bool)model).ToYesNoString();
            }

            if (type == typeof(DateTime) || type == typeof(DateTime?))
            {
                return ((DateTime)model).ToDateString();
            }

            if (type.IsEnum || Nullable.GetUnderlyingType(type)?.IsEnum == true)
            {
                return BuildEnum(model);
            }

            if (type == typeof(decimal) || type == typeof(decimal?))
            {
                return ((decimal)model).ToString("C", new CultureInfo("en-GB"));
            }

            //if (type == typeof(Address))
            //{
            //    return BuildAddress((Address)model);
            //}

            if (type == typeof(LinkSummaryItem))
            {
                return BuildLinkSummaryItem((LinkSummaryItem)model);
            }

            var value = model.ToString();

            if (string.IsNullOrEmpty(value))
            {
                return HtmlTagConstants.Empty;
            }

            return value;
        }

        private static string BuildEnum(object value)
        {
            var result = value.ToDescription();

            if (result == "NotSet")
            {
                return HtmlTagConstants.Empty;
            }

            return result;
        }

        //private static string BuildAddress(Address address)
        //{
        //    var addressLines = address.ToArray();

        //    if (addressLines.Length == 0)
        //    {
        //        return HtmlTagConstants.Empty;
        //    }

        //    return string.Join("<br />", address.ToArray());
        //}

        private static string BuildLinkSummaryItem(LinkSummaryItem linkSummaryItem)
        {
            var labelHtml = string.IsNullOrEmpty(linkSummaryItem.Label) ? string.Empty : $@"{linkSummaryItem.Label}<br />";

            return $@"{labelHtml}<a target=""_blank"" class=""govuk-link"" href=""{linkSummaryItem.Link}"">{linkSummaryItem.LinkText} (opens in a new tab)</a>";
        }
    }

    public record LinkSummaryItem
    {
        public string Label { get; set; }
        public string Link { get; set; }
        public string LinkText { get; set; }
    }
}
