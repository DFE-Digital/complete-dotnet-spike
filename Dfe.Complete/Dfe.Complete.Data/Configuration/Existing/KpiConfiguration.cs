using System;
using System.Collections.Generic;
using Dfe.ManageFreeSchoolProjects.Data.Entities.Existing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dfe.ManageFreeSchoolProjects.Data.Configuration.Existing
{
    public partial class KpiConfiguration : IEntityTypeConfiguration< Kpi>
	{
		public void Configure(EntityTypeBuilder<Kpi> builder)
		{
            builder.HasKey(e => e.Rid);
            builder.ToTable("KPI", "dbo", e => e.IsTemporal());

            builder.Property(e => e.AprilIndicator)
                .IsRequired()
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("April Indicator");
            builder.Property(e => e.BasicNeedAdditionalEvidenceOfNeed)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("Basic Need.Additional evidence of need");
            builder.Property(e => e.BasicNeedAdditionalEvidenceOfNeedSecondary)
                .HasMaxLength(999)
                .IsUnicode(false)
                .HasColumnName("Basic Need.Additional evidence of need - secondary");
            builder.Property(e => e.BasicNeedAdditionalEvidenceOfNeedSecondaryAssessment)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Basic Need.Additional evidence of need - secondary (assessment)");
            builder.Property(e => e.BasicNeedKp02PlanningAreaCode)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("Basic Need.KP02_Planning area code");
            builder.Property(e => e.BasicNeedKp04PlanningAreaCode)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("Basic Need.KP04_Planning area code");
            builder.Property(e => e.BasicNeedPercentageShortfallInLocalAreaAllYearGroupsInScapYear4)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Basic Need.Percentage shortfall in local area (all year groups in SCAP year +4)");
            builder.Property(e => e.BasicNeedPercentageShortfallInLocalAreaAllYearGroupsInScapYear4Secondary)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Basic Need.Percentage shortfall in local area (all year groups in SCAP year +4) - secondary");
            builder.Property(e => e.BasicNeedPercentageShortfallInLocalAreaYearOfOpeningAllYearGroups)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Basic Need.Percentage shortfall in local area — year of opening (all year groups)");
            builder.Property(e => e.BasicNeedPercentageShortfallInLocalAreaYearOfOpeningAllYearGroupsSecondary)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Basic Need.Percentage shortfall in local area - year of opening (all year groups) - secondary");
            builder.Property(e => e.BasicNeedPlanningAreaCodeSecondary)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("Basic Need.Planning area code - secondary");
            builder.Property(e => e.BasicNeedPlanningAreaCodeSecondaryAssessment)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("Basic Need.Planning area code - secondary (assessment)");
            builder.Property(e => e.BasicNeedSchoolInLocalAreaWithAShortfallOfPlacesInLocalArea)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Basic Need.School in local area with a shortfall of places in local area");
            builder.Property(e => e.BasicNeedSchoolInLocalAreaWithAShortfallOfPlacesInLocalAreaSecondary)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Basic Need.School in local area with a shortfall of places in local area - secondary");
            builder.Property(e => e.BasicNeedSchoolInLocalAreaWithAShortfallOfPlacesSecondaryAssessment)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Basic Need.School in local area with a shortfall of places - secondary (assessment)");
            builder.Property(e => e.BasicNeedSchoolInPlanningAreaOfBasicNeed)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Basic Need.School in planning area of basic need");
            builder.Property(e => e.BasicNeedSchoolInPlanningAreaOfBasicNeedAssessment)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Basic Need.School in planning area of basic need (assessment)");
            builder.Property(e => e.BasicNeedSchoolInPlanningAreaOfBasicNeedSecondary)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Basic Need.School in planning area of basic need - secondary");
            builder.Property(e => e.BasicNeedSchoolInPlanningAreaOfBasicNeedSecondaryAssessment)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Basic Need.School in planning area of basic need - secondary (assessment)");
            builder.Property(e => e.BasicNeedShortfallOfPlacesInLocalAreaAllYearGroupsInScapYear4)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("Basic Need.Shortfall of places in local area (all year groups in SCAP year +4)");
            builder.Property(e => e.BasicNeedShortfallOfPlacesInLocalAreaAllYearGroupsInScapYear4Secondary)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("Basic Need.Shortfall of places in local area (all year groups in SCAP year +4) - secondary");
            builder.Property(e => e.BasicNeedShortfallOfPlacesInLocalAreaYearOfOpeningAllYearGroups)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("Basic Need.Shortfall of places in local area — year of opening (all year groups)");
            builder.Property(e => e.BasicNeedShortfallOfPlacesInLocalAreaYearOfOpeningAllYearGroupsSecondary)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("Basic Need.Shortfall of places in local area - year of opening (all year groups) - secondary");
            builder.Property(e => e.BasicNeedYearOfProjectedNeedSecondaryAssessment)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Basic Need.Year of projected need - secondary (assessment)");
            builder.Property(e => e.BasicNeedYearOfScapSurvey)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Basic Need.Year of SCAP survey");
            builder.Property(e => e.BasicNeedYearOfScapSurveySecondary)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Basic Need.Year of SCAP survey - secondary");
            builder.Property(e => e.CommunicationsArchivedLinesToTake)
                .IsUnicode(false)
                .HasColumnName("Communications.Archived lines to take");
            builder.Property(e => e.CommunicationsCurrentLinesToTake)
                .IsUnicode(false)
                .HasColumnName("Communications.Current lines to take");
            builder.Property(e => e.CommunicationsMediaPenPortrait)
                .IsUnicode(false)
                .HasColumnName("Communications.Media pen portrait");
            builder.Property(e => e.ContingencyPlanningBackUpField)
                .IsUnicode(false)
                .HasColumnName("Contingency Planning.Back-up Field");
            builder.Property(e => e.ContingencyPlanningCanCurrentCohortRemainInSchool)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Contingency Planning.Can current cohort remain in school?");
            builder.Property(e => e.ContingencyPlanningCanSchoolTakeOnAnotherCohort)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Contingency Planning.Can school take on another cohort?");
            builder.Property(e => e.ContingencyPlanningCanTempsBeExtended)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("Contingency Planning.Can temps be extended?");
            builder.Property(e => e.ContingencyPlanningEssentialThatItIsDeliveredForSeptemberOrCurrentScheduledDateInTheRealisticYearOfOpening)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Contingency Planning.Essential that it is delivered for September (or current scheduled date) in the Realistic Year of Opening?");
            builder.Property(e => e.ContingencyPlanningExtraInformation)
                .IsUnicode(false)
                .HasColumnName("Contingency Planning.Extra information");
            builder.Property(e => e.ContingencyPlanningFscDeliverabilityAssessment)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Contingency Planning.FSC Deliverability Assessment");
            builder.Property(e => e.ContingencyPlanningFscDeliverabilityComment)
                .IsUnicode(false)
                .HasColumnName("Contingency Planning.FSC Deliverability Comment");
            builder.Property(e => e.ContingencyPlanningHowLongCanTempsBeExtended)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("Contingency Planning.How long can temps be extended?");
            builder.Property(e => e.ContingencyPlanningHowManyStudentsWillNeedAlternativeArrangements)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("Contingency Planning.How many students will need alternative arrangements?");
            builder.Property(e => e.ContingencyPlanningIfOtherWhy)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Contingency Planning.If 'Other', why?");
            builder.Property(e => e.ContingencyPlanningIfOtherWhyForRAndAExplainAnythingBeingExploredOrNextSteps)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Contingency Planning.If 'Other', why? (for R and A, explain anything being explored or next steps)");
            builder.Property(e => e.ContingencyPlanningIfYesWhy)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Contingency Planning.If ‘Yes’, why?");
            builder.Property(e => e.ContingencyPlanningProjectedLengthOfDelayToProject)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Contingency Planning.Projected length of delay to project");
            builder.Property(e => e.ContingencyPlanningRddRationale)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Contingency Planning.RDD Rationale");
            builder.Property(e => e.ContingencyPlanningRddSiteContingencyRag)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Contingency Planning.RDD Site Contingency RAG");
            builder.Property(e => e.ContingencyPlanningSiteShutdown)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Contingency Planning.Site shutdown");
            builder.Property(e => e.FsType)
                .IsRequired()
                .HasMaxLength(14)
                .IsUnicode(false)
                .HasColumnName("FS_Type");
            builder.Property(e => e.FsType1)
                .IsRequired()
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasColumnName("FS_Type_1");
            builder.Property(e => e.KeyContactsAddressOfLeadProposer)
                .IsUnicode(false)
                .HasColumnName("Key Contacts.Address of lead proposer");
            builder.Property(e => e.KeyContactsAllocatedLawFirm)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Key Contacts.Allocated law firm");
            builder.Property(e => e.KeyContactsAssessmentTeamLeader)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Key Contacts.Assessment team leader");
            builder.Property(e => e.KeyContactsChairOfGovernorsEmail)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Key Contacts.Chair of Governors email");
            builder.Property(e => e.KeyContactsChairOfGovernorsMat)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Key Contacts.Chair of governors MAT");
            builder.Property(e => e.KeyContactsChairOfGovernorsMatEmail)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Key Contacts.Chair of governors MAT email");
            builder.Property(e => e.KeyContactsChairOfGovernorsMatPhone)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Key Contacts.Chair of governors MAT phone");
            builder.Property(e => e.KeyContactsChairOfGovernorsName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Key Contacts.Chair of Governors name");
            builder.Property(e => e.KeyContactsChairOfGovernorsPhone)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Key Contacts.Chair of Governors phone");
            builder.Property(e => e.KeyContactsCommercialManager)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Key Contacts.Commercial Manager");
            builder.Property(e => e.KeyContactsEaOnceSchoolIsOpen)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Key Contacts.EA once school is open");
            builder.Property(e => e.KeyContactsEducationAdviserAssessment)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Key Contacts.Education adviser (assessment)");
            builder.Property(e => e.KeyContactsEducationAdviserPreOpening)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Key Contacts.Education adviser (pre-opening)");
            builder.Property(e => e.KeyContactsEsfaAcademiesSeniorAdviser)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Key Contacts.ESFA academies senior adviser");
            builder.Property(e => e.KeyContactsEsfaCapitalHeadOfRegion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Key Contacts.ESFA Capital Head of Region");
            builder.Property(e => e.KeyContactsEsfaCapitalProjectDirector)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Key Contacts.ESFA Capital project director");
            builder.Property(e => e.KeyContactsEsfaCapitalProjectManager)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Key Contacts.ESFA Capital project manager");
            builder.Property(e => e.KeyContactsEsfaCapitalProjectManagerFirm)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Key Contacts.ESFA Capital project manager firm");
            builder.Property(e => e.KeyContactsEsfaLinkOfficer)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Key Contacts.ESFA Link Officer");
            builder.Property(e => e.KeyContactsEsfaPropertyLead)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Key Contacts.ESFA property lead");
            builder.Property(e => e.KeyContactsEsfaRegionalPropertyLead)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Key Contacts.ESFA regional property lead");
            builder.Property(e => e.KeyContactsEsfaTechnicalAdviser)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Key Contacts.ESFA technical adviser");
            builder.Property(e => e.KeyContactsFrameworkPlanningConsultant)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Key Contacts.Framework planning consultant");
            builder.Property(e => e.KeyContactsFrameworkPlanningFirm)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Key Contacts.Framework planning firm");
            builder.Property(e => e.KeyContactsFrameworkPlanningFirmOther)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Key Contacts.Framework planning firm – other");
            builder.Property(e => e.KeyContactsFsgAssessmentLead)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Key Contacts.FSG assessment lead");
            builder.Property(e => e.KeyContactsFsgGrade6)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Key Contacts.FSG Grade 6");
            builder.Property(e => e.KeyContactsFsgLeadContact)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Key Contacts.FSG lead contact");
            builder.Property(e => e.KeyContactsFsgTeamLeader)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Key Contacts.FSG team leader");
            builder.Property(e => e.KeyContactsIctAdviser)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Key Contacts.ICT adviser");
            builder.Property(e => e.KeyContactsInterviewChair)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Key Contacts.Interview chair");
            builder.Property(e => e.KeyContactsLeadProposerEmail)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Key Contacts.Lead proposer email ");
            builder.Property(e => e.KeyContactsLeadProposerName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Key Contacts.Lead proposer name");
            builder.Property(e => e.KeyContactsLeadProposerPhone)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Key Contacts.Lead proposer phone");
            builder.Property(e => e.KeyContactsLegalFirm)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Key Contacts.Legal firm");
            builder.Property(e => e.KeyContactsLegalManager)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Key Contacts.Legal manager");
            builder.Property(e => e.KeyContactsLocalAuthorityContactPresumptionProject)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Key Contacts.Local authority contact (presumption project)");
            builder.Property(e => e.KeyContactsLocatEdAcquisitionManager)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Key Contacts.LocatED acquisition manager");
            builder.Property(e => e.KeyContactsNamedContactOnceSchoolIsOpen)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Key Contacts.Named contact once school is open");
            builder.Property(e => e.KeyContactsPlanningAdviser)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Key Contacts.Planning Adviser");
            builder.Property(e => e.KeyContactsPostCodeForMapping)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Key Contacts.PostCode for Mapping");
            builder.Property(e => e.KeyContactsPostcode)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Key Contacts.Postcode");
            builder.Property(e => e.KeyContactsPrincipalDesignateEmail)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Key Contacts.Principal Designate email");
            builder.Property(e => e.KeyContactsPrincipalDesignateName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Key Contacts.Principal Designate Name");
            builder.Property(e => e.KeyContactsPrincipalDesignatePhone)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Key Contacts.Principal Designate phone");
            builder.Property(e => e.KeyContactsPropertyAdviserAllocated)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Key Contacts.Property adviser allocated");
            builder.Property(e => e.KeyContactsPropertyDocumentRepositoryLink)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Key Contacts.Property document repository link");
            builder.Property(e => e.KeyContactsPropertyFirmDealing)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Key Contacts.Property firm dealing");
            builder.Property(e => e.KeyContactsSchoolAddress)
                .IsUnicode(false)
                .HasColumnName("Key Contacts.School address");
            builder.Property(e => e.KeyContactsSeniorExecutiveLeaderEmail)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Key Contacts.Senior Executive Leader email");
            builder.Property(e => e.KeyContactsSeniorExecutiveLeaderName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Key Contacts.Senior Executive Leader name");
            builder.Property(e => e.KeyContactsSeniorExecutiveLeaderPhone)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Key Contacts.Senior Executive Leader phone");
            builder.Property(e => e.KeyContactsStrategicDesignAdviser)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Key Contacts.Strategic design adviser");
            builder.Property(e => e.KeyContactsTechnicalAdvisoryFirm)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Key Contacts.Technical advisory firm");
            builder.Property(e => e.KeyContactsTrustSIctLeadContact)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Key Contacts.Trust's ICT lead contact");
            builder.Property(e => e.KeyContactsTrustSIctLeadContactEmail)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Key Contacts.Trust's ICT lead contact email");
            builder.Property(e => e.KeyContactsTrustSIctLeadContactPhone)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Key Contacts.Trust's ICT lead contact phone");
            builder.Property(e => e.LeadSponsorId)
                .HasMaxLength(7)
                .IsUnicode(false)
                .HasColumnName("Lead sponsor ID");
            builder.Property(e => e.LeadSponsorName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Lead sponsor name");
            builder.Property(e => e.LocalAuthority)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Local authority");
            builder.Property(e => e.MatUnitProjects)
                .IsRequired()
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasColumnName("MAT Unit Projects");
            builder.Property(e => e.PRid)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasColumnName("p_rid");
            builder.Property(e => e.ProjectStatusActualDateOfOpeningInPermanentAccommodation)
                .HasColumnType("date")
                .HasColumnName("Project Status.Actual date of opening in permanent accommodation");
            builder.Property(e => e.ProjectStatusActualDateOfOpeningInTemporaryAccommodation)
                .HasColumnType("date")
                .HasColumnName("Project Status.Actual date of opening in temporary accommodation");
            builder.Property(e => e.ProjectStatusActualOpeningDate)
                .HasColumnType("date")
                .HasColumnName("Project Status.Actual opening date");
            builder.Property(e => e.ProjectStatusCommentaryForCancellation)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Project Status.Commentary for cancellation");
            builder.Property(e => e.ProjectStatusCommentaryForFirstDeferral)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Project Status.Commentary for first deferral");
            builder.Property(e => e.ProjectStatusCommentaryForSecondDeferral)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Project Status.Commentary for second deferral");
            builder.Property(e => e.ProjectStatusCommentaryForThirdDeferral)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Project Status.Commentary for third deferral");
            builder.Property(e => e.ProjectStatusCommentaryForWithdrawal)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Project Status.Commentary for withdrawal");
            builder.Property(e => e.ProjectStatusCurrentFreeSchoolName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Project Status.Current free school name");
            builder.Property(e => e.ProjectStatusDateCancelled)
                .HasColumnType("date")
                .HasColumnName("Project Status.Date cancelled");
            builder.Property(e => e.ProjectStatusDateClosed)
                .HasColumnType("date")
                .HasColumnName("Project Status.Date closed");
            builder.Property(e => e.ProjectStatusDateOfApplicationIfOutsideWave)
                .HasColumnType("date")
                .HasColumnName("Project Status.Date of application if outside wave");
            builder.Property(e => e.ProjectStatusDateOfEntryIntoPreOpening)
                .HasColumnType("date")
                .HasColumnName("Project Status.Date of entry into pre-opening");
            builder.Property(e => e.ProjectStatusDateOfFirstDeferral)
                .HasColumnType("date")
                .HasColumnName("Project Status.Date of first deferral");
            builder.Property(e => e.ProjectStatusDateOfSecondDeferral)
                .HasColumnType("date")
                .HasColumnName("Project Status.Date of second deferral");
            builder.Property(e => e.ProjectStatusDateOfThirdDeferral)
                .HasColumnType("date")
                .HasColumnName("Project Status.Date of third deferral");
            builder.Property(e => e.ProjectStatusDateWithdrawn)
                .HasColumnType("date")
                .HasColumnName("Project Status.Date withdrawn");
            builder.Property(e => e.ProjectStatusFreeSchoolApplicationWave)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Project Status.Free school application wave");
            builder.Property(e => e.ProjectStatusFreeSchoolPenPortrait)
                .IsUnicode(false)
                .HasColumnName("Project Status.Free school pen portrait");
            builder.Property(e => e.ProjectStatusFreeSchoolsApplicationNumber)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Project Status.Free schools application number");
            builder.Property(e => e.ProjectStatusHasProjectBeenCancelled)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Project Status.Has project been cancelled?");
            builder.Property(e => e.ProjectStatusHasProjectBeenDeferredForASecondTime)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Project Status.Has project been deferred for a second time?");
            builder.Property(e => e.ProjectStatusHasProjectBeenDeferredForAThirdTime)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Project Status.Has project been deferred for a third time?");
            builder.Property(e => e.ProjectStatusHasProjectBeenWithdrawn)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Project Status.Has project been withdrawn?");
            builder.Property(e => e.ProjectStatusHasTheFreeSchoolChangedItsName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Project Status.Has the free school changed its name?");
            builder.Property(e => e.ProjectStatusHasTheProjectBeenDeferred)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Project Status.Has the project been deferred?");
            builder.Property(e => e.ProjectStatusKp05ReasonForSiteDeferral)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Project Status.KP05_Reason for site deferral");
            builder.Property(e => e.ProjectStatusKp06ReasonForSiteDeferral)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Project Status.KP06_Reason for site deferral");
            builder.Property(e => e.ProjectStatusNewOpeningDateFollowingFirstDeferral)
                .HasColumnType("date")
                .HasColumnName("Project Status.New opening date following first deferral");
            builder.Property(e => e.ProjectStatusNewOpeningDateFollowingSecondDeferral)
                .HasColumnType("date")
                .HasColumnName("Project Status.New opening date following second deferral");
            builder.Property(e => e.ProjectStatusNewOpeningDateFollowingThirdDeferral)
                .HasColumnType("date")
                .HasColumnName("Project Status.New opening date following third deferral");
            builder.Property(e => e.ProjectStatusPlannedMoveDateToPermanentSite)
                .HasColumnType("date")
                .HasColumnName("Project Status.Planned move date to permanent site");
            builder.Property(e => e.ProjectStatusPreviousFreeSchoolName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Project Status.Previous free school name");
            builder.Property(e => e.ProjectStatusPrimaryReasonForCancellation)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Project Status.Primary reason for cancellation");
            builder.Property(e => e.ProjectStatusPrimaryReasonForFirstDeferral)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Project Status.Primary reason for first deferral");
            builder.Property(e => e.ProjectStatusPrimaryReasonForSecondDeferral)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Project Status.Primary reason for second deferral");
            builder.Property(e => e.ProjectStatusPrimaryReasonForThirdDeferral)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Project Status.Primary reason for third deferral");
            builder.Property(e => e.ProjectStatusPrimaryReasonForWithdrawal)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Project Status.Primary reason for withdrawal");
            builder.Property(e => e.ProjectStatusProjectId)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("Project Status.Project ID");
            builder.Property(e => e.ProjectStatusProjectStatus)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Project Status.Project status");
            builder.Property(e => e.ProjectStatusProvisionalOpeningDateAgreedWithTrust)
                .HasColumnType("date")
                .HasColumnName("Project Status.Provisional opening date agreed with trust");
            builder.Property(e => e.ProjectStatusRealisticYearOfOpening)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Project Status.Realistic year of opening");
            builder.Property(e => e.ProjectStatusReasonForSiteCancellation)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Project Status.Reason for site cancellation");
            builder.Property(e => e.ProjectStatusReasonForSiteDeferral)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Project Status.Reason for site deferral");
            builder.Property(e => e.ProjectStatusReasonForSiteWithdrawal)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Project Status.Reason for site withdrawal");
            builder.Property(e => e.ProjectStatusRebrokeredUrn)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Project Status.Rebrokered URN");
            builder.Property(e => e.ProjectStatusTrustsPreferredYearOfOpening)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Project Status.Trusts preferred year of opening");
            builder.Property(e => e.ProjectStatusUrnWhenGivenOne)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Project Status.URN (when given one)");
            builder.Property(e => e.RatProvisionalOpeningDateAgreedWithTrust)
                .HasColumnType("date")
                .HasColumnName("RAT Provisional opening date agreed with trust");
            builder.Property(e => e.Rid)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasColumnName("RID");
            builder.Property(e => e.RyooWd)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("RYOO_WD");
            builder.Property(e => e.SchoolDetailsAeaCatagory)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("School Details.AEA Catagory");
            builder.Property(e => e.SchoolDetailsAgeRange)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("School Details.Age range");
            builder.Property(e => e.SchoolDetailsConstituency)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("School Details.Constituency");
            builder.Property(e => e.SchoolDetailsConstituencyMp)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("School Details.Constituency MP");
            builder.Property(e => e.SchoolDetailsDeprivationDecline)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("School Details.Deprivation decline");
            builder.Property(e => e.SchoolDetailsDetailsOfResidentialBoardingProvision)
                .IsUnicode(false)
                .HasColumnName("School Details.Details of residential/boarding provision");
            builder.Property(e => e.SchoolDetailsDistinguishingFeatures)
                .IsUnicode(false)
                .HasColumnName("School Details.Distinguishing features");
            builder.Property(e => e.SchoolDetailsDistrict)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("School Details.District");
            builder.Property(e => e.SchoolDetailsEfaTerritory)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("School Details.EFA Territory");
            builder.Property(e => e.SchoolDetailsEmployerPartners)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("School Details.Employer Partners");
            builder.Property(e => e.SchoolDetailsEmployerSponsorsUtcsSsOnly)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("School Details.Employer sponsors - UTCs/SS only");
            builder.Property(e => e.SchoolDetailsFaithStatus)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("School Details.Faith status");
            builder.Property(e => e.SchoolDetailsFaithType)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("School Details.Faith type");
            builder.Property(e => e.SchoolDetailsGender)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("School Details.Gender");
            builder.Property(e => e.SchoolDetailsGeographicalRegion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("School Details.Geographical Region");
            builder.Property(e => e.SchoolDetailsIndependentConverter)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("School Details.Independent converter");
            builder.Property(e => e.SchoolDetailsLaestabWhenGivenOne)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("School Details.LAESTAB (when given one)");
            builder.Property(e => e.SchoolDetailsLeadSponsorId)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("School Details.Lead sponsor ID");
            builder.Property(e => e.SchoolDetailsLeadSponsorName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("School Details.Lead sponsor name");
            builder.Property(e => e.SchoolDetailsLocalAuthority)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("School Details.Local authority");
            builder.Property(e => e.SchoolDetailsLocalAuthorityControl)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("School Details.Local authority control");
            builder.Property(e => e.SchoolDetailsNeetInLa)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("School Details.% NEET in LA");
            builder.Property(e => e.SchoolDetailsNumberOfFormsOfEntry)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("School Details.Number of forms of entry");
            builder.Property(e => e.SchoolDetailsNursery)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("School Details.Nursery");
            builder.Property(e => e.SchoolDetailsAlternativeProvision)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("School Details.Alternative Provision");
            builder.Property(e => e.SchoolDetailsSpecialEducationNeeds)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("School Details.Special Education Needs");
            builder.Property(e => e.SchoolDetailsOtherPartners)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("School Details.Other Partners");
            builder.Property(e => e.SchoolDetailsPleaseSpecifyOtherFaithType)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("School Details.Please specify other faith type");
            builder.Property(e => e.SchoolDetailsPleaseSpecifyOtherTypeOfProposerGroup)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("School Details.Please specify other type of proposer group");
            builder.Property(e => e.SchoolDetailsPoliticalParty)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("School Details.Political party");
            builder.Property(e => e.SchoolDetailsResidentialOrBoardingProvision)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("School Details.Residential or boarding provision");
            builder.Property(e => e.SchoolDetailsRscRegion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("School Details.RSC region");
            builder.Property(e => e.SchoolDetailsSchoolPhasePrimarySecondary)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("School Details.School phase (primary, secondary)");
            builder.Property(e => e.SchoolDetailsSchoolTypeMainstreamApEtc)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("School Details.School type (mainstream, AP etc)");
            builder.Property(e => e.SchoolDetailsSixthForm)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("School Details.Sixth form");
            builder.Property(e => e.SchoolDetailsSixthFormType)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("School Details.Sixth form type");
            builder.Property(e => e.SchoolDetailsSizeOfGoverningBody)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("School Details.Size of Governing Body");
            builder.Property(e => e.SchoolDetailsSpecialism)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("School Details.Specialism");
            builder.Property(e => e.SchoolDetailsSpecialistResourceProvision)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("School Details.Specialist Resource Provision");
            builder.Property(e => e.SchoolDetailsSponsorType)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("School Details.Sponsor type");
            builder.Property(e => e.SchoolDetailsStartOfTermDate)
                .HasColumnType("date")
                .HasColumnName("School Details.Start of term date");
            builder.Property(e => e.SchoolDetailsTrustId)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("School Details.Trust ID");
            builder.Property(e => e.SchoolDetailsTrustName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("School Details.Trust name");
            builder.Property(e => e.SchoolDetailsTrustType)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("School Details.Trust type");
            builder.Property(e => e.SchoolDetailsTypeOfProposerGroup)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("School Details.Type of proposer group");
            builder.Property(e => e.SchoolDetailsUniversitySponsor)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("School Details.University Sponsor");
            builder.Property(e => e.SponsorUnitProjects)
                .IsRequired()
                .HasMaxLength(39)
                .IsUnicode(false)
                .HasColumnName("Sponsor Unit Projects");
            builder.Property(e => e.TrustId)
                .HasMaxLength(7)
                .IsUnicode(false)
                .HasColumnName("Trust ID");
            builder.Property(e => e.TrustName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Trust name");
            builder.Property(e => e.TrustType)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Trust type");
            builder.Property(e => e.UpperStatus)
                .IsRequired()
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Upper Status");
            builder.Property(e => e.Wave)
                .IsRequired()
                .HasMaxLength(16)
                .IsUnicode(false);

            AuditConfiguration.Apply(builder);
        }
	}

}
