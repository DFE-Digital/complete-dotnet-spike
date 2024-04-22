using Dfe.ManageFreeSchoolProjects.API.Contracts.Project.Tasks;
using Dfe.ManageFreeSchoolProjects.Data;
using Microsoft.EntityFrameworkCore;

namespace Dfe.ManageFreeSchoolProjects.API.UseCases.Project.Tasks.PDG.StopPayments
{
    public class GetStopPaymentService
    {
        private readonly MfspContext _context;

        public GetStopPaymentService(MfspContext context)
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
                                    StopPayment = StopPaymentBuilder.Build(po)
                                }).FirstOrDefaultAsync();

            return result ?? new GetProjectByTaskResponse() { StopPayment = new() };
        }

    }
}