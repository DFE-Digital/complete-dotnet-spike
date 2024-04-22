using Dfe.ManageFreeSchoolProjects.API.Contracts.Project.Tasks;
using Dfe.ManageFreeSchoolProjects.API.Tests.Fixtures;
using Dfe.ManageFreeSchoolProjects.API.Tests.Helpers;
using Dfe.ManageFreeSchoolProjects.API.Tests.Utils;
using System.Net;
using System.Threading.Tasks;

namespace Dfe.ManageFreeSchoolProjects.API.Tests.Integration
{
    [Collection(ApiTestCollection.ApiTestCollectionName)]
	public class ProjectTaskApiTests : ApiTestsBase
	{
		public ProjectTaskApiTests(ApiTestFixture apiTestFixture) : base(apiTestFixture)
		{
		}

		[Fact]
		public async Task Get_ProjectByTask_NoDependentDataCreated_Returns_200()
		{
			// Ensures that if the child tables for the tasks are not populated, the api still works
			var project = DatabaseModelBuilder.BuildProject();
			var projectId = project.ProjectStatusProjectId;

			using var context = _testFixture.GetContext();
			context.Kpi.Add(project);

			var tasks = TasksStub.BuildListOfTasks(project.Rid);
			context.Tasks.AddRange(tasks);

			await context.SaveChangesAsync();

			var getProjectByTaskResponse = await _client.GetAsync($"/api/v1/client/projects/{projectId}/tasks/school");
			getProjectByTaskResponse.StatusCode.Should().Be(HttpStatusCode.OK);
		}

		[Fact]
		public async Task Get_ProjectByTask_DoesNotExist_Returns_404()
		{
			var getProjectByTaskResponse = await _client.GetAsync($"/api/v1/client/projects/NotExist/tasks/school");
			getProjectByTaskResponse.StatusCode.Should().Be(HttpStatusCode.NotFound);
		}

        [Fact]
		public async Task Patch_Task_NoProjectExists_Returns_404()
		{
			var request = new UpdateProjectByTaskRequest()
			{
			};

			var updateTaskResponse = await _client.PatchAsync($"/api/v1/client/projects/NotExist/tasks", request.ConvertToJson());
			updateTaskResponse.StatusCode.Should().Be(HttpStatusCode.NotFound);
		}
	}
}
