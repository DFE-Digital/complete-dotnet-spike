namespace Dfe.ManageFreeSchoolProjects.API.UseCases.Project.Tasks.Constituency
{
    public class UpdateConstituencyTaskService : IUpdateTaskService
    {
        public async Task Update(UpdateTaskServiceParameters parameters)
        {
            var task = parameters.Request.Constituency;
            var dbKpi = parameters.Kpi;

            if (task == null)
            {
                return;
            }

            dbKpi.SchoolDetailsConstituency = task.Name;
            dbKpi.SchoolDetailsConstituencyMp = task.MPName;
            dbKpi.SchoolDetailsPoliticalParty = task.Party;
        }
    }
}
