namespace Dfe.Complete.API.Contracts.Project.Transfer
{
    public class CreateTransferProjectRequest
    {
        public string Urn { get; set; }
        public DateTime? Date { get; set; }
        public string OutgoingTrustUkprn { get; set; }
        public string IncomingTrustUkprn { get; set; }
        public bool? IsDateProvisional { get; set; }
        public Region? Region { get; set; }
        public bool? IsIsDueTo2RI { get; set; }
        public bool? IsDueToOfstedRating { get; set; }
        public bool? IsDueToIssues { get; set; }
        public DateTime? AdvisoryBoardDate { get; set; }
        public string AdvisoryBoardConditions { get; set; }
    }
}
