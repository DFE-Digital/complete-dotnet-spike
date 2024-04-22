using Dfe.ManageFreeSchoolProjects.API.Contracts.Project;
using Dfe.ManageFreeSchoolProjects.API.Contracts.ResponseModels;
using System.Threading.Tasks;

namespace Dfe.ManageFreeSchoolProjects.Services.Project
{
    public interface IGetProjectOverviewService
    {
        public Task<ProjectOverviewResponse> Execute(string projectId);
    }

    public class GetProjectOverviewService : IGetProjectOverviewService
    {
        private readonly MfspApiClient _apiClient;

        public GetProjectOverviewService(MfspApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<ProjectOverviewResponse> Execute(string projectId)
        {
            var endpoint = $"/api/v1/client/projects/{projectId}/overview";

            var result = await _apiClient.Get<ApiSingleResponseV2<ProjectOverviewResponse>>(endpoint);

            return result.Data;
        }
    }
}
