using System.Collections.Generic;
using Dfe.ManageFreeSchoolProjects.API.Contracts.Project.Tasks;
using Dfe.ManageFreeSchoolProjects.Data.Entities.Existing;

namespace Dfe.ManageFreeSchoolProjects.API.Tests.Utils;

public static class TasksStub
{
    public static List<Tasks> BuildListOfTasks(string projectRid)
    {
        return new List<Tasks>()
        {
            new()
            {
                Rid = projectRid,
                Status = Status.NotStarted,
                TaskName = TaskName.School
            },
            new ()
            {
                Rid = projectRid,
                Status = Status.NotStarted,
                TaskName = TaskName.Dates
            }
        };
    }
}