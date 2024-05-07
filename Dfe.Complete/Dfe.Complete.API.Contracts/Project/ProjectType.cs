using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dfe.Complete.API.Contracts.Project
{
    public enum ProjectType
    {
        Conversion = 1,
        Transfer = 2
    }

    public static class ProjectTypeExtensions
    {
        private const string ConversionProjectType = "Conversion::Project";
        private const string TransferProjectType = "Transfer::Project";

        public static string ToProjectTypeString(this ProjectType? projectType)
        {
            // We haven't controlled this since it came from the Ruby code, but it defines one of only 2 types of project
            // If we get something that I haven't seen supported we should throw an exception, to make sure we do not corrupt the data
            return projectType switch
            {
                ProjectType.Conversion => ConversionProjectType,
                ProjectType.Transfer => TransferProjectType,
                _ => throw new ArgumentNullException($"Unknown project type '{projectType}'")
            };
        }

        public static ProjectType ToProjectType(string projectType)
        {
            return projectType switch
            {
                ConversionProjectType => ProjectType.Conversion,
                TransferProjectType => ProjectType.Transfer,
                _ => throw new ArgumentException($"Unknown project type '{projectType}'"),
            };
        }
    }
}
