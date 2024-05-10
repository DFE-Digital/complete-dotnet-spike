using Dfe.Complete.API.Contracts.Http;
using Dfe.Complete.API.Contracts.Project;
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
    }
}
