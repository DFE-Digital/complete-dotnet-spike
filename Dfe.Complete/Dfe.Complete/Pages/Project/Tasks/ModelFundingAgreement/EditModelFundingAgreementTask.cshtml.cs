using Dfe.ManageFreeSchoolProjects.API.Contracts.Project.Tasks;
using Dfe.ManageFreeSchoolProjects.Services;
using Dfe.ManageFreeSchoolProjects.Services.Project;
using Dfe.ManageFreeSchoolProjects.Logging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Dfe.ManageFreeSchoolProjects.Constants;
using System;
using Dfe.ManageFreeSchoolProjects.Models;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using Dfe.ManageFreeSchoolProjects.API.Contracts.Common;
using Dfe.ManageFreeSchoolProjects.Validators;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;


namespace Dfe.ManageFreeSchoolProjects.Pages.Project.Tasks.ModelFundingAgreement
{
    public class EditModelFundingAgreementTaskModel : PageModel
    {
        private readonly IGetProjectByTaskService _getProjectService;
        private readonly IUpdateProjectByTaskService _updateProjectTaskService;
        private readonly ILogger<EditModelFundingAgreementTaskModel> _logger;
        private readonly ErrorService _errorService;

        [BindProperty(SupportsGet = true, Name = "projectId")]
        public string ProjectId { get; set; }
        
        [BindProperty(Name = "tailored-model-funding-agreement")]
        public bool? TailoredAModelFundingAgreement { get; set; }
        
        [BindProperty(Name = "shared-fa-with-the-trust")]
        public bool? SharedFAWithTheTrust { get; set; }
        
        [BindProperty(Name = "trust-agrees-with-model-fa")]
        public string TrustAgreesWithModelFA { get; set; }
        
        [BindProperty(Name = "date-trust-agrees-with-model-fa", BinderType = typeof(DateInputModelBinder))]
        
        public DateTime?  DateTrustAgreesWithModelFA{ get; set; }
        
        [BindProperty(Name = "comments")]
        [Display(Name = "Comments")]
        [ValidText(999)]
        public string Comments { get; set; }
        
        [BindProperty(Name = "drafted-fa-health-check")]
        public bool?  DraftedFAHealthCheck { get; set; }
        
        [BindProperty(Name = "saved-fa-documents-in-workplaces-folder")]
        public bool? SavedFADocumentsInWorkplacesFolder { get; set; }

        public string SchoolName { get; set; }
        
        public EditModelFundingAgreementTaskModel(IGetProjectByTaskService getProjectService,
            IUpdateProjectByTaskService updateProjectTaskService,
            ILogger<EditModelFundingAgreementTaskModel> logger,
            ErrorService errorService)
        {
            _getProjectService = getProjectService;
            _updateProjectTaskService = updateProjectTaskService;
            _logger = logger;
            _errorService = errorService;
        }

        public async Task<ActionResult> OnGet()
        {
            _logger.LogMethodEntered();

            await LoadProject();
            return Page();
        }

        public async Task<ActionResult> OnPost()
        {
            var trustAgreesWithModelFa = ConvertYesNo(TrustAgreesWithModelFA);

            if (trustAgreesWithModelFa != YesNo.Yes)
            {
                // Ignore any errors for the RPA fields if the trust is not opting into RPA
                var errorKeys = ModelState.Keys.Where(k => k.StartsWith("date-trust-agrees-with-model-fa")).ToList();

                errorKeys.ForEach(k => ModelState.Remove(k));
            }
            
            
            var project = await _getProjectService.Execute(ProjectId, TaskName.ModelFundingAgreement);
            SchoolName = project.SchoolName;
            
            if (!ModelState.IsValid)
            {
                _errorService.AddErrors(ModelState.Keys, ModelState);
                return Page();
            }

            try
            {
                var request = new UpdateProjectByTaskRequest()
                {
                    ModelFundingAgreement = new ModelFundingAgreementTask()
                    {
                        TrustAgreesWithModelFA = ConvertYesNo(TrustAgreesWithModelFA),
                        DraftedFAHealthCheck = DraftedFAHealthCheck ?? false,
                        DateTrustAgreesWithModelFA = null,
                        Comments = Comments,
                        SavedFADocumentsInWorkplacesFolder = SavedFADocumentsInWorkplacesFolder ?? false,
                        TailoredAModelFundingAgreement = TailoredAModelFundingAgreement ?? false,
                        SharedFAWithTheTrust = SharedFAWithTheTrust ?? false,   
                    }
                };
                
                if (trustAgreesWithModelFa == YesNo.Yes)
                {
                    request.ModelFundingAgreement.DateTrustAgreesWithModelFA = DateTrustAgreesWithModelFA;
                }

                await _updateProjectTaskService.Execute(ProjectId, request);

                return Redirect(string.Format(RouteConstants.ViewModelFundingAgreement, ProjectId));
            }
            catch (Exception ex)
            {
                _logger.LogErrorMsg(ex);
                throw;
            }
        }

        private async Task LoadProject()
        {
            var project = await _getProjectService.Execute(ProjectId, TaskName.ModelFundingAgreement);

            TrustAgreesWithModelFA = project.ModelFundingAgreement.TrustAgreesWithModelFA?.ToString();
            DraftedFAHealthCheck = project.ModelFundingAgreement.DraftedFAHealthCheck;
            DateTrustAgreesWithModelFA = project.ModelFundingAgreement.DateTrustAgreesWithModelFA;
            Comments = project.ModelFundingAgreement.Comments;
            SavedFADocumentsInWorkplacesFolder = project.ModelFundingAgreement.SavedFADocumentsInWorkplacesFolder;
            TailoredAModelFundingAgreement = project.ModelFundingAgreement.TailoredAModelFundingAgreement;
            SharedFAWithTheTrust = project.ModelFundingAgreement.SharedFAWithTheTrust;
            
            SchoolName = project.SchoolName;
        }
        
        public static YesNo? ConvertYesNo(string value)
        {
            return Enum.TryParse<YesNo>(value, true, out var result) ? result : null;
        }
    }
}
