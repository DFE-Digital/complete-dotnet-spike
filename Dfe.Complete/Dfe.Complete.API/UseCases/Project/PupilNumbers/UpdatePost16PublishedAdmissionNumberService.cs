using Dfe.ManageFreeSchoolProjects.API.Contracts.Project.PupilNumbers;
using Dfe.ManageFreeSchoolProjects.Data.Entities.Existing;

namespace Dfe.ManageFreeSchoolProjects.API.UseCases.Project.PupilNumbers
{
    public interface IUpdatePost16PublishedAdmissionNumberService
    {
        public void Execute(Po po, UpdatePupilNumbersRequest request);
    }

    public class UpdatePost16PublishedAdmissionNumberService : IUpdatePost16PublishedAdmissionNumberService
    {
        public void Execute(Po po, UpdatePupilNumbersRequest request)
        {
            if (request.Post16PublishedAdmissionNumber == null)
            {
                return;
            }

            po.PupilNumbersAndCapacityY12Pan = request.Post16PublishedAdmissionNumber.Year12.ToString();
            po.PupilNumbersAndCapacityYOtherPanPost16 = request.Post16PublishedAdmissionNumber.OtherPost16.ToString();

            var total = request.Post16PublishedAdmissionNumber.Year12 + request.Post16PublishedAdmissionNumber.OtherPost16;

            po.PupilNumbersAndCapacityTotalPanPost16 = total.ToString();
        }
    }
}
