using Dfe.ManageFreeSchoolProjects.Services.Project;
using FluentAssertions;

namespace Dfe.ManageFreeSchoolProjects.Tests.Project
{
    public class CreateBulkProjectValidatorTests
    {
        private static readonly Fixture _fixture = new();

        [Fact]
        public void When_NoErrors_Returns_Empty()
        {
            var validator = new CreateBulkProjectValidator();
            var projectTable = _fixture.Create<ProjectTable>();

            var result = validator.Validate(projectTable);

            result.Should().BeEmpty();
        }

        [Fact]
        public void When_HasErrors_ReturnsErrors()
        {
            var validator = new CreateBulkProjectValidator();
            var projectTable = new ProjectTable()
            {
                Rows = new List<ProjectRow>()
                {
                    
                    new ProjectRow() 
                    {
                    }
                }
            };

            var result = validator.Validate(projectTable);
            result.Should().HaveCount(1);

            var rowResult = result.First();
            rowResult.Errors.Should().HaveCount(7);

            rowResult.Errors.Should().Contain("'Project Title' must not be empty.");
            rowResult.Errors.Should().Contain("'Project Id' must not be empty.");
            rowResult.Errors.Should().Contain("'Trust Name' must not be empty.");
            rowResult.Errors.Should().Contain("'Region' must not be empty.");
            rowResult.Errors.Should().Contain("'Local Authority' must not be empty.");
            rowResult.Errors.Should().Contain("'Realistic Opening Date' must not be empty.");
            rowResult.Errors.Should().Contain("'Status' must not be empty.");
        }
    }
}
