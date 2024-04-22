using System;
using System.Collections.Generic;
using Dfe.ManageFreeSchoolProjects.Data.Entities.Existing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dfe.ManageFreeSchoolProjects.Data.Configuration.Existing
{
	public partial class TechnicalQaConfiguration : IEntityTypeConfiguration< TechnicalQa>
	{
		public void Configure(EntityTypeBuilder<TechnicalQa> builder)
		{
            builder
                .HasNoKey()
                .ToTable("Technical_QA", "dbo");

            builder.Property(e => e.Bim).HasColumnName("BIM");
            builder.Property(e => e.ComgdIssued).HasColumnName("COMGD Issued");
            builder.Property(e => e.ContractAwardValue).HasColumnName("Contract Award Value £");
            builder.Property(e => e.ContractBudgetValue).HasColumnName("Contract Budget Value £");
            builder.Property(e => e.ContractProcurementStatus).HasColumnName("Contract Procurement Status");
            builder.Property(e => e.ContractingParty).HasColumnName("Contracting Party");
            builder.Property(e => e.DeliveryParty).HasColumnName("Delivery Party");
            builder.Property(e => e.EnterIntoMainContractActual).HasColumnName("Enter into Main Contract Actual");
            builder.Property(e => e.FeasibilityReportApproved).HasColumnName("Feasibility Report Approved");
            builder.Property(e => e.FeasibiltyReportStartDate).HasColumnName("Feasibilty Report Start Date");
            builder.Property(e => e.FinalContractValue).HasColumnName("Final Contract Value £");
            builder.Property(e => e.Gifa).HasColumnName("GIFA");
            builder.Property(e => e.Month)
                .HasMaxLength(100)
                .IsUnicode(false);
            builder.Property(e => e.PcCertificateIssuedActual).HasColumnName("PC Certificate Issued Actual");
            builder.Property(e => e.ProcurementRoute).HasColumnName("Procurement Route");
            builder.Property(e => e.ProcurementStartActual).HasColumnName("Procurement Start Actual");
            builder.Property(e => e.TypeOfWork).HasColumnName("Type of Work");

		}
	}

}
