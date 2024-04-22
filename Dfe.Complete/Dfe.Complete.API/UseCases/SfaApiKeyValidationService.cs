namespace Dfe.ManageFreeSchoolProjects.API.UseCases
{
    public interface ISfaApiKeyValidationService
    {
        public bool Execute(HttpContext context, string keyToValidate);
    }

    public class SfaApiKeyValidationService : ISfaApiKeyValidationService
    {
        private readonly IConfiguration _configuration;

        public SfaApiKeyValidationService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public bool Execute(HttpContext context, string keyToValidate)
        {
            if (!context.Request.Path.StartsWithSegments("/api/v1/client/reports/sfa-export"))
            {
                return false;
            }

            var expectedKey = _configuration
                .GetSection("ManageFreeSchoolProjects")
                .GetValue<string>("SfaApiKey");

            return keyToValidate == expectedKey;
        }
    }
}
