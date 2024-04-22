
using Dfe.ManageFreeSchoolProjects.Data;
using Dfe.ManageFreeSchoolProjects.Data.Entities.Existing;
using Microsoft.EntityFrameworkCore;

namespace Dfe.ManageFreeSchoolProjects.API.UseCases.Project.Tasks.FinancePlan
{
    public class UpdateFinancePlanTaskService : IUpdateTaskService
    {
        private readonly MfspContext _context;

        public UpdateFinancePlanTaskService(MfspContext context)
        {
            _context = context;
        }

        public async Task Update(UpdateTaskServiceParameters parameters)
        {
            var task = parameters.Request.FinancePlan;
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
            milestone.FsgPreOpeningMilestonesBefpApplicable = task.FinancePlanAgreed?.ToString();
            milestone.FsgPreOpeningMilestonesBefpActualDateOfCompletion = task.DateAgreed?.Date;
            milestone.FinancePlanSavedInWorkplacesFolder = task.PlanSavedInWorksplacesFolder;
            milestone.LAAgreedPupilNumbers = task.LocalAuthorityAgreedPupilNumbers;
            milestone.FsgPreOpeningMilestonesMi72CommentsOnDecisionToApproveIfApplicable = task.Comments;
            milestone.TrustOptInRPA = task.TrustWillOptIntoRpa;
            milestone.RPAStartDate = task.RpaStartDate;
            milestone.RPACoverType = task.RpaCoverType;

            await _context.SaveChangesAsync();
        }
    }
}
