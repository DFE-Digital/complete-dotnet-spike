using Dfe.ManageFreeSchoolProjects.API.Contracts.Project.Sites;

namespace Dfe.ManageFreeSchoolProjects.API.Tests.Helpers
{
    public static class AssertionHelper
    {
        public static void AssertProjectSite(ProjectSite actual, ProjectSite expected)
        {
            actual.Address.Should().BeEquivalentTo(expected.Address);
            actual.StartDateOfSiteOccupation.Value.Date.Should().Be(expected.StartDateOfSiteOccupation.Value.Date);
            actual.DatePlanningPermissionObtained.Should().Be(expected.DatePlanningPermissionObtained);
        }
    }
}
