using Dfe.Complete.API.Contracts.Http;
using Dfe.Complete.API.Contracts.Project.Notes;
using System.Threading.Tasks;

namespace Dfe.Complete.Services.Project
{
    public interface ICreateProjectNoteService
    {
        public Task Execute(string projectId, CreateProjectNoteRequest request);
    }

    public class CreateProjectNoteService : ICreateProjectNoteService
    {
        private readonly CompleteApiClient _completeClient;

        public CreateProjectNoteService(CompleteApiClient completeClient)
        {
            _completeClient = completeClient;
        }

        public async Task Execute(string projectId, CreateProjectNoteRequest request)
        {
            var endpoint = string.Format(RouteConstants.ProjectNote, projectId);

            await _completeClient.Post<CreateProjectNoteRequest, object>(endpoint, request);
        }
    }
}
