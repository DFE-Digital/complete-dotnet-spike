using Dfe.Complete.API.Contracts.Http;
using Dfe.Complete.API.Contracts.Project;
using Dfe.Complete.API.Contracts.Project.Conversion;
using Dfe.Complete.API.Contracts.Project.Tasks;
using Dfe.Complete.API.Contracts.Project.Transfer;
using Dfe.Complete.API.Contracts.Project.Transfer.Tasks;
using Dfe.Complete.API.Tests.Fixtures;
using Dfe.Complete.API.Tests.Helpers;
using System;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Dfe.Complete.API.Tests.Integration.Project.Conversion.Tasks
{
    [Collection(ApiTestCollection.ApiTestCollectionName)]
    public class ConversionProjectByTaskSummaryApiTests : ApiTestsBase
    {
        public ConversionProjectByTaskSummaryApiTests(ApiTestFixture apiTestFixture) : base(apiTestFixture)
        {
        }

        [Fact]
        public async Task Get_ProjectDoesNotExist_Returns_404()
        {
            var projectId = Guid.NewGuid();

            var response = await _client.GetAsync($"{string.Format(RouteConstants.ConversionProjectTaskSummary, projectId)}");
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);

            var error = await response.Content.ReadAsStringAsync();
            error.Should().Contain($"Project with id {projectId} not found");
        }

        [Fact]
        public async Task Get_ProjectExists_NoTask_Returns_EmptyTask_200()
        {
            using var context = _testFixture.GetContext();
            var user = context.Users.FirstOrDefault(u => u.Email == _testFixture.DefaultUser.Email);

            var project = DatabaseModelBuilder.BuildInProgressProject(user);
            project.Type = ProjectType.Conversion;
            context.Projects.AddRange(project);

            await context.SaveChangesAsync();

            var response = await _client.GetAsync($"{string.Format(RouteConstants.ConversionProjectTaskSummary, project.Id)}");
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var taskSummary = await response.Content.ReadFromJsonAsync<GetTransferProjectByTaskSummaryResponse>();
            taskSummary.HandoverWithDeliveryOfficer.Status.Should().Be(ProjectTaskStatus.NotStarted);
        }

        [Fact]
        public async Task Get_ProjectDetails_Returns_200()
        {
            var createProjectRequest = _autoFixture.Create<CreateConversionProjectRequest>();
            createProjectRequest.Region = Region.NorthWest;
            createProjectRequest.IncomingTrustUkprn = 10000001;
            createProjectRequest.OutgoingTrustUkprn = null;

            var createResponse = await _client.PostAsync(RouteConstants.CreateConversionProject, createProjectRequest.ConvertToJson());
            createResponse.StatusCode.Should().Be(HttpStatusCode.Created);

            var createdProject = await createResponse.Content.ReadFromJsonAsync<CreateConversionProjectResponse>();
            var projectId = createdProject.Id;

            var response = await _client.GetAsync($"{string.Format(RouteConstants.ConversionProjectTaskSummary, projectId)}");
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var taskSummary = await response.Content.ReadFromJsonAsync<GetTransferProjectByTaskSummaryResponse>();

            taskSummary.ProjectDetails.Date.Value.Date.Should().Be(createProjectRequest.Date.Value.Date);
            taskSummary.ProjectDetails.IsDateProvisional.Should().Be(createProjectRequest.IsDateProvisional);
            taskSummary.ProjectDetails.IncomingTrustUkprn.Should().Be(createProjectRequest.IncomingTrustUkprn);
            taskSummary.ProjectDetails.IncomingTrustName.Should().Be("Trust 1");
            taskSummary.ProjectDetails.OutgoingTrustUkprn.Should().BeNull();
            taskSummary.ProjectDetails.OutgoingTrustName.Should().BeNull();
            taskSummary.ProjectDetails.Region.Should().Be("North West");
            taskSummary.ProjectDetails.ProjectType.Should().Be(ProjectType.Conversion);
            taskSummary.ProjectDetails.LocalAuthority.Should().Be("Local authority 1");
            taskSummary.ProjectDetails.Name.Should().Be("Establishment 1");
        }
    }
}
