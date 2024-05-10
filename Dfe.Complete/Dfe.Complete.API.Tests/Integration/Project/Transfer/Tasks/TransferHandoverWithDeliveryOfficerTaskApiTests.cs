using Dfe.Complete.API.Contracts.Http;
using Dfe.Complete.API.Contracts.Project;
using Dfe.Complete.API.Contracts.Project.Tasks;
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
    public class TransferHandoverWithDeliveryOfficerTaskApiTests : ApiTestsBase
    {
        public TransferHandoverWithDeliveryOfficerTaskApiTests(ApiTestFixture apiTestFixture) : base(apiTestFixture)
        {
        }

        [Fact]
        public async Task Update_HandoverWithDeliveryOfficerTask_Returns_200()
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

            var updateResponse = await _client.PatchAsync($"{string.Format(RouteConstants.TransferProjectTask, project.Id)}", request.ConvertToJson());
            updateResponse.StatusCode.Should().Be(HttpStatusCode.OK);

            var getResponse = await _client.GetAsync($"{string.Format(RouteConstants.TransferProjectTask, project.Id)}?taskName={TransferProjectTaskName.HandoverWithDeliveryOfficer}");
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
                    AttendHandoverMeeting = true
                }
            };

            var updateResponse = await _client.PatchAsync($"{string.Format(RouteConstants.TransferProjectTask, project.Id)}", request.ConvertToJson());
            updateResponse.StatusCode.Should().Be(HttpStatusCode.OK);

            var getResponse = await _client.GetAsync($"{string.Format(RouteConstants.TransferProjectTaskSummary, project.Id)}");
            getResponse.StatusCode.Should().Be(HttpStatusCode.OK);

            var summary = await getResponse.Content.ReadFromJsonAsync<GetTransferProjectByTaskSummaryResponse>();

            summary.HandoverWithDeliveryOfficer.Status.Should().Be(ProjectTaskStatus.InProgress);
        }
    }
}
