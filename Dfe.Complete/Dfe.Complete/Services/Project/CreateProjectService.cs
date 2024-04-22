using Dfe.ManageFreeSchoolProjects.API.Contracts.Project;
using Dfe.ManageFreeSchoolProjects.API.Contracts.RequestModels.Projects;
using System.Threading.Tasks;

namespace Dfe.ManageFreeSchoolProjects.Services.Project
{
    public interface ICreateProjectService
    {
        public Task<CreateProjectResponse> Execute(CreateProjectRequest createProjectRequest);
    }

    public class CreateProjectService : ICreateProjectService
    {
        private readonly MfspApiClient _apiClient;

        public CreateProjectService(MfspApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<CreateProjectResponse> Execute(CreateProjectRequest createProjectRequest)
        {
            return await _apiClient.Post<CreateProjectRequest, CreateProjectResponse>($"/api/v1/client/projects/create/", createProjectRequest);
        }
    }
}

