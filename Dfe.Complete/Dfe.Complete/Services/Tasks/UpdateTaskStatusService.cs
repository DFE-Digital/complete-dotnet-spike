using System;
using System.Threading.Tasks;
using Dfe.ManageFreeSchoolProjects.API.Contracts.Task;

namespace Dfe.ManageFreeSchoolProjects.Services.Tasks;

public interface IUpdateTaskStatusService
{
    Task Execute(string projectId, UpdateTaskStatusRequest request);
}

public class UpdateTaskStatusService : IUpdateTaskStatusService
{
    private readonly MfspApiClient _apiClient;

    public UpdateTaskStatusService(MfspApiClient apiClient)
    {
        _apiClient = apiClient;
    }

    public async Task Execute(string projectId, UpdateTaskStatusRequest request)
    {
        var endpoint = $"/api/v1/{projectId}/task/status";

        try
        {
            await _apiClient.Patch<UpdateTaskStatusRequest, object>(endpoint, request);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}

