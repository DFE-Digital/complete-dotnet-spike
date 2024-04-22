using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Dfe.ManageFreeSchoolProjects.Data
{
    public partial class MfspContext : DbContext
    {
        public virtual DbSet<Entities.Existing.TermVisitsUtcs> TermVisitsUtcs { get; set; }
    }
}

namespace Dfe.ManageFreeSchoolProjects.Data.Entities.Existing
{
    public partial class TermVisitsUtcs
    {
        public string PRid { get; set; }

        public string Rid { get; set; }

        public string TermVisitsUtcSchoolTermVisit { get; set; }

        public string TermVisitsUtcPostOfstedUtcVisitNameOfEducationAdviser { get; set; }

        public string TermVisitsUtcPostOfstedUtcVisitNameOfDfEOfficial { get; set; }

        public DateTime? TermVisitsUtcPostOfstedUtcVisitDateOfVisit { get; set; }

        public string TermVisitsUtcPostOfstedUtcVisitVisitRating { get; set; }

        public string TermVisitsUtcPostOfstedUtcVisitReportLink { get; set; }

        public string TermVisitsUtcPostOfstedUtcVisitSummary { get; set; }

        public DateTime? TermVisitsUtcPostOfstedUtcVisitNextVisitDate { get; set; }
    }
}