using Dfe.ManageFreeSchoolProjects.API.Contracts.Common;

namespace Dfe.ManageFreeSchoolProjects.API.Contracts.Project.Tasks;

public class ModelFundingAgreementTask
{
    public bool? TailoredAModelFundingAgreement { get; set; }
    public bool? SharedFAWithTheTrust { get; set; }
    public YesNo? TrustAgreesWithModelFA { get; set; }
    public DateTime? DateTrustAgreesWithModelFA { get; set; }
    public string Comments { get; set; }
    public bool? DraftedFAHealthCheck { get; set; }
    
    public bool? SavedFADocumentsInWorkplacesFolder { get; set; }
}