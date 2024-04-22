using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Dfe.ManageFreeSchoolProjects.API.Contracts.Project;
using Dfe.ManageFreeSchoolProjects.API.Contracts.Project.Tasks;
using Dfe.ManageFreeSchoolProjects.Constants;
using Dfe.ManageFreeSchoolProjects.Logging;
using Dfe.ManageFreeSchoolProjects.Models;
using Dfe.ManageFreeSchoolProjects.Services;
using Dfe.ManageFreeSchoolProjects.Services.Project;
using Dfe.ManageFreeSchoolProjects.Validators;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Dfe.ManageFreeSchoolProjects.Pages.Project.Tasks.School
{
    public class EditSchoolTaskModel : PageModel
    {
        private readonly IGetProjectByTaskService _getProjectService;
        private readonly IUpdateProjectByTaskService _updateProjectTaskService;
        private readonly ILogger<EditSchoolTaskModel> _logger;
        private readonly ErrorService _errorService;

        [BindProperty(SupportsGet = true, Name = "projectId")]
        public string ProjectId { get; set; }

        [BindProperty(Name = "current-free-school-name")]
        [Display(Name = "Current free school name")]
        [ValidText(100)]
        [Required]
        public  string CurrentFreeSchoolName { get; set; }

        [BindProperty(Name = "school-type")]
        [Display(Name = "School type")]
        [Required]
        public SchoolType SchoolType { get; set; }

        [BindProperty(Name = "school-phase")]
        [Display(Name = "School phase")]
        [Required]
        public SchoolPhase SchoolPhase { get; set; }

        [BindProperty(Name = "age-range", BinderType = typeof(NumberRangeModelBinder))]
        [Display(Name = "Age range")]
		[Required(ErrorMessage = "Enter a 'from' and 'to' age range")]
		public string AgeRange { get; set; }

        [BindProperty(Name = "forms-of-entry")]
        [Display(Name = "Forms of entry")]
        [ValidText(100)]
        public string FormsOfEntry { get; set; }

        [BindProperty(Name = "gender")]
        [Display(Name = "Gender")]
        [Required]
        public Gender Gender { get; set; }

        [BindProperty(Name = "nursery")]
        [Display(Name = "Nursery")]
        [Required]
        public ClassType.Nursery Nursery { get; set; }

        [BindProperty(Name = "sixth-form")]
        [Display(Name = "Sixth form")]
        [Required]
        public ClassType.SixthForm SixthForm { get; set; }

        [BindProperty(Name = "alternative-provision")]
        [Display(Name = "Alternative provision")]
        public ClassType.AlternativeProvision AlternativeProvision { get; set; }

        [BindProperty(Name = "special-education-needs")]
        [Display(Name = "Special educational needs")]
        public ClassType.SpecialEducationNeeds SpecialEducationNeeds { get; set; }

        [BindProperty(Name = "faith-status")]
        [Display(Name = "Faith status")]
        [Required]
        public FaithStatus FaithStatus { get; set; }

        [BindProperty(Name = "faith-type")]
        [Display(Name = "Faith type")]
        public FaithType FaithType { get; set; }

        [BindProperty(Name = "other-faith-type")]
        [Display(Name = "Other faith type")]
        public string OtherFaithType { get; set; }
        
        public IEnumerable<SchoolType> SchoolTypes { get; set; } = Enum.GetValues<SchoolType>().Except(new[] { SchoolType.NotSet });

        public EditSchoolTaskModel(
            IGetProjectByTaskService getProjectService,
            IUpdateProjectByTaskService updateProjectTaskService,
            ILogger<EditSchoolTaskModel> logger,
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

            try
            {
                var project = await _getProjectService.Execute(ProjectId, TaskName.School);
                CurrentFreeSchoolName = project.School.CurrentFreeSchoolName;
                SchoolPhase = project.School.SchoolPhase;
                Nursery = project.School.Nursery;
                SixthForm = project.School.SixthForm;
                AlternativeProvision = project.School.AlternativeProvision;
                SpecialEducationNeeds = project.School.SpecialEducationNeeds;
                Gender = project.School.Gender;
                FaithStatus = project.School.FaithStatus;
                FaithType = project.School.FaithType;
                OtherFaithType = project.School.OtherFaithType;
                FormsOfEntry = project.School.FormsOfEntry;

                if (project.School.SchoolType != SchoolType.FurtherEducation)
                {
                    SchoolTypes = SchoolTypes.Except(new[] { SchoolType.FurtherEducation });
                }
                
                SchoolType = project.School.SchoolType;
                
                if (!string.IsNullOrEmpty(project.School.AgeRange))
                {
                    AgeRange = project.School.AgeRange;
                }
            }
            catch (Exception ex)
            {
                _logger.LogErrorMsg(ex);
            }

            return Page();
        }

        public async Task<ActionResult> OnPost()
        {
            ValidateFaithFields();

            if (ProjectConstants.SchoolTypesWithSpecialistProvisions.Contains(SchoolType))
            {
                if (AlternativeProvision == ClassType.AlternativeProvision.NotSet)
                {
                    ModelState.AddModelError("alternative-provision", "Select yes if it will have alternative provision");
                }

                if (SpecialEducationNeeds == ClassType.SpecialEducationNeeds.NotSet)
                {
                    ModelState.AddModelError("special-education-needs", "Select yes if it will have special educational needs provision");
                }

            }

            else
            {
                AlternativeProvision = ClassType.AlternativeProvision.NotSet;
                SpecialEducationNeeds = ClassType.SpecialEducationNeeds.NotSet;
            }

            if (!ModelState.IsValid)
            {
                _errorService.AddErrors(ModelState.Keys, ModelState);
                return Page();
            }

            try
            {
                var request = new UpdateProjectByTaskRequest
                {
                    School = CreateUpdatedSchoolTask()
                };

                await _updateProjectTaskService.Execute(ProjectId, request);

                return Redirect(string.Format(RouteConstants.ViewSchoolTask, ProjectId));
            }
            catch (Exception ex)
            {
                _logger.LogErrorMsg(ex);
                throw;
            }
        }

        private void ValidateFaithFields()
        {
            if ((FaithStatus == FaithStatus.Ethos || FaithStatus == FaithStatus.Designation) && (FaithType == FaithType.NotSet))
            {
                ModelState.AddModelError("faith-type", "Faith type is required.");
            }

            if (FaithStatus == FaithStatus.None)
            {
                FaithType = FaithType.NotSet;
            }

            if (FaithType == FaithType.Other)
            {
                if (string.IsNullOrEmpty(OtherFaithType))
                {
                    ModelState.AddModelError("other-faith-type", "Other faith type is required.");
                }
                else if (OtherFaithType.Length > 100)
                {
                    ModelState.AddModelError("other-faith-type", "Other faith type must be 100 characters or less.");
                }
                else if (Regex.Match(OtherFaithType, "[^a-zA-Z\\s]", RegexOptions.None, TimeSpan.FromSeconds(5)).Success)
                {
                    ModelState.AddModelError("other-faith-type", "Other faith type must only contain letters and spaces.");
                }
            }
            else if (FaithType != FaithType.Other && !string.IsNullOrEmpty(OtherFaithType))
            {
                OtherFaithType = string.Empty;
            }
        }

        private SchoolTask CreateUpdatedSchoolTask()
        {
            return new SchoolTask
            {
                CurrentFreeSchoolName = CurrentFreeSchoolName,
                SchoolType = SchoolType,
                SchoolPhase = SchoolPhase,
                Nursery = Nursery,
                SixthForm = SixthForm,
                AlternativeProvision = AlternativeProvision,
                SpecialEducationNeeds = SpecialEducationNeeds,
                Gender = Gender,
                FaithStatus = FaithStatus,
                FaithType = FaithType,
                OtherFaithType = OtherFaithType,
                AgeRange = AgeRange,
                FormsOfEntry = FormsOfEntry
            };
        }
    }
}