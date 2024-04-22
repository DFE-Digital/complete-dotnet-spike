using Dfe.ManageFreeSchoolProjects.API.Contracts.Project.Tasks;
using Dfe.ManageFreeSchoolProjects.API.UseCases.Project.Tasks.AdmissionsArrangements;
using Dfe.ManageFreeSchoolProjects.API.UseCases.Project.Tasks.ApplicationsEvidence;
using Dfe.ManageFreeSchoolProjects.API.UseCases.Project.Tasks.ArticlesOfAssociation;
using Dfe.ManageFreeSchoolProjects.API.UseCases.Project.Tasks.Constituency;
using Dfe.ManageFreeSchoolProjects.API.UseCases.Project.Tasks.Dates;
using Dfe.ManageFreeSchoolProjects.API.UseCases.Project.Tasks.DraftGovernancePlan;
using Dfe.ManageFreeSchoolProjects.API.UseCases.Project.Tasks.EducationBrief;
using Dfe.ManageFreeSchoolProjects.API.UseCases.Project.Tasks.EvidenceOfAcceptedOffers;
using Dfe.ManageFreeSchoolProjects.API.UseCases.Project.Tasks.FinancePlan;
using Dfe.ManageFreeSchoolProjects.API.UseCases.Project.Tasks.Gias;
using Dfe.ManageFreeSchoolProjects.API.UseCases.Project.Tasks.ImpactAssessment;
using Dfe.ManageFreeSchoolProjects.API.UseCases.Project.Tasks.KickOffMeeting;
using Dfe.ManageFreeSchoolProjects.API.UseCases.Project.Tasks.ModelFundingAgreement;
using Dfe.ManageFreeSchoolProjects.API.UseCases.Project.Tasks.RegionAndLocalAuthority;
using Dfe.ManageFreeSchoolProjects.API.UseCases.Project.Tasks.RiskAppraisalMeeting;
using Dfe.ManageFreeSchoolProjects.API.UseCases.Project.Tasks.School;
using Dfe.ManageFreeSchoolProjects.API.UseCases.Project.Tasks.Trusts;
using Dfe.ManageFreeSchoolProjects.API.UseCases.Project.Tasks.StatutoryConsultation;
using Dfe.ManageFreeSchoolProjects.Data;
using Microsoft.EntityFrameworkCore;
using Dfe.ManageFreeSchoolProjects.API.UseCases.Project.Tasks.EqualitiesAssessment;
using Dfe.ManageFreeSchoolProjects.API.UseCases.Project.Tasks.OfstedInspection;
using Dfe.ManageFreeSchoolProjects.API.UseCases.Project.Tasks.FundingAgreementHealthCheck;
using Dfe.ManageFreeSchoolProjects.API.UseCases.Project.Tasks.PDG;
using Dfe.ManageFreeSchoolProjects.API.UseCases.Project.Tasks.PDG.TrustLetterPDGLetterSent;
using Dfe.ManageFreeSchoolProjects.API.UseCases.Project.Tasks.PDG.PaymentSchedule;
using Dfe.ManageFreeSchoolProjects.API.UseCases.Project.Tasks.PDG.StopPayments;
using Dfe.ManageFreeSchoolProjects.API.UseCases.Project.Tasks.PDG.Refunds;
using Dfe.ManageFreeSchoolProjects.API.UseCases.Project.Tasks.PDG.WriteOff;
using Dfe.ManageFreeSchoolProjects.API.UseCases.Project.Tasks.FinalFinancePlan;

namespace Dfe.ManageFreeSchoolProjects.API.UseCases.Project.Tasks
{
    public interface IGetProjectByTaskService
    {
        public Task<GetProjectByTaskResponse> Execute(string projectId, TaskName taskName);
    }

    public class GetProjectByTaskService : IGetProjectByTaskService
    {
        private readonly MfspContext _context;

        public GetProjectByTaskService(MfspContext context)
        {
            _context = context;
        }

