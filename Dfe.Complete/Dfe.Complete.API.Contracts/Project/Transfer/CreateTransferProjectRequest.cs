namespace Dfe.Complete.API.Contracts.Project.Transfer
{
    public record CreateTransferProjectRequest : CreateProjectRequest
    {
        public CreateTrustDetails OutgoingTrustDetails { get; set; } = new();
        public bool? IsDueToOfstedRating { get; set; }
        public bool? IsDueToIssues { get; set; }
    }
}
