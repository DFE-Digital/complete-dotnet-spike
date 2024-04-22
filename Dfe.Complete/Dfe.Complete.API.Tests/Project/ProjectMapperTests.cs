using Dfe.ManageFreeSchoolProjects.API.Contracts.Project;
using Dfe.ManageFreeSchoolProjects.API.Contracts.Project.Tasks;
using Dfe.ManageFreeSchoolProjects.API.UseCases.Project;

namespace Dfe.ManageFreeSchoolProjects.API.Tests.Project
{
    public class ProjectMapperTests
    {
        [Theory]
        [InlineData("FS - AP", SchoolType.AlternativeProvision)]
        [InlineData("FS - Special", SchoolType.Special)]
        [InlineData("SS", SchoolType.StudioSchool)]
        [InlineData("UTC", SchoolType.UniversityTechnicalCollege)]
        [InlineData("InvalidType", SchoolType.NotSet)]
        public void ToSchoolType_Returns_ExpectedString(string input, SchoolType? expectedResult)
        {
            var result = ProjectMapper.ToSchoolType(input);

            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(SchoolType.AlternativeProvision, "FS - AP")]
        [InlineData(SchoolType.Special, "FS - Special")]
        [InlineData(SchoolType.StudioSchool, "SS")]
        [InlineData(SchoolType.UniversityTechnicalCollege, "UTC")]
        [InlineData(null, "NotSet")]
        public void ToSchoolType_ReturnsExpectedEnum(SchoolType? input, string expectedResult)
        {
            var result = ProjectMapper.ToSchoolType(input);

            Assert.Equal(expectedResult, result);
        }
        
        [Theory]
        [InlineData("Standalone",TrustType.SingleAcademyTrust)]
        [InlineData( "MAT",TrustType.MultiAcademyTrust)]
        [InlineData("NotSet",null)]
        public void ToTrustType_ReturnsExpectedEnum(string input, TrustType expectedResult)
        {
            var result = ProjectMapper.ToTrustType(input);
            Assert.Equal(expectedResult, result);
        }
    }
}
