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
            var project = _context.GetTransferProjects(projectId).FirstOrDefault();

            var task = _context.TransferTasksData.Where(t => t.Id == project.TasksDataId).FirstOrDefault();

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
                IncomingTrustDetails = BuildTrustDetails(establishmentAndTrust.IncomingTrust),
                OutgoingTrustDetails = BuildTrustDetails(establishmentAndTrust.OutgoingTrust),
                SchoolDetails = BuildSchoolDetails(establishmentAndTrust.Establishment)
            };

            return result;
        }

        private SchoolDetails BuildSchoolDetails(GetEstablishmentResponse establishmentResponse)
        {
            if (establishmentResponse == null) 
            {
                return new();
            }

            var result = new SchoolDetails()
            {
                Name = establishmentResponse.Name,
                Urn = establishmentResponse.Urn,
                Type = establishmentResponse.EstablishmentType.Name,
                Phase = establishmentResponse.PhaseOfEducation.Name,
                LowerAge = establishmentResponse.StatutoryLowAge,
                UpperAge = establishmentResponse.StatutoryHighAge,
                Address = new()
                {
                    Street = establishmentResponse.Address.Street,
                    Town = establishmentResponse.Address.Town,
                    Postcode = establishmentResponse.Address.Postcode
                }
            };

            return result;
        }

        private TrustDetails BuildTrustDetails(GetTrustResponse trustResponse)
        {
            if (trustResponse == null)
            {
                return new();
            }

            var result = new TrustDetails()
            {
                Name = trustResponse.Name,
                UkPrn = trustResponse.Ukprn,
                GroupId = trustResponse.ReferenceNumber,
                CompaniesHouseNumber = trustResponse.CompaniesHouseNumber,
                Address = new()
                {
                    Street = trustResponse.Address.Street,
                    Town = trustResponse.Address.Town,
                    Postcode = trustResponse.Address.Postcode
                }
            };

            return result;
        }
    }
}
