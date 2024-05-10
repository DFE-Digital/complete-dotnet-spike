using Dfe.Complete.API.Contracts.Http;
using Dfe.Complete.API.Contracts.Project.Transfer.Tasks;
using System.Threading.Tasks;

namespace Dfe.Complete.Services.Project.Transfer
{
    public interface IGetTransferProjectByTaskSummaryService
    {
        public Task<GetTransferProjectByTaskSummaryResponse> Execute(string projectId);
    }

    public class GetTransferProjectByTaskSummaryService : IGetTransferProjectByTaskSummaryService
    {
        private readonly CompleteApiClient _completeApiClient;

        public GetTransferProjectByTaskSummaryService(CompleteApiClient completeApiClient)
        {
            _completeApiClient = completeApiClient;
        }

        public async Task<GetTransferProjectByTaskSummaryResponse> Execute(string projectId)
        {
            var endpoint = string.Format(RouteConstants.TransferProjectTaskSummary, projectId);

            var result = await _completeApiClient.Get<GetTransferProjectByTaskSummaryResponse>(endpoint);

            return result;
        }
    }
}
