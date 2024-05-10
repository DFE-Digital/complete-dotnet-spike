using Dfe.Complete.API.Contracts.Http;
using Dfe.Complete.API.Contracts.Project;
using Dfe.Complete.API.Contracts.Project.Conversion.Tasks;
using Dfe.Complete.API.Contracts.Project.Tasks;
using Dfe.Complete.API.Tests.Fixtures;
using Dfe.Complete.API.Tests.Helpers;
using Dfe.Complete.Data.Entities;
using System;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Dfe.Complete.API.Tests.Integration.Project.Conversion.Tasks
{
    [Collection(ApiTestCollection.ApiTestCollectionName)]
    public class ConversionHandoverWithDeliveryOfficerTaskApiTests : ApiTestsBase
    {
        public ConversionHandoverWithDeliveryOfficerTaskApiTests(ApiTestFixture apiTestFixture) : base(apiTestFixture)
        {
        }

        [Fact]
        public async Task Update_HandoverWithDeliveryOfficerTask_Returns_200()
        {
            using var context = _testFixture.GetContext();
            var user = context.Users.FirstOrDefault(u => u.Email == _testFixture.DefaultUser.Email);

            var project = DatabaseModelBuilder.BuildInProgressProject(user);
            project.Type = ProjectType.Conversion;
            context.Projects.AddRange(project);

            var task = new ConversionTasksData();
            task.Id = Guid.NewGuid();
            project.TasksDataId = task.Id;
            project.TasksDataType = TaskType.Conversion;

            context.ConversionTasksData.Add(task);

            await context.SaveChangesAsync();

            var request = new UpdateConversionProjectByTaskRequest()
            {
                HandoverWithDeliveryOfficer = new HandoverWithDeliveryOfficerTask()
                {
                    AttendHandoverMeeting = true,
                    MakeNotes = true,
                    ReviewProjectInformation = true,
                    NotApplicable = true
                }
            };

            var updateResponse = await _client.PatchAsync($"{string.Format(RouteConstants.ConversionProjectTask, project.Id)}", request.ConvertToJson());
            updateResponse.StatusCode.Should().Be(HttpStatusCode.OK);

            var getResponse = await _client.GetAsync($"{string.Format(RouteConstants.ConversionProjectTask, project.Id)}?taskName={ConversionProjectTaskName.HandoverWithDeliveryOfficer}");
            getResponse.StatusCode.Should().Be(HttpStatusCode.OK);

            var updatedTask = await getResponse.Content.ReadFromJsonAsync<GetConversionProjectByTaskResponse>();

            updatedTask.HandoverWithDeliveryOfficer.NotApplicable.Should().BeTrue();
            updatedTask.HandoverWithDeliveryOfficer.AttendHandoverMeeting.Should().BeTrue();
            updatedTask.HandoverWithDeliveryOfficer.MakeNotes.Should().BeTrue();
            updatedTask.HandoverWithDeliveryOfficer.ReviewProjectInformation.Should().BeTrue();
        }

        [Fact]
        public async Task Get_HandoverWithDeliveryOfficer_TaskSummary_Returns_200()
        {
            using var context = _testFixture.GetContext();
            var user = context.Users.FirstOrDefault(u => u.Email == _testFixture.DefaultUser.Email);

            var project = DatabaseModelBuilder.BuildInProgressProject(user);
            project.Type = ProjectType.Conversion;
            context.Projects.AddRange(project);

            var task = new ConversionTasksData();
            task.Id = Guid.NewGuid();
            project.TasksDataId = task.Id;
            project.TasksDataType = TaskType.Conversion;

            context.ConversionTasksData.Add(task);

            await context.SaveChangesAsync();

            var request = new UpdateConversionProjectByTaskRequest()
            {
                HandoverWithDeliveryOfficer = new HandoverWithDeliveryOfficerTask()
                {
                    AttendHandoverMeeting = true
                }
            };

            var updateResponse = await _client.PatchAsync($"{string.Format(RouteConstants.ConversionProjectTask, project.Id)}", request.ConvertToJson());
            updateResponse.StatusCode.Should().Be(HttpStatusCode.OK);

            var getResponse = await _client.GetAsync($"{string.Format(RouteConstants.ConversionProjectTaskSummary, project.Id)}");
            getResponse.StatusCode.Should().Be(HttpStatusCode.OK);

            var summary = await getResponse.Content.ReadFromJsonAsync<GetConversionProjectByTaskSummaryResponse>();

            summary.HandoverWithDeliveryOfficer.Status.Should().Be(ProjectTaskStatus.InProgress);
        }
    }
}
