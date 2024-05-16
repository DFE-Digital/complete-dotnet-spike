using Dfe.Complete.API.Contracts.Project.Transfer;
using Dfe.Complete.API.Exceptions;
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
                IncomingTrustDetails = BuildTrustDetails(establishmentAndTrust.IncomingTrust, project.IncomingTrustSharepointLink),
                OutgoingTrustDetails = BuildTrustDetails(establishmentAndTrust.OutgoingTrust, project.OutgoingTrustSharepointLink),
                SchoolDetails = BuildSchoolDetails(establishmentAndTrust.Establishment, project.EstablishmentSharepointLink)
            };

            return result;
        }

        private SchoolDetails BuildSchoolDetails(GetEstablishmentResponse establishmentResponse, string sharepointLink)
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
                    Locality = establishmentResponse.Address.Locality,
                    Additional = establishmentResponse.Address.Additional,
                    Town = establishmentResponse.Address.Town,
                    County = establishmentResponse.Address.County,
                    Postcode = establishmentResponse.Address.Postcode
                },
                Diocese = establishmentResponse.Diocese.Name,
                SharePointLink = sharepointLink
            };

            return result;
        }

        private TrustDetails BuildTrustDetails(GetTrustResponse trustResponse, string sharepointLink)
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
                SharePointLink = sharepointLink,
                Address = new()
                {
                    Street = trustResponse.Address.Street,
                    Locality = trustResponse.Address.Locality,
                    Additional = trustResponse.Address.Additional,
                    Town = trustResponse.Address.Town,
                    County = trustResponse.Address.County,
                    Postcode = trustResponse.Address.Postcode
                }
            };

            return result;
        }
    }
}
