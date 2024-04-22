using Dfe.ManageFreeSchoolProjects.API.Contracts.Project.Tasks;

namespace Dfe.ManageFreeSchoolProjects.API.UseCases.Project.Tasks.School
{
    public class UpdateSchoolTaskService : IUpdateTaskService
    {
        public async Task Update(UpdateTaskServiceParameters parameters)
        {
            var task = parameters.Request.School;
            var dbKpi = parameters.Kpi;

            if (task == null)
            {
                return;
            }

            var faithStatus = task.FaithStatus == FaithStatus.NotSet ? string.Empty : task.FaithStatus.ToString();
            var faithType = task.FaithType == FaithType.NotSet ? string.Empty : task.FaithType.ToString();
            var gender = task.Gender == Gender.NotSet ? string.Empty : task.Gender.ToString();

            if (dbKpi.ProjectStatusCurrentFreeSchoolName != task.CurrentFreeSchoolName)
            {
                dbKpi.ProjectStatusPreviousFreeSchoolName = dbKpi.ProjectStatusCurrentFreeSchoolName;
                dbKpi.ProjectStatusHasTheFreeSchoolChangedItsName = "Yes";
            }

            dbKpi.ProjectStatusCurrentFreeSchoolName = task.CurrentFreeSchoolName;
            dbKpi.SchoolDetailsSchoolTypeMainstreamApEtc = ProjectMapper.ToSchoolType(task.SchoolType);
            dbKpi.SchoolDetailsSchoolPhasePrimarySecondary = ProjectMapper.ToSchoolPhase(task.SchoolPhase);
            dbKpi.SchoolDetailsGender = gender;
            dbKpi.SchoolDetailsAgeRange = task.AgeRange;
            dbKpi.SchoolDetailsNursery = task.Nursery.ToString();
            dbKpi.SchoolDetailsSixthForm = task.SixthForm.ToString();
            dbKpi.SchoolDetailsAlternativeProvision = task.AlternativeProvision.ToString();
            dbKpi.SchoolDetailsSpecialEducationNeeds = task.SpecialEducationNeeds.ToString();


            dbKpi.SchoolDetailsFaithStatus = faithStatus;
            dbKpi.SchoolDetailsFaithType = faithType;
            dbKpi.SchoolDetailsPleaseSpecifyOtherFaithType = task.OtherFaithType;
            dbKpi.SchoolDetailsNumberOfFormsOfEntry = task.FormsOfEntry;
        }
    }
}
