using Dfe.ManageFreeSchoolProjects.API.Contracts.Project.Tasks;
using Dfe.ManageFreeSchoolProjects.API.Exceptions;
using Dfe.ManageFreeSchoolProjects.API.UseCases.Project;
using Dfe.ManageFreeSchoolProjects.API.UseCases.Project.Tasks.ApplicationsEvidence;
using Dfe.ManageFreeSchoolProjects.Data;
using Dfe.ManageFreeSchoolProjects.Data.Entities.Existing;
using Microsoft.EntityFrameworkCore;

namespace Dfe.ManageFreeSchoolProjects.API.UseCases.Tasks;

public interface IGetTasksService
{ 
    Task<ProjectByTaskSummaryResponse> Execute(string projectId);
}

public class GetAllTasksStatusService : IGetTasksService
{
    private readonly MfspContext _context;

    public GetAllTasksStatusService(MfspContext context)
    {
        _context = context;
    }

    public async Task<ProjectByTaskSummaryResponse> Execute(string projectId)
    {
        var dbKpi = await _context.Kpi.FirstOrDefaultAsync(x => x.ProjectStatusProjectId == projectId);

        if (dbKpi == null)
        {
            throw new NotFoundException($"Project with id {projectId} not found");
        }

        var dbTasks = await _context.Tasks.Where(x => x.Rid == dbKpi.Rid).ToListAsync();

        var projectTasks = dbTasks.Select(task =>
        {
            return new TaskSummaryResponse
            {
                Name = task.TaskName.ToString(),
                Status = task.Status.Map()
            };
        });

        ProjectByTaskSummaryResponse result = BuildProjectByTaskSummaryResponse(dbKpi, projectTasks);

        return result;
    }

    private static ProjectByTaskSummaryResponse BuildProjectByTaskSummaryResponse(Kpi dbKpi, IEnumerable<TaskSummaryResponse> projectTasks)
    {
        var result = new ProjectByTaskSummaryResponse
        {
            SchoolName = dbKpi.ProjectStatusCurrentFreeSchoolName,
            School = SafeRetrieveTaskSummary(projectTasks, "School"),
            Dates = SafeRetrieveTaskSummary(projectTasks, "Dates"),
            Trust = SafeRetrieveTaskSummary(projectTasks, "Trust"),
            RegionAndLocalAuthority = SafeRetrieveTaskSummary(projectTasks, "RegionAndLocalAuthority"),
            RiskAppraisalMeeting = SafeRetrieveTaskSummary(projectTasks, "RiskAppraisalMeeting"),
            Constituency = SafeRetrieveTaskSummary(projectTasks, "Constituency"),
            ModelFundingAgreement = SafeRetrieveTaskSummary(projectTasks, "ModelFundingAgreement"),
            StatutoryConsultation = SafeRetrieveTaskSummary(projectTasks, "StatutoryConsultation"),
            ArticlesOfAssociation = SafeRetrieveTaskSummary(projectTasks, "ArticlesOfAssociation"),
            FinancePlan = SafeRetrieveTaskSummary(projectTasks, "FinancePlan"),
            KickOffMeeting = SafeRetrieveTaskSummary(projectTasks, "KickOffMeeting"),
            Gias = SafeRetrieveTaskSummary(projectTasks, "Gias"),
            DraftGovernancePlan = SafeRetrieveTaskSummary(projectTasks, TaskName.DraftGovernancePlan.ToString()),
            EducationBrief = SafeRetrieveTaskSummary(projectTasks, "EducationBrief"),
            EqualitiesAssessment = SafeRetrieveTaskSummary(projectTasks, "EqualitiesAssessment"),
            AdmissionsArrangements = SafeRetrieveTaskSummary(projectTasks, "AdmissionsArrangements"),
            ImpactAssessment = SafeRetrieveTaskSummary(projectTasks, "ImpactAssessment"),
            EvidenceOfAcceptedOffers = SafeRetrieveTaskSummary(projectTasks, "EvidenceOfAcceptedOffers"),
            OfstedInspection = SafeRetrieveTaskSummary(projectTasks, "OfstedInspection"),
            FundingAgreementHealthCheck = SafeRetrieveTaskSummary(projectTasks, "FundingAgreementHealthCheck"),
            PDG = SafeRetrieveTaskSummary(projectTasks, "PDG"),
            FinalFinancePlan = SafeRetrieveTaskSummary(projectTasks, TaskName.FinalFinancePlan.ToString())
        };

        var applicationsEvidenceTask = SafeRetrieveTaskSummary(projectTasks, TaskName.ApplicationsEvidence.ToString());
        result.ApplicationsEvidence = BuildApplicationsEvidenceTask(applicationsEvidenceTask, dbKpi);

        return result;
    }

    private static TaskSummaryResponse SafeRetrieveTaskSummary(IEnumerable<TaskSummaryResponse> projectTasks, string taskName)
    {
        return projectTasks.FirstOrDefault(x => x.Name == taskName, new TaskSummaryResponse { Name = taskName, Status = ProjectTaskStatus.NotStarted });
    }

    private static TaskSummaryResponse BuildApplicationsEvidenceTask(TaskSummaryResponse taskSummaryResponse, Kpi kpi)
    {
        var parameters = new ApplicationsEvidenceTaskSummaryBuilderParameters()
        {
            SchoolType = ProjectMapper.ToSchoolType(kpi.SchoolDetailsSchoolTypeMainstreamApEtc),
            TaskSummary = taskSummaryResponse
        };

        var result = new ApplicationsEvidenceTaskSummaryBuilder().Build(parameters);

        return result;
    }
}

