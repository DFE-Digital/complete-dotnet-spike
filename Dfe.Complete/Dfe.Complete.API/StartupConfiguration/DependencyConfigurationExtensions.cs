using Dfe.ManageFreeSchoolProjects.API.UseCases;
using Dfe.ManageFreeSchoolProjects.API.UseCases.Constituency;
using Dfe.ManageFreeSchoolProjects.API.UseCases.Construct;
using Dfe.ManageFreeSchoolProjects.API.UseCases.Dashboard;
using Dfe.ManageFreeSchoolProjects.API.UseCases.Email;
using Dfe.ManageFreeSchoolProjects.API.UseCases.Project;
using Dfe.ManageFreeSchoolProjects.API.UseCases.Project.Contacts;
using Dfe.ManageFreeSchoolProjects.API.UseCases.Project.PupilNumbers;
using Dfe.ManageFreeSchoolProjects.API.UseCases.Project.Risk;
using Dfe.ManageFreeSchoolProjects.API.UseCases.Project.Sites;
using Dfe.ManageFreeSchoolProjects.API.UseCases.Project.Tasks;
using Dfe.ManageFreeSchoolProjects.API.UseCases.Project.Tasks.AdmissionsArrangements;
using Dfe.ManageFreeSchoolProjects.API.UseCases.Project.Tasks.ApplicationsEvidence;
using Dfe.ManageFreeSchoolProjects.API.UseCases.Project.Tasks.ArticlesOfAssociation;
using Dfe.ManageFreeSchoolProjects.API.UseCases.Project.Tasks.Constituency;
using Dfe.ManageFreeSchoolProjects.API.UseCases.Project.Tasks.Dates;
using Dfe.ManageFreeSchoolProjects.API.UseCases.Project.Tasks.DraftGovernancePlan;
using Dfe.ManageFreeSchoolProjects.API.UseCases.Project.Tasks.EducationBrief;
using Dfe.ManageFreeSchoolProjects.API.UseCases.Project.Tasks.EqualitiesAssessment;
using Dfe.ManageFreeSchoolProjects.API.UseCases.Project.Tasks.EvidenceOfAcceptedOffers;
using Dfe.ManageFreeSchoolProjects.API.UseCases.Project.Tasks.FinancePlan;
using Dfe.ManageFreeSchoolProjects.API.UseCases.Project.Tasks.FundingAgreementHealthCheck;
using Dfe.ManageFreeSchoolProjects.API.UseCases.Project.Tasks.Gias;
using Dfe.ManageFreeSchoolProjects.API.UseCases.Project.Tasks.ImpactAssessment;
using Dfe.ManageFreeSchoolProjects.API.UseCases.Project.Tasks.KickOffMeeting;
using Dfe.ManageFreeSchoolProjects.API.UseCases.Project.Tasks.ModelFundingAgreement;
using Dfe.ManageFreeSchoolProjects.API.UseCases.Project.Tasks.OfstedInspection;
using Dfe.ManageFreeSchoolProjects.API.UseCases.Project.Tasks.RegionAndLocalAuthority;
using Dfe.ManageFreeSchoolProjects.API.UseCases.Project.Tasks.RiskAppraisalMeeting;
using Dfe.ManageFreeSchoolProjects.API.UseCases.Project.Tasks.School;
using Dfe.ManageFreeSchoolProjects.API.UseCases.Project.Tasks.StatutoryConsultation;
using Dfe.ManageFreeSchoolProjects.API.UseCases.Project.Tasks.Trusts;
using Dfe.ManageFreeSchoolProjects.API.UseCases.ProjectOverview;
using Dfe.ManageFreeSchoolProjects.API.UseCases.Reports;
using Dfe.ManageFreeSchoolProjects.API.UseCases.Tasks;
using Dfe.ManageFreeSchoolProjects.API.UseCases.Users;
using Dfe.ManageFreeSchoolProjects.Logging;
using Dfe.ManageFreeSchoolProjects.UserContext;
using FluentValidation;
using System.Reflection;
using Dfe.ManageFreeSchoolProjects.API.UseCases.Project.Tasks.PDG.PaymentSchedule;
using Dfe.ManageFreeSchoolProjects.API.UseCases.Project.Tasks.PDG.TrustLetterPDGLetterSent;
using Dfe.ManageFreeSchoolProjects.API.UseCases.Project.Tasks.PDG.StopPayments;
using Dfe.ManageFreeSchoolProjects.API.UseCases.Project.Tasks.PDG.Refunds;
using Dfe.ManageFreeSchoolProjects.API.UseCases.Project.Tasks.PDG.WriteOff;
using Dfe.ManageFreeSchoolProjects.API.UseCases.Project.Tasks.FinalFinancePlan;

