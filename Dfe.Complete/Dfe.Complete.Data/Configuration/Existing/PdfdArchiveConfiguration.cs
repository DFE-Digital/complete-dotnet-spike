using System;
using System.Collections.Generic;
using Dfe.ManageFreeSchoolProjects.Data.Entities.Existing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dfe.ManageFreeSchoolProjects.Data.Configuration.Existing
{
	public partial class PdfdArchiveConfiguration : IEntityTypeConfiguration< PdfdArchive>
	{
		public void Configure(EntityTypeBuilder<PdfdArchive> builder)
		{
            builder
                .HasNoKey()
                .ToTable("PDFD_Archive", "dbo");

            builder.Property(e => e.ActualDateOfOpeningActual)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Actual date of opening (Actual)");
            builder.Property(e => e.AllPupilsOutOfTemporaryAccommodationActual)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("All pupils out of temporary accommodation (Actual)");
            builder.Property(e => e.AllPupilsOutOfTemporaryAccommodationForecast)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("All pupils out of temporary accommodation (Forecast)");
            builder.Property(e => e.CapitalProjectRagRating)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Capital Project RAG Rating");
            builder.Property(e => e.CompleteOnSiteAcquisitionForMainSchoolBuildingActual)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Complete on site acquisition for Main School Building (Actual)");
            builder.Property(e => e.CompleteOnSiteAcquisitionForMainSchoolBuildingForecast)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Complete on site acquisition for Main School Building (Forecast)");
            builder.Property(e => e.ContractorAppointedForMainSchoolBuildingSpmEwaPcsaActual)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Contractor appointed for main school building (SPM, EWA, PCSA) (Actual)");
            builder.Property(e => e.ContractorAppointedForMainSchoolBuildingSpmEwaPcsaForecast)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Contractor appointed for main school building (SPM, EWA, PCSA) (Forecast)");
            builder.Property(e => e.DateHoTSecuredOnSiteForMainSchoolBuildingActual)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Date HoT secured on site for main school building (Actual)");
            builder.Property(e => e.DateHoTSecuredOnSiteForMainSchoolBuildingBaseline)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Date HoT secured on site for main school building (Baseline)");
            builder.Property(e => e.DateOfCompletionOnTemporaryAccommodationSiteIfRequiredActual)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Date of completion on temporary accommodation site, if required (Actual)");
            builder.Property(e => e.DateOfCompletionOnTemporaryAccommodationSiteIfRequiredForecast)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Date of completion on temporary accommodation site, if required (Forecast)");
            builder.Property(e => e.DateOfExchangeOnSiteForMainSchoolBuildingActual)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Date of exchange on site for main school building (Actual)");
            builder.Property(e => e.DateOfExchangeOnSiteForMainSchoolBuildingBaseline)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Date of exchange on site for main school building (Baseline)");
            builder.Property(e => e.DateOfHoTSecuredOnTemporaryAccommodationSiteIfRequiredActual)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Date of HoT secured on temporary accommodation site, if required (Actual)");
            builder.Property(e => e.DateOfHoTSecuredOnTemporaryAccommodationSiteIfRequiredForecast)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Date of HoT secured on temporary accommodation site, if required (Forecast)");
            builder.Property(e => e.DateOfPositivePlanningDecisionNoticeSecuredForMainSchoolBuildingActual)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Date of positive planning decision notice secured for main school building (Actual)");
            builder.Property(e => e.DateOfPositivePlanningDecisionNoticeSecuredForMainSchoolBuildingForecast)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Date of positive planning decision notice secured for main school building (Forecast)");
            builder.Property(e => e.EndOfProjectNoMoreCapitalSpendEndOfDefectsActual)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("End of Project (No more capital spend/end of defects) (Actual)");
            builder.Property(e => e.EndOfProjectNoMoreCapitalSpendEndOfDefectsForecast)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("End of Project (No more capital spend/end of defects) (Forecast)");
            builder.Property(e => e.EnterIntoContractForMainSchoolBuildingActual)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Enter into Contract for Main School Building (Actual)");
            builder.Property(e => e.EnterIntoContractForMainSchoolBuildingForecast)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Enter into Contract for Main School Building (Forecast)");
            builder.Property(e => e.EnterIntoContractForTheInitialProvisionOfTemporaryAccommodationActual)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Enter into contract for the initial provision of temporary accommodation (Actual)");
            builder.Property(e => e.EnterIntoContractForTheInitialProvisionOfTemporaryAccommodationForecast)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Enter into contract for the initial provision of temporary accommodation (Forecast)");
            builder.Property(e => e.EnterIntoFundingAgreementActual)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Enter into Funding Agreement (Actual)");
            builder.Property(e => e.EnterIntoFundingAgreementForecast)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Enter into Funding Agreement (Forecast)");
            builder.Property(e => e.FeasibilityStartedForMainSchoolBuildingActual)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Feasibility Started for Main School Building (Actual)");
            builder.Property(e => e.FreeSchoolName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Free School Name");
            builder.Property(e => e.HeadOfRegion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Head of Region");
            builder.Property(e => e.IfRequiredAdditionalTemporaryAccommodationReadyForOccupationActual)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("If required, additional temporary accommodation ready for occupation (Actual)");
            builder.Property(e => e.IfRequiredAdditionalTemporaryAccommodationReadyForOccupationForecast)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("If required, additional temporary accommodation ready for occupation (Forecast)");
            builder.Property(e => e.IfRequiredEnterIntoContractForAdditionalTemporaryAccommodationActual)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("If required, enter into contract for additional temporary accommodation (Actual)");
            builder.Property(e => e.IfRequiredEnterIntoContractForAdditionalTemporaryAccommodationForecast)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("If required, enter into contract for additional temporary accommodation (Forecast)");
            builder.Property(e => e.MainSchoolBuildingFirstReadyToBeOpenedForOccupationActual)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Main school building first ready to be opened for occupation (Actual)");
            builder.Property(e => e.MainSchoolBuildingFirstReadyToBeOpenedForOccupationForecast)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Main school building first ready to be opened for occupation (Forecast)");
            builder.Property(e => e.Month)
                .HasMaxLength(100)
                .IsUnicode(false);
            builder.Property(e => e.PracticalCompletionOfContractForMainSchoolBuildingActual)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Practical completion of contract for Main School Building (Actual)");
            builder.Property(e => e.PracticalCompletionOfContractForMainSchoolBuildingForecast)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Practical completion of contract for Main School Building (Forecast)");
            builder.Property(e => e.ProjectDirector)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Project Director");
            builder.Property(e => e.ProjectDirectorApproval)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Project Director Approval");
            builder.Property(e => e.ProjectId)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Project ID");
            builder.Property(e => e.ProjectManager)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Project Manager");
            builder.Property(e => e.RealisticYearOfOpening)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Realistic Year of Opening");
            builder.Property(e => e.RegionalHeadFreezeDate)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Regional Head - Freeze Date");
            builder.Property(e => e.SiteIdentifiedForMainSchoolBuildingActual)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Site identified for main school building (Actual)");
            builder.Property(e => e.StartOfConstructionOfMainSchoolBuildingActual)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Start of construction of main school building (Actual)");
            builder.Property(e => e.StartOfConstructionOfMainSchoolBuildingForecast)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Start of construction of main school building (Forecast)");
            builder.Property(e => e.StartOfProcurementForMainSchoolBuildingActual)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Start of procurement for Main School Building (Actual)");
            builder.Property(e => e.StartOfProcurementForMainSchoolBuildingForecast)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Start of procurement for Main School Building (Forecast)");
            builder.Property(e => e.SubmissionOfPlanningPermissionForPermanentMainSchoolBuildingActual)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Submission of planning permission for permanent main school building (Actual)");
            builder.Property(e => e.SubmissionOfPlanningPermissionForPermanentMainSchoolBuildingForecast)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Submission of planning permission for permanent main school building (Forecast)");
            builder.Property(e => e.TemporaryAccommodationFirstReadyForOccupationActual)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Temporary accommodation first ready for occupation (Actual)");
            builder.Property(e => e.TemporaryAccommodationFirstReadyForOccupationForecast)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Temporary accommodation first ready for occupation (Forecast)");

		}
	}

}
