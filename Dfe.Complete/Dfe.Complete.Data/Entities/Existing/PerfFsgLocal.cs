using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Dfe.ManageFreeSchoolProjects.Data
{
    public partial class MfspContext : DbContext
    {
        public virtual DbSet<Entities.Existing.PerfFsgLocal> PerfFsgLocal { get; set; }
    }
}

namespace Dfe.ManageFreeSchoolProjects.Data.Entities.Existing
{
    public partial class PerfFsgLocal
    {
        public string Urn { get; set; }

        public string ProjectId { get; set; }

        public string Year { get; set; }

        public string Attainment8ScoreLaAverage { get; set; }

        public string Ks4CInEnglishMathsLaAverage { get; set; }

        public string Ks4EbaccEnteredForEbacc { get; set; }

        public string Ks5ALevelApsPerEntry { get; set; }

        public string Ks5AcademicProgressScore { get; set; }

        public string Ks5AcademicProgressScoreAverageGrade { get; set; }

        public string Ks5TechLevelApsPerEntry { get; set; }

        public string Ks5TechLevelApsPerEntryLaAverage { get; set; }

        public string TotalOfStudentsStayingInEducationOrEmployment { get; set; }

        public string InEducationPercentage { get; set; }
    }
}