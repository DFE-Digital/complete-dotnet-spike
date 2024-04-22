using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Dfe.ManageFreeSchoolProjects.Data
{
    public partial class MfspContext : DbContext
    {
        public virtual DbSet<Entities.Existing.ConstructData> ConstructData { get; set; }
    }
}

namespace Dfe.ManageFreeSchoolProjects.Data.Entities.Existing
{
    public partial class ConstructData : IAuditable
    {
        public string ProjectId { get; set; }

        public string HoTAgreedForSiteForMainSchoolBuildingActual { get; set; }

        public string TemporaryAccommodationFirstReadyForOccupationForecast { get; set; }

        public string TemporaryAccommodationFirstReadyForOccupationActual { get; set; }

        public string MainSchoolBuildingFirstReadyForOccupationForecast { get; set; }

        public string MainSchoolBuildingFirstReadyForOccupationActual { get; set; }

        public string SiteIdentifiedForMainSchoolBuildingActual { get; set; }

        public string CapitalProjectRag { get; set; }

        public string PlanningSiteId { get; set; }

        public string IsThisTheMainPlanningRecord { get; set; }

        public string PlanningRisk { get; set; }

        public string PlanningDecision { get; set; }

        public string SiteId { get; set; }

        public string TypeOfSite { get; set; }

        public string SiteStatus { get; set; }

        public string PostcodeOfSite { get; set; }

        public string PracticalCompletionCertificateIssuedDateA { get; set; }

        public string RegionalHead { get; set; }

        public string ProjectDirector { get; set; }

        public string ProjectManager { get; set; }

        public string TemporaryRagRating { get; set; }

        public string CapitalProjectRagRatingCommentary { get; set; }

        public string TemporaryRagRatingCommentary { get; set; }

        public string DateOfHoTSecuredOnTemporaryAccommodationSiteIfRequired { get; set; }
    }
}