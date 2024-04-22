using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using Dfe.ManageFreeSchoolProjects.API.Contracts.Project.Tasks;
using Dfe.ManageFreeSchoolProjects.Constants;
using Dfe.ManageFreeSchoolProjects.Services;
using Dfe.ManageFreeSchoolProjects.Services.Project;
using Microsoft.AspNetCore.Mvc;

namespace Dfe.ManageFreeSchoolProjects.Pages.Project.Create.Individual;

public class FaithTypeModel : CreateProjectBaseModel
{

    [BindProperty(Name = "faith-type")]
    public FaithType FaithType { get; set; }
    
    [BindProperty(Name = "other-faith-type")]
    [Display(Name = "Other faith type")]
    public string OtherFaithType { get; set; }
    
    private readonly ErrorService _errorService;

    public FaithTypeModel(ICreateProjectCache createProjectCache, ErrorService errorService)
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

        FaithType = project.FaithType;
        OtherFaithType = project.OtherFaithType;
        
        BackLink = GetPreviousPage(CreateProjectPageName.FaithType);

        return Page();
    }

    public IActionResult OnPost()
    {
        var project = _createProjectCache.Get();
        BackLink = GetPreviousPage(CreateProjectPageName.FaithType);

        if (!ModelState.IsValid)
        {
            _errorService.AddErrors(ModelState.Keys, ModelState);
            return Page();
        }
        
        ValidateFaithFields();
        
        if (!ModelState.IsValid)
        {
            _errorService.AddErrors(ModelState.Keys, ModelState);
            return Page();
        }

        if (project.ReachedCheckYourAnswers)
        {
            project.FaithStatus = project.PreviousFaithStatus;
        }

        project.FaithType = FaithType;
        project.OtherFaithType = OtherFaithType;

        _createProjectCache.Update(project);

        return Redirect(GetNextPage(CreateProjectPageName.FaithType));
    }

    private void ValidateFaithFields()
    {
        if (FaithType == FaithType.NotSet)
        {
            ModelState.AddModelError("faith-type", "Select the faith type of the free school");
        }

        if (FaithType == FaithType.Other)
        {
            if (string.IsNullOrEmpty(OtherFaithType))
            {
                ModelState.AddModelError("other-faith-type", "Enter the other faith type");
            }
            else if (OtherFaithType.Length > 100)
            {
                ModelState.AddModelError("other-faith-type", "Other faith type must be 100 characters or less");
            }
            else if (Regex.Match(OtherFaithType, "[^a-zA-Z\\s]", RegexOptions.None, TimeSpan.FromSeconds(5)).Success)
            {
                ModelState.AddModelError("other-faith-type", "Other faith type must only contain letters and spaces");
            }
        }
        else if (FaithType != FaithType.Other && !string.IsNullOrEmpty(OtherFaithType))
        {
            OtherFaithType = string.Empty;
        }
    }
    
}