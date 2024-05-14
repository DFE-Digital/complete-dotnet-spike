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

        public GetProjectDetailsService(IGetTrustsBulkService getTrustsBulkService)
        {
            _getTrustsBulkService = getTrustsBulkService;
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
                Region = project.Region.ToDescription()
            };

            var trusts = await _getTrustsBulkService.Execute([project.IncomingTrustUkprn.Value, project.OutgoingTrustUkprn.Value]);

            var trustLookup = trusts.ToDictionary(t => t.Ukprn);

            projectDetails.IncomingTrustName = GetTrustName(project.IncomingTrustUkprn, trustLookup);
            projectDetails.OutgoingTrustName = GetTrustName(project.OutgoingTrustUkprn, trustLookup);

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