namespace Dfe.ManageFreeSchoolProjects.API.StartupConfiguration
{
    public static class DependencyConfigurationExtensions
	{
		public static IServiceCollection AddApiDependencies(this IServiceCollection services)
		{
			services.AddScoped<IServerUserInfoService, ServerUserInfoService>();
			
			services.AddScoped<ICorrelationContext, CorrelationContext>();

            services.AddScoped<IGetDashboardService, GetDashboardService>();
			services.AddScoped<ICreateProjectService, CreateProject>();
            services.AddScoped<ICreateUserService, CreateUserService>();
			services.AddScoped<IGetProjectOverviewService, GetProjectOverviewService>();
			services.AddScoped<IUpdateProjectByTaskService, UpdateProjectByTaskService>();
            services.AddScoped<IGetProjectByTaskService, GetProjectByTaskService>();
			services.AddScoped<IGetLocalAuthoritiesService, GetLocalAuthoritiesService>();
			services.AddScoped<IEmailService, EmailService>();
			services.AddScoped<IGetTasksService, GetAllTasksStatusService>();
			services.AddScoped<IGetTaskStatusService, GetTaskStatusService>(); 
			services.AddScoped<IUpdateTaskStatusService, UpdateTaskStatusService>();
			services.AddScoped<ICreateTasksService, CreateTasksService>();
			services.AddScoped<ICreateProjectRiskService,  CreateProjectRiskService>();
			services.AddScoped<IGetProjectRiskService,  GetProjectRiskService>();
			services.AddScoped<IGetTrustByRefService, GetTrustByRefService>();
            services.AddScoped<ISearchTrustByRefService, SearchTrustByRefService>();
            services.AddScoped<ISearchConstituencyService, SearchConstituencyService>();
            services.AddScoped<IGetProjectManagersService, GetProjectManagersService>();
            services.AddScoped<IGetProjectContactsService, GetProjectContactsService>();
            services.AddScoped<IUpdateProjectContactsService, UpdateProjectContactsService>();
			services.AddScoped<IUpdateTaskService, UpdateSchoolTaskService>();
			services.AddScoped<IUpdateTaskService, UpdateDatesTaskService>();
			services.AddScoped<IUpdateTaskService, UpdateRegionAndLocalAuthorityTaskService>();
			services.AddScoped<IUpdateTaskService, UpdateRiskAppraisalMeetingTaskService>();
			services.AddScoped<IUpdateTaskService, UpdateConstituencyTaskService>();
			services.AddScoped<IUpdateTaskService, UpdateTrustTaskService>();
            services.AddScoped<IUpdateTaskService, UpdateArticlesOfAssociationTaskService>();
			services.AddScoped<IUpdateTaskService, UpdateFinancePlanTaskService>();
			services.AddScoped<IGetConstructProjectListService, GetConstructProjectListService>();
			services.AddScoped<IApiKeyValidationService, ApiKeyValidationService>();
			services.AddScoped<IConstructApiKeyValidationService, ConstructApiKeyValidationService>();
            services.AddScoped<IUpdateTaskService, UpdateKickOffMeetingTaskService>();
            services.AddScoped<IUpdateTaskService, UpdateGiasTaskService>();
            services.AddScoped<IUpdateTaskService, UpdateStatutoryConsultationTaskService>();
            services.AddScoped<IUpdateTaskService, UpdateModelFundingAgreementTaskService>();
			services.AddScoped<IUpdateTaskService, UpdateDraftGovernancePlanTaskService>();
			services.AddScoped<IUpdateTaskService, UpdateEducationBriefTaskService>();
			services.AddScoped<IUpdateTaskService, UpdateEqualitiesAssessmentTaskService>();
			services.AddScoped<IUpdateTaskService, UpdateImpactAssessmentTaskService>();
			services.AddScoped<IUpdateTaskService, UpdateEvidenceOfAcceptedOffersTaskService>();
			services.AddScoped<IUpdateTaskService, UpdateOfstedInspectionTaskService>();
			services.AddScoped<IUpdateTaskService, UpdateApplicationsEvidenceTaskService>();
            services.AddScoped<IUpdateTaskService, UpdateFundingAgreementHealthCheckTaskService>();
            services.AddScoped<IUpdateTaskService, UpdatePDGPaymentSchedule>();
            services.AddScoped<IUpdateTaskService, UpdatePDGTrustLetterSent>();
            services.AddScoped<IUpdateTaskService, UpdateStopPaymentService>();
            services.AddScoped<IUpdateTaskService, UpdateRefundsService>();
            services.AddScoped<IUpdateTaskService, UpdateWriteOffService>();
            services.AddScoped<IUpdateTaskService, UpdateFinalFinancePlanTaskService>();
            services.AddScoped<IAllProjectsReportService, AllProjectsReportService>();
			services.AddScoped<ISfaReportService, SfaReportService>();
			services.AddScoped<IUpdateTaskService, UpdateAdmissionsArrangementsTaskService>();
			services.AddScoped<ISfaApiKeyValidationService, SfaApiKeyValidationService>();
			services.AddScoped<IGetProjectSitesService, GetProjectSitesService>();
			services.AddScoped<IUpdateProjectSiteService,  UpdateProjectSiteService>();
			services.AddScoped<IGetPupilNumbersService, GetPupilNumbersService>();
			services.AddScoped<IUpdatePupilNumbersService, UpdatePupilNumbersService>();
			services.AddScoped<IUpdateCapacityWhenFullService, UpdateCapacityWhenFullService>();
			services.AddScoped<IUpdatePre16PublishedAdmissionNumberService, UpdatePre16PublishedAdmissionNumberService>();
			services.AddScoped<IUpdatePost16PublishedAdmissionNumberService, UpdatePost16PublishedAdmissionNumberService>();
			services.AddScoped<IUpdatePre16CapacityBuildupService, UpdatePre16CapacityBuildupService>();
			services.AddScoped<IUpdatePost16CapacityBuildupService, UpdatePost16CapacityBuildupService>();
			services.AddScoped<IUpdateRecruitmentAndViabilityService, UpdateRecruitmentAndViabilityService>();
			services.AddScoped<IUpdatePublishedAdmissionNumberPercentageService, UpdatePublishedAdmissionNumberPercentageService>();

            services.AddValidatorsFromAssembly(Assembly.Load(Assembly.GetExecutingAssembly().FullName));

            return services;
		}
	}
}
