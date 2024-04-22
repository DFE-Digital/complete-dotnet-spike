using System.ComponentModel;

namespace Dfe.ManageFreeSchoolProjects.API.Contracts.Project
{
    public enum ProjectRegion
    {
        [Description("East Midlands")]
        EastMidlands = 1,
        [Description("East of England")]
        EastOfEngland = 2,
        [Description("London")]
        London = 3,
        [Description("North East")]
        NorthEast = 4,
        [Description("North West")]
        NorthWest = 5,
        [Description("South East")]
        SouthEast = 6,
        [Description("South West")]
        SouthWest = 7,
        [Description("West Midlands")]
        WestMidlands = 8,
        [Description("Yorkshire and the Humber")]
        YorkshireAndHumber = 9
    }
}
