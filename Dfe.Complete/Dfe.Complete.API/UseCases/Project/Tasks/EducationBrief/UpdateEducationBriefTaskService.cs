using Dfe.ManageFreeSchoolProjects.Data;
using Microsoft.EntityFrameworkCore;

namespace Dfe.ManageFreeSchoolProjects.API.UseCases.Project.Tasks.EducationBrief;

public class UpdateEducationBriefTaskService : IUpdateTaskService
{
    private readonly MfspContext _context;

    public UpdateEducationBriefTaskService(MfspContext context)
    {
        _context = context;
    }

    public async Task Update(UpdateTaskServiceParameters parameters)
    {
        var task = parameters.Request.EducationBrief;
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

        db.FSGPreOpeningMilestonesEducationPlanInBrief = task.EducationPlanInEducationBrief;
        db.FSGPreOpeningMilestonesEducationPolicesInBrief = task.EducationPolicesInEducationBrief;
        db.FSGPreOpeningMilestonesEducationBriefPupilAssessmentAndTrackingHistory = task.PupilAssessmentAndTrackingHistoryInPlace;
        db.FSGPreOpeningMilestonesEducationBriefSavedToWorkplaces = task.EducationBriefSavedToWorkplaces;
    }
}
