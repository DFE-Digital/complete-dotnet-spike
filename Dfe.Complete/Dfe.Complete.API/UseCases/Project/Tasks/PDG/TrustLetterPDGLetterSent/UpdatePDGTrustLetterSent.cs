using Dfe.ManageFreeSchoolProjects.Data;
using Dfe.ManageFreeSchoolProjects.Data.Entities.Existing;
using Microsoft.EntityFrameworkCore;

namespace Dfe.ManageFreeSchoolProjects.API.UseCases.Project.Tasks.PDG.TrustLetterPDGLetterSent
{
    public class UpdatePDGTrustLetterSent : IUpdateTaskService
    {
        private readonly MfspContext _context;

        public UpdatePDGTrustLetterSent(MfspContext context)
        {
            _context = context;
        }

        public async Task Update(UpdateTaskServiceParameters parameters)
        {
            var task = parameters.Request.TrustPDGLetterSent;
            var dbKpi = parameters.Kpi;

            if (task is null)
            {
                return;
            }

            var db = await _context.Po.FirstOrDefaultAsync(r => r.Rid == dbKpi.Rid);

            if (db == null)
            {
                db = new Po();
                db.Rid = dbKpi.Rid;
                _context.Add(db);
            }

            db.ProjectDevelopmentGrantFundingPdgGrantLetterDate = task.TrustSignedPDGLetterDate;
            db.PdgGrantLetterLinkSavedToWorkplaces = task.PDGLetterSavedInWorkspaces;
        }
    }
}
