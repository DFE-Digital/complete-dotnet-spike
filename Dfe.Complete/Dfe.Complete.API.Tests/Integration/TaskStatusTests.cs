using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Dfe.ManageFreeSchoolProjects.API.Contracts.Project.Tasks;
using Dfe.ManageFreeSchoolProjects.API.Contracts.ResponseModels;
using Dfe.ManageFreeSchoolProjects.API.Contracts.Task;
using Dfe.ManageFreeSchoolProjects.API.Tests.Fixtures;
using Dfe.ManageFreeSchoolProjects.API.Tests.Helpers;
using Dfe.ManageFreeSchoolProjects.API.Tests.Utils;
using Dfe.ManageFreeSchoolProjects.API.UseCases.Tasks;
using Dfe.ManageFreeSchoolProjects.Data.Entities.Existing;
using Microsoft.EntityFrameworkCore;

namespace Dfe.ManageFreeSchoolProjects.API.Tests.Integration;

[Collection(ApiTestCollection.ApiTestCollectionName)]
public class TaskStatusTests : ApiTestsBase
{
    public TaskStatusTests(ApiTestFixture apiTestFixture) : base(apiTestFixture)
    {
    }

    [Fact]
    public async Task When_Get_Returns_TaskStatus_200_OK()
    {
        using var context = _testFixture.GetContext();

        var project = DatabaseModelBuilder.BuildProject();
        context.Kpi.Add(project);

        var tasks = TasksStub.BuildListOfTasks(project.Rid);
        context.Tasks.AddRange(tasks);

        await context.SaveChangesAsync();

        var taskStatusResponse =
            await _client.GetAsync($"/api/v1/{project.ProjectStatusProjectId}/task/status?taskName={TaskName.School}");
        taskStatusResponse.StatusCode.Should().Be(HttpStatusCode.OK);

        var responseContent =
            await taskStatusResponse.Content.ReadFromJsonAsync<ApiSingleResponseV2<TaskStatusResponse>>();

        responseContent.Data.ProjectTaskStatus.Should().Be(Status.NotStarted.Map());
    }
    
    [Fact]
    public async Task When_Get_With_No_TaskName_Returns_400BadRequest()
    {
        using var context = _testFixture.GetContext();

        var project = DatabaseModelBuilder.BuildProject();
        context.Kpi.Add(project);

        var tasks = TasksStub.BuildListOfTasks(project.Rid);
        context.Tasks.AddRange(tasks);

        await context.SaveChangesAsync();

        var taskStatusResponse =
            await _client.GetAsync($"/api/v1/{project.ProjectStatusProjectId}/task/status");
        taskStatusResponse.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }
    
    
    [InlineData("School", ProjectTaskStatus.InProgress)]
    [Theory]
    public async Task When_Patch_TaskStatus_Updated_Returns_200_OK(string expectedTaskName, ProjectTaskStatus expectedProjectTaskStatus)
    {
        using var context = _testFixture.GetContext();

        var project = DatabaseModelBuilder.BuildProject();
        context.Kpi.Add(project);

        var tasks = TasksStub.BuildListOfTasks(project.Rid);
        context.Tasks.AddRange(tasks);

        await context.SaveChangesAsync();

        var updateTaskStatusRequest = new UpdateTaskStatusRequest
        {
            ProjectTaskStatus = expectedProjectTaskStatus, TaskName = expectedTaskName
        };
        
        var taskUpdateResponse =
            await _client.PatchAsync($"/api/v1/{project.ProjectStatusProjectId}/task/status", updateTaskStatusRequest.ConvertToJson());
        taskUpdateResponse.StatusCode.Should().Be(HttpStatusCode.OK);

        var taskStatusResponse =
            await _client.GetAsync($"/api/v1/{project.ProjectStatusProjectId}/task/status?taskName={expectedTaskName}");
        taskStatusResponse.StatusCode.Should().Be(HttpStatusCode.OK);

        var responseContent =
            await taskStatusResponse.Content.ReadFromJsonAsync<ApiSingleResponseV2<TaskStatusResponse>>();

        responseContent.Data.ProjectTaskStatus.Should().Be(expectedProjectTaskStatus);
    }
    
    [Fact]
    public async Task When_Patch_TaskStatus_With_No_TaskName_Returns_400BadRequest()
    {
        using var context = _testFixture.GetContext();

        var project = DatabaseModelBuilder.BuildProject();
        context.Kpi.Add(project);

        var tasks = TasksStub.BuildListOfTasks(project.Rid);
        context.Tasks.AddRange(tasks);

        await context.SaveChangesAsync();

        var updateTaskStatusRequest = new UpdateTaskStatusRequest
        {
        };
        
        var taskUpdateResponse =
            await _client.PatchAsync($"/api/v1/{project.ProjectStatusProjectId}/task/status", updateTaskStatusRequest.ConvertToJson());
        taskUpdateResponse.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task When_Post_Creates_Tasks_Returns_201Created()
    {
        using var context = _testFixture.GetContext();
        var project = DatabaseModelBuilder.BuildProject();
        context.Kpi.Add(project);
        await context.SaveChangesAsync();
        
        var createTasksRequest = await _client.PostAsync($"/api/v1/{project.ProjectStatusProjectId}/task/status", null);

        createTasksRequest.StatusCode.Should().Be(HttpStatusCode.Created);

        var tasks = await context.Tasks.Where(x => x.Rid == project.Rid).ToListAsync();

        tasks.Should().NotBeNull();
        tasks.Count.Should().BeGreaterThan(1);
    }
}