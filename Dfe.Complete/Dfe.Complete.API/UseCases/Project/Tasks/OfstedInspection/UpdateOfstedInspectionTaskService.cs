
using Dfe.ManageFreeSchoolProjects.Data;
using Dfe.ManageFreeSchoolProjects.Data.Entities.Existing;
using Microsoft.EntityFrameworkCore;

namespace Dfe.ManageFreeSchoolProjects.API.UseCases.Project.Tasks.OfstedInspection
{
    public class UpdateOfstedInspectionTaskService : IUpdateTaskService
    {
        
        private readonly MfspContext _context;

        public UpdateOfstedInspectionTaskService(MfspContext context)
        {
            _context = context;
        }
        
        public async Task Update(UpdateTaskServiceParameters parameters)
        {
            var task = parameters.Request.OfstedInspection;
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

            db.FsgPreOpeningMilestonesProcessDetailsProvided = task.ProcessDetailsProvided;
            db.FsgPreOpeningMilestonesInspectionBlockDecided = task.InspectionBlockDecided;
            db.FsgPreOpeningMilestonesOfstedAndTrustLiaisonDetailsConfirmed = task.OfstedAndTrustLiaisonDetailsConfirmed;
            db.FsgPreOpeningMilestonesBlockAndContentDetailsToOpenersSpreadSheet = task.BlockAndContentDetailsToOpenersSpreadSheet;
            db.FsgPreOpeningMilestonesSharedOutcomeWithTrust = task.SharedOutcomeWithTrust;
            db.FsgPreOpeningMilestonesInspectionConditionsMet = InspectionConditionsMet(task.InspectionConditionsMet);
            db.FsgPreOpeningMilestonesProposedToOpenOnGias = task.ProposedToOpenOnGias;
            db.FsgPreOpeningMilestonesDocumentsAndG6SavedToWorkplaces = task.SavedToWorkplaces;
        }
        
        private static string InspectionConditionsMet(bool? conditionMet)
        {
            switch (conditionMet)
            {
                case true:
                    return "Yes";
                case false:
                    return "No";
                default:
                    return null;
            }
        }
    }
}
