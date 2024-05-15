namespace Dfe.Complete.API.Contracts.Project
{
    public record ProjectDetails
    {
        public string Urn { get; set; }

        public string Name { get; set; }

        public DateTime? Date { get; set; }

        public bool? IsDateProvisional { get; set; }

        public string IncomingTrustUkprn { get; set; }

        public string IncomingTrustName { get; set; }

        public string OutgoingTrustUkprn { get; set; }

        public string OutgoingTrustName { get; set; }

        public ProjectType? ProjectType { get; set; }

        public string LocalAuthority { get; set; }

        public string Region { get; set; }
    }
}
