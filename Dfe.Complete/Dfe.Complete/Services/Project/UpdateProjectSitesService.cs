using Dfe.ManageFreeSchoolProjects.API.Contracts.Project.Sites;
using Dfe.ManageFreeSchoolProjects.API.Contracts.ResponseModels;
using System.Threading.Tasks;

namespace Dfe.ManageFreeSchoolProjects.Services.Project
{
    public interface IUpdateProjectSitesService
    {
        public Task Execute(string projectId, UpdateProjectSiteRequest request, ProjectSiteType projectSiteType);
    }

    public class UpdateProjectSitesService : IUpdateProjectSitesService
    {
        private readonly MfspApiClient _apiClient;

        public UpdateProjectSitesService(MfspApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task Execute(string projectId, UpdateProjectSiteRequest request, ProjectSiteType projectSiteType)
        {
            var endpoint = $"/api/v1/client/projects/{projectId}/sites/{projectSiteType.ToString().ToLower()}";

            await _apiClient.Patch<UpdateProjectSiteRequest, ApiSingleResponseV2<object>>(endpoint, request);
        }
    }
}
