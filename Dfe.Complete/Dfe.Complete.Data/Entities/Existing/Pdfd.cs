using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Dfe.ManageFreeSchoolProjects.Data
{
    public partial class MfspContext : DbContext
    {
        public virtual DbSet<Entities.Existing.Pdfd> Pdfd { get; set; }
    }
}

namespace Dfe.ManageFreeSchoolProjects.Data.Entities.Existing
{
    public partial class Pdfd
    {
        public string PRid { get; set; }

        public string Rid { get; set; }

        public string ProjectDirectorForecastingDashboardFdYear { get; set; }

        public string ProjectDirectorForecastingDashboardRealisticYearOfOpening { get; set; }

        public DateTime? ProjectDirectorForecastingDashboardSiteIdenfitifiedForMainSchoolBuildingActual { get; set; }

        public DateTime? ProjectDirectorForecastingDashboardHoTAgreedForSiteForMainSchoolBuildingRp1 { get; set; }

        public DateTime? ProjectDirectorForecastingDashboardHoTAgreedForSiteForMainSchoolBuildingRp2 { get; set; }

        public DateTime? ProjectDirectorForecastingDashboardHoTAgreedForSiteForMainSchoolBuildingRp3 { get; set; }

        public DateTime? ProjectDirectorForecastingDashboardHoTAgreedForSiteForMainSchoolBuildingActual { get; set; }

        public DateTime? ProjectDirectorForecastingDashboardFeasibilityStartedForMainSchoolBuildingActual { get; set; }

        public DateTime? ProjectDirectorForecastingDashboardExchangeOnSiteForMainSchoolBuildingRp1 { get; set; }

        public DateTime? ProjectDirectorForecastingDashboardExchangeOnSiteForMainSchoolBuildingRp2 { get; set; }

        public DateTime? ProjectDirectorForecastingDashboardExchangeOnSiteForMainSchoolBuildingRp3 { get; set; }

        public DateTime? ProjectDirectorForecastingDashboardExchangeOnSiteForMainSchoolBuildingActual { get; set; }

        public DateTime? ProjectDirectorForecastingDashboardDateOfHoTSecuredOnTemporaryAccommodationSiteIfRequiredRp1 { get; set; }

        public DateTime? ProjectDirectorForecastingDashboardDateOfHoTSecuredOnTemporaryAccommodationSiteIfRequiredRp2 { get; set; }

        public DateTime? ProjectDirectorForecastingDashboardDateOfHoTSecuredOnTemporaryAccommodationSiteIfRequiredRp3 { get; set; }

        public DateTime? ProjectDirectorForecastingDashboardDateOfHoTSecuredOnTemporaryAccommodationSiteIfRequiredActual { get; set; }

        public DateTime? ProjectDirectorForecastingDashboardDateOfCompletionOnTemporaryAccommodationSiteIfRequiredRp1 { get; set; }

        public DateTime? ProjectDirectorForecastingDashboardDateOfCompletionOnTemporaryAccommodationSiteIfRequiredRp2 { get; set; }

        public DateTime? ProjectDirectorForecastingDashboardDateOfCompletionOnTemporaryAccommodationSiteIfRequiredRp3 { get; set; }

        public DateTime? ProjectDirectorForecastingDashboardDateOfCompletionOnTemporaryAccommodationSiteIfRequiredActual { get; set; }

        public DateTime? ProjectDirectorForecastingDashboardCompleteOnSiteForMainSchoolBuildingRp1 { get; set; }

        public DateTime? ProjectDirectorForecastingDashboardCompleteOnSiteForMainSchoolBuildingRp2 { get; set; }

        public DateTime? ProjectDirectorForecastingDashboardCompleteOnSiteForMainSchoolBuildingRp3 { get; set; }

        public DateTime? ProjectDirectorForecastingDashboardCompleteOnSiteForMainSchoolBuildingActual { get; set; }

        public DateTime? ProjectDirectorForecastingDashboardEnterIntoContractForTheInitialProvisionOfTemporaryAccommodationRp1 { get; set; }

        public DateTime? ProjectDirectorForecastingDashboardEnterIntoContractForTheInitialProvisionOfTemporaryAccommodationRp2 { get; set; }

        public DateTime? ProjectDirectorForecastingDashboardEnterIntoContractForTheInitialProvisionOfTemporaryAccommodationRp3 { get; set; }

        public DateTime? ProjectDirectorForecastingDashboardEnterIntoContractForTheInitialProvisionOfTemporaryAccommodationActual { get; set; }

        public DateTime? ProjectDirectorForecastingDashboardTemporaryAccommodationFirstReadyForOccupationRp1 { get; set; }

        public DateTime? ProjectDirectorForecastingDashboardTemporaryAccommodationFirstReadyForOccupationRp2 { get; set; }

        public DateTime? ProjectDirectorForecastingDashboardTemporaryAccommodationFirstReadyForOccupationRp3 { get; set; }

