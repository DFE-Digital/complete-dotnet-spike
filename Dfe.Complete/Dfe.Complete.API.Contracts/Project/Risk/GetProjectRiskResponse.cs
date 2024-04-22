using System.ComponentModel;

namespace Dfe.ManageFreeSchoolProjects.API.Contracts.Project.Risk
{
    public class GetProjectRiskResponse
    {
        public DateTime? Date { get; set; }

        public ProjectRiskEntryResponse GovernanceAndSuitability { get; set; } = new();

        public ProjectRiskEntryResponse Education { get; set; } = new();

        public ProjectRiskEntryResponse Finance { get; set; } = new();

        public ProjectRiskEntryResponse Overall { get; set; } = new();

        public string RiskAppraisalFormSharepointLink { get; set; }

        public List<ProjectRiskHistoryResponse> History { get; set; } = new List<ProjectRiskHistoryResponse>();
    }

    public class ProjectRiskHistoryResponse
    {
        public DateTime? Date { get; set; }
        public ProjectRiskRating? RiskRating { get; set; }
    }

    public class ProjectRiskEntryResponse
    {
        public ProjectRiskRating? RiskRating { get; set; }
        public string Summary { get; set; }
    }

    public enum ProjectRiskRating
    {
        [Description("Green")]
        Green = 1,
        [Description("Amber/Green")]
        AmberGreen = 2,
        [Description("Amber/Red")]
        AmberRed = 3,
        [Description("Red")]
        Red = 4
    }
}
