namespace Dfe.Complete.API.Contracts.Project.Tasks
{
    public class StakeholderKickoffTask
    {
        public bool? SendIntroEmails { get; set; }

        public bool? SendInvites { get; set; }

        public bool? HostMeetingOrCall { get; set; }
    }
}
