using Dfe.ManageFreeSchoolProjects.API.Contracts.Project.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Dfe.ManageFreeSchoolProjects.API.UseCases.Project.Tasks.Trusts
{
    public class GetTrustTaskService : IGetTaskService
    {
        public async Task<GetProjectByTaskResponse> Get(GetTaskServiceParameters parameters)
        {
            var query = parameters.BaseQuery;

            var result = await query.Select(kpi => new GetProjectByTaskResponse()
            {
                Trust = TrustTaskBuilder.Build(kpi)
            }).FirstOrDefaultAsync();

            return result;
        }
    }
}
