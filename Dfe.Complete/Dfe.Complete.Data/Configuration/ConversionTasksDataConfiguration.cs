using System;
using System.Collections.Generic;
using Dfe.Complete.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dfe.Complete.Data.Configuration
{
    public partial class ConversionTasksDataConfiguration : IEntityTypeConfiguration<ConversionTasksDatum>
    {
        public void Configure(EntityTypeBuilder<ConversionTasksDatum> builder)
        {
            builder.HasKey(e => e.Id).HasName("PK__conversi__3213E83F5864AE8A");

            builder.ToTable("conversion_tasks_data", "complete");

            builder.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("id");
            builder.Property(e => e.AcademyDetailsName)
                .HasMaxLength(4000)
                .HasColumnName("academy_details_name");
            builder.Property(e => e.ArticlesOfAssociationCleared).HasColumnName("articles_of_association_cleared");
            builder.Property(e => e.ArticlesOfAssociationNotApplicable).HasColumnName("articles_of_association_not_applicable");
            builder.Property(e => e.ArticlesOfAssociationReceived).HasColumnName("articles_of_association_received");
            builder.Property(e => e.ArticlesOfAssociationSaved).HasColumnName("articles_of_association_saved");
            builder.Property(e => e.ArticlesOfAssociationSigned).HasColumnName("articles_of_association_signed");
            builder.Property(e => e.CheckAccuracyOfHigherNeedsConfirmNumber).HasColumnName("check_accuracy_of_higher_needs_confirm_number");
            builder.Property(e => e.CheckAccuracyOfHigherNeedsConfirmPublishedNumber).HasColumnName("check_accuracy_of_higher_needs_confirm_published_number");
            builder.Property(e => e.ChurchSupplementalAgreementCleared).HasColumnName("church_supplemental_agreement_cleared");
            builder.Property(e => e.ChurchSupplementalAgreementNotApplicable).HasColumnName("church_supplemental_agreement_not_applicable");
            builder.Property(e => e.ChurchSupplementalAgreementReceived).HasColumnName("church_supplemental_agreement_received");
            builder.Property(e => e.ChurchSupplementalAgreementSaved).HasColumnName("church_supplemental_agreement_saved");
            builder.Property(e => e.ChurchSupplementalAgreementSent).HasColumnName("church_supplemental_agreement_sent");
            builder.Property(e => e.ChurchSupplementalAgreementSigned).HasColumnName("church_supplemental_agreement_signed");
            builder.Property(e => e.ChurchSupplementalAgreementSignedDiocese).HasColumnName("church_supplemental_agreement_signed_diocese");
            builder.Property(e => e.ChurchSupplementalAgreementSignedSecretaryState).HasColumnName("church_supplemental_agreement_signed_secretary_state");
            builder.Property(e => e.CommercialTransferAgreementEmailSigned).HasColumnName("commercial_transfer_agreement_email_signed");
            builder.Property(e => e.CommercialTransferAgreementReceiveSigned).HasColumnName("commercial_transfer_agreement_receive_signed");
            builder.Property(e => e.CommercialTransferAgreementSaveSigned).HasColumnName("commercial_transfer_agreement_save_signed");
            builder.Property(e => e.CompleteNotificationOfChangeCheckDocument).HasColumnName("complete_notification_of_change_check_document");
            builder.Property(e => e.CompleteNotificationOfChangeNotApplicable).HasColumnName("complete_notification_of_change_not_applicable");
            builder.Property(e => e.CompleteNotificationOfChangeSendDocument).HasColumnName("complete_notification_of_change_send_document");
            builder.Property(e => e.CompleteNotificationOfChangeTellLocalAuthority).HasColumnName("complete_notification_of_change_tell_local_authority");
            builder.Property(e => e.ConfirmDateAcademyOpenedDateOpened)
                .HasColumnType("date")
                .HasColumnName("confirm_date_academy_opened_date_opened");
            builder.Property(e => e.ConversionGrantCheckVendorAccount).HasColumnName("conversion_grant_check_vendor_account");
            builder.Property(e => e.ConversionGrantNotApplicable).HasColumnName("conversion_grant_not_applicable");
            builder.Property(e => e.ConversionGrantPaymentForm).HasColumnName("conversion_grant_payment_form");
            builder.Property(e => e.ConversionGrantSendInformation).HasColumnName("conversion_grant_send_information");
            builder.Property(e => e.ConversionGrantSharePaymentDate).HasColumnName("conversion_grant_share_payment_date");
            builder.Property(e => e.CreatedAt)
                .HasPrecision(6)
                .HasColumnName("created_at");
            builder.Property(e => e.DeedOfVariationCleared).HasColumnName("deed_of_variation_cleared");
            builder.Property(e => e.DeedOfVariationNotApplicable).HasColumnName("deed_of_variation_not_applicable");
            builder.Property(e => e.DeedOfVariationReceived).HasColumnName("deed_of_variation_received");
            builder.Property(e => e.DeedOfVariationSaved).HasColumnName("deed_of_variation_saved");
            builder.Property(e => e.DeedOfVariationSent).HasColumnName("deed_of_variation_sent");
            builder.Property(e => e.DeedOfVariationSigned).HasColumnName("deed_of_variation_signed");
            builder.Property(e => e.DeedOfVariationSignedSecretaryState).HasColumnName("deed_of_variation_signed_secretary_state");
            builder.Property(e => e.DirectionToTransferCleared).HasColumnName("direction_to_transfer_cleared");
            builder.Property(e => e.DirectionToTransferNotApplicable).HasColumnName("direction_to_transfer_not_applicable");
            builder.Property(e => e.DirectionToTransferReceived).HasColumnName("direction_to_transfer_received");
            builder.Property(e => e.DirectionToTransferSaved).HasColumnName("direction_to_transfer_saved");
            builder.Property(e => e.DirectionToTransferSigned).HasColumnName("direction_to_transfer_signed");
            builder.Property(e => e.HandoverMeeting).HasColumnName("handover_meeting");
            builder.Property(e => e.HandoverNotApplicable).HasColumnName("handover_not_applicable");
            builder.Property(e => e.HandoverNotes).HasColumnName("handover_notes");
            builder.Property(e => e.HandoverReview).HasColumnName("handover_review");
            builder.Property(e => e.LandQuestionnaireCleared).HasColumnName("land_questionnaire_cleared");
            builder.Property(e => e.LandQuestionnaireReceived).HasColumnName("land_questionnaire_received");
            builder.Property(e => e.LandQuestionnaireSaved).HasColumnName("land_questionnaire_saved");
            builder.Property(e => e.LandQuestionnaireSigned).HasColumnName("land_questionnaire_signed");
            builder.Property(e => e.LandRegistryCleared).HasColumnName("land_registry_cleared");
            builder.Property(e => e.LandRegistryReceived).HasColumnName("land_registry_received");
            builder.Property(e => e.LandRegistrySaved).HasColumnName("land_registry_saved");
            builder.Property(e => e.MasterFundingAgreementCleared).HasColumnName("master_funding_agreement_cleared");
            builder.Property(e => e.MasterFundingAgreementNotApplicable).HasColumnName("master_funding_agreement_not_applicable");
            builder.Property(e => e.MasterFundingAgreementReceived).HasColumnName("master_funding_agreement_received");
            builder.Property(e => e.MasterFundingAgreementSaved).HasColumnName("master_funding_agreement_saved");
            builder.Property(e => e.MasterFundingAgreementSent).HasColumnName("master_funding_agreement_sent");
            builder.Property(e => e.MasterFundingAgreementSigned).HasColumnName("master_funding_agreement_signed");
            builder.Property(e => e.MasterFundingAgreementSignedSecretaryState).HasColumnName("master_funding_agreement_signed_secretary_state");
            builder.Property(e => e.OneHundredAndTwentyFiveYearLeaseEmail).HasColumnName("one_hundred_and_twenty_five_year_lease_email");
            builder.Property(e => e.OneHundredAndTwentyFiveYearLeaseNotApplicable).HasColumnName("one_hundred_and_twenty_five_year_lease_not_applicable");
            builder.Property(e => e.OneHundredAndTwentyFiveYearLeaseReceive).HasColumnName("one_hundred_and_twenty_five_year_lease_receive");
            builder.Property(e => e.OneHundredAndTwentyFiveYearLeaseSaveLease).HasColumnName("one_hundred_and_twenty_five_year_lease_save_lease");
            builder.Property(e => e.ProposedCapacityOfTheAcademyNotApplicable).HasColumnName("proposed_capacity_of_the_academy_not_applicable");
            builder.Property(e => e.ProposedCapacityOfTheAcademyReceptionToSixYears)
                .HasMaxLength(4000)
                .HasColumnName("proposed_capacity_of_the_academy_reception_to_six_years");
            builder.Property(e => e.ProposedCapacityOfTheAcademySevenToElevenYears)
                .HasMaxLength(4000)
                .HasColumnName("proposed_capacity_of_the_academy_seven_to_eleven_years");
            builder.Property(e => e.ProposedCapacityOfTheAcademyTwelveOrAboveYears)
                .HasMaxLength(4000)
                .HasColumnName("proposed_capacity_of_the_academy_twelve_or_above_years");
            builder.Property(e => e.ReceiveGrantPaymentCertificateCheckCertificate).HasColumnName("receive_grant_payment_certificate_check_certificate");
            builder.Property(e => e.ReceiveGrantPaymentCertificateDateReceived)
                .HasColumnType("date")
                .HasColumnName("receive_grant_payment_certificate_date_received");
            builder.Property(e => e.ReceiveGrantPaymentCertificateSaveCertificate).HasColumnName("receive_grant_payment_certificate_save_certificate");
            builder.Property(e => e.RedactAndSendRedact).HasColumnName("redact_and_send_redact");
            builder.Property(e => e.RedactAndSendSaveRedaction).HasColumnName("redact_and_send_save_redaction");
            builder.Property(e => e.RedactAndSendSendRedaction).HasColumnName("redact_and_send_send_redaction");
            builder.Property(e => e.RedactAndSendSendSolicitors).HasColumnName("redact_and_send_send_solicitors");
            builder.Property(e => e.RiskProtectionArrangementOption)
                .HasMaxLength(4000)
                .HasColumnName("risk_protection_arrangement_option");
            builder.Property(e => e.RiskProtectionArrangementReason)
                .HasMaxLength(4000)
                .HasColumnName("risk_protection_arrangement_reason");
            builder.Property(e => e.SchoolCompletedEmailed).HasColumnName("school_completed_emailed");
            builder.Property(e => e.SchoolCompletedSaved).HasColumnName("school_completed_saved");
            builder.Property(e => e.ShareInformationEmail).HasColumnName("share_information_email");
            builder.Property(e => e.SingleWorksheetApprove).HasColumnName("single_worksheet_approve");
            builder.Property(e => e.SingleWorksheetComplete).HasColumnName("single_worksheet_complete");
            builder.Property(e => e.SingleWorksheetSend).HasColumnName("single_worksheet_send");
            builder.Property(e => e.SponsoredSupportGrantInformTrust).HasColumnName("sponsored_support_grant_inform_trust");
            builder.Property(e => e.SponsoredSupportGrantNotApplicable).HasColumnName("sponsored_support_grant_not_applicable");
            builder.Property(e => e.SponsoredSupportGrantPaymentAmount).HasColumnName("sponsored_support_grant_payment_amount");
            builder.Property(e => e.SponsoredSupportGrantPaymentForm).HasColumnName("sponsored_support_grant_payment_form");
            builder.Property(e => e.SponsoredSupportGrantSendInformation).HasColumnName("sponsored_support_grant_send_information");
            builder.Property(e => e.SponsoredSupportGrantType)
                .HasMaxLength(4000)
                .HasColumnName("sponsored_support_grant_type");
            builder.Property(e => e.StakeholderKickOffCheckProvisionalConversionDate).HasColumnName("stakeholder_kick_off_check_provisional_conversion_date");
            builder.Property(e => e.StakeholderKickOffIntroductoryEmails).HasColumnName("stakeholder_kick_off_introductory_emails");
            builder.Property(e => e.StakeholderKickOffLocalAuthorityProforma).HasColumnName("stakeholder_kick_off_local_authority_proforma");
            builder.Property(e => e.StakeholderKickOffMeeting).HasColumnName("stakeholder_kick_off_meeting");
            builder.Property(e => e.StakeholderKickOffSetupMeeting).HasColumnName("stakeholder_kick_off_setup_meeting");
            builder.Property(e => e.SubleasesCleared).HasColumnName("subleases_cleared");
            builder.Property(e => e.SubleasesEmailSigned).HasColumnName("subleases_email_signed");
            builder.Property(e => e.SubleasesNotApplicable).HasColumnName("subleases_not_applicable");
            builder.Property(e => e.SubleasesReceiveSigned).HasColumnName("subleases_receive_signed");
            builder.Property(e => e.SubleasesReceived).HasColumnName("subleases_received");
            builder.Property(e => e.SubleasesSaveSigned).HasColumnName("subleases_save_signed");
            builder.Property(e => e.SubleasesSaved).HasColumnName("subleases_saved");
            builder.Property(e => e.SubleasesSigned).HasColumnName("subleases_signed");
            builder.Property(e => e.SupplementalFundingAgreementCleared).HasColumnName("supplemental_funding_agreement_cleared");
            builder.Property(e => e.SupplementalFundingAgreementReceived).HasColumnName("supplemental_funding_agreement_received");
            builder.Property(e => e.SupplementalFundingAgreementSaved).HasColumnName("supplemental_funding_agreement_saved");
            builder.Property(e => e.SupplementalFundingAgreementSent).HasColumnName("supplemental_funding_agreement_sent");
            builder.Property(e => e.SupplementalFundingAgreementSigned).HasColumnName("supplemental_funding_agreement_signed");
            builder.Property(e => e.SupplementalFundingAgreementSignedSecretaryState).HasColumnName("supplemental_funding_agreement_signed_secretary_state");
            builder.Property(e => e.TenancyAtWillEmailSigned).HasColumnName("tenancy_at_will_email_signed");
            builder.Property(e => e.TenancyAtWillNotApplicable).HasColumnName("tenancy_at_will_not_applicable");
            builder.Property(e => e.TenancyAtWillReceiveSigned).HasColumnName("tenancy_at_will_receive_signed");
            builder.Property(e => e.TenancyAtWillSaveSigned).HasColumnName("tenancy_at_will_save_signed");
            builder.Property(e => e.TrustModificationOrderCleared).HasColumnName("trust_modification_order_cleared");
            builder.Property(e => e.TrustModificationOrderNotApplicable).HasColumnName("trust_modification_order_not_applicable");
            builder.Property(e => e.TrustModificationOrderReceived).HasColumnName("trust_modification_order_received");
            builder.Property(e => e.TrustModificationOrderSaved).HasColumnName("trust_modification_order_saved");
            builder.Property(e => e.TrustModificationOrderSentLegal).HasColumnName("trust_modification_order_sent_legal");
            builder.Property(e => e.UpdateEsfaUpdate).HasColumnName("update_esfa_update");
            builder.Property(e => e.UpdatedAt)
                .HasPrecision(6)
                .HasColumnName("updated_at");

        }
    }

}
