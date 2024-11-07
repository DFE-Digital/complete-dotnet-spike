using Dfe.Complete.API.Contracts.Http;
using Dfe.Complete.API.Contracts.Project.Conversion;
using Dfe.Complete.API.Contracts.Project.Conversion.Tasks;
using Dfe.Complete.API.Contracts.Project.Tasks;
using Dfe.Complete.API.Tests.Fixtures;
using Dfe.Complete.API.Tests.Helpers;
using System.Net;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Dfe.Complete.API.Tests.Integration.Project.Conversion.Tasks
{
    [Collection(ApiTestCollection.ApiTestCollectionName)]
    public class ConversionLandRegistryApiTest : ApiTestsBase
    {
        public ConversionLandRegistryApiTest(ApiTestFixture apiTestFixture) : base(apiTestFixture)
        {
        }

        [Fact]
        public async Task Update_LandRegistryTask_Returns_200()
        {
            var createProjectRequest = new CreateConversionProjectRequest();
            var createResponse = await _client.PostAsync(RouteConstants.CreateConversionProject, createProjectRequest.ConvertToJson());
            createResponse.StatusCode.Should().Be(HttpStatusCode.Created);

            var project = await createResponse.Content.ReadFromJsonAsync<CreateConversionProjectResponse>();

            var request = new UpdateConversionProjectByTaskRequest()
            {
                LandRegistry = new ConversionLandRegistryTask()
                {
                    Received = true,
                    Cleared = true,
                    Saved = true
                }
            };

            var updateResponse = await _client.PatchAsync($"{string.Format(RouteConstants.ConversionProjectTask, project.Id)}", request.ConvertToJson());
            updateResponse.StatusCode.Should().Be(HttpStatusCode.OK);

            var getResponse = await _client.GetAsync($"{string.Format(RouteConstants.ConversionProjectTask, project.Id)}?taskName={ConversionProjectTaskName.LandRegistry}");
            getResponse.StatusCode.Should().Be(HttpStatusCode.OK);

            var updatedTask = await getResponse.Content.ReadFromJsonAsync<GetConversionProjectByTaskResponse>();

            updatedTask.LandRegistry.Received.Should().BeTrue();
            updatedTask.LandRegistry.Cleared.Should().BeTrue();
            updatedTask.LandRegistry.Saved.Should().BeTrue();
        }

        [Fact]
        public async Task Get_LandRegistry_TaskSummary_Returns_200()
        {
            var createProjectRequest = new CreateConversionProjectRequest();
            var createResponse = await _client.PostAsync(RouteConstants.CreateConversionProject, createProjectRequest.ConvertToJson());
            createResponse.StatusCode.Should().Be(HttpStatusCode.Created);

            var createdProject = await createResponse.Content.ReadFromJsonAsync<CreateConversionProjectResponse>();
            var projectId = createdProject.Id;

            var request = new UpdateConversionProjectByTaskRequest()
            {
                LandRegistry = new()
                {
                    Received = true,
                }
            };

            var updateResponse = await _client.PatchAsync($"{string.Format(RouteConstants.ConversionProjectTask, projectId)}", request.ConvertToJson());
            updateResponse.StatusCode.Should().Be(HttpStatusCode.OK);

            var getResponse = await _client.GetAsync($"{string.Format(RouteConstants.ConversionProjectTaskSummary, projectId)}");
            getResponse.StatusCode.Should().Be(HttpStatusCode.OK);

            var summary = await getResponse.Content.ReadFromJsonAsync<GetConversionProjectByTaskSummaryResponse>();

            summary.LandRegistry.Status.Should().Be(ProjectTaskStatus.InProgress);
        }
    }
}
