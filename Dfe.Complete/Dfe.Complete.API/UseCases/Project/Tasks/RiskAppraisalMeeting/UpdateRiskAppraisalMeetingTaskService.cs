
using Dfe.ManageFreeSchoolProjects.API.Contracts.Project.Tasks;
using Dfe.ManageFreeSchoolProjects.Data;
using Microsoft.EntityFrameworkCore;

namespace Dfe.ManageFreeSchoolProjects.API.UseCases.Project.Tasks.RiskAppraisalMeeting
{
    public class UpdateRiskAppraisalMeetingTaskService : IUpdateTaskService
    {
        private readonly MfspContext _context;

        public UpdateRiskAppraisalMeetingTaskService(MfspContext context)
        {
            _context = context;
        }

        public async Task Update(UpdateTaskServiceParameters parameters)
        {
            var task = parameters.Request.RiskAppraisalMeeting;
            var dbKpi = parameters.Kpi;

            if (task is null)
            {
                return;
            }

            var dbRiskAppraisalMeetingTask = await _context.RiskAppraisalMeetingTask.FirstOrDefaultAsync(r => r.RID == dbKpi.Rid);

            if (dbRiskAppraisalMeetingTask == null)
            {
                dbRiskAppraisalMeetingTask = new Data.Entities.RiskAppraisalMeetingTask();
                dbRiskAppraisalMeetingTask.RID = dbKpi.Rid;
                _context.Add(dbRiskAppraisalMeetingTask);
            }

            setRiskAppraisalMeeting(task, dbRiskAppraisalMeetingTask);
        }

        private static void setRiskAppraisalMeeting(RiskAppraisalMeetingTask riskAppraisalMeetingTask, Data.Entities.RiskAppraisalMeetingTask dbRiskAppraisalMeetingTask)
        {
            dbRiskAppraisalMeetingTask.MeetingCompleted = riskAppraisalMeetingTask.InitialRiskAppraisalMeetingCompleted;
            dbRiskAppraisalMeetingTask.ForecastDate = riskAppraisalMeetingTask.ForecastDate;
            dbRiskAppraisalMeetingTask.ActualDate = riskAppraisalMeetingTask.ActualDate;
            dbRiskAppraisalMeetingTask.CommentOnDecision = riskAppraisalMeetingTask.CommentsOnDecisionToApprove;
            dbRiskAppraisalMeetingTask.ReasonNotApplicable = riskAppraisalMeetingTask.ReasonNotApplicable;
        }
    }
}
