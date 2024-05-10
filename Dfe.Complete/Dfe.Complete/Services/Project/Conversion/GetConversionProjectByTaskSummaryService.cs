using Dfe.Complete.API.Contracts.Http;
using Dfe.Complete.API.Contracts.Project.Conversion.Tasks;
using System.Threading.Tasks;

namespace Dfe.Complete.Services.Project.Conversion
{
    public interface IGetConversionProjectByTaskSummaryService
    {
        public Task<GetConversionProjectByTaskSummaryResponse> Execute(string projectId);
    }

    public class GetConversionProjectByTaskSummaryService : IGetConversionProjectByTaskSummaryService
    {
        private readonly CompleteApiClient _completeApiClient;

        public GetConversionProjectByTaskSummaryService(CompleteApiClient completeApiClient)
        {
            _completeApiClient = completeApiClient;
        }

        public async Task<GetConversionProjectByTaskSummaryResponse> Execute(string projectId)
        {
            var endpoint = string.Format(RouteConstants.ConversionProjectTaskSummary, projectId);

            var result = await _completeApiClient.Get<GetConversionProjectByTaskSummaryResponse>(endpoint);

            return result;
        }
    }
}
