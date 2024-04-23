using Dfe.Complete.Authorization;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Hosting.Internal;
using Microsoft.Net.Http.Headers;
using NSubstitute;
using NSubstitute.Core;

namespace Dfe.Complete.Tests.Authorization
{
    public class AutomationHandlerTests
    {
        private Fixture _fixture;

        public AutomationHandlerTests()
        {
            _fixture = new Fixture();
        }

        [Theory]
        [MemberData(nameof(GetEnvironmentTestCases))]
        public void ValidateHostEnviroment(string environment, bool expected)
        {
            IHostEnvironment hostEnvironment = new HostingEnvironment()
            {
                EnvironmentName = environment
            };

            var httpContext = new DefaultHttpContext();
            httpContext.Request.Headers.Add(HeaderNames.Authorization, "Bearer 123");

            var httpAccessor = Substitute.For<IHttpContextAccessor>();
            httpAccessor.HttpContext = httpContext;

            var configurationSettings = new Dictionary<string, string>()
            {
                { "CypressTestSecret", "123" }
            };

            IConfiguration configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(configurationSettings)
                .Build();

            var result = AutomationHandler.ClientSecretHeaderValid(hostEnvironment, httpAccessor, configuration);

            result.Should().Be(expected);
        }

        [Theory]
        [MemberData(nameof(GetAuthKeyTestCases))]
        public void ValidateAuthKey(string headerAuthKey, string serverAuthKey)
        {
            IHostEnvironment hostEnvironment = new HostingEnvironment()
            {
                EnvironmentName = Environments.Development
            };

            var httpContext = new DefaultHttpContext();
            httpContext.Request.Headers.Add(HeaderNames.Authorization, $"Bearer {headerAuthKey}");

            var httpAccessor = Substitute.For<IHttpContextAccessor>();
            httpAccessor.HttpContext = httpContext;

            var configurationSettings = new Dictionary<string, string>()
            {
                { "CypressTestSecret", serverAuthKey }
            };

            IConfiguration configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(configurationSettings)
                .Build();

            var result = AutomationHandler.ClientSecretHeaderValid(hostEnvironment, httpAccessor, configuration);

            result.Should().BeFalse();
        }

        public static TheoryData<string, bool> GetEnvironmentTestCases()
        {
            return new TheoryData<string, bool>()
            {
                { Environments.Development, true },
                { Environments.Staging, true },
                { Environments.Production, false }
            }; 
        }

        public static TheoryData<string?, string?> GetAuthKeyTestCases()
        {
            return new TheoryData<string?, string?>()
            {
                { null, null },
                { "123", null },
                { "", "" },
                { "123", "456" }
            };
        }
    }
}
