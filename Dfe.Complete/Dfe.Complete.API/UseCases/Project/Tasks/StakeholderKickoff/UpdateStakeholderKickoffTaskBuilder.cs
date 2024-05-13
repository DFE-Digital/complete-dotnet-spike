using Dfe.Complete.API.Contracts.Project.Tasks;
using Dfe.Complete.Data.Entities;

namespace Dfe.Complete.API.UseCases.Project.Tasks.StakeholderKickoff
{
    public static class UpdateStakeholderKickoffTaskBuilder
    {
        public static void Execute(StakeholderKickoffTask task, IProjectTasksData dbTask)
        {
            dbTask.StakeholderKickOffMeeting = task.HostMeetingOrCall;
            dbTask.StakeholderKickOffIntroductoryEmails = task.SendIntroEmails;
            dbTask.StakeholderKickOffSetupMeeting = task.SendInvites;
        }
    }
}
