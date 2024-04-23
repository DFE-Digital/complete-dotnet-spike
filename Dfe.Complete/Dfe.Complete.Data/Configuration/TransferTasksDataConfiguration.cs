using System;
using System.Collections.Generic;
using Dfe.Complete.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dfe.Complete.Data.Configuration
{
    public partial class TransferTasksDataConfiguration : IEntityTypeConfiguration<TransferTasksDatum>
    {
        public void Configure(EntityTypeBuilder<TransferTasksDatum> builder)
        {
            builder.HasKey(e => e.Id).HasName("PK__transfer__3213E83F06874456");
            builder.ToTable("transfer_tasks_data", "complete");

            builder.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("id");
            builder.Property(e => e.ArticlesOfAssociationCleared).HasColumnName("articles_of_association_cleared");
            builder.Property(e => e.ArticlesOfAssociationNotApplicable).HasColumnName("articles_of_association_not_applicable");
            builder.Property(e => e.ArticlesOfAssociationReceived).HasColumnName("articles_of_association_received");
            builder.Property(e => e.ArticlesOfAssociationSaved).HasColumnName("articles_of_association_saved");
            builder.Property(e => e.ArticlesOfAssociationSigned).HasColumnName("articles_of_association_signed");
            builder.Property(e => e.BankDetailsChangingYesNo)
                .HasDefaultValueSql("((0))")
                .HasColumnName("bank_details_changing_yes_no");
            builder.Property(e => e.CheckAndConfirmFinancialInformationAcademySurplusDeficit)
                .HasMaxLength(4000)
                .HasColumnName("check_and_confirm_financial_information_academy_surplus_deficit");
            builder.Property(e => e.CheckAndConfirmFinancialInformationNotApplicable).HasColumnName("check_and_confirm_financial_information_not_applicable");
            builder.Property(e => e.CheckAndConfirmFinancialInformationTrustSurplusDeficit)
                .HasMaxLength(4000)
                .HasColumnName("check_and_confirm_financial_information_trust_surplus_deficit");
            builder.Property(e => e.ChurchSupplementalAgreementCleared).HasColumnName("church_supplemental_agreement_cleared");
            builder.Property(e => e.ChurchSupplementalAgreementNotApplicable).HasColumnName("church_supplemental_agreement_not_applicable");
            builder.Property(e => e.ChurchSupplementalAgreementReceived).HasColumnName("church_supplemental_agreement_received");
            builder.Property(e => e.ChurchSupplementalAgreementSavedAfterSigningBySecretaryState).HasColumnName("church_supplemental_agreement_saved_after_signing_by_secretary_state");
            builder.Property(e => e.ChurchSupplementalAgreementSavedAfterSigningByTrustDiocese).HasColumnName("church_supplemental_agreement_saved_after_signing_by_trust_diocese");
            builder.Property(e => e.ChurchSupplementalAgreementSignedDiocese).HasColumnName("church_supplemental_agreement_signed_diocese");
            builder.Property(e => e.ChurchSupplementalAgreementSignedIncomingTrust).HasColumnName("church_supplemental_agreement_signed_incoming_trust");
            builder.Property(e => e.ChurchSupplementalAgreementSignedSecretaryState).HasColumnName("church_supplemental_agreement_signed_secretary_state");
            builder.Property(e => e.ClosureOrTransferDeclarationCleared).HasColumnName("closure_or_transfer_declaration_cleared");
            builder.Property(e => e.ClosureOrTransferDeclarationNotApplicable).HasColumnName("closure_or_transfer_declaration_not_applicable");
            builder.Property(e => e.ClosureOrTransferDeclarationReceived).HasColumnName("closure_or_transfer_declaration_received");
            builder.Property(e => e.ClosureOrTransferDeclarationSaved).HasColumnName("closure_or_transfer_declaration_saved");
            builder.Property(e => e.ClosureOrTransferDeclarationSent).HasColumnName("closure_or_transfer_declaration_sent");
            builder.Property(e => e.CommercialTransferAgreementConfirmAgreed).HasColumnName("commercial_transfer_agreement_confirm_agreed");
            builder.Property(e => e.CommercialTransferAgreementConfirmSigned).HasColumnName("commercial_transfer_agreement_confirm_signed");
            builder.Property(e => e.CommercialTransferAgreementSaveConfirmationEmails).HasColumnName("commercial_transfer_agreement_save_confirmation_emails");
            builder.Property(e => e.ConfirmDateAcademyTransferredDateTransferred)
                .HasColumnType("date")
                .HasColumnName("confirm_date_academy_transferred_date_transferred");
            builder.Property(e => e.ConfirmIncomingTrustHasCompletedAllActionsEmailed).HasColumnName("confirm_incoming_trust_has_completed_all_actions_emailed");
            builder.Property(e => e.ConfirmIncomingTrustHasCompletedAllActionsSaved).HasColumnName("confirm_incoming_trust_has_completed_all_actions_saved");
            builder.Property(e => e.CreatedAt)
                .HasPrecision(6)
                .HasColumnName("created_at");
            builder.Property(e => e.DeclarationOfExpenditureCertificateCorrect)
                .HasDefaultValueSql("((0))")
                .HasColumnName("declaration_of_expenditure_certificate_correct");
            builder.Property(e => e.DeclarationOfExpenditureCertificateDateReceived)
                .HasColumnType("date")
                .HasColumnName("declaration_of_expenditure_certificate_date_received");
            builder.Property(e => e.DeclarationOfExpenditureCertificateNotApplicable)
                .HasDefaultValueSql("((0))")
                .HasColumnName("declaration_of_expenditure_certificate_not_applicable");
            builder.Property(e => e.DeclarationOfExpenditureCertificateSaved)
                .HasDefaultValueSql("((0))")
                .HasColumnName("declaration_of_expenditure_certificate_saved");
            builder.Property(e => e.DeedOfNovationAndVariationCleared).HasColumnName("deed_of_novation_and_variation_cleared");
            builder.Property(e => e.DeedOfNovationAndVariationReceived).HasColumnName("deed_of_novation_and_variation_received");
            builder.Property(e => e.DeedOfNovationAndVariationSaveAfterSign).HasColumnName("deed_of_novation_and_variation_save_after_sign");
            builder.Property(e => e.DeedOfNovationAndVariationSaved).HasColumnName("deed_of_novation_and_variation_saved");
            builder.Property(e => e.DeedOfNovationAndVariationSignedIncomingTrust).HasColumnName("deed_of_novation_and_variation_signed_incoming_trust");
            builder.Property(e => e.DeedOfNovationAndVariationSignedOutgoingTrust).HasColumnName("deed_of_novation_and_variation_signed_outgoing_trust");
            builder.Property(e => e.DeedOfNovationAndVariationSignedSecretaryState).HasColumnName("deed_of_novation_and_variation_signed_secretary_state");
            builder.Property(e => e.DeedOfTerminationForTheMasterFundingAgreementCleared).HasColumnName("deed_of_termination_for_the_master_funding_agreement_cleared");
            builder.Property(e => e.DeedOfTerminationForTheMasterFundingAgreementContactFinancialReportingTeam).HasColumnName("deed_of_termination_for_the_master_funding_agreement_contact_financial_reporting_team");
            builder.Property(e => e.DeedOfTerminationForTheMasterFundingAgreementNotApplicable).HasColumnName("deed_of_termination_for_the_master_funding_agreement_not_applicable");
            builder.Property(e => e.DeedOfTerminationForTheMasterFundingAgreementReceived).HasColumnName("deed_of_termination_for_the_master_funding_agreement_received");
            builder.Property(e => e.DeedOfTerminationForTheMasterFundingAgreementSavedAcademyAndOutgoingTrustSharepoint).HasColumnName("deed_of_termination_for_the_master_funding_agreement_saved_academy_and_outgoing_trust_sharepoint");
            builder.Property(e => e.DeedOfTerminationForTheMasterFundingAgreementSavedInAcademySharepointFolder).HasColumnName("deed_of_termination_for_the_master_funding_agreement_saved_in_academy_sharepoint_folder");
            builder.Property(e => e.DeedOfTerminationForTheMasterFundingAgreementSigned).HasColumnName("deed_of_termination_for_the_master_funding_agreement_signed");
            builder.Property(e => e.DeedOfTerminationForTheMasterFundingAgreementSignedSecretaryState).HasColumnName("deed_of_termination_for_the_master_funding_agreement_signed_secretary_state");
            builder.Property(e => e.DeedOfVariationCleared).HasColumnName("deed_of_variation_cleared");
            builder.Property(e => e.DeedOfVariationNotApplicable).HasColumnName("deed_of_variation_not_applicable");
            builder.Property(e => e.DeedOfVariationReceived).HasColumnName("deed_of_variation_received");
            builder.Property(e => e.DeedOfVariationSaved).HasColumnName("deed_of_variation_saved");
            builder.Property(e => e.DeedOfVariationSent).HasColumnName("deed_of_variation_sent");
            builder.Property(e => e.DeedOfVariationSigned).HasColumnName("deed_of_variation_signed");
            builder.Property(e => e.DeedOfVariationSignedSecretaryState).HasColumnName("deed_of_variation_signed_secretary_state");
            builder.Property(e => e.DeedTerminationChurchAgreementCleared).HasColumnName("deed_termination_church_agreement_cleared");
            builder.Property(e => e.DeedTerminationChurchAgreementNotApplicable).HasColumnName("deed_termination_church_agreement_not_applicable");
            builder.Property(e => e.DeedTerminationChurchAgreementReceived).HasColumnName("deed_termination_church_agreement_received");
            builder.Property(e => e.DeedTerminationChurchAgreementSaved).HasColumnName("deed_termination_church_agreement_saved");
            builder.Property(e => e.DeedTerminationChurchAgreementSavedAfterSigningBySecretaryState).HasColumnName("deed_termination_church_agreement_saved_after_signing_by_secretary_state");
            builder.Property(e => e.DeedTerminationChurchAgreementSignedDiocese).HasColumnName("deed_termination_church_agreement_signed_diocese");
            builder.Property(e => e.DeedTerminationChurchAgreementSignedOutgoingTrust).HasColumnName("deed_termination_church_agreement_signed_outgoing_trust");
            builder.Property(e => e.DeedTerminationChurchAgreementSignedSecretaryState).HasColumnName("deed_termination_church_agreement_signed_secretary_state");
            builder.Property(e => e.FinancialSafeguardingGovernanceIssues)
                .HasDefaultValueSql("((0))")
                .HasColumnName("financial_safeguarding_governance_issues");
            builder.Property(e => e.FormMCleared).HasColumnName("form_m_cleared");
            builder.Property(e => e.FormMReceivedFormM).HasColumnName("form_m_received_form_m");
            builder.Property(e => e.FormMReceivedTitlePlans).HasColumnName("form_m_received_title_plans");
            builder.Property(e => e.FormMSaved).HasColumnName("form_m_saved");
            builder.Property(e => e.FormMSigned).HasColumnName("form_m_signed");
            builder.Property(e => e.HandoverMeeting).HasColumnName("handover_meeting");
            builder.Property(e => e.HandoverNotApplicable).HasColumnName("handover_not_applicable");
            builder.Property(e => e.HandoverNotes).HasColumnName("handover_notes");
            builder.Property(e => e.HandoverReview).HasColumnName("handover_review");
            builder.Property(e => e.InadequateOfsted)
                .HasDefaultValueSql("((0))")
                .HasColumnName("inadequate_ofsted");
            builder.Property(e => e.LandConsentLetterDrafted).HasColumnName("land_consent_letter_drafted");
            builder.Property(e => e.LandConsentLetterNotApplicable).HasColumnName("land_consent_letter_not_applicable");
            builder.Property(e => e.LandConsentLetterSaved).HasColumnName("land_consent_letter_saved");
            builder.Property(e => e.LandConsentLetterSent).HasColumnName("land_consent_letter_sent");
            builder.Property(e => e.LandConsentLetterSigned).HasColumnName("land_consent_letter_signed");
            builder.Property(e => e.MasterFundingAgreementCleared).HasColumnName("master_funding_agreement_cleared");
            builder.Property(e => e.MasterFundingAgreementNotApplicable).HasColumnName("master_funding_agreement_not_applicable");
            builder.Property(e => e.MasterFundingAgreementReceived).HasColumnName("master_funding_agreement_received");
            builder.Property(e => e.MasterFundingAgreementSaved).HasColumnName("master_funding_agreement_saved");
            builder.Property(e => e.MasterFundingAgreementSigned).HasColumnName("master_funding_agreement_signed");
            builder.Property(e => e.MasterFundingAgreementSignedSecretaryState).HasColumnName("master_funding_agreement_signed_secretary_state");
            builder.Property(e => e.OutgoingTrustToClose)
                .HasDefaultValueSql("((0))")
                .HasColumnName("outgoing_trust_to_close");
            builder.Property(e => e.RedactAndSendDocumentsRedact).HasColumnName("redact_and_send_documents_redact");
            builder.Property(e => e.RedactAndSendDocumentsSaved).HasColumnName("redact_and_send_documents_saved");
            builder.Property(e => e.RedactAndSendDocumentsSendToEsfa).HasColumnName("redact_and_send_documents_send_to_esfa");
            builder.Property(e => e.RedactAndSendDocumentsSendToFundingTeam).HasColumnName("redact_and_send_documents_send_to_funding_team");
            builder.Property(e => e.RedactAndSendDocumentsSendToSolicitors).HasColumnName("redact_and_send_documents_send_to_solicitors");
            builder.Property(e => e.RequestNewUrnAndRecordComplete).HasColumnName("request_new_urn_and_record_complete");
            builder.Property(e => e.RequestNewUrnAndRecordGive).HasColumnName("request_new_urn_and_record_give");
            builder.Property(e => e.RequestNewUrnAndRecordNotApplicable).HasColumnName("request_new_urn_and_record_not_applicable");
            builder.Property(e => e.RequestNewUrnAndRecordReceive).HasColumnName("request_new_urn_and_record_receive");
            builder.Property(e => e.RpaPolicyConfirm).HasColumnName("rpa_policy_confirm");
            builder.Property(e => e.SponsoredSupportGrantNotApplicable)
                .HasDefaultValueSql("((0))")
                .HasColumnName("sponsored_support_grant_not_applicable");
            builder.Property(e => e.SponsoredSupportGrantType)
                .HasMaxLength(4000)
                .HasColumnName("sponsored_support_grant_type");
            builder.Property(e => e.StakeholderKickOffIntroductoryEmails).HasColumnName("stakeholder_kick_off_introductory_emails");
            builder.Property(e => e.StakeholderKickOffMeeting).HasColumnName("stakeholder_kick_off_meeting");
            builder.Property(e => e.StakeholderKickOffSetupMeeting).HasColumnName("stakeholder_kick_off_setup_meeting");
            builder.Property(e => e.SupplementalFundingAgreementCleared).HasColumnName("supplemental_funding_agreement_cleared");
            builder.Property(e => e.SupplementalFundingAgreementReceived).HasColumnName("supplemental_funding_agreement_received");
            builder.Property(e => e.SupplementalFundingAgreementSaved).HasColumnName("supplemental_funding_agreement_saved");
            builder.Property(e => e.UpdatedAt)
                .HasPrecision(6)
                .HasColumnName("updated_at");

        }
    }

}
