using Dfe.ManageFreeSchoolProjects.API.Contracts.Project.Tasks;
using Dfe.ManageFreeSchoolProjects.Data.Entities.Existing;

namespace Dfe.ManageFreeSchoolProjects.API.UseCases.Project.Tasks.Dates
{
    public static class DatesTaskBuilder
    {
        public static DatesTask Build(Kpi kpi)
        {
            return new DatesTask
            {
                DateOfEntryIntoPreopening = kpi.ProjectStatusDateOfEntryIntoPreOpening,
                ProvisionalOpeningDateAgreedWithTrust = kpi.ProjectStatusProvisionalOpeningDateAgreedWithTrust,
            };
        }
    }
}
