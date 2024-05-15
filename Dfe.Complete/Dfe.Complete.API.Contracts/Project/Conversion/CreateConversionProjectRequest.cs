namespace Dfe.Complete.API.Contracts.Project.Conversion
{
    public class CreateConversionProjectRequest
    {
        public DateTime? Date { get; set; }
        public string OutgoingTrustUkprn { get; set; }
        public string IncomingTrustUkprn { get; set; }
        public bool? IsDateProvisional { get; set; }
        public Region? Region { get; set; }
    }
}
