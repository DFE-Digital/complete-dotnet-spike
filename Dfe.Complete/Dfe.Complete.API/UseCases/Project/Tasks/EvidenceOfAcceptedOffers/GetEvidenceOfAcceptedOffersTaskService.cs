using Dfe.ManageFreeSchoolProjects.API.Contracts.Project.Tasks;
using Dfe.ManageFreeSchoolProjects.Data;
using Microsoft.EntityFrameworkCore;


namespace Dfe.ManageFreeSchoolProjects.API.UseCases.Project.Tasks.EvidenceOfAcceptedOffers
{
    public class GetEvidenceOfAcceptedOffersTaskService : IGetTaskService
    {
        private readonly MfspContext _context;

        public GetEvidenceOfAcceptedOffersTaskService(MfspContext context)
        {
            _context = context;
        }

        public async Task<GetProjectByTaskResponse> Get(GetTaskServiceParameters parameters)
        {
            var result = await(from kpi in parameters.BaseQuery
                join milestones in _context.Milestones on kpi.Rid equals milestones.Rid into joinedMilestones
                from milestones in joinedMilestones.DefaultIfEmpty()
                select new GetProjectByTaskResponse()
                {
                    EvidenceOfAcceptedOffers = EvidenceOfAcceptedOffersTaskBuilder.Build(milestones)
                }).FirstOrDefaultAsync();

            return result ?? new GetProjectByTaskResponse() { EvidenceOfAcceptedOffers = new () };
        }
    }
}
