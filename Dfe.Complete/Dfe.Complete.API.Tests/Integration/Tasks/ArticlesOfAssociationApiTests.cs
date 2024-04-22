using Dfe.ManageFreeSchoolProjects.API.Contracts.Project.Tasks;
using Dfe.ManageFreeSchoolProjects.API.Tests.Fixtures;
using Dfe.ManageFreeSchoolProjects.API.Tests.Helpers;
using System;
using System.Threading.Tasks;

namespace Dfe.ManageFreeSchoolProjects.API.Tests.Integration.Tasks
{
    [Collection(ApiTestCollection.ApiTestCollectionName)]
    public class ArticlesOfAssociationApiTests : ApiTestsBase
    {
        public ArticlesOfAssociationApiTests(ApiTestFixture apiTestFixture) : base(apiTestFixture)
        {
        }

        [Fact]
        public async Task Patch_NewArticlesOfAssociation_Returns_201()
        {
            var project = DatabaseModelBuilder.BuildProject();
            var projectId = project.ProjectStatusProjectId;

            using var context = _testFixture.GetContext();
            context.Kpi.Add(project);
            await context.SaveChangesAsync();

            var DateTenDaysInFuture = new DateTime().AddDays(10);
            var DateNineDaysInFuture = new DateTime().AddDays(9);

            var request = new UpdateProjectByTaskRequest()
            {
                ArticlesOfAssociation = new ArticlesOfAssociationTask()
                {
                    ForecastDate = DateTenDaysInFuture,
                    ActualDate = DateNineDaysInFuture,
                    CommentsOnDecision = "CommentsOnDecisionToApprove",
                    ChairHaveSubmittedConfirmation = true,
                    CheckedSubmittedArticlesMatch = true,
                    ArrangementsMatchGovernancePlans = true,
                    SharepointLink = "https://sharepoint/completed"
                }
            };

            var projectResponse = await _client.UpdateProjectTask(projectId, request, TaskName.ArticlesOfAssociation.ToString());

            projectResponse.ArticlesOfAssociation.ForecastDate.Should().Be(DateTenDaysInFuture);
            projectResponse.ArticlesOfAssociation.ActualDate.Should().Be(DateNineDaysInFuture);
            projectResponse.ArticlesOfAssociation.CommentsOnDecision.Should().Be("CommentsOnDecisionToApprove");
            projectResponse.ArticlesOfAssociation.ChairHaveSubmittedConfirmation.Should().Be(true);
            projectResponse.ArticlesOfAssociation.CheckedSubmittedArticlesMatch.Should().Be(true);
            projectResponse.ArticlesOfAssociation.ArrangementsMatchGovernancePlans.Should().Be(true);
            projectResponse.ArticlesOfAssociation.SharepointLink.Should().Be("https://sharepoint/completed");
            projectResponse.SchoolName.Should().Be(project.ProjectStatusCurrentFreeSchoolName);
        }

        [Fact]
        public async Task Patch_ExistingNewArticlesOfAssociation_Returns_201()
        {
            var project = DatabaseModelBuilder.BuildProject();
            var projectId = project.ProjectStatusProjectId;

            using var context = _testFixture.GetContext();
            context.Kpi.Add(project);

            var articlesOfAssociationTask = DatabaseModelBuilder.BuildMilestone(project.Rid);
            context.Milestones.Add(articlesOfAssociationTask);

            await context.SaveChangesAsync();

            var DateTenDaysInFuture = new DateTime().AddDays(10);
            var DateNineDaysInFuture = new DateTime().AddDays(9);

            var request = new UpdateProjectByTaskRequest()
            {
                ArticlesOfAssociation = new ArticlesOfAssociationTask()
                {
                    ForecastDate = DateTenDaysInFuture,
                    ActualDate = DateNineDaysInFuture,
                    CommentsOnDecision = "CommentsOnDecisionToApprove",
                    ChairHaveSubmittedConfirmation = true,
                    CheckedSubmittedArticlesMatch = true,
                    ArrangementsMatchGovernancePlans = true,
                    SharepointLink = "https://sharepoint/completed"
                }
            };

            var projectResponse = await _client.UpdateProjectTask(projectId, request, TaskName.ArticlesOfAssociation.ToString());

            projectResponse.ArticlesOfAssociation.ForecastDate.Should().Be(DateTenDaysInFuture);
            projectResponse.ArticlesOfAssociation.ActualDate.Should().Be(DateNineDaysInFuture);
            projectResponse.ArticlesOfAssociation.CommentsOnDecision.Should().Be("CommentsOnDecisionToApprove");
            projectResponse.ArticlesOfAssociation.ChairHaveSubmittedConfirmation.Should().Be(true);
            projectResponse.ArticlesOfAssociation.CheckedSubmittedArticlesMatch.Should().Be(true);
            projectResponse.ArticlesOfAssociation.ArrangementsMatchGovernancePlans.Should().Be(true);
            projectResponse.ArticlesOfAssociation.SharepointLink.Should().Be("https://sharepoint/completed");
            projectResponse.SchoolName.Should().Be(project.ProjectStatusCurrentFreeSchoolName);
        }
    }
}
