using System;
using System.Collections.Generic;
using Dfe.ManageFreeSchoolProjects.Data.Entities.Existing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dfe.ManageFreeSchoolProjects.Data.Configuration.Existing
{
	public partial class PdfdConfiguration : IEntityTypeConfiguration< Pdfd>
	{
		public void Configure(EntityTypeBuilder<Pdfd> builder)
		{
            builder.ToTable("PDFD", "dbo", e => e.IsTemporal());

            builder.HasKey(e => e.Rid);

            builder.Property(e => e.PRid)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasColumnName("p_rid");
            builder.Property(e => e.ProjectDirectorForecastingDashboardActualDateOfOpeningActual)
                .HasColumnType("date")
                .HasColumnName("Project Director Forecasting Dashboard.Actual date of opening (Actual)");
            builder.Property(e => e.ProjectDirectorForecastingDashboardAllPupilsOutOfTemporaryAccommodationActual)
                .HasColumnType("date")
                .HasColumnName("Project Director Forecasting Dashboard.All pupils out of temporary accommodation (Actual)");
            builder.Property(e => e.ProjectDirectorForecastingDashboardAllPupilsOutOfTemporaryAccommodationRp1)
                .HasColumnType("date")
                .HasColumnName("Project Director Forecasting Dashboard.All pupils out of temporary accommodation (RP1)");
            builder.Property(e => e.ProjectDirectorForecastingDashboardAllPupilsOutOfTemporaryAccommodationRp2)
                .HasColumnType("date")
                .HasColumnName("Project Director Forecasting Dashboard.All pupils out of temporary accommodation (RP2)");
            builder.Property(e => e.ProjectDirectorForecastingDashboardAllPupilsOutOfTemporaryAccommodationRp3)
                .HasColumnType("date")
                .HasColumnName("Project Director Forecasting Dashboard.All pupils out of temporary accommodation (RP3)");
            builder.Property(e => e.ProjectDirectorForecastingDashboardCapitalProjectRagRating)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Project Director Forecasting Dashboard.Capital Project RAG Rating");
            builder.Property(e => e.ProjectDirectorForecastingDashboardCapitalProjectRagRatingCommentary)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("Project Director Forecasting Dashboard.Capital Project RAG Rating commentary");
            builder.Property(e => e.ProjectDirectorForecastingDashboardCompleteOnSiteForMainSchoolBuildingActual)
                .HasColumnType("date")
                .HasColumnName("Project Director Forecasting Dashboard.Complete on site for Main School Building (Actual)");
            builder.Property(e => e.ProjectDirectorForecastingDashboardCompleteOnSiteForMainSchoolBuildingRp1)
                .HasColumnType("date")
                .HasColumnName("Project Director Forecasting Dashboard.Complete on site for Main School Building (RP1)");
            builder.Property(e => e.ProjectDirectorForecastingDashboardCompleteOnSiteForMainSchoolBuildingRp2)
                .HasColumnType("date")
                .HasColumnName("Project Director Forecasting Dashboard.Complete on site for Main School Building (RP2)");
            builder.Property(e => e.ProjectDirectorForecastingDashboardCompleteOnSiteForMainSchoolBuildingRp3)
                .HasColumnType("date")
                .HasColumnName("Project Director Forecasting Dashboard.Complete on site for Main School Building (RP3)");
            builder.Property(e => e.ProjectDirectorForecastingDashboardConstruction)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Project Director Forecasting Dashboard.Construction");
            builder.Property(e => e.ProjectDirectorForecastingDashboardConstructionCommentary)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("Project Director Forecasting Dashboard.Construction commentary");
            builder.Property(e => e.ProjectDirectorForecastingDashboardContractorAppointedForMainSchoolBuildingSpmEwaPcsaActual)
                .HasColumnType("date")
                .HasColumnName("Project Director Forecasting Dashboard.Contractor appointed for main school building (SPM, EWA, PCSA) (Actual)");
            builder.Property(e => e.ProjectDirectorForecastingDashboardContractorAppointedForMainSchoolBuildingSpmEwaPcsaRp1)
                .HasColumnType("date")
                .HasColumnName("Project Director Forecasting Dashboard.Contractor appointed for main school building (SPM, EWA, PCSA) (RP1)");
            builder.Property(e => e.ProjectDirectorForecastingDashboardContractorAppointedForMainSchoolBuildingSpmEwaPcsaRp2)
                .HasColumnType("date")
                .HasColumnName("Project Director Forecasting Dashboard.Contractor appointed for main school building (SPM, EWA, PCSA) (RP2)");
            builder.Property(e => e.ProjectDirectorForecastingDashboardContractorAppointedForMainSchoolBuildingSpmEwaPcsaRp3)
                .HasColumnType("date")
                .HasColumnName("Project Director Forecasting Dashboard.Contractor appointed for main school building (SPM, EWA, PCSA) (RP3)");
            builder.Property(e => e.ProjectDirectorForecastingDashboardDateOfCompletionOnTemporaryAccommodationSiteIfRequiredActual)
                .HasColumnType("date")
                .HasColumnName("Project Director Forecasting Dashboard.Date of completion on temporary accommodation site, if required (Actual)");
            builder.Property(e => e.ProjectDirectorForecastingDashboardDateOfCompletionOnTemporaryAccommodationSiteIfRequiredRp1)
                .HasColumnType("date")
                .HasColumnName("Project Director Forecasting Dashboard.Date of completion on temporary accommodation site, if required (RP1)");
            builder.Property(e => e.ProjectDirectorForecastingDashboardDateOfCompletionOnTemporaryAccommodationSiteIfRequiredRp2)
                .HasColumnType("date")
                .HasColumnName("Project Director Forecasting Dashboard.Date of completion on temporary accommodation site, if required (RP2)");
            builder.Property(e => e.ProjectDirectorForecastingDashboardDateOfCompletionOnTemporaryAccommodationSiteIfRequiredRp3)
                .HasColumnType("date")
                .HasColumnName("Project Director Forecasting Dashboard.Date of completion on temporary accommodation site, if required (RP3)");
            builder.Property(e => e.ProjectDirectorForecastingDashboardDateOfHoTSecuredOnTemporaryAccommodationSiteIfRequiredActual)
                .HasColumnType("date")
                .HasColumnName("Project Director Forecasting Dashboard.Date of HoT secured on temporary accommodation site, if required (Actual)");
            builder.Property(e => e.ProjectDirectorForecastingDashboardDateOfHoTSecuredOnTemporaryAccommodationSiteIfRequiredRp1)
                .HasColumnType("date")
                .HasColumnName("Project Director Forecasting Dashboard.Date of HoT secured on temporary accommodation site, if required (RP1)");
            builder.Property(e => e.ProjectDirectorForecastingDashboardDateOfHoTSecuredOnTemporaryAccommodationSiteIfRequiredRp2)
                .HasColumnType("date")
                .HasColumnName("Project Director Forecasting Dashboard.Date of HoT secured on temporary accommodation site, if required (RP2)");
            builder.Property(e => e.ProjectDirectorForecastingDashboardDateOfHoTSecuredOnTemporaryAccommodationSiteIfRequiredRp3)
                .HasColumnType("date")
                .HasColumnName("Project Director Forecasting Dashboard.Date of HoT secured on temporary accommodation site, if required (RP3)");
            builder.Property(e => e.ProjectDirectorForecastingDashboardDateOfPositivePlanningDecisionNoticeSecuredForMainSchoolBuildingActual)
                .HasColumnType("date")
                .HasColumnName("Project Director Forecasting Dashboard.Date of positive planning decision notice secured for main school building (Actual)");
            builder.Property(e => e.ProjectDirectorForecastingDashboardDateOfPositivePlanningDecisionNoticeSecuredForMainSchoolBuildingRp1)
                .HasColumnType("date")
                .HasColumnName("Project Director Forecasting Dashboard.Date of positive planning decision notice secured for main school building (RP1)");
            builder.Property(e => e.ProjectDirectorForecastingDashboardDateOfPositivePlanningDecisionNoticeSecuredForMainSchoolBuildingRp2)
                .HasColumnType("date")
                .HasColumnName("Project Director Forecasting Dashboard.Date of positive planning decision notice secured for main school building (RP2)");
            builder.Property(e => e.ProjectDirectorForecastingDashboardDateOfPositivePlanningDecisionNoticeSecuredForMainSchoolBuildingRp3)
                .HasColumnType("date")
                .HasColumnName("Project Director Forecasting Dashboard.Date of positive planning decision notice secured for main school building (RP3)");
            builder.Property(e => e.ProjectDirectorForecastingDashboardEndOfProjectNoMoreCapitalSpendEndOfDefectsActual)
                .HasColumnType("date")
                .HasColumnName("Project Director Forecasting Dashboard.End of Project (No more capital spend/end of defects) (Actual)");
            builder.Property(e => e.ProjectDirectorForecastingDashboardEndOfProjectNoMoreCapitalSpendEndOfDefectsRp1)
                .HasColumnType("date")
                .HasColumnName("Project Director Forecasting Dashboard.End of Project (No more capital spend/end of defects) (RP1)");
            builder.Property(e => e.ProjectDirectorForecastingDashboardEndOfProjectNoMoreCapitalSpendEndOfDefectsRp2)
                .HasColumnType("date")
                .HasColumnName("Project Director Forecasting Dashboard.End of Project (No more capital spend/end of defects) (RP2)");
            builder.Property(e => e.ProjectDirectorForecastingDashboardEndOfProjectNoMoreCapitalSpendEndOfDefectsRp3)
                .HasColumnType("date")
                .HasColumnName("Project Director Forecasting Dashboard.End of Project (No more capital spend/end of defects) (RP3)");
            builder.Property(e => e.ProjectDirectorForecastingDashboardEnterIntoContractForMainSchoolBuildingActual)
                .HasColumnType("date")
                .HasColumnName("Project Director Forecasting Dashboard.Enter into Contract for Main School Building (Actual)");
            builder.Property(e => e.ProjectDirectorForecastingDashboardEnterIntoContractForMainSchoolBuildingRp1)
                .HasColumnType("date")
                .HasColumnName("Project Director Forecasting Dashboard.Enter into Contract for Main School Building (RP1)");
            builder.Property(e => e.ProjectDirectorForecastingDashboardEnterIntoContractForMainSchoolBuildingRp2)
                .HasColumnType("date")
                .HasColumnName("Project Director Forecasting Dashboard.Enter into Contract for Main School Building (RP2)");
            builder.Property(e => e.ProjectDirectorForecastingDashboardEnterIntoContractForMainSchoolBuildingRp3)
                .HasColumnType("date")
                .HasColumnName("Project Director Forecasting Dashboard.Enter into Contract for Main School Building (RP3)");
            builder.Property(e => e.ProjectDirectorForecastingDashboardEnterIntoContractForTheInitialProvisionOfTemporaryAccommodationActual)
                .HasColumnType("date")
                .HasColumnName("Project Director Forecasting Dashboard.Enter into contract for the initial provision of temporary accommodation (Actual)");
            builder.Property(e => e.ProjectDirectorForecastingDashboardEnterIntoContractForTheInitialProvisionOfTemporaryAccommodationRp1)
                .HasColumnType("date")
                .HasColumnName("Project Director Forecasting Dashboard.Enter into contract for the initial provision of temporary accommodation (RP1)");
            builder.Property(e => e.ProjectDirectorForecastingDashboardEnterIntoContractForTheInitialProvisionOfTemporaryAccommodationRp2)
                .HasColumnType("date")
                .HasColumnName("Project Director Forecasting Dashboard.Enter into contract for the initial provision of temporary accommodation (RP2)");
            builder.Property(e => e.ProjectDirectorForecastingDashboardEnterIntoContractForTheInitialProvisionOfTemporaryAccommodationRp3)
                .HasColumnType("date")
                .HasColumnName("Project Director Forecasting Dashboard.Enter into contract for the initial provision of temporary accommodation (RP3)");
            builder.Property(e => e.ProjectDirectorForecastingDashboardEnterIntoFundingAgreementActual)
                .HasColumnType("date")
                .HasColumnName("Project Director Forecasting Dashboard.Enter into Funding Agreement (Actual)");
            builder.Property(e => e.ProjectDirectorForecastingDashboardEnterIntoFundingAgreementRp1)
                .HasColumnType("date")
                .HasColumnName("Project Director Forecasting Dashboard.Enter into Funding Agreement (RP1)");
            builder.Property(e => e.ProjectDirectorForecastingDashboardEnterIntoFundingAgreementRp2)
                .HasColumnType("date")
                .HasColumnName("Project Director Forecasting Dashboard.Enter into Funding Agreement (RP2)");
            builder.Property(e => e.ProjectDirectorForecastingDashboardEnterIntoFundingAgreementRp3)
                .HasColumnType("date")
                .HasColumnName("Project Director Forecasting Dashboard.Enter into Funding Agreement (RP3)");
            builder.Property(e => e.ProjectDirectorForecastingDashboardEsfaProjectDirectorRp1DateApproved)
                .HasColumnType("date")
                .HasColumnName("Project Director Forecasting Dashboard.ESFA Project Director (RP1) (Date Approved)");
            builder.Property(e => e.ProjectDirectorForecastingDashboardEsfaProjectDirectorRp2DateApproved)
                .HasColumnType("date")
                .HasColumnName("Project Director Forecasting Dashboard.ESFA Project Director (RP2) (Date Approved)");
            builder.Property(e => e.ProjectDirectorForecastingDashboardEsfaProjectDirectorRp3DateApproved)
                .HasColumnType("date")
                .HasColumnName("Project Director Forecasting Dashboard.ESFA Project Director (RP3) (Date Approved)");
            builder.Property(e => e.ProjectDirectorForecastingDashboardExchangeOnSiteForMainSchoolBuildingActual)
                .HasColumnType("date")
                .HasColumnName("Project Director Forecasting Dashboard.Exchange on site for Main School Building (Actual)");
            builder.Property(e => e.ProjectDirectorForecastingDashboardExchangeOnSiteForMainSchoolBuildingRp1)
                .HasColumnType("date")
                .HasColumnName("Project Director Forecasting Dashboard.Exchange on site for Main School Building (RP1)");
            builder.Property(e => e.ProjectDirectorForecastingDashboardExchangeOnSiteForMainSchoolBuildingRp2)
                .HasColumnType("date")
                .HasColumnName("Project Director Forecasting Dashboard.Exchange on site for Main School Building (RP2)");
            builder.Property(e => e.ProjectDirectorForecastingDashboardExchangeOnSiteForMainSchoolBuildingRp3)
                .HasColumnType("date")
                .HasColumnName("Project Director Forecasting Dashboard.Exchange on site for Main School Building (RP3)");
            builder.Property(e => e.ProjectDirectorForecastingDashboardFdYear)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Project Director Forecasting Dashboard.FD_Year");
            builder.Property(e => e.ProjectDirectorForecastingDashboardFeasibilityStartedForMainSchoolBuildingActual)
                .HasColumnType("date")
                .HasColumnName("Project Director Forecasting Dashboard.Feasibility Started for Main School Building (Actual)");
            builder.Property(e => e.ProjectDirectorForecastingDashboardFsgLeadContactActualLastUpdated)
                .HasColumnType("date")
                .HasColumnName("Project Director Forecasting Dashboard.FSG Lead Contact (Actual) (Last Updated)");
            builder.Property(e => e.ProjectDirectorForecastingDashboardFsgLeadContactRp1LastUpdated)
                .HasColumnType("date")
                .HasColumnName("Project Director Forecasting Dashboard.FSG Lead Contact (RP1) (Last Updated)");
            builder.Property(e => e.ProjectDirectorForecastingDashboardFsgLeadContactRp2LastUpdated)
                .HasColumnType("date")
                .HasColumnName("Project Director Forecasting Dashboard.FSG Lead Contact (RP2) (Last Updated)");
            builder.Property(e => e.ProjectDirectorForecastingDashboardFsgLeadContactRp3LastUpdated)
                .HasColumnType("date")
                .HasColumnName("Project Director Forecasting Dashboard.FSG Lead Contact (RP3) (Last Updated)");
            builder.Property(e => e.ProjectDirectorForecastingDashboardHoTAgreedForSiteForMainSchoolBuildingActual)
                .HasColumnType("date")
                .HasColumnName("Project Director Forecasting Dashboard.HoT Agreed for site for Main School Building (Actual)");
            builder.Property(e => e.ProjectDirectorForecastingDashboardHoTAgreedForSiteForMainSchoolBuildingRp1)
                .HasColumnType("date")
                .HasColumnName("Project Director Forecasting Dashboard.HoT Agreed for site for Main School Building (RP1)");
            builder.Property(e => e.ProjectDirectorForecastingDashboardHoTAgreedForSiteForMainSchoolBuildingRp2)
                .HasColumnType("date")
                .HasColumnName("Project Director Forecasting Dashboard.HoT Agreed for site for Main School Building (RP2)");
            builder.Property(e => e.ProjectDirectorForecastingDashboardHoTAgreedForSiteForMainSchoolBuildingRp3)
                .HasColumnType("date")
                .HasColumnName("Project Director Forecasting Dashboard.HoT Agreed for site for Main School Building (RP3)");
            builder.Property(e => e.ProjectDirectorForecastingDashboardIfRequiredAdditionalTemporaryAccommodationReadyForOccupationActual)
                .HasColumnType("date")
                .HasColumnName("Project Director Forecasting Dashboard.If required, additional temporary accommodation ready for occupation (Actual)");
            builder.Property(e => e.ProjectDirectorForecastingDashboardIfRequiredAdditionalTemporaryAccommodationReadyForOccupationRp1)
                .HasColumnType("date")
                .HasColumnName("Project Director Forecasting Dashboard.If required, additional temporary accommodation ready for occupation (RP1)");
            builder.Property(e => e.ProjectDirectorForecastingDashboardIfRequiredAdditionalTemporaryAccommodationReadyForOccupationRp2)
                .HasColumnType("date")
                .HasColumnName("Project Director Forecasting Dashboard.If required, additional temporary accommodation ready for occupation (RP2)");
            builder.Property(e => e.ProjectDirectorForecastingDashboardIfRequiredAdditionalTemporaryAccommodationReadyForOccupationRp3)
                .HasColumnType("date")
                .HasColumnName("Project Director Forecasting Dashboard.If required, additional temporary accommodation ready for occupation (RP3)");
            builder.Property(e => e.ProjectDirectorForecastingDashboardIfRequiredEnterIntoContractForAdditionalTemporaryAccommodationActual)
                .HasColumnType("date")
                .HasColumnName("Project Director Forecasting Dashboard.If required, enter into contract for additional temporary accommodation (Actual)");
            builder.Property(e => e.ProjectDirectorForecastingDashboardIfRequiredEnterIntoContractForAdditionalTemporaryAccommodationRp1)
                .HasColumnType("date")
                .HasColumnName("Project Director Forecasting Dashboard.If required, enter into contract for additional temporary accommodation (RP1)");
            builder.Property(e => e.ProjectDirectorForecastingDashboardIfRequiredEnterIntoContractForAdditionalTemporaryAccommodationRp2)
                .HasColumnType("date")
                .HasColumnName("Project Director Forecasting Dashboard.If required, enter into contract for additional temporary accommodation (RP2)");
            builder.Property(e => e.ProjectDirectorForecastingDashboardIfRequiredEnterIntoContractForAdditionalTemporaryAccommodationRp3)
                .HasColumnType("date")
                .HasColumnName("Project Director Forecasting Dashboard.If required, enter into contract for additional temporary accommodation (RP3)");
            builder.Property(e => e.ProjectDirectorForecastingDashboardLastUpdatedByPd)
                .HasColumnType("date")
                .HasColumnName("Project Director Forecasting Dashboard.Last Updated by PD");
            builder.Property(e => e.ProjectDirectorForecastingDashboardMainSchoolBuildingFirstReadyForOccupationActual)
                .HasColumnType("date")
                .HasColumnName("Project Director Forecasting Dashboard.Main School Building first ready for occupation (Actual)");
            builder.Property(e => e.ProjectDirectorForecastingDashboardMainSchoolBuildingFirstReadyForOccupationRp1)
                .HasColumnType("date")
                .HasColumnName("Project Director Forecasting Dashboard.Main School Building first ready for occupation (RP1)");
            builder.Property(e => e.ProjectDirectorForecastingDashboardMainSchoolBuildingFirstReadyForOccupationRp2)
                .HasColumnType("date")
                .HasColumnName("Project Director Forecasting Dashboard.Main School Building first ready for occupation (RP2)");
            builder.Property(e => e.ProjectDirectorForecastingDashboardMainSchoolBuildingFirstReadyForOccupationRp3)
                .HasColumnType("date")
                .HasColumnName("Project Director Forecasting Dashboard.Main School Building first ready for occupation (RP3)");
            builder.Property(e => e.ProjectDirectorForecastingDashboardPlanning)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Project Director Forecasting Dashboard.Planning");
            builder.Property(e => e.ProjectDirectorForecastingDashboardPlanningCommentary)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("Project Director Forecasting Dashboard.Planning commentary");
            builder.Property(e => e.ProjectDirectorForecastingDashboardPracticalCompletionOfContractForMainSchoolBuildingActual)
                .HasColumnType("date")
                .HasColumnName("Project Director Forecasting Dashboard.Practical completion of contract for Main School Building (Actual)");
            builder.Property(e => e.ProjectDirectorForecastingDashboardPracticalCompletionOfContractForMainSchoolBuildingRp1)
                .HasColumnType("date")
                .HasColumnName("Project Director Forecasting Dashboard.Practical completion of contract for Main School Building (RP1)");
            builder.Property(e => e.ProjectDirectorForecastingDashboardPracticalCompletionOfContractForMainSchoolBuildingRp2)
                .HasColumnType("date")
                .HasColumnName("Project Director Forecasting Dashboard.Practical completion of contract for Main School Building (RP2)");
            builder.Property(e => e.ProjectDirectorForecastingDashboardPracticalCompletionOfContractForMainSchoolBuildingRp3)
                .HasColumnType("date")
                .HasColumnName("Project Director Forecasting Dashboard.Practical completion of contract for Main School Building (RP3)");
            builder.Property(e => e.ProjectDirectorForecastingDashboardProperty)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Project Director Forecasting Dashboard.Property");
            builder.Property(e => e.ProjectDirectorForecastingDashboardPropertyCommentary)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("Project Director Forecasting Dashboard.Property commentary");
            builder.Property(e => e.ProjectDirectorForecastingDashboardRealisticYearOfOpening)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Project Director Forecasting Dashboard.Realistic Year of Opening");
            builder.Property(e => e.ProjectDirectorForecastingDashboardRhFreezeDataForReportingPeriodRp1DateApproved)
                .HasColumnType("date")
                .HasColumnName("Project Director Forecasting Dashboard.RH - Freeze data for Reporting Period (RP1) (Date Approved)");
            builder.Property(e => e.ProjectDirectorForecastingDashboardRhFreezeDataForReportingPeriodRp2DateApproved)
                .HasColumnType("date")
                .HasColumnName("Project Director Forecasting Dashboard.RH - Freeze data for Reporting Period (RP2) (Date Approved)");
            builder.Property(e => e.ProjectDirectorForecastingDashboardRhFreezeDataForReportingPeriodRp3DateApproved)
                .HasColumnType("date")
                .HasColumnName("Project Director Forecasting Dashboard.RH - Freeze data for Reporting Period (RP3) (Date Approved)");
            builder.Property(e => e.ProjectDirectorForecastingDashboardSiteIdenfitifiedForMainSchoolBuildingActual)
                .HasColumnType("date")
                .HasColumnName("Project Director Forecasting Dashboard.Site idenfitified for main school building (Actual)");
            builder.Property(e => e.ProjectDirectorForecastingDashboardStartOfConstructionOfMainSchoolBuildingActual)
                .HasColumnType("date")
                .HasColumnName("Project Director Forecasting Dashboard.Start of construction of main school building (Actual)");
            builder.Property(e => e.ProjectDirectorForecastingDashboardStartOfConstructionOfMainSchoolBuildingRp1)
                .HasColumnType("date")
                .HasColumnName("Project Director Forecasting Dashboard.Start of construction of main school building (RP1)");
            builder.Property(e => e.ProjectDirectorForecastingDashboardStartOfConstructionOfMainSchoolBuildingRp2)
                .HasColumnType("date")
                .HasColumnName("Project Director Forecasting Dashboard.Start of construction of main school building (RP2)");
            builder.Property(e => e.ProjectDirectorForecastingDashboardStartOfConstructionOfMainSchoolBuildingRp3)
                .HasColumnType("date")
                .HasColumnName("Project Director Forecasting Dashboard.Start of construction of main school building (RP3)");
            builder.Property(e => e.ProjectDirectorForecastingDashboardStartOfProcurementForMainSchoolBuildingActual)
                .HasColumnType("date")
                .HasColumnName("Project Director Forecasting Dashboard.Start of procurement for Main School Building (Actual)");
            builder.Property(e => e.ProjectDirectorForecastingDashboardStartOfProcurementForMainSchoolBuildingRp1)
                .HasColumnType("date")
                .HasColumnName("Project Director Forecasting Dashboard.Start of procurement for Main School Building (RP1)");
            builder.Property(e => e.ProjectDirectorForecastingDashboardStartOfProcurementForMainSchoolBuildingRp2)
                .HasColumnType("date")
                .HasColumnName("Project Director Forecasting Dashboard.Start of procurement for Main School Building (RP2)");
            builder.Property(e => e.ProjectDirectorForecastingDashboardStartOfProcurementForMainSchoolBuildingRp3)
                .HasColumnType("date")
                .HasColumnName("Project Director Forecasting Dashboard.Start of procurement for Main School Building (RP3)");
            builder.Property(e => e.ProjectDirectorForecastingDashboardSubmissionOfPlanningPermissionForPermanentMainSchoolBuildingActual)
                .HasColumnType("date")
                .HasColumnName("Project Director Forecasting Dashboard.Submission of planning permission for permanent main school building (Actual)");
            builder.Property(e => e.ProjectDirectorForecastingDashboardSubmissionOfPlanningPermissionForPermanentMainSchoolBuildingRp1)
                .HasColumnType("date")
                .HasColumnName("Project Director Forecasting Dashboard.Submission of planning permission for permanent main school building (RP1)");
            builder.Property(e => e.ProjectDirectorForecastingDashboardSubmissionOfPlanningPermissionForPermanentMainSchoolBuildingRp2)
                .HasColumnType("date")
                .HasColumnName("Project Director Forecasting Dashboard.Submission of planning permission for permanent main school building (RP2)");
            builder.Property(e => e.ProjectDirectorForecastingDashboardSubmissionOfPlanningPermissionForPermanentMainSchoolBuildingRp3)
                .HasColumnType("date")
                .HasColumnName("Project Director Forecasting Dashboard.Submission of planning permission for permanent main school building (RP3)");
            builder.Property(e => e.ProjectDirectorForecastingDashboardTemporary)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Project Director Forecasting Dashboard.Temporary");
            builder.Property(e => e.ProjectDirectorForecastingDashboardTemporaryAccommodationFirstReadyForOccupationActual)
                .HasColumnType("date")
                .HasColumnName("Project Director Forecasting Dashboard.Temporary accommodation first ready for occupation (Actual)");
            builder.Property(e => e.ProjectDirectorForecastingDashboardTemporaryAccommodationFirstReadyForOccupationRp1)
                .HasColumnType("date")
                .HasColumnName("Project Director Forecasting Dashboard.Temporary accommodation first ready for occupation (RP1)");
            builder.Property(e => e.ProjectDirectorForecastingDashboardTemporaryAccommodationFirstReadyForOccupationRp2)
                .HasColumnType("date")
                .HasColumnName("Project Director Forecasting Dashboard.Temporary accommodation first ready for occupation (RP2)");
            builder.Property(e => e.ProjectDirectorForecastingDashboardTemporaryAccommodationFirstReadyForOccupationRp3)
                .HasColumnType("date")
                .HasColumnName("Project Director Forecasting Dashboard.Temporary accommodation first ready for occupation (RP3)");
            builder.Property(e => e.ProjectDirectorForecastingDashboardTemporaryCommentary)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("Project Director Forecasting Dashboard.Temporary commentary");
            builder.Property(e => e.Rid)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasColumnName("RID");

		}
	}

}
