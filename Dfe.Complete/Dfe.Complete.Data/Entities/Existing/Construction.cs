using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Dfe.ManageFreeSchoolProjects.Data
{
    public partial class MfspContext : DbContext
    {
        public virtual DbSet<Entities.Existing.Construction> Construction { get; set; }
    }
}

namespace Dfe.ManageFreeSchoolProjects.Data.Entities.Existing
{
    public partial class Construction
    {
        public string PRid { get; set; }

        public string Rid { get; set; }

        public string SiteDetailsMinimumGrossAreaRequiredM2 { get; set; }

        public string SiteDetailsAreaOfExistingBuildingsM2TemporaryArea { get; set; }

        public string SiteDetailsAreaOfExistingBuildingsM2PermanentArea { get; set; }

        public string SiteDetailsMaximumGrossAreaRequiredM2 { get; set; }

        public string SiteDetailsTypeOfWorks { get; set; }

        public string SiteDetailsLocation { get; set; }

        public string SiteDetailsAreaOfNewBuildM2 { get; set; }

        public string SiteDetailsAreaOfMajorRefurbishmentM2 { get; set; }

        public string SiteDetailsAreaOfRefurbishmentM2 { get; set; }

        public string SiteDetailsAreaOfMinorRefurbishmentM2 { get; set; }

        public string SiteDetailsAreaOfRefreshM2 { get; set; }

        public string SiteDetailsAreaOfHardStandingM2 { get; set; }

        public string SiteDetailsAreaOfMugaPlayingFieldsM2 { get; set; }

        public string SiteDetailsAreaOfTemporaryAccommodationRequiredM2 { get; set; }

        public string SiteDetailsSprinklers { get; set; }

        public string SiteDetailsSprinklerInstallationType { get; set; }

        public string SiteDetailsSprinklerType { get; set; }

        public DateTime? IctDetailsIctProcurementRouteAgreedWithTrust { get; set; }

        public DateTime? IctDetailsBroadbandOrdered { get; set; }
    }
}