using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Dfe.ManageFreeSchoolProjects.Data
{
    public partial class MfspContext : DbContext
    {
        public virtual DbSet<Entities.Existing.LaData> LaData { get; set; }
    }
}

namespace Dfe.ManageFreeSchoolProjects.Data.Entities.Existing
{
    public partial class LaData
    {
        public string LocalAuthoritiesLaName { get; set; }

        public string LocalAuthoritiesLaCode { get; set; }

        public string LocalAuthoritiesLaLondonBased { get; set; }

        public string LocalAuthoritiesRscRegion { get; set; }

        public string LocalAuthoritiesGeographicalRegion { get; set; }

        public string LocalAuthoritiesCapitalCostTier { get; set; }

        public string LocalAuthoritiesLondonNotLondon { get; set; }
    }
}