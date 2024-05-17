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
                ReasonForTheConversion = new ReasonForTheConversion()
                {
                    IsDueTo2RI = project.TwoRequiresImprovement,
                    HasAcademyOrderBeenIssued = project.DirectiveAcademyOrder,
                },
                AdvisoryBoardDetails = new AdvisoryBoardDetails()
                {
                    Date = project.AdvisoryBoardDate,
                    Conditions = project.AdvisoryBoardConditions
                },
                IncomingTrustDetails = TrustDetailsBuilder.Execute(establishmentAndTrust.IncomingTrust, project.IncomingTrustSharepointLink),
                SchoolDetails = SchoolDetailsBuilder.Execute(establishmentAndTrust.Establishment, project.EstablishmentSharepointLink)
            };

            return result;
        }
    }
}
