using Dfe.ManageFreeSchoolProjects.API.Contracts.Project.Risk;
using Dfe.ManageFreeSchoolProjects.API.Contracts.ResponseModels;
using System.Threading.Tasks;

namespace Dfe.ManageFreeSchoolProjects.Services.Project
{
    public interface IGetProjectRiskService
    {
        Task<GetProjectRiskResponse> Execute(string projectId, int entry);
    }

    public class GetProjectRiskService : IGetProjectRiskService
    {
        private readonly MfspApiClient _apiClient;

        public GetProjectRiskService(MfspApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<GetProjectRiskResponse> Execute(string projectId, int entry)
        {
            var endpoint = $"/api/v1/client/projects/{projectId}/risk?entry={entry}";

            var result = await _apiClient.Get<ApiSingleResponseV2<GetProjectRiskResponse>>(endpoint);

            return result.Data;
        }
    }
}
