namespace Dfe.ManageFreeSchoolProjects.API.Contracts.Project.Risk
{
    public class CreateProjectRiskRequest
    {
        public ProjectRiskEntryRequest GovernanceAndSuitability { get; set; } = new();

        public ProjectRiskEntryRequest Education { get; set; } = new();

        public ProjectRiskEntryRequest Finance { get; set; } = new();

        public ProjectRiskEntryRequest Overall { get; set; } = new();

        public string RiskAppraisalFormSharepointLink { get; set; }
    }

    public class ProjectRiskEntryRequest
    {
        public ProjectRiskRating? RiskRating { get; set; }
        public string Summary { get; set; }
    }
}
