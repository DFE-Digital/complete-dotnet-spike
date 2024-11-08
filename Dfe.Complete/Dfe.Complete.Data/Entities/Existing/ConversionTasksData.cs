using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Dfe.Complete.Data
{
    public partial class CompleteContext : DbContext
    {
        public virtual DbSet<Entities.ConversionTasksData> ConversionTasksData { get; set; }
    }
}

namespace Dfe.Complete.Data.Entities
{
public partial class ConversionTasksData : IProjectTasksData
    {
    public Guid Id { get; set; }

    public bool? HandoverReview { get; set; }

    public bool? HandoverNotes { get; set; }

    public bool? HandoverMeeting { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public bool? StakeholderKickOffIntroductoryEmails { get; set; }

    public bool? StakeholderKickOffLocalAuthorityProforma { get; set; }

    public bool? StakeholderKickOffSetupMeeting { get; set; }

    public bool? StakeholderKickOffMeeting { get; set; }

    public bool? ConversionGrantCheckVendorAccount { get; set; }

    public bool? ConversionGrantPaymentForm { get; set; }

    public bool? ConversionGrantSendInformation { get; set; }

    public bool? ConversionGrantSharePaymentDate { get; set; }

    public bool? LandQuestionnaireReceived { get; set; }

    public bool? LandQuestionnaireCleared { get; set; }

    public bool? LandQuestionnaireSigned { get; set; }

    public bool? LandQuestionnaireSaved { get; set; }

    public bool? LandRegistryReceived { get; set; }

    public bool? LandRegistryCleared { get; set; }

    public bool? LandRegistrySaved { get; set; }

    public bool? SupplementalFundingAgreementReceived { get; set; }

    public bool? SupplementalFundingAgreementCleared { get; set; }

    public bool? SupplementalFundingAgreementSigned { get; set; }

    public bool? SupplementalFundingAgreementSaved { get; set; }

    public bool? SupplementalFundingAgreementSent { get; set; }

    public bool? SupplementalFundingAgreementSignedSecretaryState { get; set; }

    public bool? ChurchSupplementalAgreementReceived { get; set; }

    public bool? ChurchSupplementalAgreementCleared { get; set; }

    public bool? ChurchSupplementalAgreementSigned { get; set; }

    public bool? ChurchSupplementalAgreementSignedDiocese { get; set; }

    public bool? ChurchSupplementalAgreementSaved { get; set; }

    public bool? ChurchSupplementalAgreementSent { get; set; }

    public bool? ChurchSupplementalAgreementSignedSecretaryState { get; set; }

    public bool? MasterFundingAgreementReceived { get; set; }

    public bool? MasterFundingAgreementCleared { get; set; }

    public bool? MasterFundingAgreementSigned { get; set; }

    public bool? MasterFundingAgreementSaved { get; set; }

    public bool? MasterFundingAgreementSent { get; set; }

    public bool? MasterFundingAgreementSignedSecretaryState { get; set; }

    public bool? ArticlesOfAssociationReceived { get; set; }

    public bool? ArticlesOfAssociationCleared { get; set; }

    public bool? ArticlesOfAssociationSigned { get; set; }

    public bool? ArticlesOfAssociationSaved { get; set; }

    public bool? DeedOfVariationReceived { get; set; }

    public bool? DeedOfVariationCleared { get; set; }

    public bool? DeedOfVariationSigned { get; set; }

    public bool? DeedOfVariationSaved { get; set; }

    public bool? DeedOfVariationSent { get; set; }

    public bool? DeedOfVariationSignedSecretaryState { get; set; }

    public bool? TrustModificationOrderReceived { get; set; }

    public bool? TrustModificationOrderSentLegal { get; set; }

    public bool? TrustModificationOrderCleared { get; set; }

    public bool? TrustModificationOrderSaved { get; set; }

    public bool? DirectionToTransferReceived { get; set; }

    public bool? DirectionToTransferCleared { get; set; }

    public bool? DirectionToTransferSigned { get; set; }

    public bool? DirectionToTransferSaved { get; set; }

    public bool? SingleWorksheetComplete { get; set; }

    public bool? SingleWorksheetApprove { get; set; }

    public bool? SingleWorksheetSend { get; set; }

    public bool? SchoolCompletedEmailed { get; set; }

    public bool? SchoolCompletedSaved { get; set; }

    public bool? RedactAndSendRedact { get; set; }

    public bool? RedactAndSendSaveRedaction { get; set; }

    public bool? RedactAndSendSendRedaction { get; set; }

    public bool? UpdateEsfaUpdate { get; set; }

    public bool? ReceiveGrantPaymentCertificateSaveCertificate { get; set; }

    public bool? OneHundredAndTwentyFiveYearLeaseEmail { get; set; }

    public bool? OneHundredAndTwentyFiveYearLeaseReceive { get; set; }

    public bool? OneHundredAndTwentyFiveYearLeaseSaveLease { get; set; }

    public bool? SubleasesReceived { get; set; }

    public bool? SubleasesCleared { get; set; }

    public bool? SubleasesSigned { get; set; }

    public bool? SubleasesSaved { get; set; }

    public bool? SubleasesEmailSigned { get; set; }

    public bool? SubleasesReceiveSigned { get; set; }

    public bool? SubleasesSaveSigned { get; set; }

    public bool? TenancyAtWillEmailSigned { get; set; }

    public bool? TenancyAtWillReceiveSigned { get; set; }

    public bool? TenancyAtWillSaveSigned { get; set; }

    public bool? CommercialTransferAgreementEmailSigned { get; set; }

    public bool? CommercialTransferAgreementReceiveSigned { get; set; }

    public bool? CommercialTransferAgreementSaveSigned { get; set; }

    public bool? ShareInformationEmail { get; set; }

    public bool? RedactAndSendSendSolicitors { get; set; }

    public bool? ArticlesOfAssociationNotApplicable { get; set; }

    public bool? ChurchSupplementalAgreementNotApplicable { get; set; }

    public bool? DeedOfVariationNotApplicable { get; set; }

    public bool? DirectionToTransferNotApplicable { get; set; }

    public bool? MasterFundingAgreementNotApplicable { get; set; }

    public bool? OneHundredAndTwentyFiveYearLeaseNotApplicable { get; set; }

    public bool? SubleasesNotApplicable { get; set; }

    public bool? TenancyAtWillNotApplicable { get; set; }

    public bool? TrustModificationOrderNotApplicable { get; set; }

    public bool? StakeholderKickOffCheckProvisionalConversionDate { get; set; }

    public bool? ConversionGrantNotApplicable { get; set; }

    public bool? SponsoredSupportGrantPaymentAmount { get; set; }

    public bool? SponsoredSupportGrantPaymentForm { get; set; }

    public bool? SponsoredSupportGrantSendInformation { get; set; }

    public bool? SponsoredSupportGrantInformTrust { get; set; }

    public bool? SponsoredSupportGrantNotApplicable { get; set; }

    public bool? HandoverNotApplicable { get; set; }

    public string AcademyDetailsName { get; set; }

    public string RiskProtectionArrangementOption { get; set; }

    public bool? CheckAccuracyOfHigherNeedsConfirmNumber { get; set; }

    public bool? CheckAccuracyOfHigherNeedsConfirmPublishedNumber { get; set; }

    public bool? CompleteNotificationOfChangeNotApplicable { get; set; }

    public bool? CompleteNotificationOfChangeTellLocalAuthority { get; set; }

    public bool? CompleteNotificationOfChangeCheckDocument { get; set; }

    public bool? CompleteNotificationOfChangeSendDocument { get; set; }

    public string SponsoredSupportGrantType { get; set; }

    public bool? ProposedCapacityOfTheAcademyNotApplicable { get; set; }

    public string ProposedCapacityOfTheAcademyReceptionToSixYears { get; set; }

    public string ProposedCapacityOfTheAcademySevenToElevenYears { get; set; }

    public string ProposedCapacityOfTheAcademyTwelveOrAboveYears { get; set; }

    public DateTime? ReceiveGrantPaymentCertificateDateReceived { get; set; }

    public bool? ReceiveGrantPaymentCertificateCheckCertificate { get; set; }

    public DateTime? ConfirmDateAcademyOpenedDateOpened { get; set; }

    public string RiskProtectionArrangementReason { get; set; }
}
}