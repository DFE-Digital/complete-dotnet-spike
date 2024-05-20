using Dfe.Complete.API.Contracts.Project.Transfer;
using Dfe.Complete.API.Extensions;
using Dfe.Complete.Data;

namespace Dfe.Complete.API.UseCases.Project.Transfer
{
    public interface IUpdateTransferProjectService
    {
        Task Execute(Guid projectId, UpdateTransferProjectRequest request);
    }

    public class UpdateTransferProjectService : IUpdateTransferProjectService
    {
        private readonly CompleteContext _context;

        public UpdateTransferProjectService(CompleteContext context)
        {
            _context = context;
        }

        public async Task Execute(Guid projectId, UpdateTransferProjectRequest request)
        {
            var queryResult = await _context.GetTransferProjectById(projectId);
            var project = queryResult.Project;
            var task = queryResult.TaskData;

            project.IncomingTrustUkprn = request.IncomingTrustUkprn.ToInt();
            project.IncomingTrustSharepointLink = request.IncomingTrustSharePointLink;
            project.OutgoingTrustUkprn = request.OutgoingTrustUkprn.ToInt();
            project.OutgoingTrustSharepointLink = request.OutgoingTrustSharePointLink;
            project.EstablishmentSharepointLink = request.SchoolSharePointLink;
            project.AdvisoryBoardDate = request.AdvisoryBoardDetails.Date;
            project.AdvisoryBoardConditions = request.AdvisoryBoardDetails.Conditions;
            project.TwoRequiresImprovement = request.ReasonForTheTransfer.IsDueTo2RI;
            task.InadequateOfsted = request.ReasonForTheTransfer.IsDueToOfstedRating;
            task.FinancialSafeguardingGovernanceIssues = request.ReasonForTheTransfer.IsDueToIssues;

            await _context.SaveChangesAsync();
        }
    }
}
