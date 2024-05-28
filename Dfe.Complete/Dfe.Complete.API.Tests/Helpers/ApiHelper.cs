using Dfe.Complete.API.Contracts.Http;
using Dfe.Complete.API.Contracts.Project.Transfer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Dfe.Complete.API.Tests.Helpers
{
    public static class ApiHelper
    {
        private static readonly Fixture _autoFixture = new Fixture();

        public static async Task<CreateTransferProjectResponse> CreateTransferProject(this HttpClient client)
        {
            var createProjectRequest = _autoFixture.Create<CreateTransferProjectRequest>();
            var createProjectResponse = await client.PostAsync(RouteConstants.CreateTransferProject, createProjectRequest.ConvertToJson());
            createProjectResponse.StatusCode.Should().Be(HttpStatusCode.Created);
            var createdProject = await createProjectResponse.Content.ReadFromJsonAsync<CreateTransferProjectResponse>();

            return createdProject;
        }
    }
}
