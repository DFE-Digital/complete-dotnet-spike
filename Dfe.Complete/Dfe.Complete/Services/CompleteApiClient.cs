using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Net.Http;

namespace Dfe.Complete.Services
{
    public class CompleteApiClient : ApiClient
    {
        public CompleteApiClient(
            IHttpClientFactory clientFactory, 
            ILogger<ApiClient> logger,
            IHttpContextAccessor httpContextAccessor,
            string httpClientName = "CompleteClient") : base(clientFactory, logger, httpContextAccessor, httpClientName)
        {
            
        }
    }
}
