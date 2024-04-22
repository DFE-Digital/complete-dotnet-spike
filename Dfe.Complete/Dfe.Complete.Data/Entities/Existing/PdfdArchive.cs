using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Dfe.ManageFreeSchoolProjects.Data
{
    public partial class MfspContext : DbContext
    {
        public virtual DbSet<Entities.Existing.PdfdArchive> PdfdArchive { get; set; }
    }
}

namespace Dfe.ManageFreeSchoolProjects.Data.Entities.Existing
{
    public partial class PdfdArchive
    {
        public string Month { get; set; }

        public string ProjectId { get; set; }

        public string FreeSchoolName { get; set; }

        public string HeadOfRegion { get; set; }

        public string ProjectDirector { get; set; }

        public string ProjectManager { get; set; }

        public string RealisticYearOfOpening { get; set; }

        public string SiteIdentifiedForMainSchoolBuildingActual { get; set; }

        public string DateHoTSecuredOnSiteForMainSchoolBuildingBaseline { get; set; }

        public string DateHoTSecuredOnSiteForMainSchoolBuildingActual { get; set; }

        public string FeasibilityStartedForMainSchoolBuildingActual { get; set; }

        public string DateOfExchangeOnSiteForMainSchoolBuildingBaseline { get; set; }

        public string DateOfExchangeOnSiteForMainSchoolBuildingActual { get; set; }

        public string DateOfHoTSecuredOnTemporaryAccommodationSiteIfRequiredForecast { get; set; }

        public string DateOfHoTSecuredOnTemporaryAccommodationSiteIfRequiredActual { get; set; }

        public string DateOfCompletionOnTemporaryAccommodationSiteIfRequiredForecast { get; set; }

        public string DateOfCompletionOnTemporaryAccommodationSiteIfRequiredActual { get; set; }

        public string CompleteOnSiteAcquisitionForMainSchoolBuildingForecast { get; set; }

        public string CompleteOnSiteAcquisitionForMainSchoolBuildingActual { get; set; }

        public string EnterIntoContractForTheInitialProvisionOfTemporaryAccommodationForecast { get; set; }

        public string EnterIntoContractForTheInitialProvisionOfTemporaryAccommodationActual { get; set; }

        public string TemporaryAccommodationFirstReadyForOccupationForecast { get; set; }

        public string TemporaryAccommodationFirstReadyForOccupationActual { get; set; }

        public string IfRequiredEnterIntoContractForAdditionalTemporaryAccommodationForecast { get; set; }

        public string IfRequiredEnterIntoContractForAdditionalTemporaryAccommodationActual { get; set; }

        public string IfRequiredAdditionalTemporaryAccommodationReadyForOccupationForecast { get; set; }

        public string IfRequiredAdditionalTemporaryAccommodationReadyForOccupationActual { get; set; }

        public string StartOfProcurementForMainSchoolBuildingForecast { get; set; }

        public string StartOfProcurementForMainSchoolBuildingActual { get; set; }

        public string ContractorAppointedForMainSchoolBuildingSpmEwaPcsaForecast { get; set; }

        public string ContractorAppointedForMainSchoolBuildingSpmEwaPcsaActual { get; set; }

        public string SubmissionOfPlanningPermissionForPermanentMainSchoolBuildingForecast { get; set; }

        public string SubmissionOfPlanningPermissionForPermanentMainSchoolBuildingActual { get; set; }

        public string DateOfPositivePlanningDecisionNoticeSecuredForMainSchoolBuildingForecast { get; set; }

        public string DateOfPositivePlanningDecisionNoticeSecuredForMainSchoolBuildingActual { get; set; }

        public string EnterIntoContractForMainSchoolBuildingForecast { get; set; }

        public string EnterIntoContractForMainSchoolBuildingActual { get; set; }

        public string EnterIntoFundingAgreementForecast { get; set; }

        public string EnterIntoFundingAgreementActual { get; set; }

        public string StartOfConstructionOfMainSchoolBuildingForecast { get; set; }

        public string StartOfConstructionOfMainSchoolBuildingActual { get; set; }

        public string MainSchoolBuildingFirstReadyToBeOpenedForOccupationForecast { get; set; }

        public string MainSchoolBuildingFirstReadyToBeOpenedForOccupationActual { get; set; }

        public string PracticalCompletionOfContractForMainSchoolBuildingForecast { get; set; }

        public string PracticalCompletionOfContractForMainSchoolBuildingActual { get; set; }

        public string ActualDateOfOpeningActual { get; set; }

        public string AllPupilsOutOfTemporaryAccommodationForecast { get; set; }

        public string AllPupilsOutOfTemporaryAccommodationActual { get; set; }

        public string EndOfProjectNoMoreCapitalSpendEndOfDefectsForecast { get; set; }

        public string EndOfProjectNoMoreCapitalSpendEndOfDefectsActual { get; set; }

        public string ProjectDirectorApproval { get; set; }

        public string RegionalHeadFreezeDate { get; set; }

        public string CapitalProjectRagRating { get; set; }
    }
}