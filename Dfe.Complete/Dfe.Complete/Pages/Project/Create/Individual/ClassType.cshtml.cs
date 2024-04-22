using Dfe.ManageFreeSchoolProjects.Services;
using Dfe.ManageFreeSchoolProjects.Services.Project;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Dfe.ManageFreeSchoolProjects.API.Contracts.Project;
using System.Text.RegularExpressions;
using System;
using DocumentFormat.OpenXml.EMMA;
using System.Collections.Generic;

namespace Dfe.ManageFreeSchoolProjects.Pages.Project.Create.Individual
{
    public class ClassTypeModel : CreateProjectBaseModel
    {
        private readonly ErrorService _errorService;
                
        [BindProperty(Name = "nursery")]
        [Display(Name = "Nursery")]
        [Required(ErrorMessage = "Select yes if it will have a nursery")]
        public ClassType.Nursery Nursery { get; set; }
        
        [BindProperty(Name = "sixth-form")]
        [Display(Name = "Sixth form")]
        [Required(ErrorMessage = "Select yes if it will have a sixth form")]
        public ClassType.SixthForm SixthForm { get; set; }

        [BindProperty(Name = "alternative-provision")]
        [Display(Name = "Alternative provision")]
        public ClassType.AlternativeProvision AlternativeProvision { get; set; }

        [BindProperty(Name = "special-education-needs")]
        [Display(Name = "Special educational needs")]
        public ClassType.SpecialEducationNeeds SpecialEducationNeeds { get; set; }

        public SchoolType SchoolType{ get; set; }



        public ClassTypeModel(ErrorService errorService, ICreateProjectCache createProjectCache)
            :base(createProjectCache)
        {
            _errorService = errorService;
        }

        public IActionResult OnGet()
        {
            if (!IsUserAuthorised())
            {
                return new UnauthorizedResult();
            }

            var project = _createProjectCache.Get();
            Nursery = project.Nursery;
            SixthForm = project.SixthForm;
            AlternativeProvision = project.AlternativeProvision;
            SpecialEducationNeeds = project.SpecialEducationNeeds;

            if (project.ReachedCheckYourAnswers && !(project.PreviousSchoolType.Equals(SchoolType.NotSet)))
            {
                project.SchoolType = project.PreviousSchoolType;
            }

            SchoolType = project.SchoolType;

            BackLink = GetPreviousPage(CreateProjectPageName.ClassType);
            
            return Page();
        }

        public IActionResult OnPost()
        {
            var project = _createProjectCache.Get();
            if (project.ReachedCheckYourAnswers && !(project.PreviousSchoolType.Equals(SchoolType.NotSet)))
            {
                project.SchoolType = project.PreviousSchoolType;
            }

            SchoolType = project.SchoolType;

            BackLink = GetPreviousPage(CreateProjectPageName.ClassType);

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

            if (!ModelState.IsValid)
            {
                _errorService.AddErrors(ModelState.Keys, ModelState);
                return Page();
            }

            project.Nursery = Nursery;
            project.SixthForm = SixthForm;
            project.AlternativeProvision = AlternativeProvision;
            project.SpecialEducationNeeds = SpecialEducationNeeds;

            _createProjectCache.Update(project);

            return Redirect(GetNextPage(CreateProjectPageName.ClassType));
        }
    }
}
