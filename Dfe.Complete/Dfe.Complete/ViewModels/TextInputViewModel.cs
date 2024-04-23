namespace Dfe.Complete.ViewModels
{
	public class TextInputViewModel
	{
		public string Id { get; set; }
		public string Name { get; set; }
		public string Value { get; set; }
		public string Label { get; set; }
		public string ErrorMessage { get; set; }
		public int Width { get; set; }
		public string Hint { get; set; }
		public bool HeadingLabel { get; set; }
		public bool? BoldLabel { get; set; }
		public string TestId { get; set; }
		public bool AddMargin { get; set; }
		public string InputStyles { get; set; }
        public bool SmallLabel { get; set; }
    }
}
