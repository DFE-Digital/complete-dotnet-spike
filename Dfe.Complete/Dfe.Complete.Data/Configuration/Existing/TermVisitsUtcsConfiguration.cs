using System;
using System.Collections.Generic;
using Dfe.ManageFreeSchoolProjects.Data.Entities.Existing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dfe.ManageFreeSchoolProjects.Data.Configuration.Existing
{
	public partial class TermVisitsUtcsConfiguration : IEntityTypeConfiguration< TermVisitsUtcs>
	{
		public void Configure(EntityTypeBuilder<TermVisitsUtcs> builder)
		{
            builder.HasKey(e => e.Rid);
            
            builder.ToTable("Term_Visits_UTCs", "dbo", e => e.IsTemporal());

            builder.Property(e => e.PRid)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasColumnName("p_rid");
            builder.Property(e => e.Rid)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasColumnName("RID");
            builder.Property(e => e.TermVisitsUtcPostOfstedUtcVisitDateOfVisit)
                .HasColumnType("date")
                .HasColumnName("Term Visits UTC.Post-Ofsted UTC Visit: Date of Visit");
            builder.Property(e => e.TermVisitsUtcPostOfstedUtcVisitNameOfDfEOfficial)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Term Visits UTC.Post-Ofsted UTC Visit: Name of DfE official");
            builder.Property(e => e.TermVisitsUtcPostOfstedUtcVisitNameOfEducationAdviser)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Term Visits UTC.Post-Ofsted UTC Visit: Name of Education Adviser");
            builder.Property(e => e.TermVisitsUtcPostOfstedUtcVisitNextVisitDate)
                .HasColumnType("date")
                .HasColumnName("Term Visits UTC.Post-Ofsted UTC Visit: Next visit date");
            builder.Property(e => e.TermVisitsUtcPostOfstedUtcVisitReportLink)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Term Visits UTC.Post-Ofsted UTC Visit: Report link");
            builder.Property(e => e.TermVisitsUtcPostOfstedUtcVisitSummary)
                .IsUnicode(false)
                .HasColumnName("Term Visits UTC.Post-Ofsted UTC Visit: Summary");
            builder.Property(e => e.TermVisitsUtcPostOfstedUtcVisitVisitRating)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Term Visits UTC.Post-Ofsted UTC Visit: Visit Rating");
            builder.Property(e => e.TermVisitsUtcSchoolTermVisit)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Term Visits UTC.School term Visit");

		}
	}

}
