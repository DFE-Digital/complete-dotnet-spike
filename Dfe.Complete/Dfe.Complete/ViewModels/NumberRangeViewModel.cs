namespace Dfe.Complete.ViewModels
{
    public class NumberRangeViewModel
    {
            public string Id { get; set; }
            public string Name { get; set; }
            public string From { get; set; }
            public string To { get; set; }
            public string Label { get; set; }
            public bool HeadingLabel { get; set; }
            public bool HeadingLabelMedium { get; set; }
            public string Hint { get; set; }
            public string ErrorMessage { get; set; }
            public bool FromInvalid { get; set; }
            public bool ToInvalid { get; set; }
    }
}
