namespace Dfe.ManageFreeSchoolProjects.API.UseCases
{
    public interface IApiKeyValidationService
    {
        public bool Execute(string keyToValidate);
    }

    public class ApiKeyValidationService : IApiKeyValidationService
    {
        private readonly IConfiguration _configuration;

        public ApiKeyValidationService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public bool Execute(string keyToValidate)
        {
	        var keyExists = _configuration
		        .GetSection("ManageFreeSchoolProjects:ApiKeys")
		        .AsEnumerable()
		        .Any(k => k.Value == keyToValidate);
	        
	        return keyExists;
        }
    }
}