using Dfe.Complete.API.Contracts.Http;
using Dfe.Complete.API.Contracts.Project.Notes;
using System.Threading.Tasks;

namespace Dfe.Complete.Services.Project
{
    public interface IGetProjectNoteListService
    {
        public Task<GetProjectNoteListResponse> Execute(string projectId);
    }

    public class GetProjectNoteListService : IGetProjectNoteListService
    {
        private readonly CompleteApiClient _apiClient;

        public GetProjectNoteListService(CompleteApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<GetProjectNoteListResponse> Execute(string projectId)
        {
            var endpoint = string.Format(RouteConstants.ProjectNote, projectId);

            var result = await _apiClient.Get<GetProjectNoteListResponse>(endpoint);

            return result;
        }
    }
}
