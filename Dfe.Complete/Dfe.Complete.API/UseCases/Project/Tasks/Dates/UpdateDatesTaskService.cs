namespace Dfe.ManageFreeSchoolProjects.API.UseCases.Project.Tasks.Dates
{
    public class UpdateDatesTaskService : IUpdateTaskService
    {
        public async Task Update(UpdateTaskServiceParameters parameters)
        {
            var dbKpi = parameters.Kpi;
            var task = parameters.Request.Dates;

            if (task == null)
            {
                return;
            }

            dbKpi.ProjectStatusDateOfEntryIntoPreOpening = task.DateOfEntryIntoPreopening;
            dbKpi.ProjectStatusProvisionalOpeningDateAgreedWithTrust = task.ProvisionalOpeningDateAgreedWithTrust;
        }
    }
}
