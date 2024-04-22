namespace Dfe.ManageFreeSchoolProjects.API.UseCases.Project.Tasks.RegionAndLocalAuthority
{
    public class UpdateRegionAndLocalAuthorityTaskService : IUpdateTaskService
    {
        public async Task Update(UpdateTaskServiceParameters parameters)
        {
            var task = parameters.Request.RegionAndLocalAuthorityTask;
            var dbKpi = parameters.Kpi;

            if (task is null)
            {
                return;
            }

            dbKpi.LocalAuthority = task.LocalAuthority;
            dbKpi.SchoolDetailsGeographicalRegion = task.Region;
            dbKpi.SchoolDetailsLocalAuthority = task.LocalAuthorityCode;
        }
    }
}
