﻿namespace Dfe.Complete.ViewModels
{
    public class RadiosInputViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public string[] Values { get; set; }
        public string Label { get; set; }
        public bool MediumHeadingLabel { get; set; }
        public bool HeadingLabel { get; set; }
		public bool XLHeadingLabel { get; set; }
		public string[] Labels { get; set; }
        public string[] HtmlLabels { get; set; }
        public string ErrorMessage { get; set; }
        public string LeadingParagraph { get; set; }
        public string[] Hints { get; set; }
        public string[] TestIds { get; set; }
    }
}
