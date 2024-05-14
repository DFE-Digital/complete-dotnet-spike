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
        private readonly IGetTrustsBulkService _getTrustsBulkService;
        private readonly IGetEstablishmentsBulkService _getEstablishmentsBulkService;

        public GetProjectDetailsService(
            IGetTrustsBulkService getTrustsBulkService,
            IGetEstablishmentsBulkService getEstablishmentsBulkService)
        {
            _getTrustsBulkService = getTrustsBulkService;
            _getEstablishmentsBulkService = getEstablishmentsBulkService;
        }

        public async Task<ProjectDetails> Execute(Data.Entities.Project project)
        {
            var projectDetails = new ProjectDetails()
            {
                Urn = project.Urn,
                Date = project.SignificantDate,
                IsDateProvisional = project.SignificantDateProvisional,
                IncomingTrustUkprn = project.IncomingTrustUkprn,
                Region = project.Region.ToDescription(),
                ProjectType = project.Type,
            };

            var trusts = await _getTrustsBulkService.Execute([project.IncomingTrustUkprn.Value]);
            var establishments = await _getEstablishmentsBulkService.Execute([project.Urn]);

            var establishment = establishments.FirstOrDefault();
            var trust = trusts.FirstOrDefault();

            projectDetails.IncomingTrustName = trust?.Name;
            projectDetails.Name = establishment?.Name;
            projectDetails.LocalAuthority = establishment?.LocalAuthorityName;

            return projectDetails;
        }
    }
}
