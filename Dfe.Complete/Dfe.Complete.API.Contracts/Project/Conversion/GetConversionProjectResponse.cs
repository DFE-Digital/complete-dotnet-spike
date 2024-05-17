namespace Dfe.Complete.API.Contracts.Project.Conversion
{
    public record GetConversionProjectResponse : GetProjectResponse
    {
        public ReasonForTheConversion ReasonForTheConversion { get; set; }
    }

    public record ReasonForTheConversion
    {
        public bool? HasAcademyOrderBeenIssued { get; set; }
        public bool? IsDueTo2RI { get; set; }
    }
}
