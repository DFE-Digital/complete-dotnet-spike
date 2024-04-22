using System.ComponentModel;

namespace Dfe.ManageFreeSchoolProjects.API.Contracts.Project
{
    public enum ProjectLocalAuthority
    {
        [Description("Bedford")]
        Bedford = 1,
        [Description("Cambridgeshire")]
        Cambridgeshire = 2,
        [Description("Central Bedfordshire")]
        CentralBedfordshire = 3,
        [Description("Essex")]
        Essex = 4,
        [Description("Hertfordshire")]
        Hertfordshire = 5
    }
}
