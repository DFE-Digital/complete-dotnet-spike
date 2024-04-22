using Dfe.ManageFreeSchoolProjects.API.Contracts.Project.Tasks;
using Dfe.ManageFreeSchoolProjects.Data.Entities.Existing;

namespace Dfe.ManageFreeSchoolProjects.API.UseCases.Tasks
{
    public static class ProjectTaskBuilder
    {
        public static IEnumerable<Data.Entities.Existing.Tasks> BuildTasks(string kpiRid)
        {
            const Status status = Status.NotStarted;

            var result =
                Enum.GetValues(typeof(TaskName))
                .Cast<TaskName>()
                .Where(t => t != TaskName.Unknown)
                .Select(t => new Data.Entities.Existing.Tasks { Rid = kpiRid, TaskName = t, Status = status });

            return result;
        }
    }
}
