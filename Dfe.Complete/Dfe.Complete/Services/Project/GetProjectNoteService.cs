using Dfe.Complete.API.Contracts.Http;
using Dfe.Complete.API.Contracts.Project.Notes;
using System.Threading.Tasks;

namespace Dfe.Complete.Services.Project
{
    public interface IGetProjectNoteService
    {
        public Task<GetProjectNoteResponse> Execute(string projectId, string noteId);
    }

    public class GetProjectNoteService : IGetProjectNoteService
    {
        private readonly CompleteApiClient _completeApiClient;

        public GetProjectNoteService(CompleteApiClient completeApiClient)
        {
            _completeApiClient = completeApiClient;
        }

        public async Task<GetProjectNoteResponse> Execute(string projectId, string noteId)
        {
            var endpoint = string.Format(RouteConstants.ProjectNoteById, projectId, noteId);

            var note = await _completeApiClient.Get<GetProjectNoteResponse>(endpoint);

            return note;
        }
    }
}
