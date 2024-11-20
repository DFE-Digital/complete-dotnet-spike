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
    public class ConversionLandQuestionnaireApiTest : ApiTestsBase
    {
        public ConversionLandQuestionnaireApiTest(ApiTestFixture apiTestFixture) : base(apiTestFixture)
        {
        }

        [Fact]
        public async Task Update_LandQuestionnaireTask_Returns_200()
        {
            var createProjectRequest = new CreateConversionProjectRequest();
            var createResponse = await _client.PostAsync(RouteConstants.CreateConversionProject, createProjectRequest.ConvertToJson());
            createResponse.StatusCode.Should().Be(HttpStatusCode.Created);

            var project = await createResponse.Content.ReadFromJsonAsync<CreateConversionProjectResponse>();

            var request = new UpdateConversionProjectByTaskRequest()
            {
                LandQuestionnaire = new ConversionLandQuestionnaireTask()
                {
                    Received = true,
                    Cleared = true,
                    Signed = true,
                    Saved = true
                }
            };

            var updateResponse = await _client.PatchAsync($"{string.Format(RouteConstants.ConversionProjectTask, project.Id)}", request.ConvertToJson());
            updateResponse.StatusCode.Should().Be(HttpStatusCode.OK);

            var getResponse = await _client.GetAsync($"{string.Format(RouteConstants.ConversionProjectTask, project.Id)}?taskName={ConversionProjectTaskName.LandQuestionnaire}");
            getResponse.StatusCode.Should().Be(HttpStatusCode.OK);

            var updatedTask = await getResponse.Content.ReadFromJsonAsync<GetConversionProjectByTaskResponse>();

            updatedTask.LandQuestionnaire.Received.Should().BeTrue();
            updatedTask.LandQuestionnaire.Cleared.Should().BeTrue();
            updatedTask.LandQuestionnaire.Signed.Should().BeTrue();
            updatedTask.LandQuestionnaire.Saved.Should().BeTrue();
        }

        [Fact]
        public async Task Get_LandQuestionnaire_TaskSummary_Returns_200()
        {
            var createProjectRequest = new CreateConversionProjectRequest();
            var createResponse = await _client.PostAsync(RouteConstants.CreateConversionProject, createProjectRequest.ConvertToJson());
            createResponse.StatusCode.Should().Be(HttpStatusCode.Created);

            var createdProject = await createResponse.Content.ReadFromJsonAsync<CreateConversionProjectResponse>();
            var projectId = createdProject.Id;

            var request = new UpdateConversionProjectByTaskRequest()
            {
                LandQuestionnaire = new()
                {
                    Received = true,
                }
            };

            var updateResponse = await _client.PatchAsync($"{string.Format(RouteConstants.ConversionProjectTask, projectId)}", request.ConvertToJson());
            updateResponse.StatusCode.Should().Be(HttpStatusCode.OK);

            var getResponse = await _client.GetAsync($"{string.Format(RouteConstants.ConversionProjectTaskSummary, projectId)}");
            getResponse.StatusCode.Should().Be(HttpStatusCode.OK);

            var summary = await getResponse.Content.ReadFromJsonAsync<GetConversionProjectByTaskSummaryResponse>();

            summary.LandQuestionnaire.Status.Should().Be(ProjectTaskStatus.InProgress);
        }
    }
}
