using System;
using System.Collections.Generic;
using Dfe.ManageFreeSchoolProjects.Data.Entities.Existing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dfe.ManageFreeSchoolProjects.Data.Configuration.Existing
{
	public partial class OfstedArchiveConfiguration : IEntityTypeConfiguration< OfstedArchive>
	{
		public void Configure(EntityTypeBuilder<OfstedArchive> builder)
		{
            builder
                .HasNoKey()
                .ToTable("Ofsted_Archive", "dbo");

            builder.Property(e => e.InspectionDate)
                .HasColumnType("date")
                .HasColumnName("Inspection date");
            builder.Property(e => e.OfstedRating)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Ofsted Rating");
            builder.Property(e => e.Urn)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("URN");

		}
	}

}
