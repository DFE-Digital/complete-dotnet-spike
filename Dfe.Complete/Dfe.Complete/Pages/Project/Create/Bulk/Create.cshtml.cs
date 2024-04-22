using Dfe.ManageFreeSchoolProjects.API.Contracts.RequestModels.Projects;
using Dfe.ManageFreeSchoolProjects.Logging;
using Dfe.ManageFreeSchoolProjects.Services.Project;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Dfe.ManageFreeSchoolProjects.Constants;

namespace Dfe.ManageFreeSchoolProjects.Pages.Project.Create.Bulk
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public IFormFile Upload { get; set; }

        public ProjectTable ProjectTable { get; set; }

        public List<ProjectRowError> RowErrors { get; set; } = new();

        private readonly IProjectTableReader _projectTableReader;
        private readonly ICreateBulkProjectValidator _createBulkProjectValidator;
        private readonly ICreateProjectService _createProjectService;
        private readonly ILogger<CreateModel> _logger;

        public CreateModel(
            IProjectTableReader projectTableReader, 
            ICreateBulkProjectValidator createBulkProjectValidator,
            ICreateProjectService createProjectService,
            ILogger<CreateModel> logger)
        {
            _projectTableReader = projectTableReader;
            _createBulkProjectValidator = createBulkProjectValidator;
            _createProjectService = createProjectService;
            _logger = logger;
        }

        public IActionResult OnGet()
        {
            if (!User.IsInRole(RolesConstants.ProjectRecordCreator))
            {
                return new UnauthorizedResult();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            _logger.LogMethodEntered();

            try
            {

                using MemoryStream stream = new MemoryStream();

                await Upload.CopyToAsync(stream);

                var projectTable = _projectTableReader.Read(stream, Upload.ContentType);

                RowErrors = _createBulkProjectValidator.Validate(projectTable);

                ProjectTable = projectTable;

                CreateProjectRequest createProjectRequest = new CreateProjectRequest();

                foreach (ProjectRow proj in ProjectTable.Rows)
                {
                    ProjectDetails projReq = new ProjectDetails
                    {
                        ProjectId = proj.ProjectId,
                        SchoolName = proj.ProjectTitle
                    };

                    createProjectRequest.Projects.Add(projReq);
                }

                await _createProjectService.Execute(createProjectRequest);
            }

            catch (Exception ex)
            {
                _logger.LogErrorMsg(ex);
            }

            return Page();

        }
    }
}
