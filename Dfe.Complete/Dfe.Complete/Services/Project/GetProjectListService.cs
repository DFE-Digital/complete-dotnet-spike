using System.Threading.Tasks;

namespace Dfe.Complete.Services.Project
{
    public interface IGetProjectListService
    {
        public Task Execute();
    }

    public class GetProjectListService : IGetProjectListService
    {
        private readonly CompleteApiClient _apiClient;

        public GetProjectListService(CompleteApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task Execute()
        {
            var response = await _apiClient.Get<string>("/client/v1/projects/list");
        }
    }
}
