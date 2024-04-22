using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Dfe.ManageFreeSchoolProjects.Data
{
    public partial class MfspContext : DbContext
    {
        public virtual DbSet<Entities.Existing.Property> Property { get; set; }
    }
}

namespace Dfe.ManageFreeSchoolProjects.Data.Entities.Existing
{
    public partial class Property : IAuditable
    {
        public string PRid { get; set; }

        public string Rid { get; set; }

        public string SiteSiteId { get; set; }

        public string SiteTypeOfSite { get; set; }

        public string Tos { get; set; }

        public string SiteLocatEdDelivery { get; set; }

        public string SiteLocatEdCommissionReference { get; set; }

        public string SiteSiteStatus { get; set; }

        public string SiteS106Funding { get; set; }

        public string SiteNameOfSite { get; set; }

        public string SiteAddressOfSite { get; set; }

        public string SitePostcodeOfSite { get; set; }

        public DateTime? SiteStartDateOfSchoolOccupationForecast { get; set; }

        public DateTime? SiteStartDateOfSchoolOccupationActual { get; set; }

        public DateTime? SiteEndDateOfSchoolOccupationForecast { get; set; }

        public DateTime? SiteEndDateOfSchoolOccupationActual { get; set; }

        public string SiteSiteSchoolCurrentlyOperatingFrom { get; set; }

        public string SiteBuildingType { get; set; }

        public string SiteDetailOfBuildingTypeOther { get; set; }

        public string SiteAreaOfExistingSiteAcres { get; set; }

        public string SiteAreaOfExistingBuildingM2 { get; set; }

        public string SiteMaximumCapacityOfTemporarySiteNoOfPupils { get; set; }

        public string SiteExistingUseClass { get; set; }

        public string SiteListing { get; set; }

        public string SiteNumberOfStoreys { get; set; }

        public string SiteTenure { get; set; }

        public string SitePleaseStateReasonIfMoreThanOneTenureTypeSelected { get; set; }

        public string SiteAcquisitionType { get; set; }

        public DateTime? SiteSiteIdentifiedForecast { get; set; }

        public DateTime? SiteSiteIdentifiedActual { get; set; }

        public DateTime? SiteDateHeadsOfTermsAgreedForecast { get; set; }

        public DateTime? SiteDateHeadsOfTermsAgreedActual { get; set; }

        public string SiteIsThereAPlanningLongStopDate { get; set; }

        public DateTime? SitePlanningLongStopDateActual { get; set; }

        public string SitePreFundingAgreementSideLetterRequired { get; set; }

        public DateTime? SiteDateOfPreFundingAgreementSideLetterActual { get; set; }

        public string SitePreFundingAgreementSideLetterLink { get; set; }

        public DateTime? SiteDateOfExchangeForecast { get; set; }

        public DateTime? SiteDateOfExchangeActual { get; set; }

        public DateTime? SiteDateOfCompletionForecast { get; set; }

        public DateTime? SiteDateOfCompletionActual { get; set; }

        public string SiteChargeRequired { get; set; }

        public DateTime? SiteDateOfChargeActual { get; set; }

        public string SiteSection77Required { get; set; }

        public DateTime? SiteDateSection77ApprovedActual { get; set; }

        public string SiteVendorName { get; set; }

        public string SiteNetCostOfAcquisition { get; set; }

        public string SiteAcquisitionVat { get; set; }

        public string SiteAcquisitionInNameOfDclg { get; set; }

        public string SiteDclgLeaseToTrustIfPurchasedInNameOfDclg { get; set; }

        public DateTime? SiteDclgLeaseToTrustDateOfExchangeActual { get; set; }

        public DateTime? SiteDclgLeaseToTrustDateOfCompletionActual { get; set; }

        public string SiteLandlordName { get; set; }

        public string SiteAnnualLeaseCostRent { get; set; }

        public string SiteGreenBookNpvLeaseCost { get; set; }

        public string SitePremiumIfApplicable { get; set; }

        public DateTime? SiteLeaseStartDateActual { get; set; }

        public DateTime? SiteLeaseEndDateActual { get; set; }

        public string SiteLengthOfLeaseYears { get; set; }

        public string SiteDecisionMakingFramework { get; set; }

        public string SiteVariationToTheLease { get; set; }

        public string SiteDetailsOfVariationToTheLease { get; set; }

        public DateTime? SiteVariationToTheLeaseDateOfCompletionActual { get; set; }

        public string SiteRbvRequired { get; set; }

        public string SiteRbvStatus { get; set; }

        public DateTime? SiteDateRbvRequiredActual { get; set; }

        public DateTime? SiteDateRbvSubmittedActual { get; set; }

        public string SiteRbvValue { get; set; }

        public string SiteAmountAboveRbv { get; set; }

        public string SiteDifference { get; set; }

        public string SiteHmtPaperRequired { get; set; }

        public DateTime? SiteDateOfHmtPaperActual { get; set; }

        public string SiteHmtPaperComments { get; set; }

        public string SiteOtherComments { get; set; }

        public string SiteIaS17Required { get; set; }

        public string SiteLandValueIaS17InPlaceOfRbv { get; set; }

        public string SiteBuildingValueIaS17InPlaceOfRbv { get; set; }

        public string SiteTypeOfSiteDisposal { get; set; }

        public string SiteNameOfPurchaser { get; set; }

        public string SiteDisposalStatus { get; set; }

        public DateTime? SiteSiteDisposalDateOfExchangeActual { get; set; }

        public DateTime? SiteSiteDisposalDateOfCompletionActual { get; set; }

        public string SiteNetValueOfDisposal { get; set; }

        public string SiteDisposalVat { get; set; }

        public string SiteLegalManagerComments { get; set; }

        public string SitePropertyAdviserComments { get; set; }
    }
}