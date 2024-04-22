using Dfe.ManageFreeSchoolProjects.API.UseCases.Reports;
using System.Collections.Generic;
using System.Linq;

namespace Dfe.ManageFreeSchoolProjects.API.Tests.Reports
{
    public class MergedCellBuilderTests
    {
        [Fact]
        public void Build_ReturnsListOfMergeCells()
        {
            // Arrange
            var grouping = new Dictionary<string, List<ProjectHeaderRow>>
            {
                { "Dates", new List<ProjectHeaderRow>() { new ProjectHeaderRow(), new ProjectHeaderRow() } },
                { "School", new List<ProjectHeaderRow>() { new ProjectHeaderRow(), new ProjectHeaderRow(), new ProjectHeaderRow() } },
            };

            // Act
            var result = MergedCellBuilder.Build(1, grouping);

            // Assert
            result.Should().NotBeNull();
            result.Count.Should().Be(2);

            var firstMergedCell = result.First();
            var secondMergedCell = result.ElementAt(1);

            firstMergedCell.Reference.Value.Should().Be("A1:B1");
            secondMergedCell.Reference.Value.Should().Be("C1:E1");
        }
    }
}
