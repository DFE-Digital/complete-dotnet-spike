using Dfe.ManageFreeSchoolProjects.API.Contracts.Project.PupilNumbers;
using Dfe.ManageFreeSchoolProjects.API.Exceptions;
using Dfe.ManageFreeSchoolProjects.API.Extensions;
using Dfe.ManageFreeSchoolProjects.Data;
using Dfe.ManageFreeSchoolProjects.Data.Entities.Existing;
using Microsoft.EntityFrameworkCore;

namespace Dfe.ManageFreeSchoolProjects.API.UseCases.Project.PupilNumbers
{
    public interface IGetPupilNumbersService
    {
        public Task<GetPupilNumbersResponse> Execute(string projectId);
    }

    public class GetPupilNumbersService : IGetPupilNumbersService
    {
        private readonly MfspContext _context;

        public GetPupilNumbersService(MfspContext context)
        {
            _context = context;
        }

        public async Task<GetPupilNumbersResponse> Execute(string projectId)
        {
            var kpi = await _context.Kpi.FirstOrDefaultAsync(kpi => kpi.ProjectStatusProjectId == projectId);

            if (kpi == null)
            {
                throw new NotFoundException($"Project with ID {projectId} not found");
            }

            var result = await _context.Po
                .Where(po => po.Rid == kpi.Rid)
                .Select(po => new GetPupilNumbersResponse()
                {
                    SchoolName = kpi.ProjectStatusCurrentFreeSchoolName,
                    CapacityWhenFull = BuildCapacityWhenFull(po),
                    RecruitmentAndViability = BuildRecruitmentAndViability(po),
                    Pre16PublishedAdmissionNumber = BuildPre16PublishedAdmissionNumber(po),
                    Post16PublishedAdmissionNumber = BuildPost16PublishedAdmissionNumber(po),
                    Pre16CapacityBuildup = BuildPre16CapacityBuildup(po),
                    Post16CapacityBuildup = BuildPost16CapacityBuildup(po)
                })
                .FirstOrDefaultAsync();

            if (result == null)
            {
                // This might happen with imported data from KIM
                // Our update will solve this but until an update has been performed the data could be missing
                return new GetPupilNumbersResponse();
            }

            return result;
        }

        private static CapacityWhenFullResponse BuildCapacityWhenFull(Po po)
        {
            return new CapacityWhenFullResponse()
            {
                Nursery = po.PupilNumbersAndCapacityNurseryUnder5s.ToInt(),
                ReceptionToYear6 = po.PupilNumbersAndCapacityYrY6Capacity.ToInt(),
                Year7ToYear11 = po.PupilNumbersAndCapacityY7Y11Capacity.ToInt(),
                Year12ToYear14 = po.PupilNumbersAndCapacityY12Y14Post16Capacity.ToInt(),
                SpecialEducationNeeds = po.PupilNumbersAndCapacitySpecialistResourceProvisionSpecial.ToInt(),
                AlternativeProvision = po.PupilNumbersAndCapacitySpecialistResourceProvisionAp.ToInt(),
                Total = po.PupilNumbersAndCapacityTotalOfCapacityTotals.ToInt()
            };
        }

