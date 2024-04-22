using Azure.Core;
using Dfe.ManageFreeSchoolProjects.API.Contracts.Project.PupilNumbers;
using Dfe.ManageFreeSchoolProjects.Data.Entities.Existing;

namespace Dfe.ManageFreeSchoolProjects.API.UseCases.Project.PupilNumbers
{
    public interface IUpdateCapacityWhenFullService
    {
        public void Execute(Po po, CapacityWhenFull capacityWhenFull);
    }

    public class UpdateCapacityWhenFullService : IUpdateCapacityWhenFullService
    {
        public void Execute(Po po, CapacityWhenFull capacityWhenFull)
        {
            if (capacityWhenFull == null)
            {
                return;
            }

            po.PupilNumbersAndCapacityNurseryUnder5s = capacityWhenFull.Nursery.ToString();
            po.PupilNumbersAndCapacityYrY6Capacity = capacityWhenFull.ReceptionToYear6.ToString();
            po.PupilNumbersAndCapacityY7Y11Capacity = capacityWhenFull.Year7ToYear11.ToString();
            po.PupilNumbersAndCapacityYrY11Pre16Capacity = (capacityWhenFull.ReceptionToYear6 + capacityWhenFull.Year7ToYear11).ToString();
            po.PupilNumbersAndCapacityY12Y14Post16Capacity = capacityWhenFull.Year12ToYear14.ToString();
            po.PupilNumbersAndCapacitySpecialistResourceProvisionSpecial = capacityWhenFull.SpecialEducationNeeds.ToString();
            po.PupilNumbersAndCapacitySpecialistResourceProvisionAp = capacityWhenFull.AlternativeProvision.ToString();

            var total =
                capacityWhenFull.Nursery +
                capacityWhenFull.ReceptionToYear6 +
                capacityWhenFull.Year7ToYear11 +
                capacityWhenFull.Year12ToYear14 +
                capacityWhenFull.SpecialEducationNeeds +
                capacityWhenFull.AlternativeProvision;

            po.PupilNumbersAndCapacityTotalOfCapacityTotals = total.ToString();
        }
    }
}
