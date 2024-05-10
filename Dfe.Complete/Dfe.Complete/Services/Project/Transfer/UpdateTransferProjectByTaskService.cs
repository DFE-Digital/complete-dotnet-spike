using Dfe.Complete.API.Contracts.Http;
using Dfe.Complete.API.Contracts.Project.Transfer.Tasks;
using System.Threading.Tasks;

namespace Dfe.Complete.Services.Project.Transfer
{
    public interface IUpdateTransferProjectByTaskService
    {
        public Task Execute(string projectId, UpdateTransferProjectByTaskRequest request);
    }

    public class UpdateTransferProjectByTaskService : IUpdateTransferProjectByTaskService
    {
        private readonly CompleteApiClient _completeApiClient;

        public UpdateTransferProjectByTaskService(CompleteApiClient completeApiClient)
        {
            _completeApiClient = completeApiClient;
        }

        public async Task Execute(string projectId, UpdateTransferProjectByTaskRequest request)
        {
            var endpoint = string.Format(RouteConstants.ConversionProjectTask, projectId);

            await _completeApiClient.Patch<UpdateTransferProjectByTaskRequest, object>(endpoint, request);
        }
    }
}
