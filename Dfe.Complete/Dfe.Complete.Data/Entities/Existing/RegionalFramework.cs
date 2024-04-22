using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Dfe.ManageFreeSchoolProjects.Data
{
    public partial class MfspContext : DbContext
    {
        public virtual DbSet<Entities.Existing.RegionalFramework> RegionalFramework { get; set; }
    }
}

namespace Dfe.ManageFreeSchoolProjects.Data.Entities.Existing
{
    public partial class RegionalFramework
    {
        public string LocalAuthority { get; set; }

        public string HighValueBandLot { get; set; }

        public string MediumValueBandLot { get; set; }

        public string LowValueBandLot { get; set; }

        public string RscRegions { get; set; }
    }
}