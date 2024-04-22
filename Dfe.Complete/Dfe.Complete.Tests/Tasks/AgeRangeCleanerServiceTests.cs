using Dfe.ManageFreeSchoolProjects.Services.Tasks;
using FluentAssertions;

namespace Dfe.ManageFreeSchoolProjects.Tests.Tasks
{
    public class AgeRangeCleanerServiceTests
    {
        [Theory]
        [InlineData("", "")]
        [InlineData(null, "")]
        [InlineData("4-11", "4-11")]
        [InlineData(" 4-11", "4-11")]
        [InlineData("4-11 ", "4-11")]
        [InlineData("0 - 19", "0-19")]
        [InlineData("7 to 16", "7-16")]
        [InlineData("5 to 12 with a description", "5-12")]
        [InlineData("1200", "")]
        [InlineData("!\"£$%^&*()", "")]
        public void Clean_AgeRange_ReturnsCleanedAgeRange(string ageRange, string result)
        {
            var ageRangeCleanerService = new AgeRangeCleanerService();

            var cleanedAgeRange = ageRangeCleanerService.Clean(ageRange);

            cleanedAgeRange.Should().Be(result);
        }
    }
}
