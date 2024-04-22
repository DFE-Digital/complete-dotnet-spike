using Dfe.ManageFreeSchoolProjects.API.Contracts.Project.Tasks;
using Dfe.ManageFreeSchoolProjects.Data.Entities.Existing;

namespace Dfe.ManageFreeSchoolProjects.API.UseCases.Tasks;

public static class TaskStatusMapper
{
    public static Status Map(this ProjectTaskStatus projectTaskStatus)
    {
        return Enum.Parse<Status>(projectTaskStatus.ToString());
    }
    public static ProjectTaskStatus Map(this Status taskStatus)
    {
        return Enum.Parse<ProjectTaskStatus>(taskStatus.ToString());
    }
}