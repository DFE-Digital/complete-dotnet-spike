using Dfe.ManageFreeSchoolProjects.Data.Entities;
using Dfe.ManageFreeSchoolProjects.Data.Entities.Existing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dfe.ManageFreeSchoolProjects.Data.Configuration.Existing
{
    public partial class MilestonesConfiguration : IEntityTypeConfiguration< Milestones>
	{
		public void Configure(EntityTypeBuilder<Milestones> builder)
		{
            builder.HasKey(e => e.Rid);

            builder.ToTable("Milestones", "dbo", e => e.IsTemporal());

            builder.Property(e => e.FsgPreOpeningMilestonesAppEvActualDateOfCompletion)
                .HasColumnType("date")
                .HasColumnName("FSG Pre Opening Milestones.AppEv Actual date of completion");
            builder.Property(e => e.FsgPreOpeningMilestonesAppEvApplicable)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("FSG Pre Opening Milestones.AppEv Applicable");
            builder.Property(e => e.FsgPreOpeningMilestonesAppEvBaselineDate)
                .HasColumnType("date")
                .HasColumnName("FSG Pre Opening Milestones.AppEv Baseline date");
            builder.Property(e => e.FsgPreOpeningMilestonesAppEvForecastDate)
                .HasColumnType("date")
                .HasColumnName("FSG Pre Opening Milestones.AppEv Forecast date");
            builder.Property(e => e.FsgPreOpeningMilestonesAppEvReasonNotApplicable)
                .IsUnicode(false)
                .HasColumnName("FSG Pre Opening Milestones.AppEv - Reason not applicable");
            builder.Property(e => e.FsgPreOpeningMilestonesBefpActualDateOfCompletion)
                .HasColumnType("date")
                .HasColumnName("FSG Pre Opening Milestones.BEFP Actual date of completion");
            builder.Property(e => e.FsgPreOpeningMilestonesBefpApplicable)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("FSG Pre Opening Milestones.BEFP Applicable");
            builder.Property(e => e.FsgPreOpeningMilestonesBefpBaselineDate)
                .HasColumnType("date")
                .HasColumnName("FSG Pre Opening Milestones.BEFP Baseline date");
            builder.Property(e => e.FsgPreOpeningMilestonesBefpForecastDate)
                .HasColumnType("date")
                .HasColumnName("FSG Pre Opening Milestones.BEFP Forecast date");
            builder.Property(e => e.FsgPreOpeningMilestonesBefpReasonNotApplicable)
                .IsUnicode(false)
                .HasColumnName("FSG Pre Opening Milestones.BEFP - Reason not applicable");
            builder.Property(e => e.FsgPreOpeningMilestonesCoGappActualDateOfCompletion)
                .HasColumnType("date")
                .HasColumnName("FSG Pre Opening Milestones.CoGapp Actual date of completion");
            builder.Property(e => e.FsgPreOpeningMilestonesCoGappBaselineDate)
                .HasColumnType("date")
                .HasColumnName("FSG Pre Opening Milestones.CoGapp Baseline date");
            builder.Property(e => e.FsgPreOpeningMilestonesCoGappForecastDate)
                .HasColumnType("date")
                .HasColumnName("FSG Pre Opening Milestones.CoGapp Forecast date");
            builder.Property(e => e.FsgPreOpeningMilestonesDbscActualDateOfCompletion)
                .HasColumnType("date")
                .HasColumnName("FSG Pre Opening Milestones.DBSC Actual date of completion");
            builder.Property(e => e.FsgPreOpeningMilestonesDbscBaselineDate)
                .HasColumnType("date")
                .HasColumnName("FSG Pre Opening Milestones.DBSC Baseline date");
            builder.Property(e => e.FsgPreOpeningMilestonesDbscForecastDate)
                .HasColumnType("date")
                .HasColumnName("FSG Pre Opening Milestones.DBSC Forecast date");
            builder.Property(e => e.FsgPreOpeningMilestonesDbsiActualDateOfCompletion)
                .HasColumnType("date")
                .HasColumnName("FSG Pre Opening Milestones.DBSI Actual date of completion");
            builder.Property(e => e.FsgPreOpeningMilestonesDbsiBaselineDate)
                .HasColumnType("date")
                .HasColumnName("FSG Pre Opening Milestones.DBSI Baseline date");
            builder.Property(e => e.FsgPreOpeningMilestonesDbsiForecastDate)
                .HasColumnType("date")
                .HasColumnName("FSG Pre Opening Milestones.DBSI Forecast date");
            builder.Property(e => e.FsgPreOpeningMilestonesDetailsOfFundingArrangementAgreedBetweenLaAndSponsor)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("FSG Pre Opening Milestones.Details of Funding arrangement agreed between LA and Sponsor");
            builder.Property(e => e.FsgPreOpeningMilestonesFundingArrangementAgreedBetweenLaAndSponsor)
                .HasColumnType("bit");
            builder.Property(e => e.FsgPreOpeningMilestonesDgpActualDateOfCompletion)
                .HasColumnType("date")
                .HasColumnName("FSG Pre Opening Milestones.DGP Actual date of completion");
            builder.Property(e => e.FsgPreOpeningMilestonesDgpBaselineDate)
                .HasColumnType("date")
                .HasColumnName("FSG Pre Opening Milestones.DGP  Baseline date");
            builder.Property(e => e.FsgPreOpeningMilestonesDgpForecastDate)
                .HasColumnType("date")
                .HasColumnName("FSG Pre Opening Milestones.DGP Forecast date");
            builder.Property(e => e.FsgPreOpeningMilestonesEaoActualDateOfCompletion)
                .HasColumnType("date")
                .HasColumnName("FSG Pre Opening Milestones.EAO Actual date of completion");
            builder.Property(e => e.FsgPreOpeningMilestonesEaoBaselineDate)
                .HasColumnType("date")
                .HasColumnName("FSG Pre Opening Milestones.EAO Baseline date");
            builder.Property(e => e.FsgPreOpeningMilestonesEaoForecastDate)
                .HasColumnType("date")
                .HasColumnName("FSG Pre Opening Milestones.EAO Forecast date");
            builder.Property(e => e.FsgPreOpeningMilestonesEaoMilestoneApplicable)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("FSG Pre Opening Milestones.EAO - Milestone applicable");
            builder.Property(e => e.FsgPreOpeningMilestonesEaoReasonNotApplicable)
                .IsUnicode(false)
                .HasColumnName("FSG Pre Opening Milestones.EAO - Reason not applicable");
            builder.Property(e => e.FsgPreOpeningMilestonesEapolActualDateOfCompletion)
                .HasColumnType("date")
                .HasColumnName("FSG Pre Opening Milestones.EAPol Actual date of completion");
            builder.Property(e => e.FsgPreOpeningMilestonesEapolBaselineDate)
                .HasColumnType("date")
                .HasColumnName("FSG Pre Opening Milestones.EAPol Baseline date");
            builder.Property(e => e.FsgPreOpeningMilestonesEapolForecastDate)
                .HasColumnType("date")
                .HasColumnName("FSG Pre Opening Milestones.EAPol  Forecast date");
            builder.Property(e => e.FsgPreOpeningMilestonesEdBrActualDateOfCompletion)
                .HasColumnType("date")
                .HasColumnName("FSG Pre Opening Milestones.EdBr Actual date of completion");
            builder.Property(e => e.FsgPreOpeningMilestonesEdBrBaselineDate)
                .HasColumnType("date")
                .HasColumnName("FSG Pre Opening Milestones.EdBr Baseline date");
            builder.Property(e => e.FsgPreOpeningMilestonesEdBrForecastDate)
                .HasColumnType("date")
                .HasColumnName("FSG Pre Opening Milestones.EdBr Forecast date");
            builder.Property(e => e.FsgPreOpeningMilestonesFaActualDateOfCompletion)
                .HasColumnType("date")
                .HasColumnName("FSG Pre Opening Milestones.FA Actual date of completion");
            builder.Property(e => e.FsgPreOpeningMilestonesFaBaselineDate)
                .HasColumnType("date")
                .HasColumnName("FSG Pre Opening Milestones.FA Baseline date");
            builder.Property(e => e.FsgPreOpeningMilestonesFaForecastDate)
                .HasColumnType("date")
                .HasColumnName("FSG Pre Opening Milestones.FA Forecast date");
            builder.Property(e => e.FsgPreOpeningMilestonesFcpActualDateOfCompletion)
                .HasColumnType("date")
                .HasColumnName("FSG Pre Opening Milestones.FCP Actual date of completion");
            builder.Property(e => e.FsgPreOpeningMilestonesFcpBaselineDate)
                .HasColumnType("date")
                .HasColumnName("FSG Pre Opening Milestones.FCP Baseline date");
            builder.Property(e => e.FsgPreOpeningMilestonesFcpForecastDate)
                .HasColumnType("date")
                .HasColumnName("FSG Pre Opening Milestones.FCP Forecast date");
            builder.Property(e => e.FsgPreOpeningMilestonesFgpaActualDateOfCompletion)
                .HasColumnType("date")
                .HasColumnName("FSG Pre Opening Milestones.FGPA Actual date of completion");
            builder.Property(e => e.FsgPreOpeningMilestonesFgpaBaselineDate)
                .HasColumnType("date")
                .HasColumnName("FSG Pre Opening Milestones.FGPA Baseline date");
            builder.Property(e => e.FsgPreOpeningMilestonesFgpaForecastDate)
                .HasColumnType("date")
                .HasColumnName("FSG Pre Opening Milestones.FGPA Forecast date");
            builder.Property(e => e.FsgPreOpeningMilestonesFpaActualDateOfCompletion)
                .HasColumnType("date")
                .HasColumnName("FSG Pre Opening Milestones.FPA Actual date of completion");
            builder.Property(e => e.FsgPreOpeningMilestonesFpaBaselineDate)
                .HasColumnType("date")
                .HasColumnName("FSG Pre Opening Milestones.FPA Baseline date");
            builder.Property(e => e.FsgPreOpeningMilestonesFpaForecastDate)
                .HasColumnType("date")
                .HasColumnName("FSG Pre Opening Milestones.FPA Forecast date");
            builder.Property(e => e.FsgPreOpeningMilestonesFsrdActualDateOfCompletion)
                .HasColumnType("date")
                .HasColumnName("FSG Pre Opening Milestones.FSRD Actual date of completion");
            builder.Property(e => e.FsgPreOpeningMilestonesFsrdBaselineDate)
                .HasColumnType("date")
                .HasColumnName("FSG Pre Opening Milestones.FSRD Baseline date");
            builder.Property(e => e.FsgPreOpeningMilestonesFsrdForecastDate)
                .HasColumnType("date")
                .HasColumnName("FSG Pre Opening Milestones.FSRD Forecast date");
            builder.Property(e => e.FsgPreOpeningMilestonesGiasActualDateOfCompletion)
                .HasColumnType("date")
                .HasColumnName("FSG Pre Opening Milestones.GIAS Actual date of completion");
            builder.Property(e => e.FsgPreOpeningMilestonesGiasBaselineDate)
                .HasColumnType("date")
                .HasColumnName("FSG Pre Opening Milestones.GIAS Baseline date");
            builder.Property(e => e.FsgPreOpeningMilestonesGiasForecastDate)
                .HasColumnType("date")
                .HasColumnName("FSG Pre Opening Milestones.GIAS Forecast date");
            builder.Property(e => e.FSGPreOpeningMilestonesGIASCheckedTrustInformation)
                .HasColumnType("bit")
                .HasColumnName("FSG Pre Opening Milestones.GIASCheckedTrustInformation");
            builder.Property(e => e.FSGPreOpeningMilestonesGIASApplicationFormSent)
                .HasColumnType("bit")
                .HasColumnName("FSG Pre Opening Milestones.GIASApplicationFormSent");
            builder.Property(e => e.FSGPreOpeningMilestonesGIASSavedToWorkspaces)
                .HasColumnType("bit")
                .HasColumnName("FSG Pre Opening Milestones.GIASSavedToWorkspaces");
            builder.Property(e => e.FSGPreOpeningMilestonesGIASURNSent)
                .HasColumnType("bit")
                .HasColumnName("FSG Pre Opening Milestones.GIASURNSent");
            builder.Property(e => e.FsgPreOpeningMilestonesHaveYouCompletedAndSavedYourRiskAppraisalForm)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("FSG Pre Opening Milestones.Have you completed and saved your Risk Appraisal Form?");
            builder.Property(e => e.FsgPreOpeningMilestonesIaeaActualDateOfCompletion)
                .HasColumnType("date")
                .HasColumnName("FSG Pre Opening Milestones.IAEA Actual date of completion");
            builder.Property(e => e.FsgPreOpeningMilestonesIaeaBaselineDate)
                .HasColumnType("date")
                .HasColumnName("FSG Pre Opening Milestones.IAEA Baseline date");
            builder.Property(e => e.FsgPreOpeningMilestonesIaeaForecastDate)
                .HasColumnType("date")
                .HasColumnName("FSG Pre Opening Milestones.IAEA Forecast date");
            builder.Property(e => e.FsgPreOpeningMilestonesInspectionConditionsMet)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("FSG Pre Opening Milestones.Inspection conditions met?");
            builder.Property(e => e.FsgPreOpeningMilestonesIsThisProjectRatedHighOrLowRiskForEducation)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("FSG Pre Opening Milestones.Is this project rated high or low risk for education?");
            builder.Property(e => e.FsgPreOpeningMilestonesIsThisProjectRatedHighOrLowRiskForFinance)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("FSG Pre Opening Milestones.Is this project rated high or low risk for finance?");
            builder.Property(e => e.FsgPreOpeningMilestonesIsThisProjectRatedHighOrLowRiskForGovernance)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("FSG Pre Opening Milestones.Is this project rated high or low risk for governance?");
            builder.Property(e => e.FsgPreOpeningMilestonesKickOffMeetingHeldActualDate)
                .HasColumnType("date")
                .HasColumnName("FSG Pre Opening Milestones.Kick off meeting held Actual Date");
            builder.Property(e => e.FsgPreOpeningMilestonesLinkToRiskAppraisalForm)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("FSG Pre Opening Milestones.Link to Risk Appraisal Form");
            builder.Property(e => e.FsgPreOpeningMilestonesMaaActualDateOfCompletion)
                .HasColumnType("date")
                .HasColumnName("FSG Pre Opening Milestones.MAA Actual date of completion");
            builder.Property(e => e.FsgPreOpeningMilestonesMaaBaselineDate)
                .HasColumnType("date")
                .HasColumnName("FSG Pre Opening Milestones.MAA Baseline date");
            builder.Property(e => e.FsgPreOpeningMilestonesMaaForecastDate)
                .HasColumnType("date")
                .HasColumnName("FSG Pre Opening Milestones.MAA Forecast date");
            builder.Property(e => e.FsgPreOpeningMilestonesMfadActualDateOfCompletion)
                .HasColumnType("date")
                .HasColumnName("FSG Pre Opening Milestones.MFAD  Actual date of completion");
            builder.Property(e => e.FsgPreOpeningMilestonesMfadBaselineDate)
                .HasColumnType("date")
                .HasColumnName("FSG Pre Opening Milestones.MFAD  Baseline date");
            builder.Property(e => e.FsgPreOpeningMilestonesMfadForecastDate)
                .HasColumnType("date")
                .HasColumnName("FSG Pre Opening Milestones.MFAD Forecast date");
            builder.Property(e => e.FsgPreOpeningMilestonesMi101CommentsOnDecisionToApproveIfApplicable)
                .HasMaxLength(999)
                .IsUnicode(false)
                .HasColumnName("FSG Pre Opening Milestones.MI101_Comments on decision to approve (if applicable)");
            builder.Property(e => e.FsgPreOpeningMilestonesMi103CommentsOnDecisionToApproveIfApplicable)
                .HasMaxLength(999)
                .IsUnicode(false)
                .HasColumnName("FSG Pre Opening Milestones.MI103_Comments on decision to approve (if applicable)");
            builder.Property(e => e.FsgPreOpeningMilestonesMi105LinkToSavedDocument)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("FSG Pre Opening Milestones.MI105_Link to saved document");
            builder.Property(e => e.FsgPreOpeningMilestonesMi107LinkToSavedDocument)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("FSG Pre Opening Milestones.MI107_Link to saved document");
            builder.Property(e => e.FsgPreOpeningMilestonesMi109LinkToSavedDocument)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("FSG Pre Opening Milestones.MI109_Link to saved document");
            builder.Property(e => e.FsgPreOpeningMilestonesMi111LinkToSavedDocument)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("FSG Pre Opening Milestones.MI111_Link to saved document");
            builder.Property(e => e.FsgPreOpeningMilestonesMi113LinkToSavedDocument)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("FSG Pre Opening Milestones.MI113_Link to saved document");
            builder.Property(e => e.FsgPreOpeningMilestonesMi115LinkToSavedDocument)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("FSG Pre Opening Milestones.MI115_Link to saved document");
            builder.Property(e => e.FsgPreOpeningMilestonesMi117LinkToSavedDocument)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("FSG Pre Opening Milestones.MI117_Link to saved document");
            builder.Property(e => e.FsgPreOpeningMilestonesMi119LinkToSavedDocument)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("FSG Pre Opening Milestones.MI119_Link to saved document");
            builder.Property(e => e.FsgPreOpeningMilestonesMi121LinkToSavedDocument)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("FSG Pre Opening Milestones.MI121_Link to saved document");
            builder.Property(e => e.FsgPreOpeningMilestonesMi123LinkToSavedDocument)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("FSG Pre Opening Milestones.MI123_Link to saved document");
            builder.Property(e => e.FsgPreOpeningMilestonesMi125LinkToSavedDocument)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("FSG Pre Opening Milestones.MI125_Link to saved document");
            builder.Property(e => e.FsgPreOpeningMilestonesMi127LinkToSavedDocument)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("FSG Pre Opening Milestones.MI127_Link to saved document");
            builder.Property(e => e.FsgPreOpeningMilestonesMi129LinkToSavedDocument)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("FSG Pre Opening Milestones.MI129_Link to saved document");
            builder.Property(e => e.FsgPreOpeningMilestonesMi131LinkToSavedDocument)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("FSG Pre Opening Milestones.MI131_Link to saved document");
            builder.Property(e => e.FsgPreOpeningMilestonesMi133LinkToSavedDocument)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("FSG Pre Opening Milestones.MI133_Link to saved document");
            builder.Property(e => e.FsgPreOpeningMilestonesMi135LinkToSavedDocument)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("FSG Pre Opening Milestones.MI135_Link to saved document");
            builder.Property(e => e.FsgPreOpeningMilestonesMi137LinkToSavedDocument)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("FSG Pre Opening Milestones.MI137_Link to saved document");
            builder.Property(e => e.FsgPreOpeningMilestonesMi139LinkToSavedDocument)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("FSG Pre Opening Milestones.MI139_Link to saved document");
            builder.Property(e => e.FsgPreOpeningMilestonesMi141LinkToSavedDocument)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("FSG Pre Opening Milestones.MI141_Link to saved document");
            builder.Property(e => e.FsgPreOpeningMilestonesMi143LinkToSavedDocument)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("FSG Pre Opening Milestones.MI143_Link to saved document");
            builder.Property(e => e.FsgPreOpeningMilestonesMi145LinkToSavedDocument)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("FSG Pre Opening Milestones.MI145_Link to saved document");
            builder.Property(e => e.FsgPreOpeningMilestonesMi147LinkToSavedDocument)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("FSG Pre Opening Milestones.MI147_Link to saved document");
            builder.Property(e => e.FsgPreOpeningMilestonesMi149LinkToSavedDocument)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("FSG Pre Opening Milestones.MI149_Link to saved document");
            builder.Property(e => e.FsgPreOpeningMilestonesMi151LinkToSavedDocument)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("FSG Pre Opening Milestones.MI151_Link to saved document");
            builder.Property(e => e.FsgPreOpeningMilestonesMi153LinkToSavedDocument)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("FSG Pre Opening Milestones.MI153_Link to saved document");
            builder.Property(e => e.FsgPreOpeningMilestonesMi155LinkToSavedDocument)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("FSG Pre Opening Milestones.MI155_Link to saved document");
            builder.Property(e => e.FsgPreOpeningMilestonesMi54CommentsOnDecisionToApproveIfApplicable)
                .HasMaxLength(999)
                .IsUnicode(false)
                .HasColumnName("FSG Pre Opening Milestones.MI54_Comments on decision to approve (if applicable)");
            builder.Property(e => e.FsgPreOpeningMilestonesMi56CommentsOnDecisionToApproveIfApplicable)
                .HasMaxLength(999)
                .IsUnicode(false)
                .HasColumnName("FSG Pre Opening Milestones.MI56_Comments on decision to approve (if applicable)");
            builder.Property(e => e.FsgPreOpeningMilestonesMi58CommentsOnDecisionToApproveIfApplicable)
                .HasMaxLength(999)
                .IsUnicode(false)
                .HasColumnName("FSG Pre Opening Milestones.MI58_Comments on decision to approve (if applicable)");
            builder.Property(e => e.FsgPreOpeningMilestonesMi60CommentsOnDecisionToApproveIfApplicable)
                .HasMaxLength(999)
                .IsUnicode(false)
                .HasColumnName("FSG Pre Opening Milestones.MI60_Comments on decision to approve (if applicable)");
            builder.Property(e => e.FsgPreOpeningMilestonesMi62CommentsOnDecisionToApproveIfApplicable)
                .HasMaxLength(999)
                .IsUnicode(false)
                .HasColumnName("FSG Pre Opening Milestones.MI62_Comments on decision to approve (if applicable)");
            builder.Property(e => e.FsgPreOpeningMilestonesMi64CommentsOnDecisionToApproveIfApplicable)
                .HasMaxLength(999)
                .IsUnicode(false)
                .HasColumnName("FSG Pre Opening Milestones.MI64_Comments on decision to approve (if applicable)");
            builder.Property(e => e.FsgPreOpeningMilestonesMi66CommentsOnDecisionToApproveIfApplicable)
                .HasMaxLength(999)
                .IsUnicode(false)
                .HasColumnName("FSG Pre Opening Milestones.MI66_Comments on decision to approve (if applicable)");
            builder.Property(e => e.FsgPreOpeningMilestonesMi68CommentsOnDecisionToApproveIfApplicable)
                .HasMaxLength(999)
                .IsUnicode(false)
                .HasColumnName("FSG Pre Opening Milestones.MI68_Comments on decision to approve (if applicable)");
            builder.Property(e => e.FsgPreOpeningMilestonesMi70CommentsOnDecisionToApproveIfApplicable)
                .HasMaxLength(999)
                .IsUnicode(false)
                .HasColumnName("FSG Pre Opening Milestones.MI70_Comments on decision to approve (if applicable)");
            builder.Property(e => e.FsgPreOpeningMilestonesMi72CommentsOnDecisionToApproveIfApplicable)
                .HasMaxLength(999)
                .IsUnicode(false)
                .HasColumnName("FSG Pre Opening Milestones.MI72_Comments on decision to approve (if applicable)");
            builder.Property(e => e.FsgPreOpeningMilestonesMi74CommentsOnDecisionToApproveIfApplicable)
                .HasMaxLength(999)
                .IsUnicode(false)
                .HasColumnName("FSG Pre Opening Milestones.MI74_Comments on decision to approve (if applicable)");
            builder.Property(e => e.FsgPreOpeningMilestonesMi76CommentsOnDecisionToApproveIfApplicable)
                .HasMaxLength(999)
                .IsUnicode(false)
                .HasColumnName("FSG Pre Opening Milestones.MI76_Comments on decision to approve (if applicable)");
            builder.Property(e => e.FsgPreOpeningMilestonesMi78CommentsOnDecisionToApproveIfApplicable)
                .HasMaxLength(999)
                .IsUnicode(false)
                .HasColumnName("FSG Pre Opening Milestones.MI78_Comments on decision to approve (if applicable)");
            builder.Property(e => e.FsgPreOpeningMilestonesMi80CommentsOnDecisionToApproveIfApplicable)
                .HasMaxLength(999)
                .IsUnicode(false)
                .HasColumnName("FSG Pre Opening Milestones.MI80_Comments on decision to approve (if applicable)");
            builder.Property(e => e.FsgPreOpeningMilestonesMi81CommentsOnDecisionToApproveIfApplicable)
                .HasMaxLength(999)
                .IsUnicode(false)
                .HasColumnName("FSG Pre Opening Milestones.MI81_Comments on decision to approve (if applicable)");
            builder.Property(e => e.FsgPreOpeningMilestonesMi83CommentsOnDecisionToApproveIfApplicable)
                .HasMaxLength(999)
                .IsUnicode(false)
                .HasColumnName("FSG Pre Opening Milestones.MI83_Comments on decision to approve (if applicable)");
            builder.Property(e => e.FsgPreOpeningMilestonesMi85CommentsOnDecisionToApproveIfApplicable)
                .HasMaxLength(999)
                .IsUnicode(false)
                .HasColumnName("FSG Pre Opening Milestones.MI85_Comments on decision to approve (if applicable)");
            builder.Property(e => e.FsgPreOpeningMilestonesMi87CommentsOnDecisionToApproveIfApplicable)
                .HasMaxLength(999)
                .IsUnicode(false)
                .HasColumnName("FSG Pre Opening Milestones.MI87_Comments on decision to approve (if applicable)");
            builder.Property(e => e.FsgPreOpeningMilestonesMi89CommentsOnDecisionToApproveIfApplicable)
                .HasMaxLength(999)
                .IsUnicode(false)
                .HasColumnName("FSG Pre Opening Milestones.MI89_Comments on decision to approve (if applicable)");
            builder.Property(e => e.FsgPreOpeningMilestonesMi91CommentsOnDecisionToApproveIfApplicable)
                .HasMaxLength(999)
                .IsUnicode(false)
                .HasColumnName("FSG Pre Opening Milestones.MI91_Comments on decision to approve (if applicable)");
            builder.Property(e => e.FsgPreOpeningMilestonesMi93CommentsOnDecisionToApproveIfApplicable)
                .HasMaxLength(999)
                .IsUnicode(false)
                .HasColumnName("FSG Pre Opening Milestones.MI93_Comments on decision to approve (if applicable)");
            builder.Property(e => e.FsgPreOpeningMilestonesMi95CommentsOnDecisionToApproveIfApplicable)
                .HasMaxLength(999)
                .IsUnicode(false)
                .HasColumnName("FSG Pre Opening Milestones.MI95_Comments on decision to approve (if applicable)");
            builder.Property(e => e.FsgPreOpeningMilestonesMi97CommentsOnDecisionToApproveIfApplicable)
                .HasMaxLength(999)
                .IsUnicode(false)
                .HasColumnName("FSG Pre Opening Milestones.MI97_Comments on decision to approve (if applicable)");
            builder.Property(e => e.FsgPreOpeningMilestonesMi99CommentsOnDecisionToApproveIfApplicable)
                .HasMaxLength(999)
                .IsUnicode(false)
                .HasColumnName("FSG Pre Opening Milestones.MI99_Comments on decision to approve (if applicable)");
            builder.Property(e => e.FsgPreOpeningMilestonesOprActualDateOfCompletion)
                .HasColumnType("date")
                .HasColumnName("FSG Pre Opening Milestones.OPR Actual date of completion");
            builder.Property(e => e.FsgPreOpeningMilestonesOprBaselineDate)
                .HasColumnType("date")
                .HasColumnName("FSG Pre Opening Milestones.OPR Baseline date");
            builder.Property(e => e.FsgPreOpeningMilestonesOprForecastDate)
                .HasColumnType("date")
                .HasColumnName("FSG Pre Opening Milestones.OPR Forecast date");
            builder.Property(e => e.FsgPreOpeningMilestonesOutcomeOfInspectionAsAdvisedByOfsted)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("FSG Pre Opening Milestones.Outcome of inspection as advised by Ofsted");
            builder.Property(e => e.FsgPreOpeningMilestonesOutcomeOfRom)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("FSG Pre Opening Milestones.Outcome of ROM");
            builder.Property(e => e.FsgPreOpeningMilestonesPdappActualDateOfCompletion)
                .HasColumnType("date")
                .HasColumnName("FSG Pre Opening Milestones.PDapp Actual date of completion");
            builder.Property(e => e.FsgPreOpeningMilestonesPdappBaselineDate)
                .HasColumnType("date")
                .HasColumnName("FSG Pre Opening Milestones.PDapp Baseline date");
            builder.Property(e => e.FsgPreOpeningMilestonesPdappForecastDate)
                .HasColumnType("date")
                .HasColumnName("FSG Pre Opening Milestones.PDapp Forecast date");
            builder.Property(e => e.FsgPreOpeningMilestonesPfacmActualDateOfCompletion)
                .HasColumnType("date")
                .HasColumnName("FSG Pre Opening Milestones.PFACM Actual date of completion");
            builder.Property(e => e.FsgPreOpeningMilestonesPfacmBaselineDate)
                .HasColumnType("date")
                .HasColumnName("FSG Pre Opening Milestones.PFACM Baseline date");
            builder.Property(e => e.FsgPreOpeningMilestonesPfacmForecastDate)
                .HasColumnType("date")
                .HasColumnName("FSG Pre Opening Milestones.PFACM Forecast date");
            builder.Property(e => e.FsgPreOpeningMilestonesPfacmMilestoneApplicable)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("FSG Pre Opening Milestones.PFACM - Milestone applicable");
            builder.Property(e => e.FsgPreOpeningMilestonesPfacmReasonNotApplicable)
                .IsUnicode(false)
                .HasColumnName("FSG Pre Opening Milestones.PFACM - Reason not applicable");
            builder.Property(e => e.FsgPreOpeningMilestonesRomActualDateOfCompletion)
                .HasColumnType("date")
                .HasColumnName("FSG Pre Opening Milestones.ROM Actual date of completion");
            builder.Property(e => e.FsgPreOpeningMilestonesRomBaselineDate)
                .HasColumnType("date")
                .HasColumnName("FSG Pre Opening Milestones.ROM Baseline date");
            builder.Property(e => e.FsgPreOpeningMilestonesRomConditionsMet)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("FSG Pre Opening Milestones.ROM conditions met?");
            builder.Property(e => e.FsgPreOpeningMilestonesRomForecastDate)
                .HasColumnType("date")
                .HasColumnName("FSG Pre Opening Milestones.ROM Forecast date");
            builder.Property(e => e.FsgPreOpeningMilestonesRomReasonNotApplicable)
                .IsUnicode(false)
                .HasColumnName("FSG Pre Opening Milestones.ROM - Reason not applicable");
            builder.Property(e => e.FsgPreOpeningMilestonesS9lActualDateOfCompletion)
                .HasColumnType("date")
                .HasColumnName("FSG Pre Opening Milestones.S9L Actual date of completion");
            builder.Property(e => e.FsgPreOpeningMilestonesS9lBaselineDate)
                .HasColumnType("date")
                .HasColumnName("FSG Pre Opening Milestones.S9L Baseline date");
            builder.Property(e => e.FsgPreOpeningMilestonesS9lForecastDate)
                .HasColumnType("date")
                .HasColumnName("FSG Pre Opening Milestones.S9L Forecast date");
            builder.Property(e => e.FsgPreOpeningMilestonesSapActualDateOfCompletion)
                .HasColumnType("date")
                .HasColumnName("FSG Pre Opening Milestones.SAP Actual date of completion");
            builder.Property(e => e.FsgPreOpeningMilestonesAdmissionsArrangementsRecommendedTemplate)
                .HasColumnType("bit")
                .HasColumnName("Fsg Pre Opening Milestones. Admissions Arrangements Recommended Template");
            builder.Property(e => e.FsgPreOpeningMilestonesAdmissionsArrangementsComplyWithPolicies)
                .HasColumnType("bit")
                .HasColumnName("Fsg Pre Opening Milestones. Admissions Arrangements Comply With Policies");
            builder.Property(e => e.FsgPreOpeningMilestonesAdmissionsArrangementsSavedToWorkplaces)
                .HasColumnType("bit")
                .HasColumnName("Fsg Pre Opening Milestones. Admissions Arrangements Saved To Workplaces");
            builder.Property(e => e.FsgPreOpeningMilestonesSapBaselineDate)
                .HasColumnType("date")
                .HasColumnName("FSG Pre Opening Milestones.SAP Baseline date");
            builder.Property(e => e.FsgPreOpeningMilestonesSapForecastDate)
                .HasColumnType("date")
                .HasColumnName("FSG Pre Opening Milestones.SAP Forecast Date");
            builder.Property(e => e.FsgPreOpeningMilestonesSccActualDateOfCompletion)
                .HasColumnType("date")
                .HasColumnName("FSG Pre Opening Milestones.SCC Actual date of completion");
            builder.Property(e => e.FsgPreOpeningMilestonesSccBaselineDate)
                .HasColumnType("date")
                .HasColumnName("FSG Pre Opening Milestones.SCC Baseline date");
            builder.Property(e => e.FsgPreOpeningMilestonesSccForecastDate)
                .HasColumnType("date")
                .HasColumnName("FSG Pre Opening Milestones.SCC Forecast date");
            builder.Property(e => e.FsgPreOpeningMilestonesScrActualDateOfCompletion)
                .HasColumnType("date")
                .HasColumnName("FSG Pre Opening Milestones.SCR Actual date of completion");
            builder.Property(e => e.FsgPreOpeningMilestonesScrBaselineDate)
                .HasColumnType("date")
                .HasColumnName("FSG Pre Opening Milestones.SCR Baseline date");
            builder.Property(e => e.FsgPreOpeningMilestonesScrForecastDate)
                .HasColumnType("date")
                .HasColumnName("FSG Pre Opening Milestones.SCR Forecast date");
            builder.Property(e => e.FsgPreOpeningMilestonesSiteKickOffMeetingHeldActualDate)
                .HasColumnType("date")
                .HasColumnName("FSG Pre Opening Milestones.Site Kick off meeting held ( actual date)");
            builder.Property(e => e.FsgPreOpeningMilestonesViewCostPlan1)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("FSG Pre Opening Milestones.View Cost Plan 1");
            builder.Property(e => e.FsgPreOpeningMilestonesViewCostPlan2)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("FSG Pre Opening Milestones.View Cost Plan 2");
            builder.Property((e => e.FSGPreOpeningMilestonesEducationPlanInBrief))
                .HasColumnType("bit")
                .HasColumnName("FSG Pre Opening Milestones. Education Plan In Brief");
            builder.Property((e => e.FSGPreOpeningMilestonesEducationPolicesInBrief))
                .HasColumnType("bit")
                .HasColumnName("FSG Pre Opening Milestones. Education Policies In Brief");
            builder.Property((e => e.FSGPreOpeningMilestonesEducationBriefPupilAssessmentAndTrackingHistory))
                .HasColumnType("bit")
                .HasColumnName("FSG Pre Opening Milestones. Pupil assessment and tracking history in place");
            builder.Property((e => e.FSGPreOpeningMilestonesEducationBriefSavedToWorkplaces))
                .HasColumnType("bit")
                .HasColumnName("FSG Pre Opening Milestones. Education Brief Saved To Workplaces");
             builder.Property((e => e.FsgPreOpeningMilestonesImpactAssessmentDone))
                .HasColumnType("bit")
                .HasColumnName("FSG Pre Opening. Milestones Impact Assessment Done");
            builder.Property((e => e.FsgPreOpeningMilestonesImpactAssessmentSavedToWorkplaces))
                .HasColumnType("bit")
                .HasColumnName("FSG Pre Opening. Milestones Impact Assessment Saved To Workplaces");
            builder.Property(e => e.FsgPreOpeningMilestonesSeenEvidenceOfAcceptedOffers)
                .HasColumnType("bit")
                .HasColumnName("Fsg Pre Opening Milestones. Seen Evidence Of Accepted Offers");
            builder.Property(e => e.FsgPreOpeningMilestonesAcceptedOffersComments)
                .HasMaxLength(999)
                .IsUnicode(false)
                .HasColumnName("Fsg Pre Opening Milestones. Accepted Offers Comments");
            builder.Property(e => e.FsgPreOpeningMilestonesAcceptedOffersEmailSavedToWorkplaces)
                .HasColumnType("bit")
                .HasColumnName("Fsg Pre Opening Milestones. Accepted Offers Email Saved To Workplaces");
            builder.Property(e => e.FsgPreOpeningMilestonesProcessDetailsProvided)
                .HasColumnType("bit")
                .HasColumnName("Fsg Pre Opening Milestones. Process Details Provided");
            builder.Property(e => e.FsgPreOpeningMilestonesInspectionBlockDecided)
                .HasColumnType("bit")
                .HasColumnName("Fsg Pre Opening Milestones. Inspection Block Decided");
            builder.Property(e => e.FsgPreOpeningMilestonesOfstedAndTrustLiaisonDetailsConfirmed)
                .HasColumnType("bit")
                .HasColumnName("Fsg Pre Opening Milestones. Ofsted And Trust Liaison Details Confirmed");
            builder.Property(e => e.FsgPreOpeningMilestonesBlockAndContentDetailsToOpenersSpreadSheet)
                .HasColumnType("bit")
                .HasColumnName("Fsg Pre Opening Milestones. Block And Content Details To Openers SpreadSheet");
            builder.Property(e => e.FsgPreOpeningMilestonesSharedOutcomeWithTrust)
                .HasColumnType("bit")
                .HasColumnName("Fsg Pre Opening Milestones. Shared Outcome With Trust");
            builder.Property(e => e.FsgPreOpeningMilestonesProposedToOpenOnGias)
                .HasColumnType("bit")
                .HasColumnName("Fsg Pre Opening Milestones. Proposed To Open On Gias");
            builder.Property(e => e.FsgPreOpeningMilestonesDocumentsAndG6SavedToWorkplaces)
                .HasColumnType("bit")
                .HasColumnName("Fsg Pre Opening Milestones. Documents And G6 Saved To Workplaces");
            builder.Property(e => e.FsgPreOpeningMilestonesApplicationsEvidenceConfirmedPupilNumbers)
                .HasColumnType("bit")
                .HasColumnName("Fsg Pre Opening Milestones. applications evidence confirmed pupil numbers");
            builder.Property(e => e.FsgPreOpeningMilestonesApplicationsEvidenceComments)
                .HasMaxLength(999)
                .IsUnicode(false)
                .HasColumnName("Fsg Pre Opening Milestones. applications evidence comments");
            builder.Property(e => e.FsgPreOpeningMilestonesApplicationsEvidenceBuildUpFormSavedToWorkplaces)
                .HasColumnType("bit")
                .HasColumnName("Fsg Pre Opening Milestones. applications evidence build up form saved to workplaces");
            builder.Property(e => e.FsgPreOpeningMilestonesApplicationsEvidenceUnderwritingAgreementSavedToWorkplaces)
                .HasColumnType("bit")
                .HasColumnName("Fsg Pre Opening Milestones. applications evidence underwriting agreement saved to workplaces");
            builder.Property(e => e.PRid)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasColumnName("p_rid");
            builder.Property(e => e.Rid)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasColumnName("RID");
            builder.Property(e => e.MAACheckedSubmittedArticlesMatch)
                .HasColumnType("bit");
            builder.Property(e => e.MAAChairHaveSubmittedConfirmation)
                .HasColumnType("bit");
            builder.Property(e => e.MAAArrangementsMatchGovernancePlans)
                .HasColumnType("bit");
            builder.Property(e => e.RPACoverType)
                .HasMaxLength(100)
                .IsUnicode(false);

            AuditConfiguration.Apply(builder);
        }
	}

}
