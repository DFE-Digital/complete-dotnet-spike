using Dfe.Complete.API.Contracts.Project;
using Dfe.Complete.API.Contracts.Project.Transfer;
using Dfe.Complete.API.UseCases.Academies;
using Dfe.Complete.Data;

namespace Dfe.Complete.API.UseCases.Project.Transfer
{
    public interface IGetTransferProjectService
    {
        public Task<GetTransferProjectResponse> Execute(Guid projectId);
    }

    public class GetTransferProjectService : IGetTransferProjectService
    {
        private readonly CompleteContext _context;
        private IGetEstablishmentAndTrustService _getEstablishmentAndTrustService;

        public GetTransferProjectService(
            CompleteContext context,
            IGetEstablishmentAndTrustService getEstablishmentAndTrustService)
        {
            _context = context;
            _getEstablishmentAndTrustService = getEstablishmentAndTrustService;
        }

        public async Task<GetTransferProjectResponse> Execute(Guid projectId)
        {
            var queryResult = await _context.GetTransferProjectById(projectId);
            var project = queryResult.Project;
            var task = queryResult.TaskData;

            var establishmentAndTrust = await _getEstablishmentAndTrustService.Execute(project.Urn, project.IncomingTrustUkprn, project.OutgoingTrustUkprn);

            var result = new GetTransferProjectResponse()
            {
                ProjectDetails = ProjectDetailsBuilder.Execute(project, establishmentAndTrust),
                ReasonForTheTransfer = new ReasonForTheTransfer()
                {
                    IsDueTo2RI = project.TwoRequiresImprovement,
                    IsDueToOfstedRating = task.InadequateOfsted,
                    IsDueToIssues = task.FinancialSafeguardingGovernanceIssues
                },
                AdvisoryBoardDetails = new AdvisoryBoardDetails()
                {
                    Date = project.AdvisoryBoardDate,
                    Conditions = project.AdvisoryBoardConditions
                },
                IncomingTrustDetails = TrustDetailsBuilder.Execute(establishmentAndTrust.IncomingTrust, project.IncomingTrustSharepointLink),
                OutgoingTrustDetails = TrustDetailsBuilder.Execute(establishmentAndTrust.OutgoingTrust, project.OutgoingTrustSharepointLink),
                SchoolDetails = SchoolDetailsBuilder.Execute(establishmentAndTrust.Establishment, project.EstablishmentSharepointLink)
            };

            return result;
        }
    }
}
