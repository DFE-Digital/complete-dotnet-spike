using Dfe.Complete.API.Contracts.Http;
using Dfe.Complete.API.Contracts.Project.Notes;
using System.Threading.Tasks;

namespace Dfe.Complete.Services.Project
{
    public interface IUpdateProjectNoteService
    {
        public Task Execute(string projectId, string noteId, UpdateProjectNoteRequest request);
    }

    public class UpdateProjectNoteService : IUpdateProjectNoteService
    {
        private readonly CompleteApiClient _completeClient;

        public UpdateProjectNoteService(CompleteApiClient completeClient)
        {
            _completeClient = completeClient;
        }

        public async Task Execute(string projectId, string noteId, UpdateProjectNoteRequest request)
        {
            var endpoint = string.Format(RouteConstants.ProjectNoteById, projectId, noteId);

            await _completeClient.Patch<UpdateProjectNoteRequest, object>(endpoint, request);
        }
    }
}
