using System;
using System.Collections.Generic;
using Dfe.ManageFreeSchoolProjects.Data.Entities.Existing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dfe.ManageFreeSchoolProjects.Data.Configuration.Existing
{
	public partial class PerfFsgLocalConfiguration : IEntityTypeConfiguration< PerfFsgLocal>
	{
		public void Configure(EntityTypeBuilder<PerfFsgLocal> builder)
		{
            builder
                .HasNoKey()
                .ToTable("Perf_FSG_Local", "dbo");

            builder.Property(e => e.Attainment8ScoreLaAverage)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Attainment 8 Score LA Average");
            builder.Property(e => e.InEducationPercentage)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("In Education (percentage)");
            builder.Property(e => e.Ks4CInEnglishMathsLaAverage)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("KS4 C+ in English & Maths LA Average (%)");
            builder.Property(e => e.Ks4EbaccEnteredForEbacc)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("KS4 Ebacc (% entered for Ebacc)");
            builder.Property(e => e.Ks5ALevelApsPerEntry)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("KS5 A-Level (APS per Entry)");
            builder.Property(e => e.Ks5AcademicProgressScore)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("KS5 Academic Progress Score");
            builder.Property(e => e.Ks5AcademicProgressScoreAverageGrade)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("KS5 Academic Progress Score (Average Grade)");
            builder.Property(e => e.Ks5TechLevelApsPerEntry)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("KS5 Tech Level (APS per Entry)");
            builder.Property(e => e.Ks5TechLevelApsPerEntryLaAverage)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("KS5 Tech Level (APS per Entry - LA Average)");
            builder.Property(e => e.ProjectId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Project ID");
            builder.Property(e => e.TotalOfStudentsStayingInEducationOrEmployment)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Total % of students staying in education or employment");
            builder.Property(e => e.Urn)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("URN");
            builder.Property(e => e.Year)
                .HasMaxLength(4)
                .IsUnicode(false);

		}
	}

}
