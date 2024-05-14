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
                OutgoingTrustUkprn = project.OutgoingTrustUkprn,
                Region = project.Region.ToDescription(),
                ProjectType = project.Type,
            };

            var ukPrns = new List<int?> { project.IncomingTrustUkprn, project.OutgoingTrustUkprn };
            var trusts = await _getTrustsBulkService.Execute(ukPrns.Where(x => x.HasValue).Select(x => x.Value).ToArray());

            var establishments = await _getEstablishmentsBulkService.Execute([project.Urn]);

            var establishment = establishments.FirstOrDefault();
            var trustLookup = trusts.ToDictionary(t => t.Ukprn);

            projectDetails.IncomingTrustName = GetTrustName(project.IncomingTrustUkprn, trustLookup);
            projectDetails.OutgoingTrustName = GetTrustName(project.OutgoingTrustUkprn, trustLookup);
            projectDetails.Name = establishment?.Name;
            projectDetails.LocalAuthority = establishment?.LocalAuthorityName;

            return projectDetails;
        }

        private string GetTrustName(int? ukPrn, Dictionary<string, GetTrustResponse> trustLookup)
        {
            string result = null;

            if (ukPrn.HasValue && trustLookup.ContainsKey(ukPrn.ToString()))
            {
                result = trustLookup[ukPrn.ToString()].Name;
            }

            return result;
        }
    }
}
