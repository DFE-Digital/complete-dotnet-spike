using Dfe.Complete.API.Contracts.Http;
using Dfe.Complete.API.Contracts.Project.Conversion;
using Dfe.Complete.API.Contracts.Project.Transfer;
using System.Threading.Tasks;

namespace Dfe.Complete.Services.Project.Conversion
{
    public interface IGetConversionProjectService
    {
        public Task<GetConversionProjectResponse> Execute(string projectId);
    }

    public class GetConversionProjectService : IGetConversionProjectService
    {
        private CompleteApiClient _client;

        public GetConversionProjectService(CompleteApiClient client)
        {
            _client = client;
        }

        public async Task<GetConversionProjectResponse> Execute(string projectId)
        {
            var result = await _client.Get<GetConversionProjectResponse>(string.Format(RouteConstants.ConversionProjectById, projectId));

            return result;
        }
    }
}
