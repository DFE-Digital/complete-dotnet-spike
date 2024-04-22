namespace Dfe.ManageFreeSchoolProjects.API.Contracts.Project.Sites
{
    public class ProjectSite
    {
        public ProjectSiteAddress Address { get; set; } = new();
        public DateTime? StartDateOfSiteOccupation { get; set; }
        public DateTime? DatePlanningPermissionObtained { get; set; }
    }

    public class ProjectSiteAddress
    {
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string TownOrCity { get; set; }
        public string Postcode { get; set; }
    }
}
