using Dfe.ManageFreeSchoolProjects.API.Contracts.Project.Tasks;
using Dfe.ManageFreeSchoolProjects.Constants;
using Dfe.ManageFreeSchoolProjects.Logging;
using Dfe.ManageFreeSchoolProjects.Services;
using Dfe.ManageFreeSchoolProjects.Services.Project;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Dfe.ManageFreeSchoolProjects.Models;
using Dfe.ManageFreeSchoolProjects.Validators;


namespace Dfe.ManageFreeSchoolProjects.Pages.Project.Tasks.OfstedPreRegistration
{
    public class EditOfstedPreRegistrationBeforeTaskModel : PageModel
    {
        private readonly IGetProjectByTaskService _getProjectService;
        private readonly IUpdateProjectByTaskService _updateProjectTaskService;
        private readonly ILogger<EditOfstedPreRegistrationBeforeTaskModel> _logger;
        

        [BindProperty(SupportsGet = true, Name = "projectId")]
        public string ProjectId { get; set; }
        
        [BindProperty(Name = "process-details-provided")]
        
        public bool? ProcessDetailsProvided{ get; set; }
        
        
        [BindProperty(Name = "inspection-block-decided")]
        
        public bool? InspectionBlockDecided{ get; set; }
        
        [BindProperty(Name = "ofsted-and-trust-liaison-details-confirmed")]
        
        public bool? OfstedAndTrustLiaisonDetailsConfirmed{ get; set; }
        
        
        [BindProperty(Name = "block-and-content-details-to-openers-spreadsheet")]
        
        public bool? BlockAndContentDetailsToOpenersSpreadSheet{ get; set; }
        
        public string SchoolName { get; set; }

        public EditOfstedPreRegistrationBeforeTaskModel(IGetProjectByTaskService getProjectService,
            IUpdateProjectByTaskService updateProjectTaskService,
            ILogger<EditOfstedPreRegistrationBeforeTaskModel> logger,
            ErrorService errorService)
        {
            _getProjectService = getProjectService;
            _updateProjectTaskService = updateProjectTaskService;
            _logger = logger;
        }

        public async Task<ActionResult> OnGet()
        {
            _logger.LogMethodEntered();

            await LoadProject();
            return Page();
        }

        public async Task<ActionResult> OnPost()
        {
            var project = await _getProjectService.Execute(ProjectId, TaskName.OfstedInspection);
            SchoolName = project.SchoolName;
         
          
            var request = new UpdateProjectByTaskRequest()
            {
                OfstedInspection = project.OfstedInspection
            };

            request.OfstedInspection.ProcessDetailsProvided = ProcessDetailsProvided;
            request.OfstedInspection.InspectionBlockDecided = InspectionBlockDecided;
            request.OfstedInspection.OfstedAndTrustLiaisonDetailsConfirmed = OfstedAndTrustLiaisonDetailsConfirmed;
            request.OfstedInspection.BlockAndContentDetailsToOpenersSpreadSheet = BlockAndContentDetailsToOpenersSpreadSheet; 
                     
                            

                await _updateProjectTaskService.Execute(ProjectId, request);
                return Redirect(string.Format(RouteConstants.ViewOfstedPreRegistrationTask, ProjectId));
        }

        private async Task LoadProject()
        {
            var project = await _getProjectService.Execute(ProjectId, TaskName.OfstedInspection);

            ProcessDetailsProvided = project.OfstedInspection.ProcessDetailsProvided;
            InspectionBlockDecided = project.OfstedInspection.InspectionBlockDecided;
            OfstedAndTrustLiaisonDetailsConfirmed = project.OfstedInspection.OfstedAndTrustLiaisonDetailsConfirmed;
            BlockAndContentDetailsToOpenersSpreadSheet = project.OfstedInspection.BlockAndContentDetailsToOpenersSpreadSheet;
            
            SchoolName = project.SchoolName;
        }
    }
}