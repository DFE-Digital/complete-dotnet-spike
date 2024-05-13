using Dfe.Complete.API.Contracts.Project.Tasks;
using Dfe.Complete.Data.Entities;

namespace Dfe.Complete.API.UseCases.Project.Tasks.StakeholderKickoff
{
    public class UpdateStakeholderKickoffTaskBuilder
    {
        public static void Execute(StakeholderKickoffTask task, TransferTasksData dbTask)
        {
            dbTask.StakeholderKickOffMeeting = task.HostMeetingOrCall;
            dbTask.StakeholderKickOffIntroductoryEmails = task.SendIntroEmails;
            dbTask.StakeholderKickOffSetupMeeting = task.SendInvites;
        }
    }
}
