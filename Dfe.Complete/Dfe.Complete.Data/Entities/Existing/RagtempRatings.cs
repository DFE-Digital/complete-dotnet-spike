using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Dfe.ManageFreeSchoolProjects.Data
{
    public partial class MfspContext : DbContext
    {
        public virtual DbSet<Entities.Existing.RagtempRatings> RagtempRatings { get; set; }
    }
}

namespace Dfe.ManageFreeSchoolProjects.Data.Entities.Existing
{
    public partial class RagtempRatings
    {
        public string Fscode { get; set; }

        public string OverallRag { get; set; }

        public string TaOverallSiteRag { get; set; }

        public string TaOverallSiteRagComments { get; set; }

        public string TaPermanentSiteRag { get; set; }

        public string TaPermanentSiteRagComments { get; set; }

        public string TatemporarySiteRag { get; set; }

        public string TatemporarySiteRagComments { get; set; }

        public string TaSeptemberSiteRag { get; set; }

        public string TaSeptemberSiteRagComments { get; set; }

        public string AccidentOnSiteInThisMonthReportedToEfa { get; set; }
    }
}