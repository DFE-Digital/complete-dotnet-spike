using Dfe.ManageFreeSchoolProjects.Data;
using Microsoft.EntityFrameworkCore;

namespace Dfe.ManageFreeSchoolProjects.API.UseCases.Project.Tasks.ModelFundingAgreement
{
    public class UpdateModelFundingAgreementTaskService : IUpdateTaskService
    {
        private readonly MfspContext _context;

        public UpdateModelFundingAgreementTaskService(MfspContext context)
        {
            _context = context;
        }

        public async Task Update(UpdateTaskServiceParameters parameters)
        {
            var task = parameters.Request.ModelFundingAgreement;
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
            
            db.FsgPreOpeningMilestonesMfadActualDateOfCompletion = task.DateTrustAgreesWithModelFA;
            db.FsgPreOpeningMilestonesMfadSavedFaDocumentsInWorkspacesFolder =  task.SavedFADocumentsInWorkplacesFolder;
            db.FsgPreOpeningMilestonesMfadTrustAgreesWithModelFa = task.TrustAgreesWithModelFA;
            db.FsgPreOpeningMilestonesMfadDraftedFaHealthCheck = task.DraftedFAHealthCheck;
            db.FsgPreOpeningMilestonesMi58CommentsOnDecisionToApproveIfApplicable = task.Comments;
            db.FsgPreOpeningMilestonesMfadTailoredAModelFundingAgreement = task.TailoredAModelFundingAgreement;
            db.FsgPreOpeningMilestonesMfadSharedFaWithTheTrust = task.SharedFAWithTheTrust;
        }
    }
}