        public DateTime? ProjectDirectorForecastingDashboardTemporaryAccommodationFirstReadyForOccupationActual { get; set; }

        public DateTime? ProjectDirectorForecastingDashboardIfRequiredEnterIntoContractForAdditionalTemporaryAccommodationRp1 { get; set; }

        public DateTime? ProjectDirectorForecastingDashboardIfRequiredEnterIntoContractForAdditionalTemporaryAccommodationRp2 { get; set; }

        public DateTime? ProjectDirectorForecastingDashboardIfRequiredEnterIntoContractForAdditionalTemporaryAccommodationRp3 { get; set; }

        public DateTime? ProjectDirectorForecastingDashboardIfRequiredEnterIntoContractForAdditionalTemporaryAccommodationActual { get; set; }

        public DateTime? ProjectDirectorForecastingDashboardIfRequiredAdditionalTemporaryAccommodationReadyForOccupationRp1 { get; set; }

        public DateTime? ProjectDirectorForecastingDashboardIfRequiredAdditionalTemporaryAccommodationReadyForOccupationRp2 { get; set; }

        public DateTime? ProjectDirectorForecastingDashboardIfRequiredAdditionalTemporaryAccommodationReadyForOccupationRp3 { get; set; }

        public DateTime? ProjectDirectorForecastingDashboardIfRequiredAdditionalTemporaryAccommodationReadyForOccupationActual { get; set; }

        public DateTime? ProjectDirectorForecastingDashboardStartOfProcurementForMainSchoolBuildingRp1 { get; set; }

        public DateTime? ProjectDirectorForecastingDashboardStartOfProcurementForMainSchoolBuildingRp2 { get; set; }

        public DateTime? ProjectDirectorForecastingDashboardStartOfProcurementForMainSchoolBuildingRp3 { get; set; }

        public DateTime? ProjectDirectorForecastingDashboardStartOfProcurementForMainSchoolBuildingActual { get; set; }

        public DateTime? ProjectDirectorForecastingDashboardSubmissionOfPlanningPermissionForPermanentMainSchoolBuildingRp1 { get; set; }

        public DateTime? ProjectDirectorForecastingDashboardSubmissionOfPlanningPermissionForPermanentMainSchoolBuildingRp2 { get; set; }

        public DateTime? ProjectDirectorForecastingDashboardSubmissionOfPlanningPermissionForPermanentMainSchoolBuildingRp3 { get; set; }

        public DateTime? ProjectDirectorForecastingDashboardSubmissionOfPlanningPermissionForPermanentMainSchoolBuildingActual { get; set; }

        public DateTime? ProjectDirectorForecastingDashboardDateOfPositivePlanningDecisionNoticeSecuredForMainSchoolBuildingRp1 { get; set; }

        public DateTime? ProjectDirectorForecastingDashboardDateOfPositivePlanningDecisionNoticeSecuredForMainSchoolBuildingRp2 { get; set; }

        public DateTime? ProjectDirectorForecastingDashboardDateOfPositivePlanningDecisionNoticeSecuredForMainSchoolBuildingRp3 { get; set; }

        public DateTime? ProjectDirectorForecastingDashboardDateOfPositivePlanningDecisionNoticeSecuredForMainSchoolBuildingActual { get; set; }

        public DateTime? ProjectDirectorForecastingDashboardContractorAppointedForMainSchoolBuildingSpmEwaPcsaRp1 { get; set; }

        public DateTime? ProjectDirectorForecastingDashboardContractorAppointedForMainSchoolBuildingSpmEwaPcsaRp2 { get; set; }

        public DateTime? ProjectDirectorForecastingDashboardContractorAppointedForMainSchoolBuildingSpmEwaPcsaRp3 { get; set; }

        public DateTime? ProjectDirectorForecastingDashboardContractorAppointedForMainSchoolBuildingSpmEwaPcsaActual { get; set; }

        public DateTime? ProjectDirectorForecastingDashboardStartOfConstructionOfMainSchoolBuildingRp1 { get; set; }

        public DateTime? ProjectDirectorForecastingDashboardStartOfConstructionOfMainSchoolBuildingRp2 { get; set; }

        public DateTime? ProjectDirectorForecastingDashboardStartOfConstructionOfMainSchoolBuildingRp3 { get; set; }

        public DateTime? ProjectDirectorForecastingDashboardStartOfConstructionOfMainSchoolBuildingActual { get; set; }

        public DateTime? ProjectDirectorForecastingDashboardEnterIntoContractForMainSchoolBuildingRp1 { get; set; }

        public DateTime? ProjectDirectorForecastingDashboardEnterIntoContractForMainSchoolBuildingRp2 { get; set; }

        public DateTime? ProjectDirectorForecastingDashboardEnterIntoContractForMainSchoolBuildingRp3 { get; set; }

        public DateTime? ProjectDirectorForecastingDashboardEnterIntoContractForMainSchoolBuildingActual { get; set; }

        public DateTime? ProjectDirectorForecastingDashboardEnterIntoFundingAgreementRp1 { get; set; }

