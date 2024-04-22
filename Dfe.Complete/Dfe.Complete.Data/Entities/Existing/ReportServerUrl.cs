using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Dfe.ManageFreeSchoolProjects.Data
{
    public partial class MfspContext : DbContext
    {
        public virtual DbSet<Entities.Existing.ReportServerUrl> ReportServerUrl { get; set; }
    }
}

namespace Dfe.ManageFreeSchoolProjects.Data.Entities.Existing
{
    public partial class ReportServerUrl
    {
        public int Id { get; set; }

        public string ReportName { get; set; }

        public string Servername { get; set; }

        public string Url { get; set; }
    }
}