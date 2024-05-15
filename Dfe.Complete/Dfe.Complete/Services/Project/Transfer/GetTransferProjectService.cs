using Dfe.Complete.API.Contracts.Http;
using Dfe.Complete.API.Contracts.Project.Transfer;
using System;
using System.Threading.Tasks;

namespace Dfe.Complete.Services.Project.Transfer
{
    public interface IGetTransferProjectService
    {
        public Task<GetTransferProjectResponse> Execute(string projectId);
    }

    public class GetTransferProjectService : IGetTransferProjectService
    {
        private CompleteApiClient _client;

        public GetTransferProjectService(CompleteApiClient client)
        {
            _client = client;
        }

        public async Task<GetTransferProjectResponse> Execute(string projectId)
        {
            var result = await _client.Get<GetTransferProjectResponse>(string.Format(RouteConstants.TransferProjectById, projectId));

            return result;
        }
    }
}
