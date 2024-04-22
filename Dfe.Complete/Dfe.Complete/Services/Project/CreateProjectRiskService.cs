using Dfe.ManageFreeSchoolProjects.API.Contracts.Project.Risk;
using System.Threading.Tasks;

namespace Dfe.ManageFreeSchoolProjects.Services.Project
{
    public interface ICreateProjectRiskService
    {
        public Task<CreateProjectRiskResponse> Execute(string projectId, CreateProjectRiskRequest request);
    }

    public class CreateProjectRiskService : ICreateProjectRiskService
    {
        private readonly MfspApiClient _apiClient;

        public CreateProjectRiskService(MfspApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<CreateProjectRiskResponse> Execute(string projectId, CreateProjectRiskRequest request)
        {
            return await _apiClient.Post<CreateProjectRiskRequest, CreateProjectRiskResponse>($"/api/v1/client/projects/{projectId}/risk", request);
        }
    }
}
