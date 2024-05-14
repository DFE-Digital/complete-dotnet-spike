using Dfe.Complete.API.Contracts.Project;
using Dfe.Complete.API.Extensions;
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
            var projectDetails = new ProjectDetails()
            {
                Urn = project.Urn,
                Date = project.SignificantDate,
                IsDateProvisional = project.SignificantDateProvisional,
                IncomingTrustUkprn = project.IncomingTrustUkprn,
                OutgoingTrustUkprn = project.OutgoingTrustUkprn,
                Region = project.Region.ToDescription(),
                ProjectType = project.Type,
            };

            var establishmentAndTrust = await _getEstablishmentAndTrustService.Execute(project.Urn, project.IncomingTrustUkprn, project.OutgoingTrustUkprn);
            var establishment = establishmentAndTrust.Establishment;

            projectDetails.IncomingTrustName = establishmentAndTrust.IncomingTrust?.Name;
            projectDetails.OutgoingTrustName = establishmentAndTrust.OutgoingTrust?.Name;
            projectDetails.Name = establishment?.Name;
            projectDetails.LocalAuthority = establishment?.LocalAuthorityName;

            return projectDetails;
        }
    }
}
