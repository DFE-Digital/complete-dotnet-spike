using Dfe.ManageFreeSchoolProjects.API.Contracts.Project.Sites;
using Dfe.ManageFreeSchoolProjects.API.Contracts.ResponseModels;
using System.Threading.Tasks;

namespace Dfe.ManageFreeSchoolProjects.Services.Project
{
    public interface IGetProjectSitesService
    {
        public Task<GetProjectSitesResponse> Execute(string projectId);
    }

    public class GetProjectSitesService : IGetProjectSitesService
    {
        private readonly MfspApiClient _apiClient;

        public GetProjectSitesService(MfspApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<GetProjectSitesResponse> Execute(string projectId)
        {
            var endpoint = $"/api/v1/client/projects/{projectId}/sites";

            var result = await _apiClient.Get<ApiSingleResponseV2<GetProjectSitesResponse>>(endpoint);

            return result.Data;
        }
    }
}
