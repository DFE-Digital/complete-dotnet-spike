using Dfe.ManageFreeSchoolProjects.API.Contracts.Project.Tasks;
using Dfe.ManageFreeSchoolProjects.Constants;
using Dfe.ManageFreeSchoolProjects.Pages.Project.Create.Individual;
using Dfe.ManageFreeSchoolProjects.Services.Project;
using FluentAssertions;
using NSubstitute;

namespace Dfe.ManageFreeSchoolProjects.Tests.Project
{
    public class CreateProjectBaseModelTests
    {
        [Theory]
        [InlineData(CreateProjectPageName.LocalAuthority, RouteConstants.CreateProjectRegion)]
        [InlineData(CreateProjectPageName.FaithType, RouteConstants.CreateFaithStatus)]
        [InlineData(CreateProjectPageName.ConfirmTrustSearch, RouteConstants.CreateProjectSearchTrust)]
        [InlineData(CreateProjectPageName.ProjectId, RouteConstants.CreateProjectMethod)]
        [InlineData(CreateProjectPageName.SchoolName, RouteConstants.CreateProjectId)]
        [InlineData(CreateProjectPageName.Region, RouteConstants.CreateProjectSchool)]
        [InlineData(CreateProjectPageName.SearchTrust, RouteConstants.CreateProjectLocalAuthority)]
        [InlineData(CreateProjectPageName.ClassType, RouteConstants.CreateProjectSchoolType)]
        [InlineData(CreateProjectPageName.SchoolPhase, RouteConstants.CreateClassType)]
        [InlineData(CreateProjectPageName.AgeRange, RouteConstants.CreateProjectSchoolPhase)]
        [InlineData(CreateProjectPageName.Capacity, RouteConstants.CreateProjectAgeRange)]
        [InlineData(CreateProjectPageName.FaithStatus, RouteConstants.CreateProjectCapacity)]
        [InlineData(CreateProjectPageName.ProvisionalOpeningDate, RouteConstants.CreateFaithType)]
        [InlineData(CreateProjectPageName.ProjectLead, RouteConstants.CreateProjectProvisionalOpeningDate)]
        [InlineData(CreateProjectPageName.CheckYourAnswers, RouteConstants.CreateProjectLead)]
        public void GetPreviousPage_Returns_CorrectPage(CreateProjectPageName currentPage, string expectedPage)
        {
            var cache = Substitute.For<ICreateProjectCache>();
            cache.Get().Returns(new CreateProjectCacheItem());

            var model = new CreateProjectBaseModel(cache);

            var result = model.GetPreviousPage(currentPage);

            result.Should().Be(expectedPage);
        }

        [Fact]
        public void GetPreviousPage_GoingBackToConfirmTrust_ReturnsCorrectTrust()
        {
            var cache = Substitute.For<ICreateProjectCache>();
            cache.Get().Returns(new CreateProjectCacheItem());

            var model = new CreateProjectBaseModel(cache);

            var result = model.GetPreviousPage(CreateProjectPageName.SchoolType, "TRN0123");

            result.Should().Be(string.Format(RouteConstants.CreateProjectConfirmTrust, "TRN0123"));
        }

        [Theory]
        [InlineData(CreateProjectPageName.LocalAuthority, RouteConstants.CreateProjectRegion)]
        [InlineData(CreateProjectPageName.FaithType, RouteConstants.CreateFaithStatus)]
        [InlineData(CreateProjectPageName.ConfirmTrustSearch, RouteConstants.CreateProjectSearchTrust)]
        [InlineData(CreateProjectPageName.SchoolPhase, RouteConstants.CreateProjectCheckYourAnswers)]
        [InlineData(CreateProjectPageName.ClassType, RouteConstants.CreateProjectSchoolType)]
        public void GetPreviousPage_WhenReachedCheckYourAnswers_ReturnsCheckYourAnswers(CreateProjectPageName currentPage, string expectedPage)
        {
            var cache = Substitute.For<ICreateProjectCache>();
            cache.Get().Returns(new CreateProjectCacheItem { ReachedCheckYourAnswers = true });

            var model = new CreateProjectBaseModel(cache);

            var result = model.GetPreviousPage(currentPage);

            result.Should().Be(expectedPage);
        }

