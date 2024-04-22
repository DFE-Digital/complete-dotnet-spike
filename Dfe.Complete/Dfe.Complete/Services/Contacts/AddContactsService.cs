using System.Threading.Tasks;
using Dfe.ManageFreeSchoolProjects.API.Contracts.Project.Contacts;
using Dfe.ManageFreeSchoolProjects.API.Contracts.ResponseModels;
using Dfe.ManageFreeSchoolProjects.API.Contracts.RequestModels;

namespace Dfe.ManageFreeSchoolProjects.Services.Contacts;

public interface IAddContactsService
{
    public Task Execute(string projectId,UpdateContactsRequest request);
}

public class AddContactsService : IAddContactsService
{
    private readonly MfspApiClient _apiClient;

    public AddContactsService(MfspApiClient apiClient)
    {
        _apiClient = apiClient;
    }
    
    public async Task Execute(string projectId, UpdateContactsRequest request)
    {
        var endpoint = $"/api/v1/client/contacts?projectId={projectId}";

        await _apiClient.Patch<UpdateContactsRequest,object>(endpoint, request);
        
    }
}