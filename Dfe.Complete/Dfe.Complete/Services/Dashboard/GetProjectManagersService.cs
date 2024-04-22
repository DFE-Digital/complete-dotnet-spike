using Dfe.ManageFreeSchoolProjects.API.Contracts.Dashboard;
using Dfe.ManageFreeSchoolProjects.API.Contracts.ResponseModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dfe.ManageFreeSchoolProjects.Services.Dashboard
{
    public interface IGetProjectManagersService
    {
        public Task<GetProjectManagersResponse> Execute();
    }

    public class GetProjectManagersService : IGetProjectManagersService
    {
        private readonly MfspApiClient _apiClient;

        public GetProjectManagersService(MfspApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<GetProjectManagersResponse> Execute()
        {
            var endpoint = "/api/v1/client/project-managers";

            var result = await _apiClient.Get<ApiSingleResponseV2<GetProjectManagersResponse>>(endpoint);

            return result.Data;
        }
    }
}
