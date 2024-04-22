using Dfe.ManageFreeSchoolProjects.API.Contracts.Project.PupilNumbers;
using System.Threading.Tasks;

namespace Dfe.ManageFreeSchoolProjects.Services.Project
{
    public interface IUpdatePupilNumbersService
    {
        public Task Execute(string projectId, UpdatePupilNumbersRequest request);
    }

    public class UpdatePupilNumbersService : IUpdatePupilNumbersService
    {
        private readonly MfspApiClient _apiClient;

        public UpdatePupilNumbersService(MfspApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task Execute(string projectId, UpdatePupilNumbersRequest request)
        {
            var endpoint = $"/api/v1/client/projects/{projectId}/pupil-numbers";

            await _apiClient.Patch<UpdatePupilNumbersRequest, object>(endpoint, request);
        }
    }
}