        public DateTime? ProjectDirectorForecastingDashboardEnterIntoFundingAgreementRp2 { get; set; }

        public DateTime? ProjectDirectorForecastingDashboardEnterIntoFundingAgreementRp3 { get; set; }

        public DateTime? ProjectDirectorForecastingDashboardEnterIntoFundingAgreementActual { get; set; }

        public DateTime? ProjectDirectorForecastingDashboardMainSchoolBuildingFirstReadyForOccupationRp1 { get; set; }

        public DateTime? ProjectDirectorForecastingDashboardMainSchoolBuildingFirstReadyForOccupationRp2 { get; set; }

        public DateTime? ProjectDirectorForecastingDashboardMainSchoolBuildingFirstReadyForOccupationRp3 { get; set; }

        public DateTime? ProjectDirectorForecastingDashboardMainSchoolBuildingFirstReadyForOccupationActual { get; set; }

        public DateTime? ProjectDirectorForecastingDashboardPracticalCompletionOfContractForMainSchoolBuildingRp1 { get; set; }

        public DateTime? ProjectDirectorForecastingDashboardPracticalCompletionOfContractForMainSchoolBuildingRp2 { get; set; }

        public DateTime? ProjectDirectorForecastingDashboardPracticalCompletionOfContractForMainSchoolBuildingRp3 { get; set; }

        public DateTime? ProjectDirectorForecastingDashboardPracticalCompletionOfContractForMainSchoolBuildingActual { get; set; }

        public DateTime? ProjectDirectorForecastingDashboardActualDateOfOpeningActual { get; set; }

        public DateTime? ProjectDirectorForecastingDashboardAllPupilsOutOfTemporaryAccommodationRp1 { get; set; }

        public DateTime? ProjectDirectorForecastingDashboardAllPupilsOutOfTemporaryAccommodationRp2 { get; set; }

        public DateTime? ProjectDirectorForecastingDashboardAllPupilsOutOfTemporaryAccommodationRp3 { get; set; }

        public DateTime? ProjectDirectorForecastingDashboardAllPupilsOutOfTemporaryAccommodationActual { get; set; }

        public DateTime? ProjectDirectorForecastingDashboardEndOfProjectNoMoreCapitalSpendEndOfDefectsRp1 { get; set; }

        public DateTime? ProjectDirectorForecastingDashboardEndOfProjectNoMoreCapitalSpendEndOfDefectsRp2 { get; set; }

        public DateTime? ProjectDirectorForecastingDashboardEndOfProjectNoMoreCapitalSpendEndOfDefectsRp3 { get; set; }

        public DateTime? ProjectDirectorForecastingDashboardEndOfProjectNoMoreCapitalSpendEndOfDefectsActual { get; set; }

        public DateTime? ProjectDirectorForecastingDashboardFsgLeadContactRp1LastUpdated { get; set; }

        public DateTime? ProjectDirectorForecastingDashboardFsgLeadContactRp2LastUpdated { get; set; }

        public DateTime? ProjectDirectorForecastingDashboardFsgLeadContactRp3LastUpdated { get; set; }

        public DateTime? ProjectDirectorForecastingDashboardFsgLeadContactActualLastUpdated { get; set; }

        public DateTime? ProjectDirectorForecastingDashboardEsfaProjectDirectorRp1DateApproved { get; set; }

        public DateTime? ProjectDirectorForecastingDashboardEsfaProjectDirectorRp2DateApproved { get; set; }

        public DateTime? ProjectDirectorForecastingDashboardEsfaProjectDirectorRp3DateApproved { get; set; }

        public DateTime? ProjectDirectorForecastingDashboardRhFreezeDataForReportingPeriodRp1DateApproved { get; set; }

        public DateTime? ProjectDirectorForecastingDashboardRhFreezeDataForReportingPeriodRp2DateApproved { get; set; }

        public DateTime? ProjectDirectorForecastingDashboardRhFreezeDataForReportingPeriodRp3DateApproved { get; set; }

        public string ProjectDirectorForecastingDashboardCapitalProjectRagRating { get; set; }

        public string ProjectDirectorForecastingDashboardCapitalProjectRagRatingCommentary { get; set; }

        public string ProjectDirectorForecastingDashboardProperty { get; set; }

        public string ProjectDirectorForecastingDashboardPropertyCommentary { get; set; }

        public string ProjectDirectorForecastingDashboardPlanning { get; set; }

        public string ProjectDirectorForecastingDashboardPlanningCommentary { get; set; }

        public string ProjectDirectorForecastingDashboardConstruction { get; set; }

        public string ProjectDirectorForecastingDashboardConstructionCommentary { get; set; }

        public string ProjectDirectorForecastingDashboardTemporary { get; set; }

        public string ProjectDirectorForecastingDashboardTemporaryCommentary { get; set; }

        public DateTime? ProjectDirectorForecastingDashboardLastUpdatedByPd { get; set; }
    }
}