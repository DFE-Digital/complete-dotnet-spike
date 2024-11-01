using Dfe.Complete.API.Contracts.Project.Conversion.Tasks;
using Dfe.Complete.API.UseCases.Project.Tasks.StakeholderKickoff;
using Dfe.Complete.Data.Entities;

namespace Dfe.Complete.API.UseCases.Project.Conversion.Tasks.StakeholderKickoff
{
    public class ConversionStakeholderKickoffTaskBuilder
    {
        public static ConversionStakeholderKickoffTask Execute(ConversionTasksData task)
        {
            var updatedTask = StakeholderKickoffTaskBuilder.Execute(task);

            var result = new ConversionStakeholderKickoffTask()
            {
                SendIntroEmails = updatedTask.SendIntroEmails,
                SendInvites = updatedTask.SendInvites,
                HostMeetingOrCall = updatedTask.HostMeetingOrCall,
                LocalAuthorityAbleToConvert = task.StakeholderKickOffCheckProvisionalConversionDate,
                LocalAuthorityProforma = task.StakeholderKickOffLocalAuthorityProforma,
                StakeholderKickOffConversionDate = task.StakeholderKickOffConversionDate
            };

            return result;
        }
    }
}
