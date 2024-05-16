using Dfe.Complete.API.Contracts.Project;
using Dfe.Complete.API.Contracts.Project.Conversion;
using Dfe.Complete.API.UseCases.Academies;
using Dfe.Complete.Data;

namespace Dfe.Complete.API.UseCases.Project.Conversion
{
    public interface IGetConversionProjectService
    {
        public Task<GetConversionProjectResponse> Execute(Guid projectId);
    }

    public class GetConversionProjectService : IGetConversionProjectService
    {
        private readonly CompleteContext _context;
        private IGetEstablishmentAndTrustService _getEstablishmentAndTrustService;

        public GetConversionProjectService(
            CompleteContext context,
            IGetEstablishmentAndTrustService getEstablishmentAndTrustService)
        {
            _context = context;
            _getEstablishmentAndTrustService = getEstablishmentAndTrustService;
        }

        public async Task<GetConversionProjectResponse> Execute(Guid projectId)
        {
            var queryResult = await _context.GetConversionProjectById(projectId);
            var project = queryResult.Project;

            var establishmentAndTrust = await _getEstablishmentAndTrustService.Execute(project.Urn, project.IncomingTrustUkprn, project.OutgoingTrustUkprn);

            var result = new GetConversionProjectResponse()
            {
                ProjectDetails = ProjectDetailsBuilder.Execute(project, establishmentAndTrust),
                ReasonForConversion = new ReasonForConversion()
                {
                    IsDueTo2RI = project.TwoRequiresImprovement,
                    HasAcademyOrderBeenIssued = project.DirectiveAcademyOrder,
                },
                AdvisoryBoardDetails = new AdvisoryBoardDetails()
                {
                    Date = project.AdvisoryBoardDate,
                    Conditions = project.AdvisoryBoardConditions
                },
                IncomingTrustDetails = BuildTrustDetails(establishmentAndTrust.IncomingTrust, project.IncomingTrustSharepointLink),
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
