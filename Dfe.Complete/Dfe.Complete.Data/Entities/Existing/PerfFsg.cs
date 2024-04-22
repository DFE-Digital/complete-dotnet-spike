using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Dfe.ManageFreeSchoolProjects.Data
{
    public partial class MfspContext : DbContext
    {
        public virtual DbSet<Entities.Existing.PerfFsg> PerfFsg { get; set; }
    }
}

namespace Dfe.ManageFreeSchoolProjects.Data.Entities.Existing
{
    public partial class PerfFsg
    {
        public string PRid { get; set; }

        public string Rid { get; set; }

        public string SchoolPerformanceDataYear { get; set; }

        public string SchoolPerformanceDataNumberOfPupils { get; set; }

        public string SchoolPerformanceDataKs2Level4EngMaths { get; set; }

        public string SchoolPerformanceDataKs2Level5EngMaths { get; set; }

        public string SchoolPerformanceDataKs2Level4Reading { get; set; }

        public string SchoolPerformanceDataKs2Level4Writing { get; set; }

        public string SchoolPerformanceDataKs2Level4Maths { get; set; }

        public string SchoolPerformanceDataKs2Level4ReadWriteMaths { get; set; }

        public string SchoolPerformanceDataKs2Level5Reading { get; set; }

        public string SchoolPerformanceDataKs2Level5Writing { get; set; }

        public string SchoolPerformanceDataKs2Level5Maths { get; set; }

        public string SchoolPerformanceDataKs2Level5ReadWriteMaths { get; set; }

        public string SchoolPerformanceDataKs2EngProgress { get; set; }

        public string SchoolPerformanceDataKs2ReadProgress { get; set; }

        public string SchoolPerformanceDataKs2WriteProgress { get; set; }

        public string SchoolPerformanceDataKs2MathsProgress { get; set; }

        public string SchoolPerformanceDataKs2ExpectedStandardInReading { get; set; }

        public string SchoolPerformanceDataKs2ExpectedStandardInWriting { get; set; }

        public string SchoolPerformanceDataKs2ExpectedStandardInMaths { get; set; }

        public string SchoolPerformanceDataKs2ExpectedStandardInReadingWritingAndMaths { get; set; }

        public string SchoolPerformanceDataKs2HighInReading { get; set; }

        public string SchoolPerformanceDataKs2HighInWriting { get; set; }

        public string SchoolPerformanceDataKs2HighInMaths { get; set; }

        public string SchoolPerformanceDataKs2HighInReadingWritingAndMaths { get; set; }

        public string SchoolPerformanceDataKs2ReadingProgressScore { get; set; }

        public string SchoolPerformanceDataKs2WritingProgressScore { get; set; }

        public string SchoolPerformanceDataKs2MathsProgressScore { get; set; }

        public string SchoolPerformanceDataKs1Ks2ValueAdded { get; set; }

        public string SchoolPerformanceDataKs2Pupils { get; set; }

        public string SchoolPerformanceDataKs2ReadingProgressUpperConfidenceInterval { get; set; }

        public string SchoolPerformanceDataKs2WritingProgressUpperConfidenceInterval { get; set; }

        public string SchoolPerformanceDataKs2MathsProgressUpperConfidenceInterval { get; set; }

        public string SchoolPerformanceDataKs2ReadingProgressLowerConfidenceInterval { get; set; }

        public string SchoolPerformanceDataKs2WritingProgressLowerConfidenceInterval { get; set; }

        public string SchoolPerformanceDataKs2MathsProgressLowerConfidenceInterval { get; set; }

        public string SchoolPerformanceDataKs2AverageScoreInReading { get; set; }

        public string SchoolPerformanceDataKs2AverageScoreInMaths { get; set; }

        public string SchoolPerformanceDataKs2PupilsAchievingAHighScoreInReadingWritingAndMaths { get; set; }

        public string SchoolPerformanceDataKs45acIncEngMathPupils { get; set; }

        public string SchoolPerformanceDataKs45acIncEngMath { get; set; }

        public string SchoolPerformanceDataKs45acIncEngMathPr { get; set; }

        public string SchoolPerformanceDataKs4EngProgress { get; set; }

        public string SchoolPerformanceDataKs4EngProgressPr { get; set; }

        public string SchoolPerformanceDataKs4MathsProgress { get; set; }

        public string SchoolPerformanceDataKs4MathsProgressPr { get; set; }

        public string SchoolPerformanceDataKs4EbaccPupils { get; set; }

        public string SchoolPerformanceDataKs4Ebacc { get; set; }

        public string SchoolPerformanceDataKs4EbaccPr { get; set; }

