using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Dfe.ManageFreeSchoolProjects.Data
{
    public partial class MfspContext : DbContext
    {
        public virtual DbSet<Entities.Existing.FsKim> FsKim { get; set; }
    }
}

namespace Dfe.ManageFreeSchoolProjects.Data.Entities.Existing
{
    public partial class FsKim : IAuditable
    {
        public string PRid { get; set; }

        public string Rid { get; set; }

        public string GeneralDetailsUrn { get; set; }

        public string GeneralDetailsLaestab { get; set; }

        public string GeneralDetailsProjectName { get; set; }

        public string GeneralDetailsAcademyUrn { get; set; }

        public string GeneralDetailsAcademyLaestab { get; set; }

        public string GeneralDetailsAcademyUkprn { get; set; }

        public string GeneralDetailsAcademyName { get; set; }

        public string GeneralDetailsProjectStatus { get; set; }

        public string ReBrokerageStatus { get; set; }

        public string GeneralDetailsAcademyStatus { get; set; }

        public DateTime? GeneralDetailsReBrokeredDate { get; set; }

        public string GeneralDetailsLocalAuthority { get; set; }

        public string GeneralDetailsRscRegion { get; set; }

        public string GeneralDetailsPhase { get; set; }

        public string GeneralDetailsRouteOfProject { get; set; }
    }
}