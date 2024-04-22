using Dfe.ManageFreeSchoolProjects.API.Contracts.Project.Tasks;

namespace Dfe.ManageFreeSchoolProjects.API.UseCases.Project.Tasks
{
    public interface IGetTaskService
    {
        public Task<GetProjectByTaskResponse> Get(GetTaskServiceParameters parameters);
    }
}
