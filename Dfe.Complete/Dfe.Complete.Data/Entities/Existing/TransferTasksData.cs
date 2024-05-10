using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Dfe.Complete.Data
{
    public partial class CompleteContext : DbContext
    {
        public virtual DbSet<Entities.TransferTasksData> TransferTasksData { get; set; }
    }
}

namespace Dfe.Complete.Data.Entities
{
public partial class TransferTasksData : IProjectTasksData
    {
    public Guid Id { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public bool? HandoverReview { get; set; }

    public bool? HandoverNotes { get; set; }

    public bool? HandoverMeeting { get; set; }

    public bool? HandoverNotApplicable { get; set; }

    public bool? StakeholderKickOffIntroductoryEmails { get; set; }

    public bool? StakeholderKickOffSetupMeeting { get; set; }

    public bool? StakeholderKickOffMeeting { get; set; }

    public bool? MasterFundingAgreementReceived { get; set; }

    public bool? MasterFundingAgreementCleared { get; set; }

    public bool? MasterFundingAgreementSigned { get; set; }

    public bool? MasterFundingAgreementSaved { get; set; }

    public bool? MasterFundingAgreementSignedSecretaryState { get; set; }

    public bool? MasterFundingAgreementNotApplicable { get; set; }

    public bool? DeedOfNovationAndVariationReceived { get; set; }

    public bool? DeedOfNovationAndVariationCleared { get; set; }

    public bool? DeedOfNovationAndVariationSignedOutgoingTrust { get; set; }

    public bool? DeedOfNovationAndVariationSignedIncomingTrust { get; set; }

    public bool? DeedOfNovationAndVariationSaved { get; set; }

    public bool? DeedOfNovationAndVariationSignedSecretaryState { get; set; }

    public bool? DeedOfNovationAndVariationSaveAfterSign { get; set; }

    public bool? ArticlesOfAssociationReceived { get; set; }

    public bool? ArticlesOfAssociationCleared { get; set; }

    public bool? ArticlesOfAssociationSigned { get; set; }

    public bool? ArticlesOfAssociationSaved { get; set; }

    public bool? ArticlesOfAssociationNotApplicable { get; set; }

    public bool? CommercialTransferAgreementConfirmAgreed { get; set; }

    public bool? CommercialTransferAgreementConfirmSigned { get; set; }

    public bool? CommercialTransferAgreementSaveConfirmationEmails { get; set; }

    public bool? SupplementalFundingAgreementReceived { get; set; }

    public bool? SupplementalFundingAgreementCleared { get; set; }

    public bool? SupplementalFundingAgreementSaved { get; set; }

    public bool? DeedOfVariationReceived { get; set; }

    public bool? DeedOfVariationCleared { get; set; }

    public bool? DeedOfVariationSigned { get; set; }

    public bool? DeedOfVariationSaved { get; set; }

    public bool? DeedOfVariationSent { get; set; }

    public bool? DeedOfVariationSignedSecretaryState { get; set; }

    public bool? DeedOfVariationNotApplicable { get; set; }

    public bool? LandConsentLetterDrafted { get; set; }

    public bool? LandConsentLetterSigned { get; set; }

    public bool? LandConsentLetterSent { get; set; }

    public bool? LandConsentLetterSaved { get; set; }

    public bool? LandConsentLetterNotApplicable { get; set; }

    public bool? RpaPolicyConfirm { get; set; }

    public bool? FormMReceivedFormM { get; set; }

    public bool? FormMReceivedTitlePlans { get; set; }

    public bool? FormMCleared { get; set; }

    public bool? FormMSigned { get; set; }

    public bool? FormMSaved { get; set; }

    public bool? ChurchSupplementalAgreementReceived { get; set; }

    public bool? ChurchSupplementalAgreementCleared { get; set; }

    public bool? ChurchSupplementalAgreementSignedIncomingTrust { get; set; }

    public bool? ChurchSupplementalAgreementSignedDiocese { get; set; }

    public bool? ChurchSupplementalAgreementSavedAfterSigningByTrustDiocese { get; set; }

    public bool? ChurchSupplementalAgreementSignedSecretaryState { get; set; }

    public bool? ChurchSupplementalAgreementSavedAfterSigningBySecretaryState { get; set; }

    public bool? ChurchSupplementalAgreementNotApplicable { get; set; }

    public bool? DeedOfTerminationForTheMasterFundingAgreementReceived { get; set; }

    public bool? DeedOfTerminationForTheMasterFundingAgreementCleared { get; set; }

    public bool? DeedOfTerminationForTheMasterFundingAgreementSigned { get; set; }

    public bool? DeedOfTerminationForTheMasterFundingAgreementSavedAcademyAndOutgoingTrustSharepoint { get; set; }

    public bool? DeedOfTerminationForTheMasterFundingAgreementContactFinancialReportingTeam { get; set; }

    public bool? DeedOfTerminationForTheMasterFundingAgreementSignedSecretaryState { get; set; }

    public bool? DeedOfTerminationForTheMasterFundingAgreementSavedInAcademySharepointFolder { get; set; }

    public bool? DeedOfTerminationForTheMasterFundingAgreementNotApplicable { get; set; }

    public bool? DeedTerminationChurchAgreementReceived { get; set; }

    public bool? DeedTerminationChurchAgreementCleared { get; set; }

    public bool? DeedTerminationChurchAgreementSignedOutgoingTrust { get; set; }

    public bool? DeedTerminationChurchAgreementSignedDiocese { get; set; }

    public bool? DeedTerminationChurchAgreementSaved { get; set; }

    public bool? DeedTerminationChurchAgreementSignedSecretaryState { get; set; }

    public bool? DeedTerminationChurchAgreementSavedAfterSigningBySecretaryState { get; set; }

    public bool? DeedTerminationChurchAgreementNotApplicable { get; set; }

    public bool? ClosureOrTransferDeclarationNotApplicable { get; set; }

    public bool? ClosureOrTransferDeclarationReceived { get; set; }

    public bool? ClosureOrTransferDeclarationCleared { get; set; }

    public bool? ClosureOrTransferDeclarationSaved { get; set; }

    public bool? ClosureOrTransferDeclarationSent { get; set; }

    public bool? ConfirmIncomingTrustHasCompletedAllActionsEmailed { get; set; }

    public bool? ConfirmIncomingTrustHasCompletedAllActionsSaved { get; set; }

    public bool? RedactAndSendDocumentsSendToEsfa { get; set; }

    public bool? RedactAndSendDocumentsRedact { get; set; }

    public bool? RedactAndSendDocumentsSaved { get; set; }

    public bool? RedactAndSendDocumentsSendToFundingTeam { get; set; }

    public bool? RedactAndSendDocumentsSendToSolicitors { get; set; }

    public bool? RequestNewUrnAndRecordNotApplicable { get; set; }

    public bool? RequestNewUrnAndRecordComplete { get; set; }

    public bool? RequestNewUrnAndRecordReceive { get; set; }

    public bool? RequestNewUrnAndRecordGive { get; set; }

    public bool? InadequateOfsted { get; set; }

    public bool? FinancialSafeguardingGovernanceIssues { get; set; }

    public bool? OutgoingTrustToClose { get; set; }

    public bool? BankDetailsChangingYesNo { get; set; }

    public bool? CheckAndConfirmFinancialInformationNotApplicable { get; set; }

    public string CheckAndConfirmFinancialInformationAcademySurplusDeficit { get; set; }

    public string CheckAndConfirmFinancialInformationTrustSurplusDeficit { get; set; }

    public DateTime? ConfirmDateAcademyTransferredDateTransferred { get; set; }

    public bool? SponsoredSupportGrantNotApplicable { get; set; }

    public string SponsoredSupportGrantType { get; set; }

    public DateTime? DeclarationOfExpenditureCertificateDateReceived { get; set; }

    public bool? DeclarationOfExpenditureCertificateCorrect { get; set; }

    public bool? DeclarationOfExpenditureCertificateSaved { get; set; }

    public bool? DeclarationOfExpenditureCertificateNotApplicable { get; set; }
}
}