        private static RecruitmentAndViabilityResponse BuildRecruitmentAndViability(Po po)
        {
            return new RecruitmentAndViabilityResponse()
            {
                ReceptionToYear6 = new RecruitmentAndViabilityEntryWithPercentage()
                {
                    MinimumViableNumber = po.PupilNumbersAndCapacityMinimumFirstYearRecruitmentForViabilityYrY6.ToInt(),
                    ApplicationsReceived = po.PupilNumbersAndCapacityNoApplicationsReceivedYrY6.ToInt(),
                    PercentageComparedToMinimumViable = po.PupilNumbersAndCapacityAcceptedApplicationsVsViabilityYrY6.ToDecimal(),
                    PercentageComparedToPublishedAdmissionNumber = po.PupilNumbersAndCapacityAcceptedApplicationsVsPanYrY6.ToDecimal()
                },
                Year7ToYear11 = new RecruitmentAndViabilityEntryWithPercentage()
                {
                    MinimumViableNumber = po.PupilNumbersAndCapacityMinimumFirstYearRecruitmentForViabilityY7Y11.ToInt(),
                    ApplicationsReceived = po.PupilNumbersAndCapacityNoApplicationsReceivedY7Y11.ToInt(),
                    PercentageComparedToMinimumViable = po.PupilNumbersAndCapacityAcceptedApplicationsVsViabilityY7Y11.ToDecimal(),
                    PercentageComparedToPublishedAdmissionNumber = po.PupilNumbersAndCapacityAcceptedApplicationsVsPanY7Y11.ToDecimal()
                },
                Year12ToYear14 = new RecruitmentAndViabilityEntryWithPercentage()
                {
                    MinimumViableNumber = po.PupilNumbersAndCapacityMinimumFirstYearRecruitmentForViabilityY12Y14.ToInt(),
                    ApplicationsReceived = po.PupilNumbersAndCapacityNoApplicationsReceivedY12Y14.ToInt(),
                    PercentageComparedToMinimumViable = po.PupilNumbersAndCapacityAcceptedApplicationsVsViabilityY12Y14.ToDecimal(),
                    PercentageComparedToPublishedAdmissionNumber = po.PupilNumbersAndCapacityAcceptedApplicationsVsPanY12Y14.ToDecimal()
                },
                Total = new RecruitmentAndViabilityEntry()
                {
                    MinimumViableNumber = po.PupilNumbersAndCapacityMinimumFirstYearRecruitmentForViabilityTotal.ToInt(),
                    ApplicationsReceived = po.PupilNumbersAndCapacityNoApplicationsReceivedTotal.ToInt()
                }
            };
        }

        private static Pre16PublishedAdmissionNumberResponse BuildPre16PublishedAdmissionNumber(Po po)
        {
            return new Pre16PublishedAdmissionNumberResponse()
            {
                Reception = po.PupilNumbersAndCapacityYrPan.ToInt(),
                Year7 = po.PupilNumbersAndCapacityY7Pan.ToInt(),
                Year10 = po.PupilNumbersAndCapacityY10Pan.ToInt(),
                OtherPre16 = po.PupilNumbersAndCapacityYOtherPanPre16.ToInt(),
                Total = po.PupilNumbersAndCapacityTotalPanPre16.ToInt()
            };
        }

        private static Post16PublishedAdmissionNumberResponse BuildPost16PublishedAdmissionNumber(Po po)
        {
            return new Post16PublishedAdmissionNumberResponse()
            {
                Year12 = po.PupilNumbersAndCapacityY12Pan.ToInt(),
                OtherPost16 = po.PupilNumbersAndCapacityYOtherPanPost16.ToInt(),
                Total = po.PupilNumbersAndCapacityTotalPanPost16.ToInt()
            };
        }

        private static Pre16CapacityBuildup BuildPre16CapacityBuildup(Po po)
        {
            return new Pre16CapacityBuildup()
            {
                Reception = BuildReceptionCapacityBuildup(po),
                Nursery = BuildNurseryCapacityBuildup(po),
                Year1 = BuildYear1CapacityBuildup(po),
                Year2 = BuildYear2CapacityBuildup(po),
                Year3 = BuildYear3CapacityBuildup(po),
                Year4 = BuildYear4CapacityBuildup(po),
                Year5 = BuildYear5CapacityBuildup(po),
                Year6 = BuildYear6CapacityBuildup(po),
                Year7 = BuildYear7CapacityBuildup(po),
                Year8 = BuildYear8CapacityBuildup(po),
                Year9 = BuildYear9CapacityBuildup(po),
                Year10 = BuildYear10CapacityBuildup(po),
                Year11 = BuildYear11CapacityBuildup(po),
                Total = BuildPre16TotalCapacityBuildup(po)
            };
        }

