using Dfe.Complete.API.Contracts.Http;
using Dfe.Complete.API.Contracts.Project;
using Dfe.Complete.API.Contracts.Project.Transfer;
using Dfe.Complete.API.Contracts.Project.Transfer.Tasks;
using Dfe.Complete.API.Tests.Fixtures;
using Dfe.Complete.API.Tests.Helpers;
using System;
using System.Net;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Dfe.Complete.API.Tests.Integration.Project.Transfer.Tasks
{
    [Collection(ApiTestCollection.ApiTestCollectionName)]
    public class TransferProjectByTaskSummaryApiTests : ApiTestsBase
    {
        public TransferProjectByTaskSummaryApiTests(ApiTestFixture apiTestFixture) : base(apiTestFixture)
        {
        }

        [Fact]
        public async Task Get_ProjectDoesNotExist_Returns_404()
        {
            var projectId = Guid.NewGuid();

            var response = await _client.GetAsync($"{string.Format(RouteConstants.TransferProjectTaskSummary, projectId)}");
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);

            var error = await response.Content.ReadAsStringAsync();
            error.Should().Contain($"Project with id {projectId} not found");
        }

        [Fact]
        public async Task Get_ProjectDetails_Returns_200()
        {
            var createProjectRequest = _autoFixture.Create<CreateTransferProjectRequest>();
            createProjectRequest.Region = Region.NorthWest;
            createProjectRequest.IncomingTrustDetails.Ukprn = "10000001";
            createProjectRequest.OutgoingTrustDetails.Ukprn = "10000002";

            var createResponse = await _client.PostAsync(RouteConstants.CreateTransferProject, createProjectRequest.ConvertToJson());
            createResponse.StatusCode.Should().Be(HttpStatusCode.Created);

            var createdProject = await createResponse.Content.ReadFromJsonAsync<CreateTransferProjectResponse>();
            var projectId = createdProject.Id;

            var response = await _client.GetAsync($"{string.Format(RouteConstants.TransferProjectTaskSummary, projectId)}");
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var taskSummary = await response.Content.ReadFromJsonAsync<GetTransferProjectByTaskSummaryResponse>();

            taskSummary.ProjectDetails.Date.Value.Date.Should().Be(createProjectRequest.Date.Value.Date);
            taskSummary.ProjectDetails.IsDateProvisional.Should().Be(createProjectRequest.IsDateProvisional);
            taskSummary.ProjectDetails.IncomingTrustUkprn.Should().Be(createProjectRequest.IncomingTrustDetails.Ukprn);
            taskSummary.ProjectDetails.IncomingTrustName.Should().Be("Trust 1");
            taskSummary.ProjectDetails.OutgoingTrustUkprn.Should().Be(createProjectRequest.OutgoingTrustDetails.Ukprn);
            taskSummary.ProjectDetails.OutgoingTrustName.Should().Be("Trust 2");
            taskSummary.ProjectDetails.Region.Should().Be("North West");
            taskSummary.ProjectDetails.ProjectType.Should().Be(ProjectType.Transfer);
            taskSummary.ProjectDetails.LocalAuthority.Should().Be("Local authority 1");
            taskSummary.ProjectDetails.Name.Should().Be("Establishment 1");
        }
    }
}
