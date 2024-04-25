namespace Dfe.Complete.API.UseCases.Academies
{
    public class AcademiesApiClient : ApiClient
    {
        public AcademiesApiClient(
            IHttpClientFactory clientFactory,
            ILogger<ApiClient> logger,
            IHttpContextAccessor httpContextAccessor,
            string httpClientName = "AcademiesClient") : base(clientFactory, logger, httpContextAccessor, httpClientName)
        {

        }
    }
}
