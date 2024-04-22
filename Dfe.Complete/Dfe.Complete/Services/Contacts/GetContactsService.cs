using System.Threading.Tasks;
using Dfe.ManageFreeSchoolProjects.API.Contracts.Project.Contacts;
using Dfe.ManageFreeSchoolProjects.API.Contracts.ResponseModels;

namespace Dfe.ManageFreeSchoolProjects.Services.Contacts;

public interface IGetContactsService
{
    public Task<GetContactsResponse> Execute(string projectId);
}

public class GetContactsService : IGetContactsService
{
    private readonly MfspApiClient _apiClient;

    public GetContactsService(MfspApiClient apiClient)
    {
        _apiClient = apiClient;
    }
    
    public async Task<GetContactsResponse> Execute(string projectId)
    {
        var endpoint = $"/api/v1/client/contacts?projectId={projectId}";

        var result = await _apiClient.Get<ApiSingleResponseV2<GetContactsResponse>>(endpoint);

        return result.Data;
    }
}