        private static Post16CapacityBuildup BuildPost16CapacityBuildup(Po po)
        {
            return new Post16CapacityBuildup()
            {
                Year12 = BuildYear12CapacityBuildup(po),
                Year13 = BuildYear13CapacityBuildup(po),
                Year14 = BuildYear14CapacityBuildup(po),
                Total = BuildPost16TotalCapacityBuildup(po)
            };
        }

        private static CapacityBuildupEntry BuildReceptionCapacityBuildup(Po po)
        {
            return new CapacityBuildupEntry()
            {
                CurrentCapacity = po.PupilNumbersAndCapacityCellA2ReceptionCurrentPupilNumbersIfAlreadyOpen.ToInt(),
                FirstYear = po.PupilNumbersAndCapacityCellB2ReceptionFirstYear.ToInt(),
                SecondYear = po.PupilNumbersAndCapacityCellC2ReceptionSecondYear.ToInt(),
                ThirdYear = po.PupilNumbersAndCapacityCellD2ReceptionThirdYear.ToInt(),
                FourthYear = po.PupilNumbersAndCapacityCellE2ReceptionFourthYear.ToInt(),
                FifthYear = po.PupilNumbersAndCapacityCellF2ReceptionFifthYear.ToInt(),
                SixthYear = po.PupilNumbersAndCapacityCellG2ReceptionSixthYear.ToInt(),
                SeventhYear = po.PupilNumbersAndCapacityCellH2ReceptionSeventhYear.ToInt()
            };
        }

        private static CapacityBuildupEntry BuildNurseryCapacityBuildup(Po po)
        {
            return new CapacityBuildupEntry()
            {
                CurrentCapacity = po.PupilNumbersAndCapacityCellA1NurseryCurrentPupilNumbersIfAlreadyOpen.ToInt(),
                FirstYear = po.PupilNumbersAndCapacityCellB1NurseryFirstYear.ToInt(),
                SecondYear = po.PupilNumbersAndCapacityCellC1NurserySecondYear.ToInt(),
                ThirdYear = po.PupilNumbersAndCapacityCellD1NurseryThirdYear.ToInt(),
                FourthYear = po.PupilNumbersAndCapacityCellE1NurseryFourthYear.ToInt(),
                FifthYear = po.PupilNumbersAndCapacityCellF1NurseryFifthYear.ToInt(),
                SixthYear = po.PupilNumbersAndCapacityCellG1NurserySixthYear.ToInt(),
                SeventhYear = po.PupilNumbersAndCapacityCellH1NurserySeventhYear.ToInt()
            };
        }

        private static CapacityBuildupEntry BuildYear1CapacityBuildup(Po po)
        {
            return new CapacityBuildupEntry()
            {
                CurrentCapacity = po.PupilNumbersAndCapacityCellA3Year1CurrentPupilNumbersIfAlreadyOpen.ToInt(),
                FirstYear = po.PupilNumbersAndCapacityCellB3Year1FirstYear.ToInt(),
                SecondYear = po.PupilNumbersAndCapacityCellC3Year1SecondYear.ToInt(),
                ThirdYear = po.PupilNumbersAndCapacityCellD3Year1ThirdYear.ToInt(),
                FourthYear = po.PupilNumbersAndCapacityCellE3Year1FourthYear.ToInt(),
                FifthYear = po.PupilNumbersAndCapacityCellF3Year1FifthYear.ToInt(),
                SixthYear = po.PupilNumbersAndCapacityCellG3Year1SixthYear.ToInt(),
                SeventhYear = po.PupilNumbersAndCapacityCellH3Year1SeventhYear.ToInt()
            };
        }

