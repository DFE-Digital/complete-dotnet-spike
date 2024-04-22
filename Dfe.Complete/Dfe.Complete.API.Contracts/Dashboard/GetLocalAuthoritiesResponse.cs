namespace Dfe.ManageFreeSchoolProjects.API.Contracts.Dashboard
{
    public record GetLocalAuthoritiesResponse
    {
        public List<RegionResponse> Regions { get; set; } = new();
    }

    public record RegionResponse
    {
        public string RegionName { get; set; }
        public List<LocalAuthorityResponse> LocalAuthorities { get; set; }
    }

    public record LocalAuthorityResponse
    {
        public string Name { get; set; }
        public string LACode { get; set; }
    }
}
