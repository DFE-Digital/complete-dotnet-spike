using Dfe.ManageFreeSchoolProjects.API.Contracts.Project.Tasks;

namespace Dfe.ManageFreeSchoolProjects.API.UseCases.Project.Tasks.RiskAppraisalMeeting
{
    public static class RiskAppraisalMeetingTaskBuilder
    {
        public static RiskAppraisalMeetingTask Build(Data.Entities.RiskAppraisalMeetingTask riskAppraisalMeetingTask)
        {
            if (riskAppraisalMeetingTask == null)
            {
                return new RiskAppraisalMeetingTask();
            }

            return new RiskAppraisalMeetingTask
            {
                InitialRiskAppraisalMeetingCompleted = riskAppraisalMeetingTask.MeetingCompleted,
                ForecastDate = riskAppraisalMeetingTask.ForecastDate,
                ActualDate = riskAppraisalMeetingTask.ActualDate,
                CommentsOnDecisionToApprove = riskAppraisalMeetingTask.CommentOnDecision,
                ReasonNotApplicable = riskAppraisalMeetingTask.ReasonNotApplicable
            };
        }
    }
}
