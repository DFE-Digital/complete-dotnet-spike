using Dfe.Complete.API.Contracts.Http;
using Dfe.Complete.API.Contracts.Project;
using Dfe.Complete.API.Contracts.Project.Tasks;
using Dfe.Complete.API.Contracts.Project.Transfer;
using Dfe.Complete.API.Contracts.Project.Transfer.Tasks;
using Dfe.Complete.API.Tests.Fixtures;
using Dfe.Complete.API.Tests.Helpers;
using System.Net;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Dfe.Complete.API.Tests.Integration.Project.Transfer.Tasks
{
    [Collection(ApiTestCollection.ApiTestCollectionName)]
    public class TransferStakeholderKickoffApiTest : ApiTestsBase
    {
        public TransferStakeholderKickoffApiTest(ApiTestFixture apiTestFixture) : base(apiTestFixture)
        {
        }

        [Fact]
        public async Task Update_StakeholderKickoffTask_Returns_200()
        {
            var createProjectRequest = new CreateTransferProjectRequest();
            var createResponse = await _client.PostAsync(RouteConstants.CreateTransferProject, createProjectRequest.ConvertToJson());
            createResponse.StatusCode.Should().Be(HttpStatusCode.Created);

            var project = await createResponse.Content.ReadFromJsonAsync<CreateTransferProjectResponse>();

            var request = new UpdateTransferProjectByTaskRequest()
            {
                StakeholderKickoff = new StakeholderKickoffTask()
                {
                    HostMeetingOrCall = true,
                    SendIntroEmails = true,
                    SendInvites = true
                }
            };

            var updateResponse = await _client.PatchAsync($"{string.Format(RouteConstants.TransferProjectTask, project.Id)}", request.ConvertToJson());
            updateResponse.StatusCode.Should().Be(HttpStatusCode.OK);

            var getResponse = await _client.GetAsync($"{string.Format(RouteConstants.TransferProjectTask, project.Id)}?taskName={TransferProjectTaskName.StakeholderKickoff}");
            getResponse.StatusCode.Should().Be(HttpStatusCode.OK);

            var updatedTask = await getResponse.Content.ReadFromJsonAsync<GetTransferProjectByTaskResponse>();

            updatedTask.StakeholderKickoff.HostMeetingOrCall.Should().BeTrue();
            updatedTask.StakeholderKickoff.SendIntroEmails.Should().BeTrue();
            updatedTask.StakeholderKickoff.SendInvites.Should().BeTrue();
        }

        [Fact]
        public async Task Get_StakeholderKickoff_TaskSummary_Returns_200()
        {
            var createProjectRequest = new CreateTransferProjectRequest();
            var createResponse = await _client.PostAsync(RouteConstants.CreateTransferProject, createProjectRequest.ConvertToJson());
            createResponse.StatusCode.Should().Be(HttpStatusCode.Created);

            var createdProject = await createResponse.Content.ReadFromJsonAsync<CreateTransferProjectResponse>();
            var projectId = createdProject.Id;

            var request = new UpdateTransferProjectByTaskRequest()
            {
                StakeholderKickoff = new()
                {
                    HostMeetingOrCall = true,
                }
            };

            var updateResponse = await _client.PatchAsync($"{string.Format(RouteConstants.TransferProjectTask, projectId)}", request.ConvertToJson());
            updateResponse.StatusCode.Should().Be(HttpStatusCode.OK);

            var getResponse = await _client.GetAsync($"{string.Format(RouteConstants.TransferProjectTaskSummary, projectId)}");
            getResponse.StatusCode.Should().Be(HttpStatusCode.OK);

            var summary = await getResponse.Content.ReadFromJsonAsync<GetTransferProjectByTaskSummaryResponse>();

            summary.StakeholderKickoff.Status.Should().Be(ProjectTaskStatus.InProgress);
        }
    }
}
