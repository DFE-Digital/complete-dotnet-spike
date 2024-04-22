using Dfe.ManageFreeSchoolProjects.API.Contracts.Project;
using Dfe.ManageFreeSchoolProjects.API.Contracts.Project.Tasks;
using Dfe.ManageFreeSchoolProjects.API.Contracts.ResponseModels;
using System.Threading.Tasks;

namespace Dfe.ManageFreeSchoolProjects.Services.Project
{
    public interface IGetProjectByTaskService
    {
        public Task<GetProjectByTaskResponse> Execute(string projectId, TaskName taskName);
    }

    public class GetProjectByTaskService : IGetProjectByTaskService
    {
        private readonly MfspApiClient _apiClient;

        public GetProjectByTaskService(MfspApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<GetProjectByTaskResponse> Execute(string projectId, TaskName taskName)
        {
            var endpoint = $"/api/v1/client/projects/{projectId}/tasks/{taskName}";

            var result = await _apiClient.Get<ApiSingleResponseV2<GetProjectByTaskResponse>>(endpoint);

            return result.Data;
        }
    }
}