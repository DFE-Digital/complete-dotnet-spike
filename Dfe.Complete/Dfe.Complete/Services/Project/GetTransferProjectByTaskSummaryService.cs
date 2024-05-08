using Dfe.Complete.API.Contracts.Project.Transfer.Tasks;
using System.Threading.Tasks;

namespace Dfe.Complete.Services.Project
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
            var endpoint = $"/api/v1/client/projects/{projectId}/transfer/tasks/summary";

            var result = await _completeApiClient.Get<GetTransferProjectByTaskSummaryResponse>(endpoint);

            return result;
        }
    }
}
