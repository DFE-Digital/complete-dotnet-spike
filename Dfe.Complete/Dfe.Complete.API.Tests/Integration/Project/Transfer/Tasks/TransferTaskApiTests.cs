using Dfe.Complete.API.Contracts.Project;
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
    public class TransferTaskApiTests : ApiTestsBase
    {
        public TransferTaskApiTests(ApiTestFixture apiTestFixture) : base(apiTestFixture)
        {
        }

        [Fact]
        public async Task Get_ProjectDoesNotExist_Returns_404()
        {
            var projectId = Guid.NewGuid();

            var response = await _client.GetAsync($"api/v1/client/projects/{projectId}/transfer/tasks?taskName={TransferProjectTaskName.HandoverWithDeliveryOfficer}");
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task Get_ProjectExists_TypeIsNotTransfer_Returns_404()
        {
            using var context = _testFixture.GetContext();
            var project = DatabaseModelBuilder.BuildProject();
            project.Type = ProjectType.Conversion;
            var projectId = project.Id;
            context.Projects.Add(project);
            await context.SaveChangesAsync();

            var response = await _client.GetAsync($"api/v1/client/projects/{projectId}/transfer/tasks?taskName={TransferProjectTaskName.HandoverWithDeliveryOfficer}");
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task Get_TransferTaskDoesNotExist_Returns_EmptyTask_200()
        {
            using var context = _testFixture.GetContext();
            var project = DatabaseModelBuilder.BuildProject();
            project.Type = ProjectType.Transfer;
            var projectId = project.Id;
            context.Projects.Add(project);
            await context.SaveChangesAsync();

            var response = await _client.GetAsync($"api/v1/client/projects/{projectId}/transfer/tasks?taskName={TransferProjectTaskName.HandoverWithDeliveryOfficer}");
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var taskResponse = await response.Content.ReadFromJsonAsync<GetTransferProjectByTaskResponse>();
            
            taskResponse.HandoverWithDeliveryOfficer.Should().NotBeNull();
            taskResponse.HandoverWithDeliveryOfficer.AttendHandoverMeeting.Should().BeNull();
            taskResponse.SchoolName.Should().Be("Establishment 1");
        }

        [Fact]
        public async Task Get_TransferTaskTypeInvalid_Returns_400()
        {
            var projectId = Guid.NewGuid();

            var response = await _client.GetAsync($"api/v1/client/projects/{projectId}/transfer/tasks?taskName=Invalid");
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task Update_ProjectDoesNotExist_Returns_404()
        {
            var projectId = Guid.NewGuid();
            var request = new UpdateTransferProjectByTaskRequest();

            var response = await _client.PatchAsync($"api/v1/client/projects/{projectId}/transfer/tasks", request.ConvertToJson());
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task Update_ProjectExists_TypeIsNotTransfer_Returns_404()
        {
            var request = new UpdateTransferProjectByTaskRequest();

            using var context = _testFixture.GetContext();
            var project = DatabaseModelBuilder.BuildProject();
            project.Type = ProjectType.Conversion;
            var projectId = project.Id;
            context.Projects.Add(project);
            await context.SaveChangesAsync();

            var response = await _client.PatchAsync($"api/v1/client/projects/{projectId}/transfer/tasks", request.ConvertToJson());
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task Update_TransferTaskDoesNotExist_Returns_422()
        {
            var request = new UpdateTransferProjectByTaskRequest()
            {
                HandoverWithDeliveryOfficer = new HandoverWithDeliveryOfficerTask()
                {
                    AttendHandoverMeeting = true
                }
            };

            using var context = _testFixture.GetContext();
            var project = DatabaseModelBuilder.BuildProject();
            project.Type = ProjectType.Transfer;
            var projectId = project.Id;
            context.Projects.Add(project);
            await context.SaveChangesAsync();

            var updateResponse = await _client.PatchAsync($"api/v1/client/projects/{projectId}/transfer/tasks", request.ConvertToJson());
            updateResponse.StatusCode.Should().Be(HttpStatusCode.UnprocessableEntity);
        }
    }
}
