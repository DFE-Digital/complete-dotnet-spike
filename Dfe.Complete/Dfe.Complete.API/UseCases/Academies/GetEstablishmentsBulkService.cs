using System.Collections.Specialized;
using System.Web;

namespace Dfe.Complete.API.UseCases.Academies
{
    public interface IGetEstablishmentsBulkService
    {
        public Task<List<GetEstablishmentResponse>> Execute(int[] urns);
    }

    public class GetEstablishmentsBulkService : IGetEstablishmentsBulkService
    {
        private readonly AcademiesApiClient _apiClient;

        public GetEstablishmentsBulkService(AcademiesApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<List<GetEstablishmentResponse>> Execute(int[] urns)
        {
            if (!urns.Any())
            {
                return new List<GetEstablishmentResponse>();
            }

            NameValueCollection queryString = HttpUtility.ParseQueryString(string.Empty);

            foreach(var urn in urns)
            {
                queryString.Add("request", urn.ToString());
            }

            var endpoint = $"/v4/establishments/bulk?{queryString}";

            var result = await _apiClient.Get<List<GetEstablishmentResponse>>(endpoint);

            return result;
        }
    }
}
