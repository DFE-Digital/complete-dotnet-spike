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
                                LocalAuthorityName = "Local authority 1",
                                EstablishmentType = new() { Name = "Voluntary aided school" },
                                PhaseOfEducation = new() { Name = "Primary" },
                                StatutoryLowAge = "3",
                                StatutoryHighAge = "16",
                                Address = new()
                                {
                                    Street = "Establishment 1 Street",
                                    Town = "Establishment 1 Town",
                                    Postcode = "Establishment 1 Postcode"
                                }
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
                                Name = "Trust 1",
                                CompaniesHouseNumber = "00001",
                                ReferenceNumber = "TR0001",
                                Address = new()
                                {
                                    Street = "Trust 1 Street",
                                    Town = "Trust 1 Town",
                                    Postcode = "Trust 1 Postcode"
                                }
                            },
                            new GetTrustResponse()
                            {
                                Ukprn = "10000002",
                                Name = "Trust 2",                        
                                CompaniesHouseNumber = "00002",
                                ReferenceNumber = "TR0002",
                                Address = new()
                                {
                                    Street = "Trust 2 Street",
                                    Town = "Trust 2 Town",
                                    Postcode = "Trust 2 Postcode"
                                }
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
