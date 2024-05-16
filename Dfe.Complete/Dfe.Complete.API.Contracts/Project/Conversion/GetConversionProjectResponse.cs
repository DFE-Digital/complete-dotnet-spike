namespace Dfe.Complete.API.Contracts.Project.Conversion
{
    public record GetConversionProjectResponse : GetProjectResponse
    {
        public ReasonForConversion ReasonForConversion { get; set; }
    }

    public record ReasonForConversion
    {
        public bool? HasAcademyOrderBeenIssued { get; set; }
        public bool? IsDueTo2RI { get; set; }
    }
}
