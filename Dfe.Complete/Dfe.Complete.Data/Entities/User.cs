using Dfe.ManageFreeSchoolProjects.Data.Entities;
using Dfe.ManageFreeSchoolProjects.Data.Entities.Existing;
using Microsoft.EntityFrameworkCore;

namespace Dfe.ManageFreeSchoolProjects.Data.Entities
{
    public class User
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public List<Kpi> Projects { get; set; } = new();
    }
}

namespace Dfe.ManageFreeSchoolProjects.Data
{
    public partial class MfspContext : DbContext
    {

        public virtual DbSet<User> Users { get; set; }
    }
}
