using Dfe.Complete.API.Contracts.Http;
using Dfe.Complete.API.Contracts.Project;
using Dfe.Complete.API.Contracts.Project.Conversion;
using Dfe.Complete.API.Contracts.Project.Conversion.Tasks;
using Dfe.Complete.API.Tests.Fixtures;
using Dfe.Complete.API.Tests.Helpers;
using System.Net;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Dfe.Complete.API.Tests.Integration.Project.Conversion.Tasks
{
    [Collection(ApiTestCollection.ApiTestCollectionName)]
    public class ConversionStakeholderKickoffApiTest : ApiTestsBase
    {
        public ConversionStakeholderKickoffApiTest(ApiTestFixture apiTestFixture) : base(apiTestFixture)
        {
        }

        [Fact]
        public async Task Update_StakeholderKickoffTask_Returns_200()
        {
            var createProjectRequest = new CreateConversionProjectRequest();
            var createResponse = await _client.PostAsync(RouteConstants.CreateConversionProject, createProjectRequest.ConvertToJson());
            createResponse.StatusCode.Should().Be(HttpStatusCode.Created);

            var project = await createResponse.Content.ReadFromJsonAsync<CreateConversionProjectResponse>();

            var request = new UpdateConversionProjectByTaskRequest()
            {
                StakeholderKickoff = new ConversionStakeholderKickoffTask()
                {
                    HostMeetingOrCall = true,
                    SendIntroEmails = true,
                    SendInvites = true,
                    LocalAuthorityAbleToConvert = true,
                    LocalAuthorityProforma = true
                }
            };

            var updateResponse = await _client.PatchAsync($"{string.Format(RouteConstants.ConversionProjectTask, project.Id)}", request.ConvertToJson());
            updateResponse.StatusCode.Should().Be(HttpStatusCode.OK);

            var getResponse = await _client.GetAsync($"{string.Format(RouteConstants.ConversionProjectTask, project.Id)}?taskName={ConversionProjectTaskName.StakeholderKickoff}");
            getResponse.StatusCode.Should().Be(HttpStatusCode.OK);

            var updatedTask = await getResponse.Content.ReadFromJsonAsync<GetConversionProjectByTaskResponse>();

            updatedTask.StakeholderKickoff.HostMeetingOrCall.Should().BeTrue();
            updatedTask.StakeholderKickoff.SendIntroEmails.Should().BeTrue();
            updatedTask.StakeholderKickoff.SendInvites.Should().BeTrue();
            updatedTask.StakeholderKickoff.LocalAuthorityAbleToConvert.Should().BeTrue();
            updatedTask.StakeholderKickoff.LocalAuthorityProforma.Should().BeTrue();
        }

        [Fact]
        public async Task Get_StakeholderKickoff_TaskSummary_Returns_200()
        {
            var createProjectRequest = new CreateConversionProjectRequest();
            var createResponse = await _client.PostAsync(RouteConstants.CreateConversionProject, createProjectRequest.ConvertToJson());
            createResponse.StatusCode.Should().Be(HttpStatusCode.Created);

            var createdProject = await createResponse.Content.ReadFromJsonAsync<CreateConversionProjectResponse>();
            var projectId = createdProject.Id;

            var request = new UpdateConversionProjectByTaskRequest()
            {
                StakeholderKickoff = new()
                {
                    HostMeetingOrCall = true,
                }
            };

            var updateResponse = await _client.PatchAsync($"{string.Format(RouteConstants.ConversionProjectTask, projectId)}", request.ConvertToJson());
            updateResponse.StatusCode.Should().Be(HttpStatusCode.OK);

            var getResponse = await _client.GetAsync($"{string.Format(RouteConstants.ConversionProjectTaskSummary, projectId)}");
            getResponse.StatusCode.Should().Be(HttpStatusCode.OK);

            var summary = await getResponse.Content.ReadFromJsonAsync<GetConversionProjectByTaskSummaryResponse>();

            summary.StakeholderKickoff.Status.Should().Be(ProjectTaskStatus.InProgress);
        }
    }
}
