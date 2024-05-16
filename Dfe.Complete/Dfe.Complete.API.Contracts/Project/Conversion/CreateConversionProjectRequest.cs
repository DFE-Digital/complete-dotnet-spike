namespace Dfe.Complete.API.Contracts.Project.Conversion
{
    public record CreateConversionProjectRequest : CreateProjectRequest
    {
        public bool? HasAcademyOrderBeenIssued { get; set; }
    }
}
