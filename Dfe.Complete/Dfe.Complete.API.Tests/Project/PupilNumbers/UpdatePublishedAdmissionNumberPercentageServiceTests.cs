using Dfe.ManageFreeSchoolProjects.API.UseCases.Project.PupilNumbers;
using Dfe.ManageFreeSchoolProjects.Data.Entities.Existing;

namespace Dfe.ManageFreeSchoolProjects.API.Tests.Project.PupilNumbers
{
    public class UpdatePublishedAdmissionNumberPercentageServiceTests
    {
        [Theory]
        [InlineData(10, 5, "50.00")]
        [InlineData(15, 19, "126.67")]
        [InlineData(0, 5, "0.00")]
        [InlineData(5, 0, "0.00")]
        [InlineData(-1, 0, "0.00")]
        [InlineData(0, -1, "0.00")]
        public void PublishedAdmissionNumberRatioReceptionToYear6(
            int receptionToYear6PublishedAdmissionNumber,
            int applicationsReceived,
            string expected)
        {
            // Arrange
            var po = new Po()
            {
                PupilNumbersAndCapacityYrPan = receptionToYear6PublishedAdmissionNumber.ToString(),
                PupilNumbersAndCapacityNoApplicationsReceivedYrY6 = applicationsReceived.ToString()
            };

            // Act
            var service = new UpdatePublishedAdmissionNumberPercentageService();

            service.Execute(po);

            // Assert
            po.PupilNumbersAndCapacityAcceptedApplicationsVsPanYrY6.Should().Be(expected);
        }

        [Theory]
        [InlineData(10, 20, 50, 160, "200.00")]
        [InlineData(33, 66, 22, 17, "14.05")]
        public void PublishedAdmissionNumberRatioYear7ToYear11(
            int year7PublishedAdmissionNumber,
            int year10PublishedAdmissionNumber,
            int otherPre16PublishedAdmissionNumber,
            int applicationsReceived,
            string expected)
        {
            // Arrange
            var po = new Po()
            {
                PupilNumbersAndCapacityY7Pan = year7PublishedAdmissionNumber.ToString(),
                PupilNumbersAndCapacityY10Pan = year10PublishedAdmissionNumber.ToString(),
                PupilNumbersAndCapacityYOtherPanPre16 = otherPre16PublishedAdmissionNumber.ToString(),
                PupilNumbersAndCapacityNoApplicationsReceivedY7Y11 = applicationsReceived.ToString()
            };

            // Act
            var service = new UpdatePublishedAdmissionNumberPercentageService();

            service.Execute(po);

            // Assert
            po.PupilNumbersAndCapacityAcceptedApplicationsVsPanY7Y11.Should().Be(expected);
        }

        [Theory]
        [InlineData(10, 70, 160, "200.00")]
        [InlineData(33, 88, 17, "14.05")]
        public void PublishedAdmissionNumberRatioYear12ToYear14(
            int year12PublishedAdmissionNumber,
            int otherPost16PublishedAdmissionNumber,
            int applicationsReceived,
            string expected)
        {
            // Arrange
            var po = new Po()
            {
                PupilNumbersAndCapacityY12Pan = year12PublishedAdmissionNumber.ToString(),
                PupilNumbersAndCapacityYOtherPanPost16 = otherPost16PublishedAdmissionNumber.ToString(),
                PupilNumbersAndCapacityNoApplicationsReceivedY12Y14 = applicationsReceived.ToString()
            };

            // Act
            var service = new UpdatePublishedAdmissionNumberPercentageService();

            service.Execute(po);

            // Assert
            po.PupilNumbersAndCapacityAcceptedApplicationsVsPanY12Y14.Should().Be(expected);
        }
    }
}
