using System.ComponentModel.DataAnnotations.Schema;

namespace Dfe.Complete.Data.Entities
{
    /// <summary>
    /// Interface that represents the data shared between conversion and transfer tasks
    /// Could do this as a class, but the problem is we have to modify a generated class to remove properties
    /// Likely this generated class will be changed multiple times as we try to stay in sync with the existing database
    /// </summary>
    public class IProjectTasksData
    {
        [NotMapped]
        public bool? HandoverReview { get; set; }

        [NotMapped]
        public bool? HandoverNotes { get; set; }

        [NotMapped]
        public bool? HandoverMeeting { get; set; }

        [NotMapped]
        public bool? HandoverNotApplicable { get; set; }
    }
}
