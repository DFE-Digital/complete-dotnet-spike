using Dfe.ManageFreeSchoolProjects.API.Contracts.Project.Tasks;
using Dfe.ManageFreeSchoolProjects.API.Contracts.ResponseModels;
using Dfe.ManageFreeSchoolProjects.API.Tests.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Dfe.ManageFreeSchoolProjects.API.Tests.Integration.Tasks
{
    public static class TaskExtensions
    {
        public static async Task<GetProjectByTaskResponse> UpdateProjectTask(this HttpClient client, string projectId, UpdateProjectByTaskRequest request, string taskName)
        {
            var updateTaskResponse = await client.PatchAsync($"/api/v1/client/projects/{projectId}/tasks", request.ConvertToJson());
            updateTaskResponse.StatusCode.Should().Be(HttpStatusCode.OK);

            var getProjectByTaskResponse = await client.GetAsync($"/api/v1/client/projects/{projectId}/tasks/{taskName}");
            getProjectByTaskResponse.StatusCode.Should().Be(HttpStatusCode.OK);

            var result = await getProjectByTaskResponse.Content.ReadFromJsonAsync<ApiSingleResponseV2<GetProjectByTaskResponse>>();

            return result.Data;
        }
    }
}
