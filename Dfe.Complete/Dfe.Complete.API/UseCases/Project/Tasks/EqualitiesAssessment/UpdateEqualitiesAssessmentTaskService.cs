using Dfe.ManageFreeSchoolProjects.Data;
using Dfe.ManageFreeSchoolProjects.Data.Entities.Existing;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace Dfe.ManageFreeSchoolProjects.API.UseCases.Project.Tasks.EqualitiesAssessment
{
    public class UpdateEqualitiesAssessmentTaskService : IUpdateTaskService
    {
        private readonly MfspContext _context;

        public UpdateEqualitiesAssessmentTaskService(MfspContext context)
        {
            _context = context;
        }

        public async Task Update(UpdateTaskServiceParameters parameters)
        {
            var task = parameters.Request.EqualitiesAssessment;
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

            db.EqualitiesAssessmentCompletedEPR = task.CompletedEqualitiesProcessRecord;
            db.EqualitiesAssessmentSavedEPRInWorkplacesFolder = task.SavedEPRInWorkplacesFolder;

        }
    }
}