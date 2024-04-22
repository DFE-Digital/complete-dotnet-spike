using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Dfe.ManageFreeSchoolProjects.Data
{
    public partial class MfspContext : DbContext
    {
        public virtual DbSet<Entities.Existing.TermVisits> TermVisits { get; set; }
    }
}

namespace Dfe.ManageFreeSchoolProjects.Data.Entities.Existing
{
    public partial class TermVisits
    {
        public string PRid { get; set; }

        public string Rid { get; set; }

        public string TermVisitsSchoolTermVisit { get; set; }

        public string Visits { get; set; }

        public string TermVisitsLinkOfficerFirstTermVisit { get; set; }

        public string TermVisitsLinkOfficerFirstTermVisitReport { get; set; }

        public string TermVisitsLinkOfficerFirstTermVisitOutcome { get; set; }

        public string TermVisitsLinkOfficerFirstTermVisitOutcomeTypeOfConcern { get; set; }

        public string TermVisitsNameOfEducationAdviser { get; set; }

        public string TermVisitsNameOfDfEOfficial { get; set; }

        public DateTime? TermVisitsDateOfVisit { get; set; }

        public string TermVisitsVisitRating { get; set; }

        public string TermVisitsVisitReport { get; set; }

        public string TermVisitsVisitSummary { get; set; }

        public string TermVisitsIsActionPlanRequested { get; set; }

        public DateTime? TermVisitsActionPlanDueDate { get; set; }

        public string TermVisitsActionPlanReceived { get; set; }

        public string TermVisitsActionPlan { get; set; }

        public string TermVisitsVisitFollowUp { get; set; }

        public DateTime? TermVisitsDateOfFollowUp { get; set; }

        public string TermVisitsFollowUpVisitRating { get; set; }

        public DateTime? TermVisitsNextVisitDate { get; set; }
    }
}