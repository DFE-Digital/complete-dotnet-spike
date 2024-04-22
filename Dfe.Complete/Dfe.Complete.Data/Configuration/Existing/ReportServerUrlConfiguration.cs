using System;
using System.Collections.Generic;
using Dfe.ManageFreeSchoolProjects.Data.Entities.Existing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dfe.ManageFreeSchoolProjects.Data.Configuration.Existing
{
	public partial class ReportServerUrlConfiguration : IEntityTypeConfiguration< ReportServerUrl>
	{
		public void Configure(EntityTypeBuilder<ReportServerUrl> builder)
		{
            builder
                .HasNoKey()
                .ToTable("Report_Server_Url", "dbo");

            builder.Property(e => e.Id).HasColumnName("id");
            builder.Property(e => e.ReportName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("report_name");
            builder.Property(e => e.Servername)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("servername");
            builder.Property(e => e.Url)
                .IsRequired()
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("url");

		}
	}

}
