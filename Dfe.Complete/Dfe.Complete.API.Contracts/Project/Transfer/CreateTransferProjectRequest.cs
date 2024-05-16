namespace Dfe.Complete.API.Contracts.Project.Transfer
{
    public record CreateTransferProjectRequest : CreateProjectRequest
    {
        public string OutgoingTrustUkprn { get; set; }
        public string OutgoingTrustSharePointLink { get; set; }
        public bool? IsDueToOfstedRating { get; set; }
        public bool? IsDueToIssues { get; set; }
    }
}
