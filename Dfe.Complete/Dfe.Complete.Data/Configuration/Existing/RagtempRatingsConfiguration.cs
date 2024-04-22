using System;
using System.Collections.Generic;
using Dfe.ManageFreeSchoolProjects.Data.Entities.Existing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dfe.ManageFreeSchoolProjects.Data.Configuration.Existing
{
	public partial class RagtempRatingsConfiguration : IEntityTypeConfiguration< RagtempRatings>
	{
		public void Configure(EntityTypeBuilder<RagtempRatings> builder)
		{
            builder
                .HasNoKey()
                .ToTable("RAGTEMP_RATINGS", "dbo");

            builder.Property(e => e.AccidentOnSiteInThisMonthReportedToEfa)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Accident on site in this month reported to EFA");
            builder.Property(e => e.Fscode)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("FSCode");
            builder.Property(e => e.OverallRag)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Overall RAG");
            builder.Property(e => e.TaOverallSiteRag)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("TA Overall Site RAG");
            builder.Property(e => e.TaOverallSiteRagComments)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("TA Overall Site RAG Comments");
            builder.Property(e => e.TaPermanentSiteRag)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("TA Permanent Site RAG");
            builder.Property(e => e.TaPermanentSiteRagComments)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("TA Permanent Site RAG Comments");
            builder.Property(e => e.TaSeptemberSiteRag)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("TA September Site RAG");
            builder.Property(e => e.TaSeptemberSiteRagComments)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("TA September Site RAG Comments");
            builder.Property(e => e.TatemporarySiteRag)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("TATemporary Site RAG");
            builder.Property(e => e.TatemporarySiteRagComments)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("TATemporary Site RAG Comments");

		}
	}

}
