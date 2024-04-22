
using Dfe.ManageFreeSchoolProjects.Data;
using Dfe.ManageFreeSchoolProjects.Data.Entities.Existing;
using Microsoft.EntityFrameworkCore;

namespace Dfe.ManageFreeSchoolProjects.API.UseCases.Project.Tasks.FinalFinancePlan
{
    public class UpdateFinalFinancePlanTaskService : IUpdateTaskService
    {
        private readonly MfspContext _context;

        public UpdateFinalFinancePlanTaskService(MfspContext context)
        {
            _context = context;
        }

        public async Task Update(UpdateTaskServiceParameters parameters)
        {
            var task = parameters.Request.FinalFinancePlan;
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
            milestone.FsgPreOpeningMilestonesFfpConfirmedTrustHasProvidedFinalPlan = task.ConfirmedTrustHasProvidedFinalPlan;
            milestone.FsgPreOpeningMilestonesFfpGrade6SignedOffFinalPlanDate = task.Grade6SignedOffFinalPlanDate;
            milestone.FsgPreOpeningMilestonesFfpSentFinalPlanToRevenueFundingMailbox = task.SentFinalPlanToRevenueFundingMailbox;
            milestone.FsgPreOpeningMilestonesFfpSavedFinalPlanInWorkplacesFolder = task.SavedFinalPlanInWorkplacesFolder;

            await _context.SaveChangesAsync();
        }
    }
}
