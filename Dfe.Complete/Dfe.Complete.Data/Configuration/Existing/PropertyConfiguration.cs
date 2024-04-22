using System;
using System.Collections.Generic;
using Dfe.ManageFreeSchoolProjects.Data.Entities;
using Dfe.ManageFreeSchoolProjects.Data.Entities.Existing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dfe.ManageFreeSchoolProjects.Data.Configuration.Existing
{
	public partial class PropertyConfiguration : IEntityTypeConfiguration< Property>
	{
		public void Configure(EntityTypeBuilder<Property> builder)
		{
            builder.HasKey(e => e.Rid);

            builder.ToTable("Property", "dbo", e => e.IsTemporal());

            builder.Property(e => e.PRid)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasColumnName("p_rid");
            builder.Property(e => e.Rid)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasColumnName("RID");
            builder.Property(e => e.SiteAcquisitionInNameOfDclg)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Site.Acquisition in name of DCLG");
            builder.Property(e => e.SiteAcquisitionType)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Site.Acquisition type");
            builder.Property(e => e.SiteAcquisitionVat)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Site.Acquisition VAT");
            builder.Property(e => e.SiteAddressOfSite)
                .IsUnicode(false)
                .HasColumnName("Site.Address of site");
            builder.Property(e => e.SiteAmountAboveRbv)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Site.Amount above RBV");
            builder.Property(e => e.SiteAnnualLeaseCostRent)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Site.Annual lease cost (rent)");
            builder.Property(e => e.SiteAreaOfExistingBuildingM2)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Site.Area of existing building (m2)");
            builder.Property(e => e.SiteAreaOfExistingSiteAcres)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Site.Area of existing site (acres)");
            builder.Property(e => e.SiteBuildingType)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Site.Building type");
            builder.Property(e => e.SiteBuildingValueIaS17InPlaceOfRbv)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Site.Building value (IA S17 in place of RBV)");
            builder.Property(e => e.SiteChargeRequired)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Site.Charge required");
            builder.Property(e => e.SiteDateHeadsOfTermsAgreedActual)
                .HasColumnType("date")
                .HasColumnName("Site.Date heads of terms agreed (actual)");
            builder.Property(e => e.SiteDateHeadsOfTermsAgreedForecast)
                .HasColumnType("date")
                .HasColumnName("Site.Date heads of terms agreed (forecast)");
            builder.Property(e => e.SiteDateOfChargeActual)
                .HasColumnType("date")
                .HasColumnName("Site.Date of charge (actual)");
            builder.Property(e => e.SiteDateOfCompletionActual)
                .HasColumnType("date")
                .HasColumnName("Site.Date of completion (actual)");
            builder.Property(e => e.SiteDateOfCompletionForecast)
                .HasColumnType("date")
                .HasColumnName("Site.Date of completion (forecast)");
            builder.Property(e => e.SiteDateOfExchangeActual)
                .HasColumnType("date")
                .HasColumnName("Site.Date of exchange (actual)");
            builder.Property(e => e.SiteDateOfExchangeForecast)
                .HasColumnType("date")
                .HasColumnName("Site.Date of exchange (forecast)");
            builder.Property(e => e.SiteDateOfHmtPaperActual)
                .HasColumnType("date")
                .HasColumnName("Site.Date of HMT paper (actual)");
            builder.Property(e => e.SiteDateOfPreFundingAgreementSideLetterActual)
                .HasColumnType("date")
                .HasColumnName("Site.Date of pre-funding agreement side letter (actual)");
            builder.Property(e => e.SiteDateRbvRequiredActual)
                .HasColumnType("date")
                .HasColumnName("Site.Date RBV required (actual)");
            builder.Property(e => e.SiteDateRbvSubmittedActual)
                .HasColumnType("date")
                .HasColumnName("Site.Date RBV submitted (actual)");
            builder.Property(e => e.SiteDateSection77ApprovedActual)
                .HasColumnType("date")
                .HasColumnName("Site.Date Section 77 approved (actual)");
            builder.Property(e => e.SiteDclgLeaseToTrustDateOfCompletionActual)
                .HasColumnType("date")
                .HasColumnName("Site.DCLG lease to Trust : Date of completion (actual)");
            builder.Property(e => e.SiteDclgLeaseToTrustDateOfExchangeActual)
                .HasColumnType("date")
                .HasColumnName("Site.DCLG lease to Trust : Date of exchange (actual)");
            builder.Property(e => e.SiteDclgLeaseToTrustIfPurchasedInNameOfDclg)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Site.DCLG lease to Trust, if purchased in name of DCLG");
            builder.Property(e => e.SiteDecisionMakingFramework)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Site.Decision making framework");
            builder.Property(e => e.SiteDetailOfBuildingTypeOther)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Site.Detail of building type - Other");
            builder.Property(e => e.SiteDetailsOfVariationToTheLease)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Site.Details of variation to the lease");
            builder.Property(e => e.SiteDifference)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Site.% difference");
            builder.Property(e => e.SiteDisposalStatus)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Site.Disposal status");
            builder.Property(e => e.SiteDisposalVat)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Site.Disposal VAT");
            builder.Property(e => e.SiteEndDateOfSchoolOccupationActual)
                .HasColumnType("date")
                .HasColumnName("Site.End date of school occupation (actual)");
            builder.Property(e => e.SiteEndDateOfSchoolOccupationForecast)
                .HasColumnType("date")
                .HasColumnName("Site.End date of school occupation (forecast)");
            builder.Property(e => e.SiteExistingUseClass)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Site.Existing use class");
            builder.Property(e => e.SiteGreenBookNpvLeaseCost)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Site.Green book NPV lease cost");
            builder.Property(e => e.SiteHmtPaperComments)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Site.HMT paper comments");
            builder.Property(e => e.SiteHmtPaperRequired)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Site.HMT paper required");
            builder.Property(e => e.SiteIaS17Required)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Site.IA S17 required");
            builder.Property(e => e.SiteIsThereAPlanningLongStopDate)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Site.Is there a planning long stop date?");
            builder.Property(e => e.SiteLandValueIaS17InPlaceOfRbv)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Site.Land value (IA S17 in place of RBV)");
            builder.Property(e => e.SiteLandlordName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Site.Landlord Name");
            builder.Property(e => e.SiteLeaseEndDateActual)
                .HasColumnType("date")
                .HasColumnName("Site.Lease end date (actual)");
            builder.Property(e => e.SiteLeaseStartDateActual)
                .HasColumnType("date")
                .HasColumnName("Site.Lease start date (actual)");
            builder.Property(e => e.SiteLegalManagerComments)
                .IsUnicode(false)
                .HasColumnName("Site.Legal manager comments");
            builder.Property(e => e.SiteLengthOfLeaseYears)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Site.Length of lease (years)");
            builder.Property(e => e.SiteListing)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Site.Listing");
            builder.Property(e => e.SiteLocatEdCommissionReference)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Site.LocatED commission reference");
            builder.Property(e => e.SiteLocatEdDelivery)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Site.LocatED delivery");
            builder.Property(e => e.SiteMaximumCapacityOfTemporarySiteNoOfPupils)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("Site.Maximum capacity of temporary site (no of pupils)");
            builder.Property(e => e.SiteNameOfPurchaser)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Site.Name of purchaser");
            builder.Property(e => e.SiteNameOfSite)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Site.Name of site");
            builder.Property(e => e.SiteNetCostOfAcquisition)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Site.Net cost of acquisition");
            builder.Property(e => e.SiteNetValueOfDisposal)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Site.Net value of disposal");
            builder.Property(e => e.SiteNumberOfStoreys)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Site.Number of storeys");
            builder.Property(e => e.SiteOtherComments)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Site.Other comments");
            builder.Property(e => e.SitePlanningLongStopDateActual)
                .HasColumnType("date")
                .HasColumnName("Site.Planning long stop date (actual)");
            builder.Property(e => e.SitePleaseStateReasonIfMoreThanOneTenureTypeSelected)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Site.Please state reason if more than one tenure type selected");
            builder.Property(e => e.SitePostcodeOfSite)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Site.Postcode of site");
            builder.Property(e => e.SitePreFundingAgreementSideLetterLink)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Site.Pre-funding agreement side letter link");
            builder.Property(e => e.SitePreFundingAgreementSideLetterRequired)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Site.Pre-funding agreement side letter required");
            builder.Property(e => e.SitePremiumIfApplicable)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Site.Premium (if applicable)");
            builder.Property(e => e.SitePropertyAdviserComments)
                .IsUnicode(false)
                .HasColumnName("Site.Property adviser comments");
            builder.Property(e => e.SiteRbvRequired)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Site.RBV required");
            builder.Property(e => e.SiteRbvStatus)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Site.RBV status");
            builder.Property(e => e.SiteRbvValue)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Site.RBV value");
            builder.Property(e => e.SiteS106Funding)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Site.S106 Funding");
            builder.Property(e => e.SiteSection77Required)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Site.Section 77 required");
            builder.Property(e => e.SiteSiteDisposalDateOfCompletionActual)
                .HasColumnType("date")
                .HasColumnName("Site.Site disposal date of completion (actual)");
            builder.Property(e => e.SiteSiteDisposalDateOfExchangeActual)
                .HasColumnType("date")
                .HasColumnName("Site.Site disposal date of exchange (actual)");
            builder.Property(e => e.SiteSiteId)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Site.Site ID");
            builder.Property(e => e.SiteSiteIdentifiedActual)
                .HasColumnType("date")
                .HasColumnName("Site.Site identified (actual)");
            builder.Property(e => e.SiteSiteIdentifiedForecast)
                .HasColumnType("date")
                .HasColumnName("Site.Site identified (forecast)");
            builder.Property(e => e.SiteSiteSchoolCurrentlyOperatingFrom)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Site.Site school currently operating from");
            builder.Property(e => e.SiteSiteStatus)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Site.Site Status");
            builder.Property(e => e.SiteStartDateOfSchoolOccupationActual)
                .HasColumnType("date")
                .HasColumnName("Site.Start date of school occupation (actual)");
            builder.Property(e => e.SiteStartDateOfSchoolOccupationForecast)
                .HasColumnType("date")
                .HasColumnName("Site.Start date of school occupation (forecast)");
            builder.Property(e => e.SiteTenure)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("Site.Tenure");
            builder.Property(e => e.SiteTypeOfSite)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Site.Type of site");
            builder.Property(e => e.SiteTypeOfSiteDisposal)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Site.Type of site disposal");
            builder.Property(e => e.SiteVariationToTheLease)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Site.Variation to the lease");
            builder.Property(e => e.SiteVariationToTheLeaseDateOfCompletionActual)
                .HasColumnType("date")
                .HasColumnName("Site.Variation to the lease : Date of completion (actual)");
            builder.Property(e => e.SiteVendorName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Site.Vendor name");
            builder.Property(e => e.Tos)
                .IsRequired()
                .HasMaxLength(9)
                .IsUnicode(false)
                .HasColumnName("TOS");
            builder.Property(e => e.TownOrCity)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasMaxLength(100)
                .HasColumnName("TownOrCity");

            AuditConfiguration.Apply(builder);
        }
	}

}
