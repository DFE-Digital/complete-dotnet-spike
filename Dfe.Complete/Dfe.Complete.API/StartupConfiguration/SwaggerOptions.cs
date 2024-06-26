using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Dfe.Complete.API.StartupConfiguration
{
    public class SwaggerOptions : IConfigureNamedOptions<SwaggerGenOptions>
    {
        private readonly IApiVersionDescriptionProvider _provider;

        private const string ApiKeyName = "ApiKey";
        private const string ServiceTitle = "Manage Free School Projects";
        private const string ServiceDescription = "Manage Free School Projects";
        private const string ContactName = "Support";
        private const string ContactEmail = "servicedelivery.rdd@education.gov.uk";

        private const string SecuritySchemeDescription = "A valid ApiKey in the 'ApiKey' header is required to " +
                                                         "access the Manage Free School Projects.";
        private const string DeprecatedMessage = "- API version has been deprecated.";
        
        public SwaggerOptions(IApiVersionDescriptionProvider provider) => _provider = provider;
        
        public void Configure(string name, SwaggerGenOptions options) => Configure(options);
        
        public void Configure(SwaggerGenOptions options)
        {
            foreach (var desc in _provider.ApiVersionDescriptions)
            {
                var openApiInfo = new OpenApiInfo
                {
                    Title = ServiceTitle,
                    Description = ServiceDescription,
                    Contact = new OpenApiContact
                    {
                        Name = ContactName,
                        Email = ContactEmail 
                    },
                    Version = desc.ApiVersion.ToString()
                };
                if (desc.IsDeprecated) openApiInfo.Description += DeprecatedMessage;
                
                options.SwaggerDoc(desc.GroupName, openApiInfo);
            }
            
            var securityScheme = new OpenApiSecurityScheme
            {
                Name = ApiKeyName,
                Description = SecuritySchemeDescription,
                Type = SecuritySchemeType.ApiKey,
                In = ParameterLocation.Header
            };
            options.AddSecurityDefinition(ApiKeyName, securityScheme);
            options.OperationFilter<AuthenticationHeaderOperationFilter>();
            //options.OperationFilter<UserContextOperationFilter>();
        }
    }
}