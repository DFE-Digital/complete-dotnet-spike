namespace Dfe.ManageFreeSchoolProjects.API.Contracts.Project.Tasks
{
    public class DraftGovernancePlanTask
    {
        public bool? PlanReceivedFromTrust { get; set; }

        public DateTime? DatePlanReceived { get; set; }

        public bool? PlanAssessedUsingTemplate { get; set; }

        public bool? PlanAndAssessmentSharedWithExpert { get; set; }

        public bool? PlanAndAssessmentSharedWithEsfa { get; set; }

        public bool? PlanFedBackToTrust { get; set; }

        public bool? SavedDocumentsInWorkplacesFolder { get; set; }

        public string Comments { get; set; }
    }
}
