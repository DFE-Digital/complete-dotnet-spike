using Dfe.ManageFreeSchoolProjects.API.Contracts.Project.PupilNumbers;
using Dfe.ManageFreeSchoolProjects.Data.Entities.Existing;

namespace Dfe.ManageFreeSchoolProjects.API.UseCases.Project.PupilNumbers
{
    public interface IUpdatePost16CapacityBuildupService
    {
        public void Execute(Po po, UpdatePupilNumbersRequest request);
    }

    public class UpdatePost16CapacityBuildupService : IUpdatePost16CapacityBuildupService
    {
        public void Execute(Po po, UpdatePupilNumbersRequest request)
        {
            if (request.Post16CapacityBuildup == null)
            {
                return;
            }

            UpdateYear12(po, request.Post16CapacityBuildup.Year12);
            UpdateYear13(po, request.Post16CapacityBuildup.Year13);
            UpdateYear14(po, request.Post16CapacityBuildup.Year14);
            UpdateTotals(po, request);
        }

        private static void UpdateYear12(Po po, CapacityBuildupEntry entry)
        {
            po.PupilNumbersAndCapacityCellA14Year12CurrentPupilNumbersIfAlreadyOpen = entry.CurrentCapacity.ToString();
            po.PupilNumbersAndCapacityCellB14Year12FirstYear = entry.FirstYear.ToString();
            po.PupilNumbersAndCapacityCellC14Year12SecondYear = entry.SecondYear.ToString();
            po.PupilNumbersAndCapacityCellD14Year12ThirdYear = entry.ThirdYear.ToString();
            po.PupilNumbersAndCapacityCellE14Year12FourthYear = entry.FourthYear.ToString();
            po.PupilNumbersAndCapacityCellF14Year12FifthYear = entry.FifthYear.ToString();
            po.PupilNumbersAndCapacityCellG14Year12SixthYear = entry.SixthYear.ToString();
            po.PupilNumbersAndCapacityCellH14Year12SeventhYear = entry.SeventhYear.ToString();
        }

        private static void UpdateYear13(Po po, CapacityBuildupEntry entry)
        {
            po.PupilNumbersAndCapacityCellA15Year13CurrentPupilNumbersIfAlreadyOpen = entry.CurrentCapacity.ToString();
            po.PupilNumbersAndCapacityCellB15Year13FirstYear = entry.FirstYear.ToString();
            po.PupilNumbersAndCapacityCellC15Year13SecondYear = entry.SecondYear.ToString();
            po.PupilNumbersAndCapacityCellD15Year13ThirdYear = entry.ThirdYear.ToString();
            po.PupilNumbersAndCapacityCellE15Year13FourthYear = entry.FourthYear.ToString();
            po.PupilNumbersAndCapacityCellF15Year13FifthYear = entry.FifthYear.ToString();
            po.PupilNumbersAndCapacityCellG15Year13SixthYear = entry.SixthYear.ToString();
            po.PupilNumbersAndCapacityCellH15Year13SeventhYear = entry.SeventhYear.ToString();
        }

        private static void UpdateYear14(Po po, CapacityBuildupEntry entry)
        {
            po.PupilNumbersAndCapacityCellA16Year14CurrentPupilNumbersIfAlreadyOpen = entry.CurrentCapacity.ToString();
            po.PupilNumbersAndCapacityCellB16Year14FirstYear = entry.FirstYear.ToString();
            po.PupilNumbersAndCapacityCellC16Year14SecondYear = entry.SecondYear.ToString();
            po.PupilNumbersAndCapacityCellD16Year14ThirdYear = entry.ThirdYear.ToString();
            po.PupilNumbersAndCapacityCellE16Year14FourthYear = entry.FourthYear.ToString();
            po.PupilNumbersAndCapacityCellF16Year14FifthYear = entry.FifthYear.ToString();
            po.PupilNumbersAndCapacityCellG16Year14SixthYear = entry.SixthYear.ToString();
            po.PupilNumbersAndCapacityCellH16Year14SeventhYear = entry.SeventhYear.ToString();
        }

