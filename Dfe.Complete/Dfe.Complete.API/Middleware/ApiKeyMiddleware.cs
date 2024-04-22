using Dfe.ManageFreeSchoolProjects.API.UseCases;

namespace Dfe.ManageFreeSchoolProjects.API.Middleware
{
    public class ApiKeyMiddleware
    {
        private readonly RequestDelegate _next;
        private const string APIKEYNAME = "ApiKey";

        public ApiKeyMiddleware(
			RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(
			HttpContext context,
            IApiKeyValidationService apiKeyValidationService,
            IConstructApiKeyValidationService constructApiKeyValidationService,
            ISfaApiKeyValidationService sfaApiKeyValidationService)
        {
	        if (IsApiCall(context))
	        {
		        if (!context.Request.Headers.TryGetValue(APIKEYNAME, out var extractedApiKey))
		        {
			        context.Response.StatusCode = 401;
			        await context.Response.WriteAsync("Api Key was not provided.");
			        return;
		        }

		        var isKeyValid = apiKeyValidationService.Execute(extractedApiKey);

		        if (!isKeyValid)
		        {
					var isConstructRouteWithValidKey = constructApiKeyValidationService.Execute(context, extractedApiKey);
                    var isSfaRouteWithValidKey = sfaApiKeyValidationService.Execute(context, extractedApiKey);

					if (!isConstructRouteWithValidKey && !isSfaRouteWithValidKey)
					{
                        context.Response.StatusCode = 401;
                        await context.Response.WriteAsync("Unauthorized client.");
                        return;
                    }
		        }
	        }

	        await _next(context);
        }

        private bool IsApiCall(HttpContext context) => context.Request.Path.HasValue;
    }
}