using Dfe.Complete.API.Middleware;
using Dfe.Complete.Middleware;

namespace Dfe.Complete.API.StartupConfiguration
{
    public static class MiddlewareConfigurationExtensions
    {
        public static void UseApiMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionHandlerMiddleware>();
            app.UseMiddleware<ApiKeyMiddleware>();
            app.UseMiddleware<UrlDecoderMiddleware>();
            app.UseMiddleware<CorrelationIdMiddleware>();
            app.UseMiddleware<UserContextReceiverMiddleware>();
        }
    }
}