        private static CapacityBuildupEntry BuildYear2CapacityBuildup(Po po)
        {
            return new CapacityBuildupEntry()
            {
                CurrentCapacity = po.PupilNumbersAndCapacityCellA4Year2CurrentPupilNumbersIfAlreadyOpen.ToInt(),
                FirstYear = po.PupilNumbersAndCapacityCellB4Year2FirstYear.ToInt(),
                SecondYear = po.PupilNumbersAndCapacityCellC4Year2SecondYear.ToInt(),
                ThirdYear = po.PupilNumbersAndCapacityCellD4Year2ThirdYear.ToInt(),
                FourthYear = po.PupilNumbersAndCapacityCellE4Year2FourthYear.ToInt(),
                FifthYear = po.PupilNumbersAndCapacityCellF4Year2FifthYear.ToInt(),
                SixthYear = po.PupilNumbersAndCapacityCellG4Year2SixthYear.ToInt(),
                SeventhYear = po.PupilNumbersAndCapacityCellH4Year2SeventhYear.ToInt()
            };
        }

        private static CapacityBuildupEntry BuildYear3CapacityBuildup(Po po)
        {
            return new CapacityBuildupEntry()
            {
                CurrentCapacity = po.PupilNumbersAndCapacityCellA5Year3CurrentPupilNumbersIfAlreadyOpen.ToInt(),
                FirstYear = po.PupilNumbersAndCapacityCellB5Year3FirstYear.ToInt(),
                SecondYear = po.PupilNumbersAndCapacityCellC5Year3SecondYear.ToInt(),
                ThirdYear = po.PupilNumbersAndCapacityCellD5Year3ThirdYear.ToInt(),
                FourthYear = po.PupilNumbersAndCapacityCellE5Year3FourthYear.ToInt(),
                FifthYear = po.PupilNumbersAndCapacityCellF5Year3FifthYear.ToInt(),
                SixthYear = po.PupilNumbersAndCapacityCellG5Year3SixthYear.ToInt(),
                SeventhYear = po.PupilNumbersAndCapacityCellH5Year3SeventhYear.ToInt()
            };
        }

        private static CapacityBuildupEntry BuildYear4CapacityBuildup(Po po)
        {
            return new CapacityBuildupEntry()
            {
                CurrentCapacity = po.PupilNumbersAndCapacityCellA6Year4CurrentPupilNumbersIfAlreadyOpen.ToInt(),
                FirstYear = po.PupilNumbersAndCapacityCellB6Year4FirstYear.ToInt(),
                SecondYear = po.PupilNumbersAndCapacityCellC6Year4SecondYear.ToInt(),
                ThirdYear = po.PupilNumbersAndCapacityCellD6Year4ThirdYear.ToInt(),
                FourthYear = po.PupilNumbersAndCapacityCellE6Year4FourthYear.ToInt(),
                FifthYear = po.PupilNumbersAndCapacityCellF6Year4FifthYear.ToInt(),
                SixthYear = po.PupilNumbersAndCapacityCellG6Year4SixthYear.ToInt(),
                SeventhYear = po.PupilNumbersAndCapacityCellH6Year4SeventhYear.ToInt()
            };
        }

        private static CapacityBuildupEntry BuildYear5CapacityBuildup(Po po)
        {
            return new CapacityBuildupEntry()
            {
                CurrentCapacity = po.PupilNumbersAndCapacityCellA7Year5CurrentPupilNumbersIfAlreadyOpen.ToInt(),
                FirstYear = po.PupilNumbersAndCapacityCellB7Year5FirstYear.ToInt(),
                SecondYear = po.PupilNumbersAndCapacityCellC7Year5SecondYear.ToInt(),
                ThirdYear = po.PupilNumbersAndCapacityCellD7Year5ThirdYear.ToInt(),
                FourthYear = po.PupilNumbersAndCapacityCellE7Year5FourthYear.ToInt(),
                FifthYear = po.PupilNumbersAndCapacityCellF7Year5FifthYear.ToInt(),
                SixthYear = po.PupilNumbersAndCapacityCellG7Year5SixthYear.ToInt(),
                SeventhYear = po.PupilNumbersAndCapacityCellH7Year5SeventhYear.ToInt()
            };
        }

