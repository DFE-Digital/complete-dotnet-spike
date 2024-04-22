using Dfe.ManageFreeSchoolProjects.Constants;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using Dfe.ManageFreeSchoolProjects.Services.Project;

namespace Dfe.ManageFreeSchoolProjects.Pages.Project.Create.Individual
{
    public class CreateProjectBaseModel : PageModel
    {
        protected internal string BackLink { get; set; }
        protected readonly ICreateProjectCache _createProjectCache;

        public CreateProjectBaseModel(ICreateProjectCache createProjectCache)
        {
            _createProjectCache = createProjectCache;
        }

        public bool IsUserAuthorised()
        {
            return User.IsInRole(RolesConstants.ProjectRecordCreator);
        }

        public string GetPreviousPage(CreateProjectPageName currentPageName,
            string routeParameter = "")
        {
            return currentPageName switch
            {
                CreateProjectPageName.LocalAuthority => RouteConstants.CreateProjectRegion,
                CreateProjectPageName.FaithType => RouteConstants.CreateFaithStatus,
                CreateProjectPageName.ConfirmTrustSearch => RouteConstants.CreateProjectSearchTrust,
                CreateProjectPageName.ClassType => RouteConstants.CreateProjectSchoolType,
                _ => DefaultPreviousRoute(currentPageName, routeParameter)
            };           
        }

        private string DefaultPreviousRoute(CreateProjectPageName currentPageName, string routeParameter)
        {
            var cache = _createProjectCache.Get();

            if (cache.ReachedCheckYourAnswers)
                return RouteConstants.CreateProjectCheckYourAnswers;

            return currentPageName switch
            {
                CreateProjectPageName.ProjectId => RouteConstants.CreateProjectMethod,
                CreateProjectPageName.SchoolName => RouteConstants.CreateProjectId,
                CreateProjectPageName.Region => RouteConstants.CreateProjectSchool,
                CreateProjectPageName.SearchTrust => RouteConstants.CreateProjectLocalAuthority,
                CreateProjectPageName.SchoolType => string.Format(RouteConstants.CreateProjectConfirmTrust,
                    routeParameter),
                CreateProjectPageName.ClassType => RouteConstants.CreateProjectSchoolType,
                CreateProjectPageName.SchoolPhase => RouteConstants.CreateClassType,
                CreateProjectPageName.AgeRange => RouteConstants.CreateProjectSchoolPhase,
                CreateProjectPageName.Capacity => RouteConstants.CreateProjectAgeRange,
                CreateProjectPageName.FaithStatus => RouteConstants.CreateProjectCapacity,
                CreateProjectPageName.ProvisionalOpeningDate => RouteConstants.CreateFaithType,
                CreateProjectPageName.ProjectLead => RouteConstants.CreateProjectProvisionalOpeningDate,
                CreateProjectPageName.CheckYourAnswers => RouteConstants.CreateProjectLead,
                _ => throw new ArgumentOutOfRangeException($"Unsupported create project page {currentPageName}")
            };
        }

        public string GetNextPage(CreateProjectPageName currentPageName, string routeParameter = "")
        {
            return currentPageName switch
            {
                CreateProjectPageName.FaithStatus => NextFaithStatus(),
                CreateProjectPageName.Region => RouteConstants.CreateProjectLocalAuthority,
                CreateProjectPageName.SearchTrust => string.Format(RouteConstants.CreateProjectConfirmTrust, routeParameter),
                CreateProjectPageName.SchoolType => RouteConstants.CreateClassType,
                _ => DefaultNextRoute(currentPageName)
            };
        }

        private string NextFaithStatus()
        {
            var cache = _createProjectCache.Get();

            var faithStatus = cache.ReachedCheckYourAnswers ? cache.PreviousFaithStatus : cache.FaithStatus;

            if (faithStatus == API.Contracts.Project.Tasks.FaithStatus.None)
                return cache.ReachedCheckYourAnswers ? RouteConstants.CreateProjectCheckYourAnswers
                                                     : RouteConstants.CreateProjectProvisionalOpeningDate;

            return RouteConstants.CreateFaithType;
        }

        private string DefaultNextRoute(CreateProjectPageName currentPageName)
        {
            var cache = _createProjectCache.Get();

            if (cache.ReachedCheckYourAnswers)
                return RouteConstants.CreateProjectCheckYourAnswers;

            return currentPageName switch
            {
                CreateProjectPageName.ProjectId => RouteConstants.CreateProjectSchool,
                CreateProjectPageName.SchoolName => RouteConstants.CreateProjectRegion,
                CreateProjectPageName.LocalAuthority => RouteConstants.CreateProjectSearchTrust,
                CreateProjectPageName.ConfirmTrustSearch => RouteConstants.CreateProjectSchoolType,
                CreateProjectPageName.SchoolType => RouteConstants.CreateClassType,
                CreateProjectPageName.ClassType => RouteConstants.CreateProjectSchoolPhase,
                CreateProjectPageName.SchoolPhase => RouteConstants.CreateProjectAgeRange,
                CreateProjectPageName.AgeRange => RouteConstants.CreateProjectCapacity,
                CreateProjectPageName.Capacity => RouteConstants.CreateFaithStatus,
                CreateProjectPageName.FaithType => RouteConstants.CreateProjectProvisionalOpeningDate,
                CreateProjectPageName.ProvisionalOpeningDate => RouteConstants.CreateProjectLead,
                CreateProjectPageName.ProjectLead => RouteConstants.CreateProjectCheckYourAnswers,
                CreateProjectPageName.CheckYourAnswers => RouteConstants.CreateProjectConfirmation,
                _ => throw new ArgumentOutOfRangeException($"Unsupported create project page {currentPageName}")
            };
        }
    }
}