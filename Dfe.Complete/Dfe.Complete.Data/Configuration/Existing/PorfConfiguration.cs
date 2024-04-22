using System;
using System.Collections.Generic;
using Dfe.ManageFreeSchoolProjects.Data.Entities.Existing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dfe.ManageFreeSchoolProjects.Data.Configuration.Existing
{
	public partial class PorfConfiguration : IEntityTypeConfiguration< Porf>
	{
		public void Configure(EntityTypeBuilder<Porf> builder)
		{
            builder.ToTable("PORF", "dbo", e => e.IsTemporal());

            builder.HasKey(e => e.Rid);

            builder.Property(e => e.PRid)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasColumnName("p_rid");
            builder.Property(e => e.PurchaseOrderRequestFormPorfGlCode)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Purchase Order Request Form.PORF GL code");
            builder.Property(e => e.PurchaseOrderRequestFormPorfId)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Purchase Order Request Form.PORF ID");
            builder.Property(e => e.PurchaseOrderRequestFormPurchaseOrderCreatedDate)
                .HasColumnType("date")
                .HasColumnName("Purchase Order Request Form.Purchase Order created date");
            builder.Property(e => e.PurchaseOrderRequestFormPurchaseOrderNumber)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Purchase Order Request Form.Purchase Order number");
            builder.Property(e => e.PurchaseOrderRequestFormPurchaseOrderRequestFormTotalValueExclVat)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Purchase Order Request Form.Purchase Order Request Form Total value (excl VAT)");
            builder.Property(e => e.PurchaseOrderRequestFormPurchaseOrderRequestFormVat)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Purchase Order Request Form.Purchase Order Request Form VAT");
            builder.Property(e => e.PurchaseOrderRequestFormPurchaseOrderRequestFormVendor)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Purchase Order Request Form.Purchase Order Request Form - Vendor");
            builder.Property(e => e.Rid)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasColumnName("RID");

		}
	}

}