        public async Task<GetProjectByTaskResponse> Execute(string projectId, TaskName taskName)
        {
            var query = _context.Kpi.Where(kpi => kpi.ProjectStatusProjectId == projectId);

            var parameters = new GetTaskServiceParameters()
            {
                ProjectId = projectId,
                BaseQuery = query
            };

            GetProjectByTaskResponse result = null;

            switch (taskName)
            {
                case TaskName.School:
                    result = await new GetSchoolTaskService().Get(parameters);
                    break;
                case TaskName.Dates:
                    result = await new GetDatesTaskService().Get(parameters);
                    break;
                case TaskName.RiskAppraisalMeeting:
                    result = await new GetRiskAppraisalMeetingTaskService(_context).Get(parameters);
                    break;
                case TaskName.Trust:
                    result = await new GetTrustTaskService().Get(parameters);
                    break;
                case TaskName.RegionAndLocalAuthority:
                    result = await new GetRegionAndLocalAuthorityTaskService().Get(parameters);
                    break;
                case TaskName.Constituency:
                    result = await new GetConstituencyTaskService().Get(parameters);
                    break;
                case TaskName.KickOffMeeting:
                    result = await new GetKickOffMeetingTaskService(_context).Get(parameters);
                    break;
                case TaskName.ModelFundingAgreement:
                    result = await new GetModelFundingAgreementTaskService(_context).Get(parameters);
                    break;
                case TaskName.StatutoryConsultation:
                    result = await new GetStatutoryConsultationTaskService(_context).Get(parameters);
                    break;
                case TaskName.ArticlesOfAssociation:
                    result = await new GetArticlesOfAssociationTaskService(_context).Get(parameters);
                    break;
                case TaskName.FinancePlan:
                    result = await new GetFinancePlanTaskService(_context).Get(parameters);
                    break;
                case TaskName.DraftGovernancePlan:
                    result = await new GetDraftGovernancePlanTaskService(_context).Get(parameters);
                    break;
                case TaskName.Gias:
                    result = await new GetGiasTaskService(_context).Get(parameters);
                    break;
                case TaskName.EducationBrief:
                    result = await new GetEducationBriefTaskService(_context).Get(parameters);
                    break;
                case TaskName.AdmissionsArrangements:
                    result = await new GetAdmissionsArrangementsTaskService(_context).Get(parameters);
                    break;
                case TaskName.EqualitiesAssessment:
                    result = await new GetEqualitiesAssessmentTaskService(_context).Get(parameters);
                    break;
                case TaskName.ImpactAssessment:
                    result = await new GetImpactAssessmentTaskService(_context).Get(parameters);
                    break;
                case TaskName.EvidenceOfAcceptedOffers:
                    result = await new GetEvidenceOfAcceptedOffersTaskService(_context).Get(parameters);
                    break;
                case TaskName.OfstedInspection:
                    result = await new GetOfstedInspectionTaskService(_context).Get(parameters);
                    break;
                case TaskName.ApplicationsEvidence:
                    result = await new GetApplicationsEvidenceTaskService(_context).Get(parameters);
                    break;
                case TaskName.FundingAgreementHealthCheck:
                    result = await new GetFundingAgreementHealthCheckTaskService(_context).Get(parameters);
                    break;
                case TaskName.PDG:
                    result = await new GetPDGDashboardService(_context).Get(parameters);
                    break;
                case TaskName.PaymentSchedule:
                    result = await new GetPaymentScheduleService(_context).Get(parameters);
                    break;
                case TaskName.TrustPDGLetterSent:
                    result = await new GetTrustPDGLetterSentService(_context).Get(parameters);
                    break;
                case TaskName.StopPayment:
                    result = await new GetStopPaymentService(_context).Get(parameters);
                    break;
                case TaskName.Refunds:
                    result = await new GetRefundsService(_context).Get(parameters);
                    break;
                case TaskName.WriteOff:
                    result = await new GetWriteOffService(_context).Get(parameters);
                    break;
                case TaskName.FinalFinancePlan:
                    result = await new GetFinalFinancePlanTaskService(_context).Get(parameters);
                    break;
                default:
                    throw new ArgumentException($"Unknown task name {taskName}");
            }

            if (result != null)
            {
                var schoolName = await query.Select(kpi => kpi.ProjectStatusCurrentFreeSchoolName).FirstOrDefaultAsync();
                result.SchoolName = schoolName;
            }

            return result;
        }
    }
}