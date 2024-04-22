using Dfe.ManageFreeSchoolProjects.Data.Entities.Existing;

namespace Dfe.ManageFreeSchoolProjects.API.UseCases.Project.Tasks
{
    public class GetTaskServiceParameters
    {
        public string ProjectId { get; set; }

        public IQueryable<Kpi> BaseQuery { get; set; }
    }
}
