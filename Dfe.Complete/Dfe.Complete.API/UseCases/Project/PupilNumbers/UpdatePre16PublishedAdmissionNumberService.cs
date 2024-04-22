using Dfe.ManageFreeSchoolProjects.API.Contracts.Project.PupilNumbers;
using Dfe.ManageFreeSchoolProjects.Data.Entities.Existing;

namespace Dfe.ManageFreeSchoolProjects.API.UseCases.Project.PupilNumbers
{
    public interface IUpdatePre16PublishedAdmissionNumberService
    {
        public void Execute(Po po, UpdatePupilNumbersRequest request);
    }

    public class UpdatePre16PublishedAdmissionNumberService : IUpdatePre16PublishedAdmissionNumberService
    {
        public void Execute(Po po, UpdatePupilNumbersRequest request)
        {
            if (request.Pre16PublishedAdmissionNumber == null)
            {
                return;
            }

            po.PupilNumbersAndCapacityYrPan = request.Pre16PublishedAdmissionNumber.Reception.ToString();
            po.PupilNumbersAndCapacityY7Pan = request.Pre16PublishedAdmissionNumber.Year7.ToString();
            po.PupilNumbersAndCapacityY10Pan = request.Pre16PublishedAdmissionNumber.Year10.ToString();
            po.PupilNumbersAndCapacityYOtherPanPre16 = request.Pre16PublishedAdmissionNumber.OtherPre16.ToString();

            var total = 
                request.Pre16PublishedAdmissionNumber.Reception +
                request.Pre16PublishedAdmissionNumber.Year7 +
                request.Pre16PublishedAdmissionNumber.Year10 +
                request.Pre16PublishedAdmissionNumber.OtherPre16;

            po.PupilNumbersAndCapacityTotalPanPre16 = total.ToString();
        }
    }
}
