
using Dfe.ManageFreeSchoolProjects.Data;
using Dfe.ManageFreeSchoolProjects.Data.Entities.Existing;
using Microsoft.EntityFrameworkCore;

namespace Dfe.ManageFreeSchoolProjects.API.UseCases.Project.Tasks.FundingAgreementHealthCheck
{
    public class UpdateFundingAgreementHealthCheckTaskService : IUpdateTaskService
    {
        private readonly MfspContext _context;

        public UpdateFundingAgreementHealthCheckTaskService(MfspContext context)
        {
            _context = context;
        }

        public async Task Update(UpdateTaskServiceParameters parameters)
        {
            var task = parameters.Request.FundingAgreementHealthCheck;
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

            milestone.FsgPreOpeningMilestonesMfadDraftedFaHealthCheck = task.DraftedFundingAgreementHealthCheck;
            milestone.FsgPreOpeningMilestonesMfadRegionalDirectorSignedOffFaHealthCheck = task.RegionalDirectorSignedOffFundingAgreementHealthCheck;
            milestone.FsgPreOpeningMilestonesMfadMinisterSignedOffFaHealthCheck = task.MinisterSignedOffFundingAgreementHealthCheck;
            milestone.FsgPreOpeningMilestonesMfadSavedFaHealthCheckInWorkplacesFolder = task.SavedFundingAgreementHealthCheckInWorkplacesFolder;

            await _context.SaveChangesAsync();
        }
    }
}
