namespace Dfe.Complete.ViewModels
{
    public class StartEndViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string StartYear { get; set; }
        public string EndYear { get; set; }
        public string Label { get; set; }
        public bool HeadingLabel { get; set; }
        public string Hint { get; set; }
        public string ErrorMessage { get; set; }
        public bool StartInvalid { get; set; }
        public bool EndInvalid { get; set; }
    }
}
