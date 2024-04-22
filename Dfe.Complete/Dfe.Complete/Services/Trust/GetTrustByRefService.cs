using Dfe.ManageFreeSchoolProjects.API.Contracts.Project;
using Dfe.ManageFreeSchoolProjects.API.Contracts.Project.Tasks;
using Dfe.ManageFreeSchoolProjects.API.Contracts.ResponseModels;
using System.Threading.Tasks;

namespace Dfe.ManageFreeSchoolProjects.Services.Trust
{
    public interface IGetTrustByRefService
    {
        public Task<GetTrustByRefResponse> Execute(string trn);
    }

    public class GetTrustByRefService : IGetTrustByRefService
    {
        private readonly MfspApiClient _apiClient;

        public GetTrustByRefService(MfspApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<GetTrustByRefResponse> Execute(string trn)
        {
            var endpoint = $"/api/v1/client/trust/{trn}";

            var result = await _apiClient.Get<ApiSingleResponseV2<GetTrustByRefResponse>>(endpoint);

            return result.Data;
        }
    }
}

