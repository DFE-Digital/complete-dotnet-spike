namespace Dfe.Complete.API.UseCases.Academies
{
    public record GetEstablishmentResponse
    {
        public string Urn { get; set; }
        public string Name { get; set; }
        public string LocalAuthorityName { get; set; }
        public PhaseOfEducation PhaseOfEducation { get; set; } = new();
        public EstablishmentType EstablishmentType { get; set; } = new();
        public Diocese Diocese { get; set; } = new();
        public Address Address { get; set; } = new();

        public string StatutoryLowAge { get; set; }

        public string StatutoryHighAge { get; set; }

        public string DioceseName { get; set; }

        public string ToAgeRange()
        {
            return $"{StatutoryLowAge}-{StatutoryHighAge}";
        }
    }

    public record GetTrustResponse
    {
        public string Ukprn { get; set; }
        public string Name { get; set; }
        public string ReferenceNumber { get; set; }
        public string CompaniesHouseNumber { get; set; }
        public Address Address { get; set; } = new();
    }

    public record Address
    {
        public string Street { get; set; }
        public string Locality { get; set; }
        public string Additional { get; set; }
        public string Town { get; set; }
        public string County { get; set; }
        public string Postcode { get; set; }
    }

    public record PhaseOfEducation
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }

    public record EstablishmentType
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }

    public record Diocese
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }

}
