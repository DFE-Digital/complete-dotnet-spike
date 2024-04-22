
using Dfe.ManageFreeSchoolProjects.Data;
using Dfe.ManageFreeSchoolProjects.Data.Entities.Existing;
using Microsoft.EntityFrameworkCore;

namespace Dfe.ManageFreeSchoolProjects.API.UseCases.Project.Tasks.EvidenceOfAcceptedOffers
{
    public class UpdateEvidenceOfAcceptedOffersTaskService : IUpdateTaskService
    {
        
        private readonly MfspContext _context;

        public UpdateEvidenceOfAcceptedOffersTaskService(MfspContext context)
        {
            _context = context;
        }
        
        public async Task Update(UpdateTaskServiceParameters parameters)
        {
            var task = parameters.Request.EvidenceOfAcceptedOffers;
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

            db.FsgPreOpeningMilestonesSeenEvidenceOfAcceptedOffers =
                task.EvidenceOfAcceptedOffers;
            db.FsgPreOpeningMilestonesAcceptedOffersComments =
                task.Comments;
            db.FsgPreOpeningMilestonesAcceptedOffersEmailSavedToWorkplaces = task.SavedToWorkplaces;
        }
    }
}
