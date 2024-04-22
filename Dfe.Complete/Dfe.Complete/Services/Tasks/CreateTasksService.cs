using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Dfe.ManageFreeSchoolProjects.Services.Tasks;

public interface ICreateTasksService
{ 
    Task Execute(string projectId);
}

public class CreateTasksService : ICreateTasksService
{
    private readonly MfspApiClient _apiClient;

    public CreateTasksService(MfspApiClient apiClient)
    {
        _apiClient = apiClient;
    }

    public async Task Execute(string projectId)
    {
        var endpoint = $"/api/v1/{projectId}/task/status";
        await _apiClient.Post<object, object>(endpoint, new {});
    }
}
