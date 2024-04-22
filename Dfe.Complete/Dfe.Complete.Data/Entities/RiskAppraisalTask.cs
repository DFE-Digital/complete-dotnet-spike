using Dfe.ManageFreeSchoolProjects.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Dfe.ManageFreeSchoolProjects.Data
{
    public partial class MfspContext : DbContext
    {
        public virtual DbSet<RiskAppraisalMeetingTask> RiskAppraisalMeetingTask { get; set; }
    }
}

namespace Dfe.ManageFreeSchoolProjects.Data.Entities
{
	public class RiskAppraisalMeetingTask : IAuditable
	{
		public string RID { get; set; }

		public bool? MeetingCompleted { get; set; }

		public DateTime? ForecastDate { get; set; }

        public DateTime? ActualDate { get; set; }

        public string CommentOnDecision { get; set; }

        public string ReasonNotApplicable { get; set; }
    }
}

