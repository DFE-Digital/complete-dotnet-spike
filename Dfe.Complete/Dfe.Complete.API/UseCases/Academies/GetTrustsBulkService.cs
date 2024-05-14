using System.Collections.Specialized;
using System.Web;

namespace Dfe.Complete.API.UseCases.Academies
{
    public interface IGetTrustsBulkService
    {
        public Task<List<GetTrustResponse>> Execute(int[] ukprns);
    }

    public class GetTrustsBulkService : IGetTrustsBulkService
    {
        private readonly AcademiesApiClient _apiClient;

        public GetTrustsBulkService(AcademiesApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<List<GetTrustResponse>> Execute(int[] ukprns)
        {
            if (!ukprns.Any())
            {
                return new List<GetTrustResponse>();
            }

            NameValueCollection queryString = HttpUtility.ParseQueryString(string.Empty);

            foreach (var urn in ukprns)
            {
                queryString.Add("ukprns", urn.ToString());
            }

            var endpoint = $"/v4/trusts/bulk?{queryString}";

            var result = await _apiClient.Get<List<GetTrustResponse>>(endpoint);

            return result;
        }
    }
}
