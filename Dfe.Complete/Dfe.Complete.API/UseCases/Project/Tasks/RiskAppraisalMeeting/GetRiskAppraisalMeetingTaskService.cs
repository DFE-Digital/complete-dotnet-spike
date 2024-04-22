using Dfe.ManageFreeSchoolProjects.API.Contracts.Project.Tasks;
using Dfe.ManageFreeSchoolProjects.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace Dfe.ManageFreeSchoolProjects.API.UseCases.Project.Tasks.RiskAppraisalMeeting
{
    public class GetRiskAppraisalMeetingTaskService : IGetTaskService
    {
        private readonly MfspContext _context;

        public GetRiskAppraisalMeetingTaskService(MfspContext context)
        {
            _context = context;
        }

        public async Task<GetProjectByTaskResponse> Get(GetTaskServiceParameters parameters)
        {
            var query = parameters.BaseQuery;

            var result = await (from kpi in query
                                join riskAppraisalMeetingTask in _context.RiskAppraisalMeetingTask on kpi.Rid equals riskAppraisalMeetingTask.RID into riskAppraisalMeetingTaskJoin
                                from riskAppraisalMeetingTask in riskAppraisalMeetingTaskJoin.DefaultIfEmpty()
                                select new GetProjectByTaskResponse()
                                {
                                    RiskAppraisalMeeting = RiskAppraisalMeetingTaskBuilder.Build(riskAppraisalMeetingTask)
                                }).FirstOrDefaultAsync();

            return result;
        }
    }
}
