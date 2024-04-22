using Dfe.ManageFreeSchoolProjects.API.Tests.Fixtures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Dfe.ManageFreeSchoolProjects.API.Tests.Integration
{
    public class ApiTestsBase
    {
        protected readonly HttpClient _client;
        protected readonly Fixture _autoFixture;
        protected readonly ApiTestFixture _testFixture;

        public ApiTestsBase(ApiTestFixture apiTestFixture)
        {
            _client = apiTestFixture.Client;
            _autoFixture = new();
            _testFixture = apiTestFixture;
        }
    }
}
