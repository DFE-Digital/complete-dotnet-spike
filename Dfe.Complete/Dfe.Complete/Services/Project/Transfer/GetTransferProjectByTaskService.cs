using Dfe.Complete.API.Contracts.Http;
using Dfe.Complete.API.Contracts.Project.Transfer.Tasks;
using System.Threading.Tasks;

namespace Dfe.Complete.Services.Project.Transfer
{
    public interface IGetTransferProjectByTaskService
    {
        public Task<GetTransferProjectByTaskResponse> Execute(string projectId, TransferProjectTaskName taskName);
    }

    public class GetTransferProjectByTaskService : IGetTransferProjectByTaskService
    {
        private readonly CompleteApiClient _completeApiClient;

        public GetTransferProjectByTaskService(CompleteApiClient completeApiClient)
        {
            _completeApiClient = completeApiClient;
        }

        public async Task<GetTransferProjectByTaskResponse> Execute(string projectId, TransferProjectTaskName taskName)
        {
            var endpoint = $"{string.Format(RouteConstants.TransferProjectTask, projectId)}?taskName={taskName}";

            var result = await _completeApiClient.Get<GetTransferProjectByTaskResponse>(endpoint);

            return result;
        }
    }
}