        private static CapacityBuildupEntry BuildYear6CapacityBuildup(Po po)
        {
            return new CapacityBuildupEntry()
            {
                CurrentCapacity = po.PupilNumbersAndCapacityCellA8Year6CurrentPupilNumbersIfAlreadyOpen.ToInt(),
                FirstYear = po.PupilNumbersAndCapacityCellB8Year6FirstYear.ToInt(),
                SecondYear = po.PupilNumbersAndCapacityCellC8Year6SecondYear.ToInt(),
                ThirdYear = po.PupilNumbersAndCapacityCellD8Year6ThirdYear.ToInt(),
                FourthYear = po.PupilNumbersAndCapacityCellE8Year6FourthYear.ToInt(),
                FifthYear = po.PupilNumbersAndCapacityCellF8Year6FifthYear.ToInt(),
                SixthYear = po.PupilNumbersAndCapacityCellG8Year6SixthYear.ToInt(),
                SeventhYear = po.PupilNumbersAndCapacityCellH8Year6SeventhYear.ToInt()
            };
        }

        private static CapacityBuildupEntry BuildPre16TotalCapacityBuildup(Po po)
        {
            return new CapacityBuildupEntry()
            {
                CurrentCapacity = po.PupilNumbersAndCapacityTotalPre16A.ToInt(),
                FirstYear = po.PupilNumbersAndCapacityTotalPre16B.ToInt(),
                SecondYear = po.PupilNumbersAndCapacityTotalPre16C.ToInt(),
                ThirdYear = po.PupilNumbersAndCapacityTotalPre16D.ToInt(),
                FourthYear = po.PupilNumbersAndCapacityTotalPre16E.ToInt(),
                FifthYear = po.PupilNumbersAndCapacityTotalPre16F.ToInt(),
                SixthYear = po.PupilNumbersAndCapacityTotalPre16G.ToInt(),
                SeventhYear = po.PupilNumbersAndCapacityTotalPre16H.ToInt()
            };
        }

        private static CapacityBuildupEntry BuildYear7CapacityBuildup(Po po)
        {
            return new CapacityBuildupEntry()
            {
                CurrentCapacity = po.PupilNumbersAndCapacityCellA9Year7CurrentPupilNumbersIfAlreadyOpen.ToInt(),
                FirstYear = po.PupilNumbersAndCapacityCellB9Year7FirstYear.ToInt(),
                SecondYear = po.PupilNumbersAndCapacityCellC9Year7SecondYear.ToInt(),
                ThirdYear = po.PupilNumbersAndCapacityCellD9Year7ThirdYear.ToInt(),
                FourthYear = po.PupilNumbersAndCapacityCellE9Year7FourthYear.ToInt(),
                FifthYear = po.PupilNumbersAndCapacityCellF9Year7FifthYear.ToInt(),
                SixthYear = po.PupilNumbersAndCapacityCellG9Year7SixthYear.ToInt(),
                SeventhYear = po.PupilNumbersAndCapacityCellH9Year7SeventhYear.ToInt()
            };
        }

        private static CapacityBuildupEntry BuildYear8CapacityBuildup(Po po)
        {
            return new CapacityBuildupEntry()
            {
                CurrentCapacity = po.PupilNumbersAndCapacityCellA10Year8CurrentPupilNumbersIfAlreadyOpen.ToInt(),
                FirstYear = po.PupilNumbersAndCapacityCellB10Year8FirstYear.ToInt(),
                SecondYear = po.PupilNumbersAndCapacityCellC10Year8SecondYear.ToInt(),
                ThirdYear = po.PupilNumbersAndCapacityCellD10Year8ThirdYear.ToInt(),
                FourthYear = po.PupilNumbersAndCapacityCellE10Year8FourthYear.ToInt(),
                FifthYear = po.PupilNumbersAndCapacityCellF10Year8FifthYear.ToInt(),
                SixthYear = po.PupilNumbersAndCapacityCellG10Year8SixthYear.ToInt(),
                SeventhYear = po.PupilNumbersAndCapacityCellH10Year8SeventhYear.ToInt()
            };
        }

