using Dfe.Complete.API.Contracts.Project.Conversion.Tasks;
using Dfe.Complete.API.UseCases.Project.Tasks.StakeholderKickoff;
using Dfe.Complete.Data.Entities;

namespace Dfe.Complete.API.UseCases.Project.Conversion.Tasks.StakeholderKickoff
{
    public static class UpdateConversionStakeholderKickoffTaskBuilder
    {
        public static void Execute(ConversionStakeholderKickoffTask task, ConversionTasksData dbTask, Data.Entities.Project project)
        {
            UpdateStakeholderKickoffTaskBuilder.Execute(task, dbTask);

            dbTask.StakeholderKickOffLocalAuthorityProforma = task.LocalAuthorityProforma;
            dbTask.StakeholderKickOffCheckProvisionalConversionDate = task.LocalAuthorityAbleToConvert;

            if (task.StakeholderKickOffConversionDate.HasValue)
            {
                project.SignificantDate = task.StakeholderKickOffConversionDate;
                project.SignificantDateProvisional = false;
            }
        }
    }
}
