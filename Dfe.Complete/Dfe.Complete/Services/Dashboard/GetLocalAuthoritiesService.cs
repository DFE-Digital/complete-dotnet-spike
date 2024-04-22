using Dfe.ManageFreeSchoolProjects.API.Contracts.Dashboard;
using Dfe.ManageFreeSchoolProjects.API.Contracts.ResponseModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dfe.ManageFreeSchoolProjects.Services.Dashboard
{
    public interface IGetLocalAuthoritiesService
    {
        public Task<GetLocalAuthoritiesResponse> Execute(List<string> regions);
    }

    public class GetLocalAuthoritiesService : IGetLocalAuthoritiesService
    {
        private readonly MfspApiClient _apiClient;

        public GetLocalAuthoritiesService(MfspApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<GetLocalAuthoritiesResponse> Execute(List<string> regions)
        {
            var regionQuery = string.Join(",", regions);

            var endpoint = $"/api/v1/client/local-authorities?regions={regionQuery}";

            var result = await _apiClient.Get<ApiSingleResponseV2<GetLocalAuthoritiesResponse>>(endpoint);

            return result.Data;
        }
    }
}
