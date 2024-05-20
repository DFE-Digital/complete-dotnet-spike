namespace Dfe.Complete.API.Contracts.Project
{
    public record CreateProjectRequest
    {
        public string Urn { get; set; }
        public DateTime? Date { get; set; }
        public bool? IsDateProvisional { get; set; }
        public string SchoolSharePointLink { get; set; }
        public Region? Region { get; set; }
        public bool? IsIsDueTo2RI { get; set; }
        public AdvisoryBoardDetails AdvisoryBoardDetails { get; set; } = new();
        public CreateTrustDetails IncomingTrustDetails { get; set; } = new();
    }

    public record CreateTrustDetails
    {
        public string Ukprn { get; set; }
        public string SharepointLink { get; set; }
    }
}