        private static void UpdateTotals(Po po, UpdatePupilNumbersRequest request)
        {
            int currentCapacityTotal = CalculateCurrentCapacityTotal(request);
            int firstYearTotal = CalculateFirstYearTotal(request);
            int secondYearTotal = CalculateSecondYearTotal(request);
            int thirdYearTotal = CalculateThirdYearTotal(request);
            int fourthYearTotal = CalculateFourthYearTotal(request);
            int fifthYearTotal = CalculateFifthYearTotal(request);
            int sixthYearTotal = CalculateSixthYearTotal(request);
            int seventhYearTotal = CalculateSeventhYearTotal(request);

            po.PupilNumbersAndCapacityTotalPost16A = currentCapacityTotal.ToString();
            po.PupilNumbersAndCapacityTotalPost16B = firstYearTotal.ToString();
            po.PupilNumbersAndCapacityTotalPost16C = secondYearTotal.ToString();
            po.PupilNumbersAndCapacityTotalPost16D = thirdYearTotal.ToString();
            po.PupilNumbersAndCapacityTotalPost16E = fourthYearTotal.ToString();
            po.PupilNumbersAndCapacityTotalPost16F = fifthYearTotal.ToString();
            po.PupilNumbersAndCapacityTotalPost16G = sixthYearTotal.ToString();
            po.PupilNumbersAndCapacityTotalPost16H = seventhYearTotal.ToString();
        }

        private static int CalculateCurrentCapacityTotal(UpdatePupilNumbersRequest request)
        {
            return request.Post16CapacityBuildup.Year12.CurrentCapacity +
                request.Post16CapacityBuildup.Year13.CurrentCapacity +
                request.Post16CapacityBuildup.Year14.CurrentCapacity;
        }

        private static int CalculateFirstYearTotal(UpdatePupilNumbersRequest request)
        {
            return request.Post16CapacityBuildup.Year12.FirstYear +
                request.Post16CapacityBuildup.Year13.FirstYear +
                request.Post16CapacityBuildup.Year14.FirstYear;
        }

        private static int CalculateSecondYearTotal(UpdatePupilNumbersRequest request)
        {
            return request.Post16CapacityBuildup.Year12.SecondYear +
                request.Post16CapacityBuildup.Year13.SecondYear +
                request.Post16CapacityBuildup.Year14.SecondYear;
        }

        private static int CalculateThirdYearTotal(UpdatePupilNumbersRequest request)
        {
            return request.Post16CapacityBuildup.Year12.ThirdYear +
                request.Post16CapacityBuildup.Year13.ThirdYear +
                request.Post16CapacityBuildup.Year14.ThirdYear;
        }

        private static int CalculateFourthYearTotal(UpdatePupilNumbersRequest request)
        {
            return request.Post16CapacityBuildup.Year12.FourthYear +
                request.Post16CapacityBuildup.Year13.FourthYear +
                request.Post16CapacityBuildup.Year14.FourthYear;
        }

        private static int CalculateFifthYearTotal(UpdatePupilNumbersRequest request)
        {
            return request.Post16CapacityBuildup.Year12.FifthYear +
                request.Post16CapacityBuildup.Year13.FifthYear +
                request.Post16CapacityBuildup.Year14.FifthYear;
        }

        private static int CalculateSixthYearTotal(UpdatePupilNumbersRequest request)
        {
            return request.Post16CapacityBuildup.Year12.SixthYear +
                request.Post16CapacityBuildup.Year13.SixthYear +
                request.Post16CapacityBuildup.Year14.SixthYear;
        }

        private static int CalculateSeventhYearTotal(UpdatePupilNumbersRequest request)
        {
            return request.Post16CapacityBuildup.Year12.SeventhYear +
                request.Post16CapacityBuildup.Year13.SeventhYear +
                request.Post16CapacityBuildup.Year14.SeventhYear;
        }
    }
}