        public string SchoolPerformanceDataKs4CInEnglishAndMaths { get; set; }

        public string SchoolPerformanceDataKs4CInEnglishAndMathsPupils { get; set; }

        public string SchoolPerformanceDataKs4AchievingAStrongPass5OrAboveInEnglishAndMaths { get; set; }

        public string SchoolPerformanceDataKs4AchievingAStrongPass5OrAboveInEnglishAndMathsPr { get; set; }

        public string SchoolPerformanceDataKs4AchievingAStandardPass5OrAboveInEnglishAndMaths { get; set; }

        public string SchoolPerformanceDataKs4AchievingAStandardPass5OrAboveInEnglishAndMathsPr { get; set; }

        public string SchoolPerformanceDataKs2Ks4ValueAdded { get; set; }

        public string SchoolPerformanceDataKs2Ks4ValueAddedPr { get; set; }

        public string SchoolPerformanceDataKs4Pupils { get; set; }

        public string SchoolPerformanceDataKs4PupilsPr { get; set; }

        public string SchoolPerformanceDataProgress8OptIn { get; set; }

        public string SchoolPerformanceDataKs4Progress8Pupils { get; set; }

        public string SchoolPerformanceDataKs4Progress8PupilsPr { get; set; }

        public string SchoolPerformanceDataKs4Progress8Score { get; set; }

        public string SchoolPerformanceDataKs4Progress8ScorePr { get; set; }

        public string SchoolPerformanceDataKs4Progress8ScoreEnglish { get; set; }

        public string SchoolPerformanceDataKs4Progress8ScoreMaths { get; set; }

        public string SchoolPerformanceDataKs4Progress8ScoreOpen { get; set; }

        public string SchoolPerformanceDataKs4Progress8ScoreEbacc { get; set; }

        public string SchoolPerformanceDataKs4Attainment8Score { get; set; }

        public string SchoolPerformanceDataKs4Attainment8ScorePr { get; set; }

        public string SchoolPerformanceDataKs4Attainment8ScoreEnglish { get; set; }

        public string SchoolPerformanceDataKs4Attainment8ScoreMaths { get; set; }

        public string SchoolPerformanceDataKs4Attainment8ScoreEbacc { get; set; }

        public string SchoolPerformanceDataKs4Attainment8ScoreOpen { get; set; }

        public string SchoolPerformanceDataKs4Progress8UpperConfidenceInterval { get; set; }

        public string SchoolPerformanceDataKs4Progress8UpperConfidenceIntervalPr { get; set; }

        public string SchoolPerformanceDataKs4Progress8LowerConfidenceInterval { get; set; }

        public string SchoolPerformanceDataKs4Progress8LowerConfidenceIntervalPr { get; set; }

        public string SchoolPerformanceDataKs5ApsPerEntryAcademic { get; set; }

        public string SchoolPerformanceDataKs5ApsPerEntryAcademicPr { get; set; }

        public string SchoolPerformanceDataKs5ApsPerEntryVocational { get; set; }

        public string SchoolPerformanceDataKs5ApsPerEntryVocationalPr { get; set; }

        public string SchoolPerformanceDataKs5ValueAddedAcademic { get; set; }

        public string SchoolPerformanceDataKs5ValueAddedAcademicPr { get; set; }

        public string SchoolPerformanceDataKs5ValueAddedAppliedGeneral { get; set; }

        public string SchoolPerformanceDataKs5ValueAddedAppliedGeneralPr { get; set; }

        public string SchoolPerformanceDataKs5ValueAddedVocational { get; set; }

        public string SchoolPerformanceDataKs5ValueAddedVocationalPr { get; set; }

        public string SchoolPerformanceDataKs5ValueAddedLowerConfidenceInterval { get; set; }

        public string SchoolPerformanceDataKs5ValueAddedLowerConfidenceIntervalPr { get; set; }

        public string SchoolPerformanceDataKs5ValueAddedUpperConfidenceInterval { get; set; }

        public string SchoolPerformanceDataKs5ValueAddedUpperConfidenceIntervalPr { get; set; }

        public string SchoolPerformanceDataKs5ApsPerEntryAppliedGeneral { get; set; }

        public string SchoolPerformanceDataKs5PupilsAcademic { get; set; }

        public string SchoolPerformanceDataKs5PupilsAcademicPr { get; set; }

        public string SchoolPerformanceDataKs5PupilsAppliedGeneral { get; set; }

        public string SchoolPerformanceDataKs5PupilsAppliedGeneralPr { get; set; }

        public string SchoolPerformanceDataKs5PupilsAll { get; set; }

        public string SchoolPerformanceDataKs5PupilsAllPr { get; set; }
    }
}