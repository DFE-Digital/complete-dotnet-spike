using System.ComponentModel;

namespace Dfe.Complete.API.Contracts.Project
{
    public enum ProjectTeam
    {
        [Description("London")]
        London = 1,
        [Description("South East")]
        SouthEast = 2,
        [Description("Yorkshire and the Humber")]
        YorkshireAndTheHumber = 3,
        [Description("North West")]
        NorthWest = 4,
        [Description("East of England")]
        EastOfEngland = 5,
        [Description("West Midlands")]
        WestMidlands = 6,
        [Description("North East")]
        NorthEast = 7,
        [Description("South West")]
        SouthWest = 8,
        [Description("East Midlands")]
        EastMidlands = 9
    }

    public static class ProjectTeamExtensions
    {
        public static string ToProjectTeamCode(this ProjectTeam? projectTeam)
        {
            return projectTeam switch
            {
                ProjectTeam.London => "london",
                ProjectTeam.SouthEast => "south_east",
                ProjectTeam.YorkshireAndTheHumber => "yorkshire_and_the_humber",
                ProjectTeam.NorthWest => "north_west",
                ProjectTeam.EastOfEngland => "east_of_england",
                ProjectTeam.WestMidlands => "west_midlands",
                ProjectTeam.NorthEast => "north_east",
                ProjectTeam.SouthWest => "south_west",
                ProjectTeam.EastMidlands => "east_midlands",
                _ => null
            };
        }

        public static ProjectTeam? ToProjectTeam(string projectTeam)
        {
            return projectTeam switch
            {
                "london" => ProjectTeam.London,
                "south_east" => ProjectTeam.SouthEast,
                "yorkshire_and_the_humber" => ProjectTeam.YorkshireAndTheHumber,
                "north_west" => ProjectTeam.NorthWest,
                "east_of_england" => ProjectTeam.EastOfEngland,
                "west_midlands" => ProjectTeam.WestMidlands,
                "north_east" => ProjectTeam.NorthEast,
                "south_west" => ProjectTeam.SouthWest,
                "east_midlands" => ProjectTeam.EastMidlands,
                _ => null,
            };
        }
    }
}
