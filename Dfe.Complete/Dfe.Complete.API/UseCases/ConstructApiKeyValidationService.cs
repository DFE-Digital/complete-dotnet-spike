namespace Dfe.ManageFreeSchoolProjects.API.UseCases
{
    public interface IConstructApiKeyValidationService
    {
        public bool Execute(HttpContext context, string keyToValidate);
    }

    public class ConstructApiKeyValidationService : IConstructApiKeyValidationService
    {
        private readonly IConfiguration _configuration;

        public ConstructApiKeyValidationService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public bool Execute(HttpContext context, string keyToValidate)
        {
            if (!context.Request.Path.StartsWithSegments("/api/v1/construct"))
            {
                return false;
            }

            var expectedKey = _configuration
                .GetSection("ManageFreeSchoolProjects")
                .GetValue<string>("ConstructApiKey");

            return keyToValidate == expectedKey;
        }
    }
}
