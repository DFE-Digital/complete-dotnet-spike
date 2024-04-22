using System.ComponentModel.DataAnnotations;
using Dfe.ManageFreeSchoolProjects.API.Contracts.Project.Tasks;

namespace Dfe.ManageFreeSchoolProjects.API.Contracts.Task;

public class UpdateTaskStatusRequest
{
    [Required]
    public string TaskName { get; set; }

    [Required]
    public ProjectTaskStatus ProjectTaskStatus { get; set; }
}