        private static CapacityBuildupEntry BuildYear9CapacityBuildup(Po po)
        {
            return new CapacityBuildupEntry()
            {
                CurrentCapacity = po.PupilNumbersAndCapacityCellA11Year9CurrentPupilNumbersIfAlreadyOpen.ToInt(),
                FirstYear = po.PupilNumbersAndCapacityCellB11Year9FirstYear.ToInt(),
                SecondYear = po.PupilNumbersAndCapacityCellC11Year9SecondYear.ToInt(),
                ThirdYear = po.PupilNumbersAndCapacityCellD11Year9ThirdYear.ToInt(),
                FourthYear = po.PupilNumbersAndCapacityCellE11Year9FourthYear.ToInt(),
                FifthYear = po.PupilNumbersAndCapacityCellF11Year9FifthYear.ToInt(),
                SixthYear = po.PupilNumbersAndCapacityCellG11Year9SixthYear.ToInt(),
                SeventhYear = po.PupilNumbersAndCapacityCellH11Year9SeventhYear.ToInt()
            };
        }

        private static CapacityBuildupEntry BuildYear10CapacityBuildup(Po po)
        {
            return new CapacityBuildupEntry()
            {
                CurrentCapacity = po.PupilNumbersAndCapacityCellA12Year10CurrentPupilNumbersIfAlreadyOpen.ToInt(),
                FirstYear = po.PupilNumbersAndCapacityCellB12Year10FirstYear.ToInt(),
                SecondYear = po.PupilNumbersAndCapacityCellC12Year10SecondYear.ToInt(),
                ThirdYear = po.PupilNumbersAndCapacityCellD12Year10ThirdYear.ToInt(),
                FourthYear = po.PupilNumbersAndCapacityCellE12Year10FourthYear.ToInt(),
                FifthYear = po.PupilNumbersAndCapacityCellF12Year10FifthYear.ToInt(),
                SixthYear = po.PupilNumbersAndCapacityCellG12Year10SixthYear.ToInt(),
                SeventhYear = po.PupilNumbersAndCapacityCellH12Year10SeventhYear.ToInt()
            };
        }

        private static CapacityBuildupEntry BuildYear11CapacityBuildup(Po po)
        {
            return new CapacityBuildupEntry()
            {
                CurrentCapacity = po.PupilNumbersAndCapacityCellA13Year11CurrentPupilNumbersIfAlreadyOpen.ToInt(),
                FirstYear = po.PupilNumbersAndCapacityCellB13Year11FirstYear.ToInt(),
                SecondYear = po.PupilNumbersAndCapacityCellC13Year11SecondYear.ToInt(),
                ThirdYear = po.PupilNumbersAndCapacityCellD13Year11ThirdYear.ToInt(),
                FourthYear = po.PupilNumbersAndCapacityCellE13Year11FourthYear.ToInt(),
                FifthYear = po.PupilNumbersAndCapacityCellF13Year11FifthYear.ToInt(),
                SixthYear = po.PupilNumbersAndCapacityCellG13Year11SixthYear.ToInt(),
                SeventhYear = po.PupilNumbersAndCapacityCellH13Year11SeventhYear.ToInt()
            };
        }

