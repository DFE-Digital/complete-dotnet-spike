namespace Dfe.Complete.API.Contracts.Project.Transfer
{
    public class UpdateTransferProjectRequest
    {
        public string SchoolSharePointLink { get; set; }

        public UpdateTrustDetails OutgoingTrustDetails { get; set; } = new();

        public UpdateTrustDetails IncomingTrustDetails { get; set; } = new();

        public ReasonForTheTransfer ReasonForTheTransfer { get; set; } = new();

        public AdvisoryBoardDetails AdvisoryBoardDetails { get; set; } = new();
    }

    public record UpdateTrustDetails
    {
        public string Ukprn { get; set; }
        public string SharePointLink { get; set; }
    }
}
