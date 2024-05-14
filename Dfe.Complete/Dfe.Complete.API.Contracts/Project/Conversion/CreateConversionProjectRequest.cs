namespace Dfe.Complete.API.Contracts.Project.Conversion
{
    public class CreateConversionProjectRequest
    {
        public DateTime? Date { get; set; }
        public int? OutgoingTrustUkprn { get; set; }
        public int? IncomingTrustUkprn { get; set; }
        public bool? IsDateProvisional { get; set; }
        public Region? Region { get; set; }
    }
}
