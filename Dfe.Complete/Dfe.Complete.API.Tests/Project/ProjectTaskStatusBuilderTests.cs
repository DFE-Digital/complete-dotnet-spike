using Dfe.Complete.API.Contracts.Project;
using Dfe.Complete.API.Contracts.Project.Transfer.Tasks;
using Dfe.Complete.API.UseCases.Project;
namespace Dfe.Complete.API.Tests.Project
{
    public class ProjectTaskStatusBuilderTests
    {
        [Fact]
        public void WhenAllFieldsEmpty_Returns_NotStarted()
        {
            var task = new HandoverWithDeliveryOfficerTask();

            var result = ProjectTaskStatusBuilder.Build(task);

            result.Should().Be(ProjectTaskStatus.NotStarted);
        }

        [Fact]
        public void WhenAllFieldsFalse_Returns_NotStarted()
        {
            var task = new HandoverWithDeliveryOfficerTask()
            {
                ReviewProjectInformation = false,
                MakeNotes = false,
                AttendHandoverMeeting = false
            };

            var result = ProjectTaskStatusBuilder.Build(task);

            result.Should().Be(ProjectTaskStatus.NotStarted);
        }

        [Fact]
        public void WhenFieldsAreSet_Returns_InProgress()
        {
            var task = new HandoverWithDeliveryOfficerTask()
            {
                ReviewProjectInformation = true,
                MakeNotes = true
            };

            var result = ProjectTaskStatusBuilder.Build(task);

            result.Should().Be(ProjectTaskStatus.InProgress);
        }

        [Fact]
        public void WhenAllFieldsSet_Returns_Completed()
        {
            var task = new HandoverWithDeliveryOfficerTask()
            {
                ReviewProjectInformation = true,
                MakeNotes = true,
                AttendHandoverMeeting = true
            };

            var result = ProjectTaskStatusBuilder.Build(task);

            result.Should().Be(ProjectTaskStatus.Completed);
        }

        [Fact]
        public void NotApplicable_Returns_NotApplicable()
        {
            var task = new HandoverWithDeliveryOfficerTask()
            {
                NotApplicable = true,
                AttendHandoverMeeting = true,
                MakeNotes = true,
                ReviewProjectInformation = true
            };

            var result = ProjectTaskStatusBuilder.Build(task);

            result.Should().Be(ProjectTaskStatus.NotApplicable);
        }
    }
}
