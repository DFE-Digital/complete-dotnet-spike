using Dfe.ManageFreeSchoolProjects.API.Contracts.Project.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Dfe.ManageFreeSchoolProjects.API.UseCases.Project.Tasks.School
{
    public class GetSchoolTaskService : IGetTaskService
    {
        public async Task<GetProjectByTaskResponse> Get(GetTaskServiceParameters parameters)
        {
            var query = parameters.BaseQuery;

            var result = await query.Select(kpi => new GetProjectByTaskResponse()
            {
                School = SchoolTaskBuilder.Build(kpi)
            }).FirstOrDefaultAsync();

            return result;
        }
    }
}
