using Dfe.ManageFreeSchoolProjects.API.Contracts.Project;
using Dfe.ManageFreeSchoolProjects.API.Contracts.Project.Sites;
using Dfe.ManageFreeSchoolProjects.API.Exceptions;
using Dfe.ManageFreeSchoolProjects.API.Extensions;
using Dfe.ManageFreeSchoolProjects.API.UseCases.Project;
using Dfe.ManageFreeSchoolProjects.API.UseCases.Project.Risk;
using Dfe.ManageFreeSchoolProjects.API.UseCases.Project.Sites;
using Dfe.ManageFreeSchoolProjects.Data;
using Dfe.ManageFreeSchoolProjects.Data.Entities.Existing;
using DocumentFormat.OpenXml.Packaging;
using Microsoft.EntityFrameworkCore;

namespace Dfe.ManageFreeSchoolProjects.API.UseCases.ProjectOverview
{
    public interface IGetProjectOverviewService
    {
        public Task<ProjectOverviewResponse> Execute(string projectId);
    }

    public class GetProjectOverviewService : IGetProjectOverviewService
    {
        private readonly MfspContext _context;
        private readonly IGetProjectSitesService _getProjectSitesService;

        public GetProjectOverviewService(
            MfspContext context,
            IGetProjectSitesService getProjectSitesService)
        {
            _context = context;
            _getProjectSitesService = getProjectSitesService;
        }

        public async Task<ProjectOverviewResponse> Execute(string projectId)
        {
            var project = await _context.Kpi.FirstOrDefaultAsync(k => k.ProjectStatusProjectId == projectId);

            if (project == null)
            {
                throw new NotFoundException($"Project {projectId} not found");
            }

            var risk = await GetRisk(project.Rid);
            var sites = await _getProjectSitesService.Execute(project);
            var pupilNumbers = await GetPupilNumbers(project.Rid);

            return BuildOverviewResponse(project, risk, sites, pupilNumbers);
        }

        private static ProjectOverviewResponse BuildOverviewResponse(
            Kpi project, 
            ProjectRiskOverviewResponse risk, 
            GetProjectSitesResponse sites, 
            PupilNumbersOverviewResponse pupilNumbers)
        {
            return new ProjectOverviewResponse()
            {
                ProjectStatus = new ProjectStatusResponse()
                {
                    ProjectStatus = project.ProjectStatusProjectStatus,
                    CurrentFreeSchoolName = project.ProjectStatusCurrentFreeSchoolName,
                    FreeSchoolsApplicationNumber = project.ProjectStatusFreeSchoolsApplicationNumber,
                    ProjectId = project.ProjectStatusProjectId,
                    Urn = project.ProjectStatusUrnWhenGivenOne,
                    ApplicationWave = project.ProjectStatusFreeSchoolApplicationWave,
                    RealisticYearOfOpening = project.ProjectStatusRealisticYearOfOpening,
                    DateOfEntryIntoPreopening = project.ProjectStatusDateOfEntryIntoPreOpening,
                    ProvisionalOpeningDateAgreedWithTrust = project.ProjectStatusProvisionalOpeningDateAgreedWithTrust,
                    ActualOpeningDate = FormatDate(project.ProjectStatusActualOpeningDate),
                    OpeningAcademicYear = project.ProjectStatusTrustsPreferredYearOfOpening,
                    DateSchoolClosed = project.ProjectStatusDateClosed
                },
                SchoolDetails = new SchoolDetailsResponse()
                {
                    LocalAuthority = project.LocalAuthority,
                    Region = project.SchoolDetailsGeographicalRegion,
                    Constituency = project.SchoolDetailsConstituency,
                    ConstituencyMp = project.SchoolDetailsConstituencyMp,
                    NumberOfEntryForms = project.SchoolDetailsNumberOfFormsOfEntry,
                    SchoolType = ProjectMapper.ToSchoolType(project.SchoolDetailsSchoolTypeMainstreamApEtc),
                    SchoolPhase = ProjectMapper.ToSchoolPhase(project.SchoolDetailsSchoolPhasePrimarySecondary),
                    AgeRange = project.SchoolDetailsAgeRange,
                    Gender = project.SchoolDetailsGender,
                    Nursery = project.SchoolDetailsNursery,
                    SixthForm = project.SchoolDetailsSixthForm,
                    AlternativeProvision = project.SchoolDetailsAlternativeProvision,
                    SpecialEducationNeeds = project.SchoolDetailsSpecialEducationNeeds,
                    IndependentConverter = project.SchoolDetailsIndependentConverter,
                    SpecialistResourceProvision = project.SchoolDetailsSpecialistResourceProvision,
                    FaithStatus = project.SchoolDetailsFaithStatus,
                    FaithType = ProjectMapper.ToFaithType(project.SchoolDetailsFaithType),
                    TrustId = project.TrustId,
                    TrustName = project.SchoolDetailsTrustName,
                    TrustType = ProjectMapper.ToTrustType(project.SchoolDetailsTrustType)
                },
                Risk = risk,
                KeyContacts = new()
                {
                    TeamLeader = project.KeyContactsFsgTeamLeader,
                    Grade6 = project.KeyContactsFsgGrade6,
                    ProjectDirector = project.KeyContactsEsfaCapitalProjectDirector,
                    ProjectManager = project.KeyContactsFsgLeadContact,
                    ChairOfGovernors = project.KeyContactsChairOfGovernorsName,
                    SchoolChairOfGovernors = project.KeyContactsChairOfGovernorsMat
                },
                SiteInformation = new()
                {
                    PermanentSite = sites.PermanentSite,
                    TemporarySite = sites.TemporarySite
                },
                PupilNumbers = pupilNumbers
            };
        }

        private static string FormatDate(DateTime? date)
        {
            if (!date.HasValue)
            {
                return null;
            }

            return date.Value.Date.ToString();
        }

        private async Task<ProjectRiskOverviewResponse> GetRisk(string rid)
        {
            var rag = await _context.Rag
                .Select(e => new 
                {
                    e.Rid,
                    RiskRating = e.RagRatingsOverallRagRating,
                    Summary = e.RagRatingsOverallRagSummary,
                    Date = EF.Property<DateTime>(e, "PeriodStart")
                }).FirstOrDefaultAsync(r => r.Rid == rid);

            if (rag == null) 
            {
                return new ProjectRiskOverviewResponse();
            }

            var result = new ProjectRiskOverviewResponse()
            {
                Date = rag.Date,
                RiskRating = ProjectRiskMapper.ToRiskRating(rag.RiskRating),
                Summary = rag.Summary
            };

            return result;
        }

        private async Task<PupilNumbersOverviewResponse> GetPupilNumbers(string rid)
        {
            var result = await _context.Po
                .Where(p => p.Rid == rid)
                .Select(po =>
                    new PupilNumbersOverviewResponse()
                    {
                        Capacity = po.PupilNumbersAndCapacityTotalOfCapacityTotals.ToInt(),
                        Pre16PublishedAdmissionNumber = po.PupilNumbersAndCapacityTotalPanPre16.ToInt(),
                        Post16PublishedAdmissionNumber = po.PupilNumbersAndCapacityTotalPanPost16.ToInt(),
                        MinimumViableNumberForFirstYear = po.PupilNumbersAndCapacityMinimumFirstYearRecruitmentForViabilityTotal.ToInt(),
                        ApplicationsReceived = po.PupilNumbersAndCapacityNoApplicationsReceivedTotal.ToInt()
                    })
                .FirstOrDefaultAsync();

            if (result == null)
            {
                return new PupilNumbersOverviewResponse();
            }

            return result;
        }
    }
}
