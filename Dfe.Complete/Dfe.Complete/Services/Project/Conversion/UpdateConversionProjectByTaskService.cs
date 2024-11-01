using Dfe.Complete.API.Contracts.Http;
using Dfe.Complete.API.Contracts.Project.Conversion.Tasks;
using System.Threading.Tasks;

namespace Dfe.Complete.Services.Project.Conversion
{
    public interface IUpdateConversionProjectByTaskService
    {
        public Task Execute(string projectId, UpdateConversionProjectByTaskRequest request);
    }

    public class UpdateConversionProjectByTaskService : IUpdateConversionProjectByTaskService
    {
        private readonly CompleteApiClient _completeApiClient;

        public UpdateConversionProjectByTaskService(CompleteApiClient completeApiClient)
        {
            _completeApiClient = completeApiClient;
        }

        public async Task Execute(string projectId, UpdateConversionProjectByTaskRequest request)
        {
            var endpoint = string.Format(RouteConstants.ConversionProjectTask, projectId);

            await _completeApiClient.Patch<UpdateConversionProjectByTaskRequest, object>(endpoint, request);
        }
    }
}
