using Dfe.Complete.API.Contracts.Http;
using Dfe.Complete.API.Contracts.Project;
using Dfe.Complete.API.Contracts.Project.Conversion.Tasks;
using Dfe.Complete.API.Contracts.Project.Tasks;
using Dfe.Complete.API.Tests.Fixtures;
using Dfe.Complete.API.Tests.Helpers;
using System;
using System.Net;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Dfe.Complete.API.Tests.Integration.Project.Conversion.Tasks
{
    [Collection(ApiTestCollection.ApiTestCollectionName)]
    public class ConversionTaskApiTests : ApiTestsBase
    {
        public ConversionTaskApiTests(ApiTestFixture apiTestFixture) : base(apiTestFixture)
        {
        }

        [Fact]
        public async Task Get_ProjectDoesNotExist_Returns_404()
        {
            var projectId = Guid.NewGuid();

            var response = await _client.GetAsync($"{string.Format(RouteConstants.ConversionProjectTask, projectId)}?taskName={ConversionProjectTaskName.HandoverWithDeliveryOfficer}");
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);

            var error = await response.Content.ReadAsStringAsync();
            error.Should().Contain($"Project with id {projectId} not found");
        }

        [Fact]
        public async Task Get_ProjectExists_TypeIsNotConversion_Returns_404()
        {
            using var context = _testFixture.GetContext();
            var project = DatabaseModelBuilder.BuildProject();
            project.Type = ProjectType.Transfer;
            var projectId = project.Id;
            context.Projects.Add(project);
            await context.SaveChangesAsync();

            var response = await _client.GetAsync($"{string.Format(RouteConstants.ConversionProjectTask, projectId)}?taskName={ConversionProjectTaskName.HandoverWithDeliveryOfficer}");
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);

            var error = await response.Content.ReadAsStringAsync();
            error.Should().Contain($"Project with id {projectId} not found");
        }

        [Fact]
        public async Task Get_ConversionTaskDoesNotExist_Returns_EmptyTask_200()
        {
            using var context = _testFixture.GetContext();
            var project = DatabaseModelBuilder.BuildProject();
            project.Type = ProjectType.Conversion;
            var projectId = project.Id;
            context.Projects.Add(project);
            await context.SaveChangesAsync();

            var response = await _client.GetAsync($"{string.Format(RouteConstants.ConversionProjectTask, projectId)}?taskName={ConversionProjectTaskName.HandoverWithDeliveryOfficer}");
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var taskResponse = await response.Content.ReadFromJsonAsync<GetConversionProjectByTaskResponse>();
            
            taskResponse.HandoverWithDeliveryOfficer.Should().NotBeNull();
            taskResponse.HandoverWithDeliveryOfficer.AttendHandoverMeeting.Should().BeNull();
            taskResponse.SchoolName.Should().Be("Establishment 1");
        }

        [Fact]
        public async Task Get_ConversionTaskTypeInvalid_Returns_400()
        {
            var projectId = Guid.NewGuid();

            var response = await _client.GetAsync($"{string.Format(RouteConstants.ConversionProjectTask, projectId)}?taskName=Invalid");
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task Update_ProjectDoesNotExist_Returns_404()
        {
            var projectId = Guid.NewGuid();
            var request = new UpdateConversionProjectByTaskRequest();

            var response = await _client.PatchAsync($"{string.Format(RouteConstants.ConversionProjectTask, projectId)}", request.ConvertToJson());
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);

            var error = await response.Content.ReadAsStringAsync();
            error.Should().Contain($"Project with id {projectId} not found");
        }

        [Fact]
        public async Task Update_ProjectExists_TypeIsNotConversion_Returns_404()
        {
            var request = new UpdateConversionProjectByTaskRequest();

            using var context = _testFixture.GetContext();
            var project = DatabaseModelBuilder.BuildProject();
            project.Type = ProjectType.Transfer;
            var projectId = project.Id;
            context.Projects.Add(project);
            await context.SaveChangesAsync();

            var response = await _client.PatchAsync($"{string.Format(RouteConstants.ConversionProjectTask, projectId)}", request.ConvertToJson());
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);

            var error = await response.Content.ReadAsStringAsync();
            error.Should().Contain($"Project with id {projectId} not found");
        }

        [Fact]
        public async Task Update_ConversionTaskDoesNotExist_Returns_422()
        {
            var request = new UpdateConversionProjectByTaskRequest()
            {
                HandoverWithDeliveryOfficer = new HandoverWithDeliveryOfficerTask()
                {
                    AttendHandoverMeeting = true
                }
            };

            using var context = _testFixture.GetContext();
            var project = DatabaseModelBuilder.BuildProject();
            project.Type = ProjectType.Conversion;
            var projectId = project.Id;
            context.Projects.Add(project);
            await context.SaveChangesAsync();

            var updateResponse = await _client.PatchAsync($"{string.Format(RouteConstants.ConversionProjectTask, projectId)}", request.ConvertToJson());
            updateResponse.StatusCode.Should().Be(HttpStatusCode.UnprocessableEntity);
        }
    }
}
