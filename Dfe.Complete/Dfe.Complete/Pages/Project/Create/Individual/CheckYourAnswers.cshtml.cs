using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Dfe.ManageFreeSchoolProjects.API.Contracts.RequestModels.Projects;
using Dfe.ManageFreeSchoolProjects.Constants;
using Dfe.ManageFreeSchoolProjects.Extensions;
using Dfe.ManageFreeSchoolProjects.Services;
using Dfe.ManageFreeSchoolProjects.Services.Project;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Dfe.ManageFreeSchoolProjects.Pages.Project.Create.Individual
{
    public class CheckYourAnswersModel : PageModel
    {
        public CreateProjectCacheItem Project { get; set; }

        private readonly ErrorService _errorService;
        private readonly ICreateProjectCache _createProjectCache;
        private readonly ICreateProjectService _createProjectService;
        private readonly INotifyUserService _notifyUserService;
        private readonly MfspApiClient _mfspApiClient;

        public CheckYourAnswersModel(ErrorService errorService, ICreateProjectCache createProjectCache,
            ICreateProjectService createProjectService, INotifyUserService notifyUserService, MfspApiClient mfspApiClient)
        {
            _createProjectCache = createProjectCache;
            _createProjectService = createProjectService;
            _notifyUserService = notifyUserService;
            _mfspApiClient = mfspApiClient;
            _errorService = errorService;
        }

        public IActionResult OnGet()
        {
            if (!User.IsInRole(RolesConstants.ProjectRecordCreator))
            {
                return new UnauthorizedResult();
            }

            Project = _createProjectCache.Get();
            Project.ReachedCheckYourAnswers = true;
            _createProjectCache.Update(Project);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var createProjectRequest = new CreateProjectRequest();
            var project = _createProjectCache.Get();

            var projReq = new ProjectDetails
            {
                ProjectId = project.ProjectId,
                SchoolName = project.SchoolName,
                SchoolType = project.SchoolType,
                SchoolPhase = project.SchoolPhase,
                CreatedBy = User.Identity?.Name,
                LocalAuthority = project.LocalAuthority,
                LocalAuthorityCode = project.LocalAuthorityCode,
                Region = project.Region.ToDescription(),
                TRN = project.TRN,
                TrustName = project.TrustName,
                AgeRange = project.AgeRange,
                YRY6Capacity = (int)project.YRY6Capacity,
                Y7Y11Capacity = (int)project.Y7Y11Capacity,
                Y12Y14Capacity = (int)project.Y12Y14Capacity,
                Nursery = project.Nursery,
                SixthForm = project.SixthForm,
                AlternativeProvision = project.AlternativeProvision,
                SpecialEducationNeeds = project.SpecialEducationNeeds,
                FormsOfEntry = project.FormsOfEntry,
                FaithStatus = project.FaithStatus,
                FaithType = project.FaithType,
                OtherFaithType = project.OtherFaithType,
                ProvisionalOpeningDate = project.ProvisionalOpeningDate,
                ProjectLead = project.ProjectLeadName,
                ApplicationWave = "FS - Presumption"
            };

            createProjectRequest.Projects.Add(projReq);

            try
            {
                await _createProjectService.Execute(createProjectRequest);

                await SendEmail();
            }
            catch (HttpRequestException e)
            {
                if (e.StatusCode == HttpStatusCode.UnprocessableEntity)
                {
                    _errorService.AddError("projectid", $"Project with ID {project.ProjectId} already exists");
                    Project = project;
                    return Page();
                }

                if (e.StatusCode == HttpStatusCode.InternalServerError) 
                    return Redirect(RouteConstants.CreateProjectConfirmation);

                throw;
            }
            
            return Redirect(RouteConstants.CreateProjectConfirmation);
        }

        private async Task SendEmail()
        {
            var projectUrl =
                $"{HttpContext.Request.Scheme}://" +
                $"{HttpContext.Request.Host}" +
                $"{string.Format(RouteConstants.ProjectOverview, _createProjectCache.Get().ProjectId)}";

            await _notifyUserService.Execute(_createProjectCache.Get().ProjectLeadEmail, projectUrl);
        }
    }
}