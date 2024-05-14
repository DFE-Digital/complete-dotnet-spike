namespace Dfe.Complete.API.Contracts.Project
{
    public record ProjectDetails
    {
        public int Urn { get; set; }

        public DateTime? Date { get; set; }

        public bool? IsDateProvisional { get; set; }

        public int? IncomingTrustUkprn { get; set; }

        public string IncomingTrustName { get; set; }

        public int? OutgoingTrustUkprn { get; set; }

        public string OutgoingTrustName { get; set; }

        public ProjectType ProjectType { get; set; }

        public string LocalAuthority { get; set; }

        public string Region { get; set; }
    }
}
