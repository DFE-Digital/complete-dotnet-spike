namespace Dfe.Complete.API.Contracts.Project.Transfer
{
    public class UpdateTransferProjectRequest
    {
        public string SchoolSharePointLink { get; set; }

        public string OutgoingTrustUkprn { get; set; }

        public string OutgoingTrustSharePointLink { get; set; }

        public string IncomingTrustUkprn { get; set; }

        public string IncomingTrustSharePointLink { get; set; }

        public ReasonForTheTransfer ReasonForTheTransfer { get; set; } = new();

        public AdvisoryBoardDetails AdvisoryBoardDetails { get; set; } = new();
    }
}
