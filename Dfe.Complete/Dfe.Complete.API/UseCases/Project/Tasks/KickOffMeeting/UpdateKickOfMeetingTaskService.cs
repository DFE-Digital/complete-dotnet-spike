using Dfe.ManageFreeSchoolProjects.Data;
using Microsoft.EntityFrameworkCore;

namespace Dfe.ManageFreeSchoolProjects.API.UseCases.Project.Tasks.KickOffMeeting
{
    public class UpdateKickOffMeetingTaskService : IUpdateTaskService
    {
        private readonly MfspContext _context;

        public UpdateKickOffMeetingTaskService(MfspContext context)
        {
            _context = context;
        }

        public async Task Update(UpdateTaskServiceParameters parameters)
        {
            var task = parameters.Request.KickOffMeeting;
            var dbKpi = parameters.Kpi;

            if (task is null)
            {
                return;
            }

            var db = await _context.Milestones.FirstOrDefaultAsync(r => r.Rid == dbKpi.Rid);

            if (db == null)
            {
                db = new Data.Entities.Existing.Milestones();
                db.Rid = dbKpi.Rid;
                _context.Add(db);
            }

            dbKpi.ProjectStatusProvisionalOpeningDateAgreedWithTrust = task.ProvisionalOpeningDate;
            dbKpi.ProjectStatusRealisticYearOfOpening = task.RealisticYearOfOpening;
            db.FsgPreOpeningMilestonesFundingArrangementAgreedBetweenLaAndSponsor = task.FundingArrangementAgreed ?? false;
            db.FsgPreOpeningMilestonesDetailsOfFundingArrangementAgreedBetweenLaAndSponsor =
                task.FundingArrangementDetailsAgreed;
            db.FsgPreOpeningMilestonesMi141LinkToSavedDocument = task.SharepointLink;
        }
    }
}