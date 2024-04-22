using Dfe.ManageFreeSchoolProjects.API.Contracts.Project.Tasks;
using Dfe.ManageFreeSchoolProjects.Data.Entities.Existing;

namespace Dfe.ManageFreeSchoolProjects.API.UseCases.Project.Tasks.Trusts
{
    public static class TrustTaskBuilder
    {
        public static TrustTask Build(Kpi kpi)
        {
            return new TrustTask()
            {
                TRN = kpi.TrustId,
                TrustName = kpi.TrustName,
                TrustType = ProjectMapper.ToTrustType(kpi.TrustType)
            };
        }
    }
}
