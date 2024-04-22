using Dfe.ManageFreeSchoolProjects.Models;
using Dfe.ManageFreeSchoolProjects.Pages.Project.Create.Individual;
using Dfe.ManageFreeSchoolProjects.Services;
using Dfe.ManageFreeSchoolProjects.Services.Project;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;

namespace Dfe.ManageFreeSchoolProjects.Pages.Project.Create
{
    public class ProvisionalOpeningDateModel : CreateProjectBaseModel
    {
        [BindProperty(Name = "provisional-opening-date", BinderType = typeof(DateInputModelBinder))]
        [Display(Name = "Provisional opening date")]
        [DateValidation(DateRangeValidationService.DateRange.Future)]
        public DateTime? ProvisionalOpeningDate { get; set; }
        
        private readonly ErrorService _errorService;

        public ProvisionalOpeningDateModel(ErrorService errorService, ICreateProjectCache createProjectCache)
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
            ProvisionalOpeningDate = project.ProvisionalOpeningDate;
            BackLink = GetPreviousPage(CreateProjectPageName.ProvisionalOpeningDate);

            return Page();
        }

        public IActionResult OnPost()
        {
            var project = _createProjectCache.Get();
            BackLink = GetPreviousPage(CreateProjectPageName.ProvisionalOpeningDate);

            if (!ModelState.IsValid)
            {
                _errorService.AddErrors(ModelState.Keys, ModelState);
                return Page();
            }

            project.ProvisionalOpeningDate = ProvisionalOpeningDate;
            _createProjectCache.Update(project);

            return Redirect(GetNextPage(CreateProjectPageName.ProvisionalOpeningDate));
        }
    }
}
