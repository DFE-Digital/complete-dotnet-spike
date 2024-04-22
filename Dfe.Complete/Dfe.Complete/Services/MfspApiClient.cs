using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Net.Http;

namespace Dfe.ManageFreeSchoolProjects.Services
{
    public class MfspApiClient : ApiClient
    {
        public MfspApiClient(
            IHttpClientFactory clientFactory, 
            ILogger<ApiClient> logger,
            IHttpContextAccessor httpContextAccessor,
            string httpClientName = "MfspClient") : base(clientFactory, logger, httpContextAccessor, httpClientName)
        {
            
        }
    }
}
