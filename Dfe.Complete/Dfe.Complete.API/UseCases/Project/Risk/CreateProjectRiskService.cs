using Dfe.ManageFreeSchoolProjects.API.Contracts.Project.Risk;
using Dfe.ManageFreeSchoolProjects.API.Exceptions;
using Dfe.ManageFreeSchoolProjects.API.Extensions;
using Dfe.ManageFreeSchoolProjects.Data;
using Dfe.ManageFreeSchoolProjects.Data.Entities.Existing;
using Microsoft.EntityFrameworkCore;

namespace Dfe.ManageFreeSchoolProjects.API.UseCases.Project.Risk
{
    public interface ICreateProjectRiskService
    {
        Task<CreateProjectRiskResponse> Execute(string projectId, CreateProjectRiskRequest request);
    }

    public class CreateProjectRiskService : ICreateProjectRiskService
    {
        private readonly MfspContext _context;

        public CreateProjectRiskService(MfspContext context)
        {
            _context = context;
        }

        public async Task<CreateProjectRiskResponse> Execute(string projectId, CreateProjectRiskRequest request)
        {
            var dbProject = await _context.Kpi.FirstOrDefaultAsync(x => x.ProjectStatusProjectId == projectId);

            if (dbProject == null)
            {
                throw new NotFoundException($"Project with id {projectId} not found");
            }

            var existingRag = await _context.Rag.FirstOrDefaultAsync(x => x.Rid == dbProject.Rid);

            if (existingRag == null) 
            {
                existingRag = new Rag();
                existingRag.Rid = dbProject.Rid;

                _context.Rag.Add(existingRag);
            }

            // Set a revision marker to force an update, even if nothing has changed
            existingRag.RevisionMarker = Guid.NewGuid();

            existingRag.Rid = dbProject.Rid;
            existingRag.RagRatingsGovernanceAndSuitabilityRagRating = request.GovernanceAndSuitability.RiskRating?.GetDescription();
            existingRag.RagRatingsGovernanceAndSuitabilityRagSummary = request.GovernanceAndSuitability.Summary;

            existingRag.RagRatingsEducationRag = request.Education.RiskRating?.GetDescription();
            existingRag.RagRatingsEducationRagSummary = request.Education.Summary;

            existingRag.RagRatingsFinancesRagRating = request.Finance.RiskRating?.GetDescription();
            existingRag.RagRatingsFinanceRagSummary = request.Finance.Summary;
            existingRag.RagRatingsOverallRagRating = request.Overall.RiskRating?.GetDescription();
            existingRag.RagRatingsOverallRagSummary = request.Overall.Summary;

            existingRag.RagRatingsRiskAppraisalFormSharepointLink = request.RiskAppraisalFormSharepointLink;

            await _context.SaveChangesAsync();

            return new CreateProjectRiskResponse();
        }
    }
}
