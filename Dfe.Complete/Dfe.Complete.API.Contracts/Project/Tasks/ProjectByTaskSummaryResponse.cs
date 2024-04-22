using System.ComponentModel;

namespace Dfe.ManageFreeSchoolProjects.API.Contracts.Project.Tasks
{
    public class ProjectByTaskSummaryResponse
    {
        public string SchoolName { get; set; }
        public TaskSummaryResponse School { get; set; }

        public TaskSummaryResponse Dates { get; set; }

        public TaskSummaryResponse Trust { get; set; }
        
        public TaskSummaryResponse Constituency { get; set; }
        
        public TaskSummaryResponse RegionAndLocalAuthority { get; set; }

        public TaskSummaryResponse RiskAppraisalMeeting { get; set; }
        
        public TaskSummaryResponse KickOffMeeting { get; set; }
        
        public TaskSummaryResponse ModelFundingAgreement { get; set; }

        public TaskSummaryResponse StatutoryConsultation { get; set; }

        public TaskSummaryResponse ArticlesOfAssociation { get; set; }

        public TaskSummaryResponse FinancePlan { get; set; }

        public TaskSummaryResponse DraftGovernancePlan { get; set; }
        
        public TaskSummaryResponse Gias { get; set; }

        public TaskSummaryResponse EducationBrief { get; set; }

        public TaskSummaryResponse AdmissionsArrangements { get; set; }

        public TaskSummaryResponse EqualitiesAssessment { get; set; }

        public TaskSummaryResponse ImpactAssessment { get; set; }

        public TaskSummaryResponse EvidenceOfAcceptedOffers { get; set; }

        public TaskSummaryResponse OfstedInspection { get; set; }

        public TaskSummaryResponse ApplicationsEvidence { get; set; }

        public TaskSummaryResponse FundingAgreementHealthCheck { get; set; }
        public TaskSummaryResponse PDG { get; set; }
        public TaskSummaryResponse FinalFinancePlan { get; set; }
    }

    public class TaskSummaryResponse
    {
        public string Name { get; set; }
        public ProjectTaskStatus Status { get; set; }

        public bool IsHidden { get; set; }
    }
}
