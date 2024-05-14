namespace Dfe.Complete.API.Contracts.Project.Transfer
{
    public class CreateTransferProjectRequest
    {
        public DateTime? Date { get; set; }
        public int? OutgoingTrustUkprn { get; set; }
        public int? IncomingTrustUkprn { get; set; }
        public bool? IsDateProvisional { get; set; }
        public Region? Region { get; set; }
    }
}
