using Dfe.ManageFreeSchoolProjects.API.Contracts.Construct;
using Dfe.ManageFreeSchoolProjects.Data;
using Microsoft.EntityFrameworkCore;

namespace Dfe.ManageFreeSchoolProjects.API.UseCases.Construct
{
    public interface IGetConstructProjectListService
    {
        public Task<List<ConstructProjectResponse>> Execute();
    }

    public class GetConstructProjectListService : IGetConstructProjectListService
    {
        private readonly MfspContext _context;

        public GetConstructProjectListService(MfspContext context)
        {
            _context = context;
        }

        public async Task<List<ConstructProjectResponse>> Execute()
        {
            var result = await (from project in _context.Kpi
                          join milestones in _context.Milestones on project.Rid equals milestones.Rid into joinedMilestones
                          from milestones in joinedMilestones.DefaultIfEmpty()
                          join pupilNumbersAndCapacity in _context.Po on project.Rid equals pupilNumbersAndCapacity.Rid into joinedPupilNumbersAndCapacity
                          from pupilNumbersAndCapacity in joinedPupilNumbersAndCapacity.DefaultIfEmpty()
                          where project.ProjectStatusProjectId != null
                          select new ConstructProjectResponse()
                          {
                              CurrentFreeSchoolName = project.ProjectStatusCurrentFreeSchoolName,
                              ProjectId = project.ProjectStatusProjectId,
                              ApplicationWave = project.ProjectStatusFreeSchoolApplicationWave,
                              ProjectStatus = project.ProjectStatusProjectStatus,
                              ProvisionalOpeningDateAgreedWithTrust = project.ProjectStatusProvisionalOpeningDateAgreedWithTrust,
                              ActualOpeningDate = project.ProjectStatusActualOpeningDate,
                              FreeSchoolPenPortrait = project.ProjectStatusFreeSchoolPenPortrait,
                              URN = project.ProjectStatusUrnWhenGivenOne,
                              DateSchoolClosed = project.ProjectStatusDateClosed,
                              DateOfEntryIntoPreOpening = project.ProjectStatusDateOfEntryIntoPreOpening,
                              LocalAuthority = project.LocalAuthority,
                              LaesTab = project.SchoolDetailsLaestabWhenGivenOne,
                              RSCRegion = project.SchoolDetailsRscRegion,
                              NumberOfFormsOfEntry = project.SchoolDetailsNumberOfFormsOfEntry,
                              SchoolType = project.SchoolDetailsSchoolTypeMainstreamApEtc,
                              SchoolPhase = project.SchoolDetailsSchoolPhasePrimarySecondary,
                              AgeRange = project.SchoolDetailsAgeRange,
                              Gender = project.SchoolDetailsGender,
                              ResidentialOrBoardingProvision = project.SchoolDetailsResidentialOrBoardingProvision,
                              ResidentialBoardingProvisionDetails = project.SchoolDetailsDetailsOfResidentialBoardingProvision,
                              Nursery = project.SchoolDetailsNursery,
                              SixthForm = project.SchoolDetailsSixthForm,
                              AlternativeProvision = project.SchoolDetailsAlternativeProvision,
                              SpecialEducationNeeds = project.SchoolDetailsSpecialEducationNeeds,
                              SixthFormType = project.SchoolDetailsSixthFormType,
                              FaithStatus = project.SchoolDetailsFaithStatus,
                              FaithType = project.SchoolDetailsFaithType,
                              OtherFaithType = project.SchoolDetailsPleaseSpecifyOtherFaithType,
                              Specialism = project.SchoolDetailsSpecialism,
                              TrustId = project.SchoolDetailsTrustId,
                              TrustName = project.SchoolDetailsTrustName,
                              SchoolAddress = project.KeyContactsSchoolAddress,
                              Postcode = project.KeyContactsPostcode,
                              FSGLeadContact = project.KeyContactsFsgLeadContact,
                              RealisticYearofOpening = project.ProjectStatusRealisticYearOfOpening,
                              MemberOfParliament = project.SchoolDetailsConstituencyMp,
                              GeographicalRegion = project.SchoolDetailsGeographicalRegion,
                              KickOfMeetingHeldDate = milestones.FsgPreOpeningMilestonesKickOffMeetingHeldActualDate,
                              FAActualCompletionDate = milestones.FsgPreOpeningMilestonesFaActualDateOfCompletion,
                              FAForecastDate = milestones.FsgPreOpeningMilestonesFaForecastDate,
                              NumberOfPupil = pupilNumbersAndCapacity.PupilNumbersAndCapacityTotalOfCapacityTotals
                          }).ToListAsync();

            return result;
        }
    }
}
