﻿using Dfe.Complete.API.Tests.FakeApi;
using Dfe.Complete.Data;
using Dfe.Complete.Data.Entities;
using Dfe.Complete.Logging;
using Dfe.Complete.UserContext;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Mime;
using System.Reflection;

namespace Dfe.Complete.API.Tests.Fixtures
{
    public class ApiTestFixture : IDisposable
	{
		public WebApplicationFactory<Startup> Application { get; init; }

		public HttpClient Client { get; init; }

		public User DefaultUser { get; } = new User { Email = "API.TestFixture@test.gov.uk", FirstName = "Automation", LastName = "User" };

        private DbContextOptions<CompleteContext> _dbContextOptions { get; init; }

		private static readonly object _lock = new();
		private static bool _isInitialised = false;

		private const string ConnectionStringKey = "ConnectionStrings:DefaultConnection";

		private readonly FakeAcademiesApi _fakeAcademies;

        public CompleteContext GetContext() => new CompleteContext(_dbContextOptions);


        public ApiTestFixture()
		{
			lock (_lock)
			{
				if (!_isInitialised)
				{
					string connectionString = null;

					Application = new WebApplicationFactory<Startup>()
						.WithWebHostBuilder(builder =>
						{
							var configPath = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.tests.json");
							builder.ConfigureServices((x) =>
							{
								x.AddHttpClient();
							});
							builder.ConfigureAppConfiguration((context, config) =>
							{
								config.AddJsonFile(configPath)
									.AddUserSecrets(Assembly.GetExecutingAssembly(), true)
									.AddEnvironmentVariables();

								connectionString = BuildDatabaseConnectionString(config);

								config.AddInMemoryCollection(new Dictionary<string, string>
								{
									[ConnectionStringKey] = connectionString
								});
							});
						});

                    var fakeUserInfo = new UserInfo()
						{ Name = DefaultUser.Email, Roles = new[] { Claims.CaseWorkerRoleClaim } };

					Client = CreateHttpClient(fakeUserInfo);

					_fakeAcademies = new FakeAcademiesApi();
					_fakeAcademies.Start();

                    _dbContextOptions = new DbContextOptionsBuilder<CompleteContext>()
						.UseSqlServer(connectionString)
						.Options;

					using var context = GetContext();
					context.Database.EnsureDeleted();
					context.Database.Migrate();

                    CreateEstablishments(context);
					CreateUsers(context);

                    context.SaveChanges();

                    _isInitialised = true;
                }
            }
		}

        public void Dispose()
        {
            Application.Dispose();
            Client.Dispose();
			_fakeAcademies.Stop();
        }

        private HttpClient CreateHttpClient(UserInfo userInfo)
		{
			var client = Application.CreateClient();
			client.DefaultRequestHeaders.Add("ApiKey", "app-key");
			client.DefaultRequestHeaders.Add("ContentType", MediaTypeNames.Application.Json);

			// add standard headers for correlation and user context.
			var clientUserInfoService = new ClientUserInfoService();
			clientUserInfoService.SetPrincipal(userInfo);
			clientUserInfoService.AddUserInfoRequestHeaders(client);

			var correlationContext = new CorrelationContext();
			correlationContext.SetContext(Guid.NewGuid().ToString());

			return client;
		}

		private static string BuildDatabaseConnectionString(IConfigurationBuilder config)
		{
			var currentConfig = config.Build();
			var connection = currentConfig[ConnectionStringKey];
			var sqlBuilder = new SqlConnectionStringBuilder(connection);
			sqlBuilder.InitialCatalog = "ApiTests";

			var result = sqlBuilder.ToString();

			return result;
		}

		private static void CreateEstablishments(CompleteContext context)
		{
			context.GiasEstablishments.AddRange(
            [
                new GiasEstablishment { Name = "DB Establishment 1", Urn = 1001 },
                new GiasEstablishment { Name = "DB Establishment 2", Urn = 1002 },
                new GiasEstablishment { Name = "DB Establishment 3", Urn = 1003 },
            ]);
		}

		private void CreateUsers(CompleteContext context)
		{
			context.Users.AddRange(
			[
				DefaultUser
			]);
		}
	}

	[CollectionDefinition(ApiTestCollectionName)]
	public class ApiTestCollection : ICollectionFixture<ApiTestFixture>
	{
		public const string ApiTestCollectionName = "ApiTestCollection";

		// This class has no code, and is never created. Its purpose is simply
		// to be the place to apply [CollectionDefinition] and all the
		// ICollectionFixture<> interfaces.
	}
}