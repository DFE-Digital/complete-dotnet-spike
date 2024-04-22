using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Dfe.ManageFreeSchoolProjects.Data
{
    public partial class MfspContext : DbContext
    {
        public virtual DbSet<Entities.Existing.Trust> Trust { get; set; }
    }
}

namespace Dfe.ManageFreeSchoolProjects.Data.Entities.Existing
{
    public partial class Trust
    {
        public string PRid { get; set; }

        public string Rid { get; set; }

        public string TrustRef { get; set; }

        public string TrustsTrustRef { get; set; }

        public string TrustsTrustName { get; set; }

        public string TrustsTrustType { get; set; }

        public string TrustsLeadSponsorId { get; set; }

        public string LeadSponsor { get; set; }

        public string TrustsLeadSponsorName { get; set; }
    }
}