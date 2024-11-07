namespace Dfe.Complete.API.Contracts.Project.Conversion.Tasks
{
    public class ConversionSupplementalFundingAgreementTask
    {
        public bool? Received { get; set; }
        public bool? Signed { get; set; }
        public bool? Cleared { get; set; }
        public bool? Saved { get; set; }
        public bool? Sent { get; set; }
        public bool? SignedSecretaryState { get; set; }
    }
}
