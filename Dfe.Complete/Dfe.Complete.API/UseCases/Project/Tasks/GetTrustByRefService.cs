using Dfe.ManageFreeSchoolProjects.API.Contracts.Project.Tasks;
using Dfe.ManageFreeSchoolProjects.Data;
using Dfe.ManageFreeSchoolProjects.Data.Entities.Existing;
using Microsoft.EntityFrameworkCore;

namespace Dfe.ManageFreeSchoolProjects.API.UseCases.Project.Tasks
{
    public interface IGetTrustByRefService
    {
        public Task<GetTrustByRefResponse> Execute(string trn);
    }

    public class GetTrustByRefService : IGetTrustByRefService
    {
        private readonly MfspContext _context;

        public GetTrustByRefService(MfspContext context)
        {
            _context = context;
        }

        public async Task<GetTrustByRefResponse> Execute(string trn)
        {
            var result = await
                (from trust in _context.Trust
                where trust.TrustRef == trn
                
                select new GetTrustByRefResponse()
                {
                    Trust = new TrustTask()
                    {
                        TRN = trust.TrustRef,
                        TrustName = trust.TrustsTrustName,
                        TrustType = ProjectMapper.ToTrustType(trust.TrustsTrustType),
                    }
                }).FirstOrDefaultAsync();

            return result;
        }
    }
}
