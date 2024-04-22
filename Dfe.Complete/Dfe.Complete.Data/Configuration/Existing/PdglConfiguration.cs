using System;
using System.Collections.Generic;
using Dfe.ManageFreeSchoolProjects.Data.Entities.Existing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dfe.ManageFreeSchoolProjects.Data.Configuration.Existing
{
	public partial class PdglConfiguration : IEntityTypeConfiguration< Pdgl>
	{
		public void Configure(EntityTypeBuilder<Pdgl> builder)
		{
            builder.ToTable("PDGL", "dbo", e => e.IsTemporal());

            builder.HasKey(e => e.Rid);

            builder.Property(e => e.PRid)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasColumnName("p_rid");
            builder.Property(e => e.ProjectDeliveryGrantLetterPdglId)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Project Delivery Grant Letter.PDGL ID");
            builder.Property(e => e.ProjectDeliveryGrantLetterProjectDeliveryGrantLetterIssuedDate)
                .HasColumnType("date")
                .HasColumnName("Project Delivery Grant Letter.Project Delivery Grant Letter issued date");
            builder.Property(e => e.ProjectDeliveryGrantLetterProjectDeliveryGrantLetterTotalValue)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Project Delivery Grant Letter.Project Delivery Grant Letter total value");
            builder.Property(e => e.Rid)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasColumnName("RID");

		}
	}

}
