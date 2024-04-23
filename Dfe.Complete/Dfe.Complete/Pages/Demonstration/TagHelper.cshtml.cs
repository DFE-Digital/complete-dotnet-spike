using Dfe.Complete.Constants;
using Dfe.Complete.Models;
using Dfe.Complete.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.ComponentModel.DataAnnotations;

namespace Dfe.Complete.Pages.Demonstration
{
    public class TagHelperModel : PageModel
    {
        [BindProperty(Name = "project-id")]
        [Display(Name = "Project ID")]
        [Required]
        [StringLength(10, ErrorMessage = ValidationConstants.TextValidationMessage)]
        public string ProjectID { get; set; }

        [BindProperty(Name = "school-name")]
        [Display(Name = "School name")]
        [Required]
        [StringLength(20, ErrorMessage = ValidationConstants.TextValidationMessage)]
        public string SchoolName { get; set; }

        [BindProperty(Name = "application-number")]
        [Display(Name = "Application number")]
        [Required]
        [StringLength(10, ErrorMessage = ValidationConstants.TextValidationMessage)]
        public string ApplicationNumber { get; set; }

        [BindProperty(Name = "application-wave")]
        [Display(Name = "Application wave")]
        [Required]
        [StringLength(10, ErrorMessage = ValidationConstants.TextValidationMessage)]
        public string ApplicationWave { get; set; }

        [BindProperty(Name = "project-date", BinderType = typeof(DateInputModelBinder))]
        [Display(Name = "Project date")]
        [Required]
        [DateValidation(DateRangeValidationService.DateRange.PastOrToday)]
        public DateTime? ProjectDate { get; set; }

        [BindProperty(Name = "project-description")]
        [Display(Name = "Project description")]
        [Required]
        [StringLength(10, ErrorMessage = ValidationConstants.TextValidationMessage)]
        public string ProjectDescription { get; set; }

        [BindProperty(Name = "project-cost", BinderType = typeof(MonetaryInputModelBinder))]
        [Display(Name = "Project cost")]
        [Required]
        public decimal ProjectCost { get; set; }

        [BindProperty(Name = "project-options")]
        public string ProjectOptions { get; set; }

        [BindProperty(Name = "project-approved", BinderType = typeof(CheckboxInputModelBinder))]
        public bool ProjectApproved { get; set; }

        [BindProperty(Name = "stamps")]
        public string[] Stamps { get; set; }

        public ErrorService _errorService;

        public TagHelperModel(
            ErrorService errorService
            )
        {
            _errorService = errorService;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                _errorService.AddErrors(ModelState.Keys, ModelState);
                return Page();
            }

            return Redirect("~/");
        }
    }
}