        [Theory]
        [InlineData(CreateProjectPageName.FaithStatus, RouteConstants.CreateFaithType)]
        [InlineData(CreateProjectPageName.Region, RouteConstants.CreateProjectLocalAuthority)]
        [InlineData(CreateProjectPageName.ProjectId, RouteConstants.CreateProjectSchool)]
        [InlineData(CreateProjectPageName.SchoolName, RouteConstants.CreateProjectRegion)]
        [InlineData(CreateProjectPageName.LocalAuthority, RouteConstants.CreateProjectSearchTrust)]
        [InlineData(CreateProjectPageName.ConfirmTrustSearch, RouteConstants.CreateProjectSchoolType)]
        [InlineData(CreateProjectPageName.SchoolType, RouteConstants.CreateClassType)]
        [InlineData(CreateProjectPageName.ClassType, RouteConstants.CreateProjectSchoolPhase)]
        [InlineData(CreateProjectPageName.SchoolPhase, RouteConstants.CreateProjectAgeRange)]
        [InlineData(CreateProjectPageName.AgeRange, RouteConstants.CreateProjectCapacity)]
        [InlineData(CreateProjectPageName.Capacity, RouteConstants.CreateFaithStatus)]
        [InlineData(CreateProjectPageName.FaithType, RouteConstants.CreateProjectProvisionalOpeningDate)]
        [InlineData(CreateProjectPageName.ProvisionalOpeningDate, RouteConstants.CreateProjectLead)]
        [InlineData(CreateProjectPageName.ProjectLead, RouteConstants.CreateProjectCheckYourAnswers)]
        [InlineData(CreateProjectPageName.CheckYourAnswers, RouteConstants.CreateProjectConfirmation)]
        public void GetNextPage_Returns_CorrectPage(CreateProjectPageName currentPage, string expectedPage)
        {
            var cache = Substitute.For<ICreateProjectCache>();
            cache.Get().Returns(new CreateProjectCacheItem());

            var model = new CreateProjectBaseModel(cache);

            var result = model.GetNextPage(currentPage);

            result.Should().Be(expectedPage);
        }

        [Fact]
        public void GetNextPage_GoingBackToConfirmTrust_ReturnsCorrectTrust()
        {
            var cache = Substitute.For<ICreateProjectCache>();
            cache.Get().Returns(new CreateProjectCacheItem());

            var model = new CreateProjectBaseModel(cache);

            var result = model.GetNextPage(CreateProjectPageName.SearchTrust, "TRN0123");

            result.Should().Be(string.Format(RouteConstants.CreateProjectConfirmTrust, "TRN0123"));
        }

        [Theory]
        [InlineData(CreateProjectPageName.Region, RouteConstants.CreateProjectLocalAuthority)]
        [InlineData(CreateProjectPageName.ProjectId, RouteConstants.CreateProjectCheckYourAnswers)]
        [InlineData(CreateProjectPageName.SchoolName, RouteConstants.CreateProjectCheckYourAnswers)]
        [InlineData(CreateProjectPageName.SchoolType, RouteConstants.CreateClassType)]
        public void GetNextPage_WhenReachedCheckYourAnswers_ReturnsCheckYourAnswers(CreateProjectPageName currentPage, string expectedPage)
        {
            var cache = Substitute.For<ICreateProjectCache>();
            cache.Get().Returns(new CreateProjectCacheItem { ReachedCheckYourAnswers = true });

            var model = new CreateProjectBaseModel(cache);

            var result = model.GetNextPage(currentPage);

            result.Should().Be(expectedPage);
        }

        [Fact]
        public void GetNextPage_FaithStatusNone_Returns_CorrectPage()
        {
            var cache = Substitute.For<ICreateProjectCache>();
            cache.Get().Returns(new CreateProjectCacheItem() { FaithStatus = FaithStatus.None });

            var model = new CreateProjectBaseModel(cache);

            var result = model.GetNextPage(CreateProjectPageName.FaithStatus);

            result.Should().Be(RouteConstants.CreateProjectProvisionalOpeningDate);
        }

        [Fact]
        public void GetNextPage_FaithStatusNone_CheckYourAnswers_Returns_CorrectPage()
        {
            var cache = Substitute.For<ICreateProjectCache>();
            cache.Get().Returns(new CreateProjectCacheItem() { PreviousFaithStatus = FaithStatus.None, ReachedCheckYourAnswers = true });

            var model = new CreateProjectBaseModel(cache);

            var result = model.GetNextPage(CreateProjectPageName.FaithStatus);

            result.Should().Be(RouteConstants.CreateProjectCheckYourAnswers);
        }
    }
}
