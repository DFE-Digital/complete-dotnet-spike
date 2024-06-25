using Azure;
using Dfe.Complete.API.UseCases.Academies;
using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
                        if (context.Request.Query.Any(v => v.Value == "1111"))
                        {
                            await WriteNotFound(context);
                            return;
                        }

                        await WriteEstablishmentResponse(context);
                    }
                    else if (context.Request.Method == HttpMethods.Get && context.Request.Path == "/v4/trusts/bulk")
                    {
                        if (context.Request.Query.Any(v => v.Value == "11111111"))
                        {
                            await WriteNotFound(context);
                            return;
                        }

                        await WriteTrustResponse(context);
                    }
                    else
                    {
                        await WriteNotFound(context);
                    }
                });
            }).Build();

            _server.Start();
        }

        public void Stop()
        {
            _server.StopAsync().Wait();
        }

        private static async Task WriteNotFound(HttpContext context)
        {
            context.Response.StatusCode = StatusCodes.Status404NotFound;
            await context.Response.WriteAsync("Not found");
        }

        private static async Task WriteEstablishmentResponse(HttpContext context)
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
                        Locality = "Establishment 1 Locality",
                        Additional = "Establishment 1 Additional",
                        Town = "Establishment 1 Town",
                        County = "Establishment 1 County",
                        Postcode = "Establishment 1 Postcode"
                    },
                    Diocese = new() { Name = "St Pauls" }
                },
                new GetEstablishmentResponse()
                {
                    Urn = "1002",
                    Name = "Transfer report",
                    LocalAuthorityName = "Local authority 2",
                    EstablishmentType = new() { Name = "Voluntary aided school" },
                    PhaseOfEducation = new() { Name = "Primary" },
                    StatutoryLowAge = "3",
                    StatutoryHighAge = "16",
                    Address = new()
                    {
                        Street = "Establishment 2 Street",
                        Locality = "Establishment 2 Locality",
                        Additional = "Establishment 2 Additional",
                        Town = "Establishment 2 Town",
                        County = "Establishment 2 County",
                        Postcode = "Establishment 2 Postcode"
                    },
                    Diocese = new() { Name = "St Pauls" }
                }
            };

            await context.Response.WriteAsJsonAsync(response);
        }

        private static async Task WriteTrustResponse(HttpContext context)
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
                        Locality = "Trust 1 Locality",
                        Additional = "Trust 1 Additional",
                        Town = "Trust 1 Town",
                        County = "Trust 1 County",
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
                        Locality = "Trust 2 Locality",
                        Additional = "Trust 2 Additional",
                        Town = "Trust 2 Town",
                        County = "Trust 2 County",
                        Postcode = "Trust 2 Postcode"
                    }
                },
                new GetTrustResponse()
                {
                    Ukprn = "10000003",
                    Name = "Trust 3",
                    CompaniesHouseNumber = "00003",
                    ReferenceNumber = "TR0003",
                    Address = new()
                    {
                        Street = "Trust 3 Street",
                        Locality = "Trust 3 Locality",
                        Additional = "Trust 3 Additional",
                        Town = "Trust 3 Town",
                        County = "Trust 3 County",
                        Postcode = "Trust 3 Postcode"
                    }
                },
                new GetTrustResponse()
                {
                    Ukprn = "10000004",
                    Name = "Trust 4",
                    CompaniesHouseNumber = "00004",
                    ReferenceNumber = "TR0004",
                    Address = new()
                    {
                        Street = "Trust 4 Street",
                        Locality = "Trust 4 Locality",
                        Additional = "Trust 4 Additional",
                        Town = "Trust 4 Town",
                        County = "Trust 4 County",
                        Postcode = "Trust 4 Postcode"
                    }
                }
            };

            await context.Response.WriteAsJsonAsync(response);

        }
    }
}
