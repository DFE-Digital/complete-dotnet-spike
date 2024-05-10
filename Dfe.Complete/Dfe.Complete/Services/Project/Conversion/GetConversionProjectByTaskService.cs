using Dfe.Complete.API.Contracts.Http;
using Dfe.Complete.API.Contracts.Project.Conversion.Tasks;
using System.Threading.Tasks;

namespace Dfe.Complete.Services.Project.Conversion
{
    public interface IGetConversionProjectByTaskService
    {
        public Task<GetConversionProjectByTaskResponse> Execute(string projectId, ConversionProjectTaskName taskName);
    }

    public class GetConversionProjectByTaskService : IGetConversionProjectByTaskService
    {
        private readonly CompleteApiClient _completeApiClient;

        public GetConversionProjectByTaskService(CompleteApiClient completeApiClient)
        {
            _completeApiClient = completeApiClient;
        }

        public async Task<GetConversionProjectByTaskResponse> Execute(string projectId, ConversionProjectTaskName taskName)
        {
            var endpoint = $"{string.Format(RouteConstants.ConversionProjectTask, projectId)}?taskName={taskName}";

            var result = await _completeApiClient.Get<GetConversionProjectByTaskResponse>(endpoint);

            return result;
        }
    }
}
