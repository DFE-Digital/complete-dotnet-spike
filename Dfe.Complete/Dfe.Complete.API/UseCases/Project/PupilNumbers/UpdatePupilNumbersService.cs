using Dfe.ManageFreeSchoolProjects.API.Contracts.Project.PupilNumbers;
using Dfe.ManageFreeSchoolProjects.API.Exceptions;
using Dfe.ManageFreeSchoolProjects.Data;
using Dfe.ManageFreeSchoolProjects.Data.Entities.Existing;
using Microsoft.EntityFrameworkCore;

namespace Dfe.ManageFreeSchoolProjects.API.UseCases.Project.PupilNumbers
{
    public interface IUpdatePupilNumbersService
    {
        public Task Execute(string projectId, UpdatePupilNumbersRequest request);
    }

    public class UpdatePupilNumbersService : IUpdatePupilNumbersService
    {
        private readonly MfspContext _context;
        private readonly IUpdateCapacityWhenFullService _updateCapacityWhenFullService;
        private readonly IUpdatePost16CapacityBuildupService _updatePost16CapacityBuildupService;
        private readonly IUpdatePost16PublishedAdmissionNumberService _updatePost16PublishedAdmissionNumberService;
        private readonly IUpdatePre16CapacityBuildupService _updatePre16CapacityBuildupService;
        private readonly IUpdatePre16PublishedAdmissionNumberService _updatePre16PublishedAdmissionNumberService;
        private readonly IUpdateRecruitmentAndViabilityService _updateRecruitmentAndViabilityService;
        private readonly IUpdatePublishedAdmissionNumberPercentageService _updatePublishedAdmissionNumberPercentageService;

        public UpdatePupilNumbersService(
            MfspContext context,
            IUpdateCapacityWhenFullService updateCapacityWhenFullService,
            IUpdatePost16CapacityBuildupService updatePost16CapacityBuildupService,
            IUpdatePost16PublishedAdmissionNumberService updatePost16PublishedAdmissionNumberService,
            IUpdatePre16CapacityBuildupService updatePre16CapacityBuildupService,
            IUpdatePre16PublishedAdmissionNumberService updatePre16PublishedAdmissionNumberService,
            IUpdateRecruitmentAndViabilityService updateRecruitmentAndViabilityService,
            IUpdatePublishedAdmissionNumberPercentageService updatePublishedAdmissionNumberPercentageService)
        {
            _context = context;
            _updateCapacityWhenFullService = updateCapacityWhenFullService;
            _updatePost16CapacityBuildupService = updatePost16CapacityBuildupService;
            _updatePost16PublishedAdmissionNumberService = updatePost16PublishedAdmissionNumberService;
            _updatePre16CapacityBuildupService = updatePre16CapacityBuildupService;
            _updatePre16PublishedAdmissionNumberService = updatePre16PublishedAdmissionNumberService;
            _updateRecruitmentAndViabilityService = updateRecruitmentAndViabilityService;
            _updatePublishedAdmissionNumberPercentageService = updatePublishedAdmissionNumberPercentageService;
        }

        public async Task Execute(string projectId, UpdatePupilNumbersRequest request)
        {
            var kpi = await _context.Kpi.FirstOrDefaultAsync(kpi => kpi.ProjectStatusProjectId == projectId);

            if (kpi == null)
            {
                throw new NotFoundException($"Project with ID {projectId} not found");
            }

            var po = await _context.Po.FirstOrDefaultAsync(po => po.Rid == kpi.Rid);

            if (po == null)
            {
                po = new Po()
                {
                    Rid = kpi.Rid,
                };

                _context.Po.Add(po);
            }

            _updateCapacityWhenFullService.Execute(po, request.CapacityWhenFull);
            _updatePost16CapacityBuildupService.Execute(po, request);
            _updatePost16PublishedAdmissionNumberService.Execute(po, request);
            _updatePre16CapacityBuildupService.Execute(po, request);
            _updatePre16PublishedAdmissionNumberService.Execute(po, request);
            _updateRecruitmentAndViabilityService.Execute(po, request);
            _updatePublishedAdmissionNumberPercentageService.Execute(po);

            await _context.SaveChangesAsync();
        }
    }
}
