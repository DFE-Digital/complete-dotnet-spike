using Dfe.Complete.API.Middleware;
using Dfe.Complete.Middleware;

namespace Dfe.Complete.API.StartupConfiguration
{
    public static class MiddlewareConfigurationExtensions
    {
        public static void UseApiMiddleware(this IApplicationBuilder app)
        {
            app.UseWhen(context =>
            {
                return context.Request.Path.StartsWithSegments("/api/v1");
            }, appBuilder =>
            {
                appBuilder.UseMiddleware<ExceptionHandlerMiddleware>();
                appBuilder.UseMiddleware<ApiKeyMiddleware>();
                appBuilder.UseMiddleware<UrlDecoderMiddleware>();
                appBuilder.UseMiddleware<CorrelationIdMiddleware>();
                appBuilder.UseMiddleware<UserContextReceiverMiddleware>();
            });
        }
    }
}
