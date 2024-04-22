using Dfe.ManageFreeSchoolProjects.Constants;
using Dfe.ManageFreeSchoolProjects.Services.Project;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.ComponentModel.DataAnnotations;

namespace Dfe.ManageFreeSchoolProjects.Pages.Project.Risk
{
    public class AddRiskBaseModel : PageModel
    {
        [BindProperty(SupportsGet = true, Name = "projectId")]
        public string ProjectId { get; set; }

        [BindProperty(Name = "risk-rating")]
        [Display(Name = "risk rating")]
        public string RiskRating { get; set; }

        [BindProperty(Name = "summary")]
        [Display(Name = "summary")]
        [StringLength(1000, ErrorMessage = ValidationConstants.TextValidationMessage)]
        public string Summary { get; set; }

        public string SchoolName { get; set; }

        public string GetNextPage()
        {
            return string.Format(RouteConstants.ProjectRiskReview, ProjectId);
        }
    }
}
