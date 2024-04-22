using System;
using System.Collections.Generic;
using Dfe.ManageFreeSchoolProjects.Data.Entities.Existing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dfe.ManageFreeSchoolProjects.Data.Configuration.Existing
{
	public partial class PropertyQaConfiguration : IEntityTypeConfiguration< PropertyQa>
	{
		public void Configure(EntityTypeBuilder<PropertyQa> builder)
		{
            builder
                .HasNoKey()
                .ToTable("Property_QA", "dbo");

            builder.Property(e => e.AddressOfSite).HasColumnName("Address of site");
            builder.Property(e => e.DateOfCompletionForecast).HasColumnName("Date of completion (forecast)");
            builder.Property(e => e.DateOfExchangeActual).HasColumnName("Date of exchange (actual)");
            builder.Property(e => e.DateOfExchangeForecast).HasColumnName("Date of exchange (forecast)");
            builder.Property(e => e.DateOfHeadsOfTermsAgreedActual).HasColumnName("Date of heads of terms agreed (actual)");
            builder.Property(e => e.DateOfHeadsOfTermsAgreedForecast).HasColumnName("Date of heads of terms agreed (forecast)");
            builder.Property(e => e.EsfaCapitalProjectManager).HasColumnName("ESFA Capital project manager");
            builder.Property(e => e.EsfaPropertyLead).HasColumnName("ESFA property lead");
            builder.Property(e => e.EsfaRegionalPropertyLead).HasColumnName("ESFA regional property lead");
            builder.Property(e => e.HeadOfRegion).HasColumnName("Head of Region");
            builder.Property(e => e.LegalManager).HasColumnName("Legal manager");
            builder.Property(e => e.LocatEdAcquisitionManager).HasColumnName("LocatED acquisition manager");
            builder.Property(e => e.LocatEdCommissionReference).HasColumnName("LocatED commission reference");
            builder.Property(e => e.LocatEdDelivery).HasColumnName("LocatED delivery");
            builder.Property(e => e.Month)
                .HasMaxLength(100)
                .IsUnicode(false);
            builder.Property(e => e.NameOfSite).HasColumnName("Name of site");
            builder.Property(e => e.PleaseStateReasonIfMoreThanOneTenureTypeSelected).HasColumnName("Please state reason if more than one tenure type selected");
            builder.Property(e => e.PostcodeOfSite).HasColumnName("Postcode of site");
            builder.Property(e => e.ProjectDirector).HasColumnName("Project director");
            builder.Property(e => e.SiteIdentifiedActual).HasColumnName("Site identified (actual)");
            builder.Property(e => e.SiteIdentifiedForecast).HasColumnName("Site identified (forecast)");
            builder.Property(e => e.TenureHighlight).HasColumnName("Tenure highlight");

		}
	}

}
