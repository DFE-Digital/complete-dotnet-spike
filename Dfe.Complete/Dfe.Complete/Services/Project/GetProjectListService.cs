using Dfe.Complete.API.Contracts.Common;
using Dfe.Complete.API.Contracts.Project;
using System.Threading.Tasks;

namespace Dfe.Complete.Services.Project
{
    public interface IGetProjectListService
    {
        public Task<ApiListWrapper<ProjectListEntryResponse>> Execute();
    }

    public class GetProjectListService : IGetProjectListService
    {
        private readonly CompleteApiClient _apiClient;

        public GetProjectListService(CompleteApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<ApiListWrapper<ProjectListEntryResponse>> Execute()
        {
            var response = await _apiClient.Get<ApiListWrapper<ProjectListEntryResponse>>("/api/v1/client/projects/list");

            return response;
        }
    }
}
