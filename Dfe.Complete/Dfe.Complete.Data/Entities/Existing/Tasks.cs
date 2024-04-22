using System.ComponentModel;
using Dfe.ManageFreeSchoolProjects.API.Contracts.Project.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Dfe.ManageFreeSchoolProjects.Data
{
    public partial class MfspContext : DbContext
    {
        public virtual DbSet<Entities.Existing.Tasks> Tasks { get; set; }
    }
}

namespace Dfe.ManageFreeSchoolProjects.Data.Entities.Existing
{
    public partial class Tasks : IAuditable
    {
        public string Rid { get; set; }
        
        public TaskName TaskName { get; set; }

        public Status Status { get; set; }
    }

    public enum Status
    {
        NotStarted,
        InProgress,
        Completed
    }
}