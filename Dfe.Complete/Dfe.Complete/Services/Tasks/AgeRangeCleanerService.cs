using System;
using System.Text.RegularExpressions;

namespace Dfe.ManageFreeSchoolProjects.Services.Tasks
{
    public interface IAgeRangeCleanerService
    {
        string Clean(string input);
    }

    public class AgeRangeCleanerService : IAgeRangeCleanerService
    {
        public AgeRangeCleanerService() { }

        public string Clean(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return "";
            }

            var cleanedInput = input.Replace("to", "-").Replace(" ", "");
            var regex = new Regex(@"\d+-\d+", RegexOptions.None, TimeSpan.FromSeconds(5));
            var match = regex.Match(cleanedInput);
            return match.Value;
        }
    }
}
