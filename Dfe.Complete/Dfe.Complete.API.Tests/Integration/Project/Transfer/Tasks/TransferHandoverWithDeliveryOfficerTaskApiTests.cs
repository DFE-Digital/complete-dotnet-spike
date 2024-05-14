using Dfe.Complete.API.Contracts.Http;
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
    public class TransferHandoverWithDeliveryOfficerTaskApiTests : ApiTestsBase
    {
        public TransferHandoverWithDeliveryOfficerTaskApiTests(ApiTestFixture apiTestFixture) : base(apiTestFixture)
        {
        }

        [Fact]
        public async Task Update_HandoverWithDeliveryOfficerTask_Returns_200()
        {
            var createProjectRequest = new CreateTransferProjectRequest();
            var createResponse = await _client.PostAsync(RouteConstants.CreateTransferProject, createProjectRequest.ConvertToJson());
            createResponse.StatusCode.Should().Be(HttpStatusCode.Created);

            var createdProject = await createResponse.Content.ReadFromJsonAsync<CreateTransferProjectResponse>();
            var projectId = createdProject.Id;

            var request = new UpdateTransferProjectByTaskRequest()
            {
                HandoverWithDeliveryOfficer = new HandoverWithDeliveryOfficerTask()
                {
                    AttendHandoverMeeting = true,
                    MakeNotes = true,
                    ReviewProjectInformation = true,
                    NotApplicable = true
                }
            };

            var updateResponse = await _client.PatchAsync($"{string.Format(RouteConstants.TransferProjectTask, projectId)}", request.ConvertToJson());
            updateResponse.StatusCode.Should().Be(HttpStatusCode.OK);

            var getResponse = await _client.GetAsync($"{string.Format(RouteConstants.TransferProjectTask, projectId)}?taskName={TransferProjectTaskName.HandoverWithDeliveryOfficer}");
            getResponse.StatusCode.Should().Be(HttpStatusCode.OK);

            var updatedTask = await getResponse.Content.ReadFromJsonAsync<GetTransferProjectByTaskResponse>();

            updatedTask.HandoverWithDeliveryOfficer.NotApplicable.Should().BeTrue();
            updatedTask.HandoverWithDeliveryOfficer.AttendHandoverMeeting.Should().BeTrue();
            updatedTask.HandoverWithDeliveryOfficer.MakeNotes.Should().BeTrue();
            updatedTask.HandoverWithDeliveryOfficer.ReviewProjectInformation.Should().BeTrue();
        }

        [Fact]
        public async Task Get_HandoverWithDeliveryOffer_TaskSummary_Returns_200()
        {
            var createProjectRequest = new CreateTransferProjectRequest();
            var createResponse = await _client.PostAsync(RouteConstants.CreateTransferProject, createProjectRequest.ConvertToJson());
            createResponse.StatusCode.Should().Be(HttpStatusCode.Created);

            var createdProject = await createResponse.Content.ReadFromJsonAsync<CreateTransferProjectResponse>();
            var projectId = createdProject.Id;

            var request = new UpdateTransferProjectByTaskRequest()
            {
                HandoverWithDeliveryOfficer = new HandoverWithDeliveryOfficerTask()
                {
                    AttendHandoverMeeting = true
                }
            };

            var updateResponse = await _client.PatchAsync($"{string.Format(RouteConstants.TransferProjectTask, projectId)}", request.ConvertToJson());
            updateResponse.StatusCode.Should().Be(HttpStatusCode.OK);

            var getResponse = await _client.GetAsync($"{string.Format(RouteConstants.TransferProjectTaskSummary, projectId)}");
            getResponse.StatusCode.Should().Be(HttpStatusCode.OK);

            var summary = await getResponse.Content.ReadFromJsonAsync<GetTransferProjectByTaskSummaryResponse>();

            summary.HandoverWithDeliveryOfficer.Status.Should().Be(ProjectTaskStatus.InProgress);
        }
    }
}
