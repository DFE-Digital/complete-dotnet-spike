using Dfe.ManageFreeSchoolProjects.Data;
using Dfe.ManageFreeSchoolProjects.Data.Entities.Existing;
using Microsoft.EntityFrameworkCore;

namespace Dfe.ManageFreeSchoolProjects.API.UseCases.Project.Tasks.ArticlesOfAssociation
{
    public class UpdateArticlesOfAssociationTaskService : IUpdateTaskService
    {
        private readonly MfspContext _context;

        public UpdateArticlesOfAssociationTaskService(MfspContext context)
        {
            _context = context;
        }

        public async Task Update(UpdateTaskServiceParameters parameters)
        {
            var task = parameters.Request.ArticlesOfAssociation;
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

            db.MAACheckedSubmittedArticlesMatch = task.CheckedSubmittedArticlesMatch ?? false;
            db.MAAChairHaveSubmittedConfirmation = task.ChairHaveSubmittedConfirmation ?? false;
            db.MAAArrangementsMatchGovernancePlans = task.ArrangementsMatchGovernancePlans ?? false;
            db.FsgPreOpeningMilestonesMaaForecastDate = task.ForecastDate;
            db.FsgPreOpeningMilestonesMaaActualDateOfCompletion = task.ActualDate;
            db.FsgPreOpeningMilestonesMi56CommentsOnDecisionToApproveIfApplicable = task.CommentsOnDecision;
            db.FsgPreOpeningMilestonesMi107LinkToSavedDocument = task.SharepointLink;
        }
    }
}
