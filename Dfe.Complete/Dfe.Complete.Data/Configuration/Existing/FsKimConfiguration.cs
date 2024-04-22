using System;
using System.Collections.Generic;
using Dfe.ManageFreeSchoolProjects.Data.Entities;
using Dfe.ManageFreeSchoolProjects.Data.Entities.Existing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dfe.ManageFreeSchoolProjects.Data.Configuration.Existing
{
	public partial class FsKimConfiguration : IEntityTypeConfiguration< FsKim>
	{
		public void Configure(EntityTypeBuilder<FsKim> builder)
		{
            builder.ToTable("FS_KIM", "dbo", e => e.IsTemporal());

            builder.HasKey(e => e.Rid);

            builder.Property(e => e.GeneralDetailsAcademyLaestab)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("General Details.Academy LAESTAB");
            builder.Property(e => e.GeneralDetailsAcademyName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("General Details.Academy Name");
            builder.Property(e => e.GeneralDetailsAcademyStatus)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("General Details.Academy Status");
            builder.Property(e => e.GeneralDetailsAcademyUkprn)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("General Details.Academy UKPRN");
            builder.Property(e => e.GeneralDetailsAcademyUrn)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("General Details.Academy URN");
            builder.Property(e => e.GeneralDetailsLaestab)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("General Details.LAESTAB");
            builder.Property(e => e.GeneralDetailsLocalAuthority)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("General Details.Local Authority");
            builder.Property(e => e.GeneralDetailsPhase)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("General Details.Phase");
            builder.Property(e => e.GeneralDetailsProjectName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("General Details.Project Name");
            builder.Property(e => e.GeneralDetailsProjectStatus)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("General Details.Project status");
            builder.Property(e => e.GeneralDetailsReBrokeredDate)
                .HasColumnType("date")
                .HasColumnName("General Details.Re-brokered date");
            builder.Property(e => e.GeneralDetailsRouteOfProject)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("General Details.Route of Project");
            builder.Property(e => e.GeneralDetailsRscRegion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("General Details.RSC Region");
            builder.Property(e => e.GeneralDetailsUrn)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("General Details.URN");
            builder.Property(e => e.PRid)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasColumnName("p_rid");
            builder.Property(e => e.ReBrokerageStatus)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Re-brokerage status");
            builder.Property(e => e.Rid)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasColumnName("RID");

            AuditConfiguration.Apply(builder);
        }
	}

}
