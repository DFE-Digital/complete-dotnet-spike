using Dfe.ManageFreeSchoolProjects.Data;
using Dfe.ManageFreeSchoolProjects.Data.Entities.Existing;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace Dfe.ManageFreeSchoolProjects.API.UseCases.Project.Tasks.StatutoryConsultation
{
    public class UpdateStatutoryConsultationTaskService : IUpdateTaskService
    {
        private readonly MfspContext _context;

        public UpdateStatutoryConsultationTaskService(MfspContext context)
        {
            _context = context;
        }

        public async Task Update(UpdateTaskServiceParameters parameters)
        {
            var task = parameters.Request.StatutoryConsultation;
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

            db.FsgPreOpeningMilestonesScrForecastDate = task.ExpectedDateForReceivingFindingsFromTrust;
            db.FsgPreOpeningMilestonesScrReceived = task.ReceivedConsultationFindingsFromTrust;
            db.FsgPreOpeningMilestonesScrActualDateOfCompletion = task.DateReceived;
            db.FsgPreOpeningMilestonesScrFulfilsSection10StatutoryDuty = task.ConsultationFulfilsTrustSection10StatutoryDuty;
            db.FsgPreOpeningMilestonesMi80CommentsOnDecisionToApproveIfApplicable = task.Comments;
            db.FsgPreOpeningMilestonesScrSavedFindingsInWorkplacesFolder = task.SavedFindingsInWorkplacesFolder;
        }
    }
}