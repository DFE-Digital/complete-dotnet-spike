
using Dfe.ManageFreeSchoolProjects.Data;
using Microsoft.EntityFrameworkCore;

namespace Dfe.ManageFreeSchoolProjects.API.UseCases.Project.Tasks.ApplicationsEvidence
{
    public class UpdateApplicationsEvidenceTaskService : IUpdateTaskService
    {
        
        private readonly MfspContext _context;

        public UpdateApplicationsEvidenceTaskService(MfspContext context)
        {
            _context = context;
        }
        
        public async Task Update(UpdateTaskServiceParameters parameters)
        {
            var task = parameters.Request.ApplicationsEvidence;
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

            db.FsgPreOpeningMilestonesApplicationsEvidenceConfirmedPupilNumbers =
                task.ConfirmedPupilNumbers;
            db.FsgPreOpeningMilestonesApplicationsEvidenceComments =
                task.Comments;
            db.FsgPreOpeningMilestonesApplicationsEvidenceBuildUpFormSavedToWorkplaces = task.BuildUpFormSavedToWorkplaces;
            db.FsgPreOpeningMilestonesApplicationsEvidenceUnderwritingAgreementSavedToWorkplaces =
                task.UnderwritingAgreementSavedToWorkplaces;
        }
    }
}
