using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Dfe.ManageFreeSchoolProjects.Data
{
    public partial class MfspContext : DbContext
    {
        public virtual DbSet<Entities.Existing.OfstedArchive> OfstedArchive { get; set; }
    }
}

namespace Dfe.ManageFreeSchoolProjects.Data.Entities.Existing
{
    public partial class OfstedArchive
    {
        public string Urn { get; set; }

        public DateTime? InspectionDate { get; set; }

        public string OfstedRating { get; set; }
    }
}