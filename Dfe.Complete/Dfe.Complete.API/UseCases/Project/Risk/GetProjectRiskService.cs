using Dfe.ManageFreeSchoolProjects.API.Contracts.Project.Risk;
using Dfe.ManageFreeSchoolProjects.API.Exceptions;
using Dfe.ManageFreeSchoolProjects.Data;
using Microsoft.EntityFrameworkCore;

namespace Dfe.ManageFreeSchoolProjects.API.UseCases.Project.Risk
{
    public interface IGetProjectRiskService
    {
        Task<GetProjectRiskResponse> Execute(string projectId, int entry);
    }

    public class GetProjectRiskService : IGetProjectRiskService
    {
        private readonly MfspContext _context;

        public GetProjectRiskService(MfspContext context)
        {
            _context = context;
        }

        public async Task<GetProjectRiskResponse> Execute(string projectId, int entry)
        {
            var dbProject = await _context.Kpi.FirstOrDefaultAsync(x => x.ProjectStatusProjectId == projectId);

            if (dbProject == null)
            {
                throw new NotFoundException($"Project with id {projectId} not found");
            }

            var ragEntries = await _context.Rag
                .TemporalAll()
                .Where(e => e.Rid == dbProject.Rid)
                .OrderByDescending(e => EF.Property<DateTime>(e, "PeriodStart"))
                .Select(rag => new GetProjectRiskResponse()
                {
                    Date = EF.Property<DateTime>(rag, "PeriodStart"),
                    GovernanceAndSuitability = new()
                    {
                        RiskRating = ProjectRiskMapper.ToRiskRating(rag.RagRatingsGovernanceAndSuitabilityRagRating),
                        Summary = rag.RagRatingsGovernanceAndSuitabilityRagSummary
                    },
                    Education = new()
                    {
                        RiskRating = ProjectRiskMapper.ToRiskRating(rag.RagRatingsEducationRag),
                        Summary = rag.RagRatingsEducationRagSummary
                    },
                    Finance = new()
                    {
                        RiskRating = ProjectRiskMapper.ToRiskRating(rag.RagRatingsFinancesRagRating),
                        Summary = rag.RagRatingsFinanceRagSummary
                    },
                    Overall = new()
                    {
                        RiskRating = ProjectRiskMapper.ToRiskRating(rag.RagRatingsOverallRagRating),
                        Summary = rag.RagRatingsOverallRagSummary
                    },
                    RiskAppraisalFormSharepointLink = rag.RagRatingsRiskAppraisalFormSharepointLink
                })
                .ToListAsync();

            GetProjectRiskResponse result = ragEntries.ElementAtOrDefault(entry - 1);

            if (result != null)
            {
                result.History = ragEntries.Select(ToHistory).ToList();
            }

            return result;
        }

        public static ProjectRiskHistoryResponse ToHistory(GetProjectRiskResponse response)
        {
            var result = new ProjectRiskHistoryResponse()
            {
                Date = response.Date,
                RiskRating = response.Overall.RiskRating
            };

            return result;
        }
    }
}
