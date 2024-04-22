using System.ComponentModel;

namespace Dfe.ManageFreeSchoolProjects.API.Contracts.Common
{
    public enum YesNoNotApplicable
    {
        [Description("No")]
        No = 0,
        [Description("Yes")]
        Yes = 1,
        [Description("Not applicable")]
        NotApplicable = 2
    }
}
