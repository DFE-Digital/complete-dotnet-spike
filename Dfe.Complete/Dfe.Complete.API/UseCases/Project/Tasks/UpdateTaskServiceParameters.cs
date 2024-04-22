using Dfe.ManageFreeSchoolProjects.API.Contracts.Project.Tasks;
using Dfe.ManageFreeSchoolProjects.Data.Entities.Existing;

namespace Dfe.ManageFreeSchoolProjects.API.UseCases.Project.Tasks
{
    public record UpdateTaskServiceParameters
    {
        public string ProjectId { get; set; }

        public UpdateProjectByTaskRequest Request { get; set; }

        public Kpi Kpi { get; set; }
    }
}
