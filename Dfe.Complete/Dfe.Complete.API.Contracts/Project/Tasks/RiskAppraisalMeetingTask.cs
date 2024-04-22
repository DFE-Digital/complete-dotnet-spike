namespace Dfe.ManageFreeSchoolProjects.API.Contracts.Project.Tasks
{
    public record RiskAppraisalMeetingTask
    {
        public bool? InitialRiskAppraisalMeetingCompleted { get; set; }
        public DateTime? ForecastDate { get; set; }
        public DateTime? ActualDate { get; set; }
        public string CommentsOnDecisionToApprove { get; set; }
        public string ReasonNotApplicable { get; set; }
    }
}
