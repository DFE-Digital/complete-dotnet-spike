using System.ComponentModel.DataAnnotations.Schema;

namespace Dfe.Complete.Data.Entities
{
    /// <summary>
    /// Interface that represents the data shared between conversion and transfer tasks
    /// Could do this as a class, but the problem is we have to modify a generated class to remove properties
    /// Likely this generated class will be changed multiple times as we try to stay in sync with the existing database
    /// </summary>
    public interface IProjectTasksData
    {
        public bool? HandoverReview { get; set; }

        public bool? HandoverNotes { get; set; }

        public bool? HandoverMeeting { get; set; }

        public bool? HandoverNotApplicable { get; set; }

        public bool? StakeholderKickOffIntroductoryEmails { get; set; }

        public bool? StakeholderKickOffSetupMeeting { get; set; }

        public bool? StakeholderKickOffMeeting { get; set; }
    }
}
