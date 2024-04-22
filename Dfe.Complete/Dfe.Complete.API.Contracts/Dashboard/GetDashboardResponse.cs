namespace Dfe.ManageFreeSchoolProjects.API.Contracts.Dashboard
{
    public class GetDashboardResponse
    {
        public string ProjectTitle { get; set; }

        public string ProjectId { get; set; }

        public string TrustName { get; set; }

        public string Region { get; set; }

        public string LocalAuthority { get; set; }

        public DateTime? RealisticOpeningDate { get; set; }

        public string Status { get; set; }

        public string ProjectManagedBy { get; set; }
    }
}
