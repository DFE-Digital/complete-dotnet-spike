using Dfe.Complete.API.Contracts.Project;
using Dfe.Complete.API.Contracts.Project.Transfer.Tasks;
using Dfe.Complete.API.Tests.Fixtures;
using Dfe.Complete.API.Tests.Helpers;
using Dfe.Complete.Data.Entities;
using System;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Dfe.Complete.API.Tests.Integration.Project.Transfer.Tasks
{
    [Collection(ApiTestCollection.ApiTestCollectionName)]
    public class HandoverWithDeliveryOfficerTaskApiTests : ApiTestsBase
    {
        public HandoverWithDeliveryOfficerTaskApiTests(ApiTestFixture apiTestFixture) : base(apiTestFixture)
        {
        }

        [Fact]
        public async Task Update_HanderWithDeliveryOfficerTask_Returns_200()
        {
            using var context = _testFixture.GetContext();
            var user = context.Users.FirstOrDefault(u => u.Email == _testFixture.DefaultUser.Email);

            var project = DatabaseModelBuilder.BuildInProgressProject(user);
            project.Type = ProjectType.Transfer;
            context.Projects.AddRange(project);

            var task = new TransferTasksData();
            task.Id = Guid.NewGuid();
            project.TasksDataId = task.Id;
            project.TasksDataType = TaskType.Transfer;

            context.TransferTasksData.Add(task);

            await context.SaveChangesAsync();

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

            var updateResponse = await _client.PatchAsync($"api/v1/client/projects/{project.Id}/transfer/tasks", request.ConvertToJson());
            updateResponse.StatusCode.Should().Be(HttpStatusCode.OK);

            var getResponse = await _client.GetAsync($"api/v1/client/projects/{project.Id}/transfer/tasks?taskName={TransferProjectTaskName.HandoverWithDeliveryOfficer}");
            getResponse.StatusCode.Should().Be(HttpStatusCode.OK);

            var updatedTask = await getResponse.Content.ReadFromJsonAsync<GetTransferProjectByTaskResponse>();

            updatedTask.HandoverWithRegionalDeliveryOfficer.NotApplicable.Should().BeTrue();
            updatedTask.HandoverWithRegionalDeliveryOfficer.AttendHandoverMeeting.Should().BeTrue();
            updatedTask.HandoverWithRegionalDeliveryOfficer.MakeNotes.Should().BeTrue();
            updatedTask.HandoverWithRegionalDeliveryOfficer.ReviewProjectInformation.Should().BeTrue();
        }
    }
}
