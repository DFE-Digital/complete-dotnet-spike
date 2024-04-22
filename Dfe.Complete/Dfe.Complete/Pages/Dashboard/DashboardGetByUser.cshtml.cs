using Dfe.ManageFreeSchoolProjects.Logging;
using Dfe.ManageFreeSchoolProjects.Services.Dashboard;
using Dfe.ManageFreeSchoolProjects.Services.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Dfe.ManageFreeSchoolProjects.Pages.Dashboard
{
    public class DashboardGetByUserModel : DashboardBasePageModel
    {
        private readonly ILogger<DashboardGetByUserModel> _logger;

        public DashboardGetByUserModel(
            ICreateUserService createUserService,
            IGetDashboardService getDashboardService,
            IGetLocalAuthoritiesService getLocalAuthoritiesService,
            IGetProjectManagersService getProjectManagersService,
            ILogger<DashboardGetByUserModel> logger) : base(createUserService, getDashboardService, getLocalAuthoritiesService, getProjectManagersService)
        {
            _logger = logger;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            _logger.LogMethodEntered();

            try
            {
                await AddUser();
                await LoadPage();
            }
            catch (Exception ex)
            {
                _logger.LogErrorMsg(ex);
                throw;
            }

            return Page();
        }

        public async Task<IActionResult> OnGetMovePage()
        {
            _logger.LogMethodEntered();

            try
            {
                await LoadPage();
            }
            catch (Exception ex)
            {
                _logger.LogErrorMsg(ex);
                throw;
            }

            return Page();
        }

        public async Task<IActionResult> OnPostSearch()
        {
            _logger.LogMethodEntered();

            try
            {
                await LoadPage();
            }
            catch (Exception ex)
            {
                _logger.LogErrorMsg(ex);
                throw;
            }

            return Page();
        }

        public async Task<IActionResult> OnGetClearFilters()
        {
            _logger.LogMethodEntered();
            try
            {
                await LoadPage();
            }
            catch (Exception ex)
            {
                _logger.LogErrorMsg(ex);
                throw;
            }

            return Page();
        }

        private async Task LoadPage()
        {
            var username = User.Identity.Name;

            var parameters = new LoadDashboardParameters
            {
                GetDashboardServiceParameters = new GetDashboardServiceParameters
                {
                    UserId = username
                },
                Url = "/my"
            };

            await LoadDashboard(parameters);

            Dashboard.Header = "Your projects";
        }
    }
}
