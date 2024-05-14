using Dfe.Complete.API.UseCases.Academies;
using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace Dfe.Complete.API.Tests.FakeApi
{
    public class FakeAcademiesApi
    {
        private IWebHost _server;

        public void Start()
        {
            _server = new WebHostBuilder().UseKestrel(x => x.ListenLocalhost(6784)).Configure(app =>
            {
                app.Run(async context =>
                {
                    if (context.Request.Method == HttpMethods.Get && context.Request.Path == "/v4/establishments/bulk")
                    {
                        var response = new List<GetEstablishmentResponse>()
                        {
                            new GetEstablishmentResponse()
                            {
                                Urn = "1001",
                                Name = "Establishment 1",
                                LocalAuthorityName = "Local authority 1"
                            }
                        };

                        await context.Response.WriteAsJsonAsync(response);
                    }
                    else if (context.Request.Method == HttpMethods.Get && context.Request.Path == "/v4/trusts/bulk")
                    {
                        var response = new List<GetTrustResponse>()
                        {
                            new GetTrustResponse()
                            {
                                Ukprn = "10000001",
                                Name = "Trust 1"
                            },
                            new GetTrustResponse()
                            {
                                Ukprn = "10000002",
                                Name = "Trust 2"
                            }
                        };

                        await context.Response.WriteAsJsonAsync(response);
                    }
                    else
                    {
                        context.Response.StatusCode = StatusCodes.Status404NotFound;
                        await context.Response.WriteAsync("Not found");
                    }
                });
            }).Build();

            _server.Start();
        }

        public void Stop()
        {
            _server.StopAsync().Wait();
        }
    }
}
