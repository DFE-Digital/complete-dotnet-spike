using System.ComponentModel;

namespace Dfe.ManageFreeSchoolProjects.API.Contracts.Project
{
    public enum SchoolType
    {
        [Description("NotSet")]
        NotSet = 0,
        [Description("Alternative provision")]
        AlternativeProvision = 1,
        [Description("Mainstream")]
        Mainstream = 2,
        [Description("Special")]
        Special = 3,
        [Description("Further education")]
        FurtherEducation = 4,
        [Description("Studio school")]
        StudioSchool = 5,
        [Description("University technical college")]
        UniversityTechnicalCollege = 6
    }
}
