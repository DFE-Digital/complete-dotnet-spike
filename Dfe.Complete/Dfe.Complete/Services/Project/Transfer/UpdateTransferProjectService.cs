using Dfe.Complete.API.Contracts.Http;
using Dfe.Complete.API.Contracts.Project.Transfer;
using System.Threading.Tasks;

namespace Dfe.Complete.Services.Project.Transfer
{
    public interface IUpdateTransferProjectService
    {
        public Task Execute(string projectId, UpdateTransferProjectRequest request);
    }

    public class UpdateTransferProjectService : IUpdateTransferProjectService
    {
        private readonly CompleteApiClient _client;

        public UpdateTransferProjectService(CompleteApiClient client)
        {
            _client = client;
        }

        public async Task Execute(string projectId, UpdateTransferProjectRequest request)
        {
            var endpoint = string.Format(RouteConstants.TransferProjectById, projectId);

            await _client.Patch<UpdateTransferProjectRequest, object>(endpoint, request);
        }
    }
}
