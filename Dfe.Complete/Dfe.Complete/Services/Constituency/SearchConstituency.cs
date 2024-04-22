using Dfe.ManageFreeSchoolProjects.API.Contracts.Constituency;
using Dfe.ManageFreeSchoolProjects.API.Contracts.Project.Tasks;
using Dfe.ManageFreeSchoolProjects.API.Contracts.ResponseModels;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Dfe.ManageFreeSchoolProjects.Services.Constituency
{
    public interface ISearchConstituency
    {
        Task<ApiSingleResponseV2<GetSearchConstituencyResponse>> Execute(string searchTerm);
    }

    public class SearchConstituency : ISearchConstituency
    {
        private readonly MfspApiClient _apiClient;

        public SearchConstituency(MfspApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<ApiSingleResponseV2<GetSearchConstituencyResponse>> Execute(string searchTerm)
        {
            var endpoint = $"/api/v1/client/constituency/search";

            QueryString query = new QueryString("");

            var url = endpoint + query.Add("searchTerm", searchTerm).ToString();

            var result = await _apiClient.Get<ApiSingleResponseV2<GetSearchConstituencyResponse>>(url);

            return result;
        }
    }
}
