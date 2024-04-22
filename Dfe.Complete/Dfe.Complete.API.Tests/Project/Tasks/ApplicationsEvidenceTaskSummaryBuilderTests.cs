using Dfe.ManageFreeSchoolProjects.API.Contracts.Project;
using Dfe.ManageFreeSchoolProjects.API.Contracts.Project.Tasks;
using Dfe.ManageFreeSchoolProjects.API.UseCases.Project.Tasks.ApplicationsEvidence;

namespace Dfe.ManageFreeSchoolProjects.API.Tests.Project.Tasks
{
    public class ApplicationsEvidenceTaskSummaryBuilderTests
    {
        [Theory]
        [InlineData(SchoolType.FurtherEducation, false)]
        [InlineData(SchoolType.Mainstream, false)]
        [InlineData(SchoolType.AlternativeProvision, true)]
        [InlineData(SchoolType.Special, true)]
        public void Build(SchoolType schoolType, bool isHidden)
        {
            // Arrange
            var builder = new ApplicationsEvidenceTaskSummaryBuilder();
            var parameters = new ApplicationsEvidenceTaskSummaryBuilderParameters
            {
                SchoolType = schoolType,
                TaskSummary = new TaskSummaryResponse
                {
                    Name = TaskName.ApplicationsEvidence.ToString(),
                    Status = ProjectTaskStatus.NotStarted,
                }
            };

            // Act
            var actual = builder.Build(parameters);

            // Assert
            actual.IsHidden.Should().Be(isHidden);
        }
    }
}
