using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Dfe.ManageFreeSchoolProjects.Data
{
    public partial class MfspContext : DbContext
    {
        public virtual DbSet<Entities.Existing.BasicNeed> BasicNeed { get; set; }
    }
}

namespace Dfe.ManageFreeSchoolProjects.Data.Entities.Existing
{
    public partial class BasicNeed
    {
        public string ProjectId { get; set; }

        public string FreeSchoolName { get; set; }

        public string Phase { get; set; }

        public string PostcodeUsedHere { get; set; }

        public string PrimaryPlanningAreaCode { get; set; }

        public string PrimaryPlanningAreaName { get; set; }

        public string SecondaryPlanningAreaCode { get; set; }

        public string SecondaryPlanningAreaName { get; set; }

        public string _201920PrimaryPhasePlanningAreaSSNoPlaces { get; set; }

        public string _201920PrimaryPhasePlanningAreaSSPlaces { get; set; }

        public string _201920SecondaryPhasePlanningAreaSSNoPlaces { get; set; }

        public string _201920SecondaryPhasePlanningAreaSSPlaces { get; set; }

        public string _201920PrimaryPhaseLocalAreaSSNoPlaces { get; set; }

        public string _201920PrimaryPhaseLocalAreaSSPlaces { get; set; }

        public string _201920SecondaryPhaseLocalAreaSSNoPlaces { get; set; }

        public string _201920SecondaryPhaseLocalAreaSSPlaces { get; set; }
    }
}