using Dfe.ManageFreeSchoolProjects.API.Contracts.Project.Tasks;
using Dfe.ManageFreeSchoolProjects.API.Contracts.Project.Tasks.PDG;
using Dfe.ManageFreeSchoolProjects.API.UseCases.Project.Tasks.PDG.PaymentSchedule;
using Dfe.ManageFreeSchoolProjects.Data;
using Microsoft.EntityFrameworkCore;

namespace Dfe.ManageFreeSchoolProjects.API.UseCases.Project.Tasks.PDG.Refunds
{
    public class GetRefundsService
    {
        private readonly MfspContext _context;

        public GetRefundsService(MfspContext context)
        {
            _context = context;
        }

        public async Task<GetProjectByTaskResponse> Get(GetTaskServiceParameters parameters)
        {
            var result = await (from kpi in parameters.BaseQuery
                                join po in _context.Po on kpi.Rid equals po.Rid into joinedPO
                                from po in joinedPO.DefaultIfEmpty()
                                select new GetProjectByTaskResponse()
                                {
                                    Refunds = RefundsBuilder.Build(po)
                                }).FirstOrDefaultAsync();

            return result ?? new GetProjectByTaskResponse() { Refunds = new() };
        }

    }
}