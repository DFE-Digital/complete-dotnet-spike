using Dfe.ManageFreeSchoolProjects.API.Contracts.Constituency;
using Dfe.ManageFreeSchoolProjects.API.Contracts.Project.Tasks;
using Dfe.ManageFreeSchoolProjects.Constants;
using Dfe.ManageFreeSchoolProjects.Logging;
using Dfe.ManageFreeSchoolProjects.Pages.Project.Tasks.School;
using Dfe.ManageFreeSchoolProjects.Services;
using Dfe.ManageFreeSchoolProjects.Services.Constituency;
using Dfe.ManageFreeSchoolProjects.Services.Project;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Dfe.ManageFreeSchoolProjects.Pages.Project.Tasks.Constituency
{
    public class EditConstituencyModel : PageModel
    {
        [BindProperty(SupportsGet = true, Name = "search")]
        public string SearchTerm { get; set; }

        [BindProperty(SupportsGet = true, Name = "projectId")]
        public string ProjectId { get; set; }

        [BindProperty]
        public string CurrentFreeSchoolName { get; set; }

        [BindProperty(Name = "constituency")]
        [Display(Name = "Constituency")]
        [Required]
        public string Constituency { get; set; }


		[BindProperty(Name = "constituencyResults")]
		public string ConstituencyResults { get; set; }

		public string[] Labels { get; set; }
        public string[] Values { get; set; }
        public string[] Hints { get; set; }

		private const string None = "#None#";

		private readonly ILogger<ViewSchoolTask> _logger;
        private readonly IGetProjectByTaskService _getProjectService;
        private readonly ISearchConstituency _searchConstituency;
        private readonly IUpdateProjectByTaskService _updateProjectTaskService;
        private readonly ErrorService _errorService;

        public EditConstituencyModel(
            IGetProjectByTaskService getProjectService,
            ISearchConstituency searchConstituency,
            ILogger<ViewSchoolTask> logger,
            IUpdateProjectByTaskService updateProjectTaskService,
            ErrorService errorService)
        {
            _logger = logger;
            _errorService = errorService;
            _getProjectService = getProjectService;
            _searchConstituency = searchConstituency;
            _updateProjectTaskService = updateProjectTaskService;
        }

        public async Task<ActionResult> OnGet()
		{
			_logger.LogMethodEntered();

			var project = await _getProjectService.Execute(ProjectId, TaskName.Constituency);

			CurrentFreeSchoolName = project.SchoolName;
            var response = await _searchConstituency.Execute(SearchTerm);
            
            if(response.Data.Constituencies.Count == 0)
            {
                return Page();
            }

			LoadPage(response.Data.Constituencies);

			return Page();
		}

		private void LoadPage(List<SearchConstituencyResponse> constituencyResponses)
		{
			Labels = constituencyResponses.Select(x => x.Name).Append("None of the above - I want to search again").ToArray();
			Values = constituencyResponses.Select(x => x.Name).Append(None).ToArray();
			Hints = constituencyResponses.Select(x => $"MP - {x.MPName}{Environment.NewLine}Political Party - {x.Party}").Append("").ToArray();

            ConstituencyResults = constituencyResponses.Select(x => $"{x.Name}~{x.MPName}~{x.Party}").Aggregate((acc, next) => acc + "|" + next);
		}

		public async Task<ActionResult> OnPost()
        {
            _logger.LogMethodEntered();

            var project = await _getProjectService.Execute(ProjectId, TaskName.Constituency);
            CurrentFreeSchoolName = project.SchoolName;

            List<SearchConstituencyResponse> constituencyResponses = ConstituencyResults.Split("|")
                .Select(x => new SearchConstituencyResponse() { Name = x.Split("~")[0], MPName = x.Split("~")[1], Party = x.Split("~")[2]}).ToList();

            if (!ModelState.IsValid)
			{
				_errorService.AddErrors(ModelState.Keys, ModelState);
				LoadPage(constituencyResponses);
				return Page();
			}

			if (Constituency == None)
            {
				return Redirect(string.Format(RouteConstants.SearchConstituency, ProjectId));
			}

            var selected = constituencyResponses.First(x => x.Name == Constituency);

            var request = new UpdateProjectByTaskRequest()
            {
                Constituency = new ConstituencyTask()
                {
                    Name = selected.Name,
                    MPName = selected.MPName,
                    Party = selected.Party,
                }
            };

            await _updateProjectTaskService.Execute(ProjectId, request);

            return Redirect(string.Format(RouteConstants.ViewConstituency, ProjectId));
		}

	}
}
