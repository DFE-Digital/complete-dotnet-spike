using Dfe.ManageFreeSchoolProjects.Data;
using Dfe.ManageFreeSchoolProjects.Data.Entities.Existing;
using Microsoft.EntityFrameworkCore;

namespace Dfe.ManageFreeSchoolProjects.API.UseCases.Project.Tasks.DraftGovernancePlan
{
    public class UpdateDraftGovernancePlanTaskService : IUpdateTaskService
    {
        private readonly MfspContext _context;

        public UpdateDraftGovernancePlanTaskService(MfspContext context)
        {
            _context = context;
        }

        public async Task Update(UpdateTaskServiceParameters parameters)
        {
            var task = parameters.Request.DraftGovernancePlan;
            var dbKpi = parameters.Kpi;

            if (task is null)
            {
                return;
            }

            var milestone = await _context.Milestones.FirstOrDefaultAsync(r => r.Rid == dbKpi.Rid);

            if (milestone == null)
            {
                milestone = new Milestones();
                milestone.Rid = dbKpi.Rid;
                _context.Add(milestone);
            }

            milestone.Rid = dbKpi.Rid;
            milestone.FsgPreOpeningMilestonesDgpActualDateOfCompletion = task.DatePlanReceived;
            milestone.DraftGovernancePlanDocumentsSavedInWorkplacesFolder = task.SavedDocumentsInWorkplacesFolder;
            milestone.DraftGovernancePlanAndAssessmentSharedWithEsfa = task.PlanAndAssessmentSharedWithEsfa;
            milestone.DraftGovernancePlanAndAssessmentSharedWithExpert = task.PlanAndAssessmentSharedWithExpert;
            milestone.DraftGovernancePlanAssessedUsingTemplate = task.PlanAssessedUsingTemplate;
            milestone.DraftGovernancePlanFedBackToTrust = task.PlanFedBackToTrust;
            milestone.DraftGovernancePlanReceivedFromTrust = task.PlanReceivedFromTrust;
            milestone.FsgPreOpeningMilestonesMi60CommentsOnDecisionToApproveIfApplicable = task.Comments;

            await _context.SaveChangesAsync();
        }
    }
}
