using Dfe.Complete.API.Contracts.Project;
using Dfe.Complete.API.UseCases.Academies;

namespace Dfe.Complete.API.UseCases.Project
{
    public interface IGetProjectDetailsService
    {
        public Task<ProjectDetails> Execute(Data.Entities.Project project);
    }

    public class GetProjectDetailsService : IGetProjectDetailsService
    {
        private readonly IGetEstablishmentAndTrustService _getEstablishmentAndTrustService;

        public GetProjectDetailsService(
            IGetEstablishmentAndTrustService getEstablishmentAndTrustService)
        {
            _getEstablishmentAndTrustService = getEstablishmentAndTrustService;
        }

        public async Task<ProjectDetails> Execute(Data.Entities.Project project)
        {
            var establishmentAndTrust = await _getEstablishmentAndTrustService.Execute(project.Urn, project.IncomingTrustUkprn, project.OutgoingTrustUkprn);

            var projectDetails = ProjectDetailsBuilder.Execute(project, establishmentAndTrust);

            return projectDetails;
        }
    }
}
