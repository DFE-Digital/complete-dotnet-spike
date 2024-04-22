using Dfe.ManageFreeSchoolProjects.API.Contracts.Project;
using Dfe.ManageFreeSchoolProjects.API.Contracts.Project.Tasks;
using SchoolType = Dfe.ManageFreeSchoolProjects.API.Contracts.Project.SchoolType;

namespace Dfe.ManageFreeSchoolProjects.API.Contracts.RequestModels.Projects
{
    public class CreateProjectRequest
    {
        public List<ProjectDetails> Projects { get; set; } = new();
    }

    public class ProjectDetails
    {
        public string ProjectId { get; set; }
        public string SchoolName { get; set; }
        public string Region { get; set; }
        public string LocalAuthority { get; set; }
        public string LocalAuthorityCode { get; set; }
        public string TRN { get; set; }
        public string TrustName { get; set; }
        public SchoolType SchoolType { get; set; }
        public SchoolPhase SchoolPhase { get; set; }
        public ClassType.Nursery Nursery { get; set; }
        public ClassType.SixthForm SixthForm { get; set; }
        public ClassType.AlternativeProvision AlternativeProvision { get; set; }
        public ClassType.SpecialEducationNeeds SpecialEducationNeeds { get; set; }
        public string AgeRange { get; set; }
        public int NurseryCapacity { get; set; }
        public int YRY6Capacity { get; set; }
        public int Y7Y11Capacity { get; set; }
        public int Y12Y14Capacity { get; set; }
        public string FormsOfEntry { get; set; }
        public FaithStatus FaithStatus { get; set; }
        public FaithType FaithType { get; set; }
        public string OtherFaithType { get; set; }
        public DateTime? ProvisionalOpeningDate { get; set; }
        public string CreatedBy { get; set; }
        public string ProjectLead { get; set; }
        public string ApplicationWave {  get; set; }
    }
}