        private static CapacityBuildupEntry BuildYear12CapacityBuildup(Po po)
        {
            return new CapacityBuildupEntry()
            {
                CurrentCapacity = po.PupilNumbersAndCapacityCellA14Year12CurrentPupilNumbersIfAlreadyOpen.ToInt(),
                FirstYear = po.PupilNumbersAndCapacityCellB14Year12FirstYear.ToInt(),
                SecondYear = po.PupilNumbersAndCapacityCellC14Year12SecondYear.ToInt(),
                ThirdYear = po.PupilNumbersAndCapacityCellD14Year12ThirdYear.ToInt(),
                FourthYear = po.PupilNumbersAndCapacityCellE14Year12FourthYear.ToInt(),
                FifthYear = po.PupilNumbersAndCapacityCellF14Year12FifthYear.ToInt(),
                SixthYear = po.PupilNumbersAndCapacityCellG14Year12SixthYear.ToInt(),
                SeventhYear = po.PupilNumbersAndCapacityCellH14Year12SeventhYear.ToInt()
            };
        }

        private static CapacityBuildupEntry BuildYear13CapacityBuildup(Po po)
        {
            return new CapacityBuildupEntry()
            {
                CurrentCapacity = po.PupilNumbersAndCapacityCellA15Year13CurrentPupilNumbersIfAlreadyOpen.ToInt(),
                FirstYear = po.PupilNumbersAndCapacityCellB15Year13FirstYear.ToInt(),
                SecondYear = po.PupilNumbersAndCapacityCellC15Year13SecondYear.ToInt(),
                ThirdYear = po.PupilNumbersAndCapacityCellD15Year13ThirdYear.ToInt(),
                FourthYear = po.PupilNumbersAndCapacityCellE15Year13FourthYear.ToInt(),
                FifthYear = po.PupilNumbersAndCapacityCellF15Year13FifthYear.ToInt(),
                SixthYear = po.PupilNumbersAndCapacityCellG15Year13SixthYear.ToInt(),
                SeventhYear = po.PupilNumbersAndCapacityCellH15Year13SeventhYear.ToInt()
            };
        }

        private static CapacityBuildupEntry BuildYear14CapacityBuildup(Po po)
        {
            return new CapacityBuildupEntry()
            {
                CurrentCapacity = po.PupilNumbersAndCapacityCellA16Year14CurrentPupilNumbersIfAlreadyOpen.ToInt(),
                FirstYear = po.PupilNumbersAndCapacityCellB16Year14FirstYear.ToInt(),
                SecondYear = po.PupilNumbersAndCapacityCellC16Year14SecondYear.ToInt(),
                ThirdYear = po.PupilNumbersAndCapacityCellD16Year14ThirdYear.ToInt(),
                FourthYear = po.PupilNumbersAndCapacityCellE16Year14FourthYear.ToInt(),
                FifthYear = po.PupilNumbersAndCapacityCellF16Year14FifthYear.ToInt(),
                SixthYear = po.PupilNumbersAndCapacityCellG16Year14SixthYear.ToInt(),
                SeventhYear = po.PupilNumbersAndCapacityCellH16Year14SeventhYear.ToInt()
            };
        }

        private static CapacityBuildupEntry BuildPost16TotalCapacityBuildup(Po po)
        {
            return new CapacityBuildupEntry()
            {
                CurrentCapacity = po.PupilNumbersAndCapacityTotalPost16A.ToInt(),
                FirstYear = po.PupilNumbersAndCapacityTotalPost16B.ToInt(),
                SecondYear = po.PupilNumbersAndCapacityTotalPost16C.ToInt(),
                ThirdYear = po.PupilNumbersAndCapacityTotalPost16D.ToInt(),
                FourthYear = po.PupilNumbersAndCapacityTotalPost16E.ToInt(),
                FifthYear = po.PupilNumbersAndCapacityTotalPost16F.ToInt(),
                SixthYear = po.PupilNumbersAndCapacityTotalPost16G.ToInt(),
                SeventhYear = po.PupilNumbersAndCapacityTotalPost16H.ToInt()
            };
        }
    }
}
