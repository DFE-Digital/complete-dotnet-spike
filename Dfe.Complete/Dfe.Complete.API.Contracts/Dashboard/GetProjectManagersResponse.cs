namespace Dfe.ManageFreeSchoolProjects.API.Contracts.Dashboard
{
    public record GetProjectManagersResponse
    {
        public List<string> ProjectManagers { get; set; } = new();
    }
}