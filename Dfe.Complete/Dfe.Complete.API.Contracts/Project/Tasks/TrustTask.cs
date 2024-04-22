using System.ComponentModel;

namespace Dfe.ManageFreeSchoolProjects.API.Contracts.Project.Tasks
{
    public record TrustTask
    {
        public string TRN { get; set; }
        public string TrustName { get; set; }
        public TrustType TrustType { get; set; }
    }
    
    public enum TrustType
    {
        NotSet,
        [Description("SAT (single academy trust)")]
        SingleAcademyTrust,
        [Description("MAT (multi-academy trust)")]
        MultiAcademyTrust,
    }
}
