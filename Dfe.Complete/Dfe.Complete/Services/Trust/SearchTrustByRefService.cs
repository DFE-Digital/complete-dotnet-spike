using Dfe.ManageFreeSchoolProjects.API.Contracts.Project.Tasks;
using Dfe.ManageFreeSchoolProjects.API.Contracts.ResponseModels;
using System.Threading.Tasks;

namespace Dfe.ManageFreeSchoolProjects.Services.Trust
{
    public interface ISearchTrustByRefService
    {
        public Task<ApiListWrapper<SearchTrustByRefResponse>> Execute(string searchTerm);
    }

    public class SearchTrustByRefService : ISearchTrustByRefService
    {
        private readonly MfspApiClient _apiClient;

        public SearchTrustByRefService(MfspApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<ApiListWrapper<SearchTrustByRefResponse>> Execute(string searchTerm)
        {
            var endpoint = $"/api/v1/client/trust/search/{searchTerm}";

            var result = await _apiClient.Get<ApiListWrapper<SearchTrustByRefResponse>>(endpoint);

            return result;
        }
    }
}

