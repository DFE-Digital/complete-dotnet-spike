using Dfe.Complete.API.Contracts.Project.Tasks;
using Dfe.Complete.Data.Entities;

namespace Dfe.Complete.API.UseCases.Project.Tasks.StakeholderKickoff
{
    public class StakeholderKickoffTaskBuilder
    {
        public static StakeholderKickoffTask Execute(TransferTasksData task)
        {
            return new StakeholderKickoffTask()
            {
                SendInvites = task.StakeholderKickOffSetupMeeting,
                SendIntroEmails = task.StakeholderKickOffIntroductoryEmails,
                HostMeetingOrCall = task.StakeholderKickOffMeeting
            };
        }
    }
}
