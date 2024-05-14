using System.ComponentModel;

namespace Dfe.Complete.API.Contracts.Project
{
    public enum Region
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

    public static class RegionExtensions
    {
        public static string ToRegionCode(this Region? region)
        {
            return region switch
            {
                Region.London => "H",
                Region.SouthEast => "J",
                Region.YorkshireAndTheHumber => "D",
                Region.NorthWest => "B",
                Region.EastOfEngland => "G",
                Region.WestMidlands => "F",
                Region.NorthEast => "A",
                Region.SouthWest => "K",
                Region.EastMidlands => "E",
                _ => null
            };
        }

        public static Region? ToRegion(string region)
        {
            return region switch
            {
                "H" => Region.London,
                "J" => Region.SouthEast,
                "D" => Region.YorkshireAndTheHumber,
                "B" => Region.NorthWest,
                "G" => Region.EastOfEngland,
                "F" => Region.WestMidlands,
                "A" => Region.NorthEast,
                "K" => Region.SouthWest,
                "E" => Region.EastMidlands,
                _ => null,
            };
        }
    }
}
