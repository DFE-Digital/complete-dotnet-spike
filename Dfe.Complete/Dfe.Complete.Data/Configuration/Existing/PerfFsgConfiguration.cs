using System;
using System.Collections.Generic;
using Dfe.ManageFreeSchoolProjects.Data.Entities.Existing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dfe.ManageFreeSchoolProjects.Data.Configuration.Existing
{
	public partial class PerfFsgConfiguration : IEntityTypeConfiguration< PerfFsg>
	{
		public void Configure(EntityTypeBuilder<PerfFsg> builder)
		{
            builder.ToTable("Perf_FSG", "dbo", e => e.IsTemporal());

            builder.HasKey(e => e.Rid);

            builder.Property(e => e.PRid)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasColumnName("p_rid");
            builder.Property(e => e.Rid)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasColumnName("RID");
            builder.Property(e => e.SchoolPerformanceDataKs1Ks2ValueAdded)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("School Performance Data.KS1-KS2 value added");
            builder.Property(e => e.SchoolPerformanceDataKs2AverageScoreInMaths)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("School Performance Data.KS2 Average score in maths");
            builder.Property(e => e.SchoolPerformanceDataKs2AverageScoreInReading)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("School Performance Data.KS2 Average score in reading");
            builder.Property(e => e.SchoolPerformanceDataKs2EngProgress)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("School Performance Data.KS2 Eng progress");
            builder.Property(e => e.SchoolPerformanceDataKs2ExpectedStandardInMaths)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("School Performance Data.KS2 expected standard in maths");
            builder.Property(e => e.SchoolPerformanceDataKs2ExpectedStandardInReading)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("School Performance Data.KS2 expected standard in reading");
            builder.Property(e => e.SchoolPerformanceDataKs2ExpectedStandardInReadingWritingAndMaths)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("School Performance Data.KS2 expected standard in reading writing and maths");
            builder.Property(e => e.SchoolPerformanceDataKs2ExpectedStandardInWriting)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("School Performance Data.KS2 expected standard in writing");
            builder.Property(e => e.SchoolPerformanceDataKs2HighInMaths)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("School Performance Data.KS2 high in maths");
            builder.Property(e => e.SchoolPerformanceDataKs2HighInReading)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("School Performance Data.KS2 high in reading");
            builder.Property(e => e.SchoolPerformanceDataKs2HighInReadingWritingAndMaths)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("School Performance Data.KS2 high in reading, writing and maths");
            builder.Property(e => e.SchoolPerformanceDataKs2HighInWriting)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("School Performance Data.KS2 high in writing");
            builder.Property(e => e.SchoolPerformanceDataKs2Ks4ValueAdded)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("School Performance Data.KS2-KS4 value added");
            builder.Property(e => e.SchoolPerformanceDataKs2Ks4ValueAddedPr)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("School Performance Data.KS2-KS4 value added Pr");
            builder.Property(e => e.SchoolPerformanceDataKs2Level4EngMaths)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("School Performance Data.KS2 level 4+ Eng maths");
            builder.Property(e => e.SchoolPerformanceDataKs2Level4Maths)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("School Performance Data.KS2 level 4+ maths");
            builder.Property(e => e.SchoolPerformanceDataKs2Level4ReadWriteMaths)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("School Performance Data.KS2 level 4+ read write maths");
            builder.Property(e => e.SchoolPerformanceDataKs2Level4Reading)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("School Performance Data.KS2 level 4+ reading");
            builder.Property(e => e.SchoolPerformanceDataKs2Level4Writing)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("School Performance Data.KS2 level 4+ writing");
            builder.Property(e => e.SchoolPerformanceDataKs2Level5EngMaths)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("School Performance Data.KS2 level 5+ Eng maths");
            builder.Property(e => e.SchoolPerformanceDataKs2Level5Maths)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("School Performance Data.KS2 level 5+ maths");
            builder.Property(e => e.SchoolPerformanceDataKs2Level5ReadWriteMaths)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("School Performance Data.KS2 level 5+ read write maths");
            builder.Property(e => e.SchoolPerformanceDataKs2Level5Reading)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("School Performance Data.KS2 level 5+ reading");
            builder.Property(e => e.SchoolPerformanceDataKs2Level5Writing)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("School Performance Data.KS2 level 5+ writing");
            builder.Property(e => e.SchoolPerformanceDataKs2MathsProgress)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("School Performance Data.KS2 maths progress");
            builder.Property(e => e.SchoolPerformanceDataKs2MathsProgressLowerConfidenceInterval)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("School Performance Data.KS2 maths progress lower confidence interval");
            builder.Property(e => e.SchoolPerformanceDataKs2MathsProgressScore)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("School Performance Data.KS2 maths progress score");
            builder.Property(e => e.SchoolPerformanceDataKs2MathsProgressUpperConfidenceInterval)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("School Performance Data.KS2 maths progress upper confidence interval");
            builder.Property(e => e.SchoolPerformanceDataKs2Pupils)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("School Performance Data.KS2 pupils");
            builder.Property(e => e.SchoolPerformanceDataKs2PupilsAchievingAHighScoreInReadingWritingAndMaths)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("School Performance Data.KS2 pupils achieving a high score in reading, writing and maths");
            builder.Property(e => e.SchoolPerformanceDataKs2ReadProgress)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("School Performance Data.KS2 read progress");
            builder.Property(e => e.SchoolPerformanceDataKs2ReadingProgressLowerConfidenceInterval)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("School Performance Data.KS2 reading progress lower confidence interval");
            builder.Property(e => e.SchoolPerformanceDataKs2ReadingProgressScore)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("School Performance Data.KS2 reading progress score");
            builder.Property(e => e.SchoolPerformanceDataKs2ReadingProgressUpperConfidenceInterval)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("School Performance Data.KS2 reading progress upper confidence interval");
            builder.Property(e => e.SchoolPerformanceDataKs2WriteProgress)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("School Performance Data.KS2 write progress");
            builder.Property(e => e.SchoolPerformanceDataKs2WritingProgressLowerConfidenceInterval)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("School Performance Data.KS2 writing progress lower confidence interval");
            builder.Property(e => e.SchoolPerformanceDataKs2WritingProgressScore)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("School Performance Data.KS2 writing progress score");
            builder.Property(e => e.SchoolPerformanceDataKs2WritingProgressUpperConfidenceInterval)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("School Performance Data.KS2 writing progress upper confidence interval");
            builder.Property(e => e.SchoolPerformanceDataKs45acIncEngMath)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("School Performance Data.KS4 5AC inc Eng math");
            builder.Property(e => e.SchoolPerformanceDataKs45acIncEngMathPr)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("School Performance Data.KS4 5AC inc Eng math Pr");
            builder.Property(e => e.SchoolPerformanceDataKs45acIncEngMathPupils)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("School Performance Data.KS4 5AC inc Eng math Pupils");
            builder.Property(e => e.SchoolPerformanceDataKs4AchievingAStandardPass5OrAboveInEnglishAndMaths)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("School Performance Data.KS4 achieving a ‘standard pass’ (5 or above) in English and maths");
            builder.Property(e => e.SchoolPerformanceDataKs4AchievingAStandardPass5OrAboveInEnglishAndMathsPr)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("School Performance Data.KS4 achieving a ‘standard pass’ (5 or above) in English and maths Pr");
            builder.Property(e => e.SchoolPerformanceDataKs4AchievingAStrongPass5OrAboveInEnglishAndMaths)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("School Performance Data.KS4 achieving a ‘strong pass’ (5 or above) in English and maths");
            builder.Property(e => e.SchoolPerformanceDataKs4AchievingAStrongPass5OrAboveInEnglishAndMathsPr)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("School Performance Data.KS4 achieving a ‘strong pass’ (5 or above) in English and maths Pr");
            builder.Property(e => e.SchoolPerformanceDataKs4Attainment8Score)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("School Performance Data.KS4 Attainment 8 score");
            builder.Property(e => e.SchoolPerformanceDataKs4Attainment8ScoreEbacc)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("School Performance Data.KS4 Attainment 8 score - Ebacc");
            builder.Property(e => e.SchoolPerformanceDataKs4Attainment8ScoreEnglish)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("School Performance Data.KS4 Attainment 8 score - English");
            builder.Property(e => e.SchoolPerformanceDataKs4Attainment8ScoreMaths)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("School Performance Data.KS4 Attainment 8 score - Maths");
            builder.Property(e => e.SchoolPerformanceDataKs4Attainment8ScoreOpen)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("School Performance Data.KS4 Attainment 8 score - Open");
            builder.Property(e => e.SchoolPerformanceDataKs4Attainment8ScorePr)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("School Performance Data.KS4 Attainment 8 score Pr");
            builder.Property(e => e.SchoolPerformanceDataKs4CInEnglishAndMaths)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("School Performance Data.KS4 C + in English and maths");
            builder.Property(e => e.SchoolPerformanceDataKs4CInEnglishAndMathsPupils)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("School Performance Data.KS4 C + in English and maths Pupils");
            builder.Property(e => e.SchoolPerformanceDataKs4Ebacc)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("School Performance Data.KS4 EBacc");
            builder.Property(e => e.SchoolPerformanceDataKs4EbaccPr)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("School Performance Data.KS4 EBacc Pr");
            builder.Property(e => e.SchoolPerformanceDataKs4EbaccPupils)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("School Performance Data.KS4 Ebacc Pupils");
            builder.Property(e => e.SchoolPerformanceDataKs4EngProgress)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("School Performance Data.KS4 Eng progress");
            builder.Property(e => e.SchoolPerformanceDataKs4EngProgressPr)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("School Performance Data.KS4 Eng progress Pr");
            builder.Property(e => e.SchoolPerformanceDataKs4MathsProgress)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("School Performance Data.KS4 maths progress");
            builder.Property(e => e.SchoolPerformanceDataKs4MathsProgressPr)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("School Performance Data.KS4 maths progress Pr");
            builder.Property(e => e.SchoolPerformanceDataKs4Progress8LowerConfidenceInterval)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("School Performance Data.KS4 progress 8 lower confidence interval");
            builder.Property(e => e.SchoolPerformanceDataKs4Progress8LowerConfidenceIntervalPr)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("School Performance Data.KS4 progress 8 lower confidence interval Pr");
            builder.Property(e => e.SchoolPerformanceDataKs4Progress8Pupils)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("School Performance Data.KS4 progress 8 pupils");
            builder.Property(e => e.SchoolPerformanceDataKs4Progress8PupilsPr)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("School Performance Data.KS4 progress 8 pupils Pr");
            builder.Property(e => e.SchoolPerformanceDataKs4Progress8Score)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("School Performance Data.KS4 progress 8 score");
            builder.Property(e => e.SchoolPerformanceDataKs4Progress8ScoreEbacc)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("School Performance Data.KS4 progress 8 score -Ebacc");
            builder.Property(e => e.SchoolPerformanceDataKs4Progress8ScoreEnglish)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("School Performance Data.KS4 progress 8 score - English");
            builder.Property(e => e.SchoolPerformanceDataKs4Progress8ScoreMaths)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("School Performance Data.KS4 progress 8 score - Maths");
            builder.Property(e => e.SchoolPerformanceDataKs4Progress8ScoreOpen)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("School Performance Data.KS4 progress 8 score - Open");
            builder.Property(e => e.SchoolPerformanceDataKs4Progress8ScorePr)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("School Performance Data.KS4 progress 8 score Pr");
            builder.Property(e => e.SchoolPerformanceDataKs4Progress8UpperConfidenceInterval)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("School Performance Data.KS4 progress 8 upper confidence interval");
            builder.Property(e => e.SchoolPerformanceDataKs4Progress8UpperConfidenceIntervalPr)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("School Performance Data.KS4 progress 8 upper confidence interval Pr");
            builder.Property(e => e.SchoolPerformanceDataKs4Pupils)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("School Performance Data.KS4 pupils");
            builder.Property(e => e.SchoolPerformanceDataKs4PupilsPr)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("School Performance Data.KS4 pupils Pr");
            builder.Property(e => e.SchoolPerformanceDataKs5ApsPerEntryAcademic)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("School Performance Data.KS5 APS per entry (Academic)");
            builder.Property(e => e.SchoolPerformanceDataKs5ApsPerEntryAcademicPr)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("School Performance Data.KS5 APS per entry (Academic) Pr");
            builder.Property(e => e.SchoolPerformanceDataKs5ApsPerEntryAppliedGeneral)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("School Performance Data.KS5 APS per entry (applied general)");
            builder.Property(e => e.SchoolPerformanceDataKs5ApsPerEntryVocational)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("School Performance Data.KS5 APS per entry (Vocational)");
            builder.Property(e => e.SchoolPerformanceDataKs5ApsPerEntryVocationalPr)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("School Performance Data.KS5 APS per entry (Vocational) Pr");
            builder.Property(e => e.SchoolPerformanceDataKs5PupilsAcademic)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("School Performance Data.KS5 pupils (academic)");
            builder.Property(e => e.SchoolPerformanceDataKs5PupilsAcademicPr)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("School Performance Data.KS5 pupils (academic) Pr");
            builder.Property(e => e.SchoolPerformanceDataKs5PupilsAll)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("School Performance Data.KS5 pupils (all)");
            builder.Property(e => e.SchoolPerformanceDataKs5PupilsAllPr)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("School Performance Data.KS5 pupils (all)PR");
            builder.Property(e => e.SchoolPerformanceDataKs5PupilsAppliedGeneral)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("School Performance Data.KS5 pupils (applied general)");
            builder.Property(e => e.SchoolPerformanceDataKs5PupilsAppliedGeneralPr)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("School Performance Data.KS5 pupils (applied general) Pr");
            builder.Property(e => e.SchoolPerformanceDataKs5ValueAddedAcademic)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("School Performance Data.KS5 value added (academic)");
            builder.Property(e => e.SchoolPerformanceDataKs5ValueAddedAcademicPr)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("School Performance Data.KS5 value added (academic) Pr");
            builder.Property(e => e.SchoolPerformanceDataKs5ValueAddedAppliedGeneral)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("School Performance Data.KS5 value added (applied general)");
            builder.Property(e => e.SchoolPerformanceDataKs5ValueAddedAppliedGeneralPr)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("School Performance Data.KS5 value added (applied general) Pr");
            builder.Property(e => e.SchoolPerformanceDataKs5ValueAddedLowerConfidenceInterval)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("School Performance Data.KS5 value added lower confidence interval");
            builder.Property(e => e.SchoolPerformanceDataKs5ValueAddedLowerConfidenceIntervalPr)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("School Performance Data.KS5 value added lower confidence interval Pr");
            builder.Property(e => e.SchoolPerformanceDataKs5ValueAddedUpperConfidenceInterval)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("School Performance Data.KS5 value added upper confidence interval");
            builder.Property(e => e.SchoolPerformanceDataKs5ValueAddedUpperConfidenceIntervalPr)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("School Performance Data.KS5 value added upper confidence interval Pr");
            builder.Property(e => e.SchoolPerformanceDataKs5ValueAddedVocational)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("School Performance Data.KS5 value added (Vocational)");
            builder.Property(e => e.SchoolPerformanceDataKs5ValueAddedVocationalPr)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("School Performance Data.KS5 value added (Vocational) Pr");
            builder.Property(e => e.SchoolPerformanceDataNumberOfPupils)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("School Performance Data.Number of pupils");
            builder.Property(e => e.SchoolPerformanceDataProgress8OptIn)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("School Performance Data.Progress 8 opt in");
            builder.Property(e => e.SchoolPerformanceDataYear)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("School Performance Data.Year");

		}
	}

}
