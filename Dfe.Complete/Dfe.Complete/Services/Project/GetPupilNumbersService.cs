using Dfe.ManageFreeSchoolProjects.API.Contracts.Project.PupilNumbers;
using Dfe.ManageFreeSchoolProjects.API.Contracts.Project.Risk;
using Dfe.ManageFreeSchoolProjects.API.Contracts.ResponseModels;
using DocumentFormat.OpenXml.Vml.Office;
using System.Threading.Tasks;

namespace Dfe.ManageFreeSchoolProjects.Services.Project
{
    public interface IGetPupilNumbersService
    {
        Task<GetPupilNumbersResponse> Execute(string projectId);
    }

    public class GetPupilNumbersService : IGetPupilNumbersService
    {
        private readonly MfspApiClient _apiClient;

        public GetPupilNumbersService(MfspApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<GetPupilNumbersResponse> Execute(string projectId)
        {
            var endpoint = $"/api/v1/client/projects/{projectId}/pupil-numbers";

            var result = await _apiClient.Get<ApiSingleResponseV2<GetPupilNumbersResponse>>(endpoint);

            return result.Data;
        }
    }
}
