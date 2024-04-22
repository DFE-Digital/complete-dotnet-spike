using Dfe.ManageFreeSchoolProjects.API.Contracts.Project.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Dfe.ManageFreeSchoolProjects.API.UseCases.Project.Tasks.RegionAndLocalAuthority
{
    public class GetRegionAndLocalAuthorityTaskService : IGetTaskService
    {
        public async Task<GetProjectByTaskResponse> Get(GetTaskServiceParameters parameters)
        {
            var query = parameters.BaseQuery;

            var result = await query.Select(kpi => new GetProjectByTaskResponse()
            {
                RegionAndLocalAuthority = RegionAndLocalAuthorityTaskBuilder.Build(kpi)
            }).FirstOrDefaultAsync();

            return result;
        }
    }
}
