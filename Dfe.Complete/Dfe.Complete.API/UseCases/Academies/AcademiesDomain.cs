namespace Dfe.Complete.API.UseCases.Academies
{
    public record GetEstablishmentResponse
    {
        public string Urn { get; set; }
        public string Name { get; set; }
        public string LocalAuthorityName { get; set; }
    }

    public record GetTrustResponse
    {
        public string Ukprn { get; set; }
        public string Name { get; set; }
    }
}
