using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Dfe.ManageFreeSchoolProjects.Data
{
    public partial class MfspContext : DbContext
    {
        public virtual DbSet<Entities.Existing.PlanningQa> PlanningQa { get; set; }
    }
}

namespace Dfe.ManageFreeSchoolProjects.Data.Entities.Existing
{
    public partial class PlanningQa
    {
        public string Month { get; set; }

        public int PlanningRiskHighlight { get; set; }

        public int TypeOfPlanningRequiredHighlight { get; set; }

        public int DateLetterSentToLocalPlanningAuthorityForecastHighlight { get; set; }

        public int DateLetterSentToLocalPlanningAuthorityActualHighlight { get; set; }

        public int ClassCExpiryDateActualHighlight { get; set; }

        public int LpaApplicationReferenceHighlight { get; set; }

        public int DatePlanningApplicationSubmittedForecastHighlight { get; set; }

        public int DatePlanningApplicationSubmittedActualHighlight { get; set; }

        public int DatePlanningApplicationValidatedActualHighlight { get; set; }

        public int DateOfStatutoryDeterminationActualHighlight { get; set; }

        public int DateOfPlanningDecisionNoticeForecastHighlight { get; set; }

        public int DateOfPlanningDecisionNoticeActualHighlight { get; set; }

        public int AppealRequiredHighlight { get; set; }

        public int AppealProcedureHighlight { get; set; }

        public int DateAppealSubmittedForecastHighlight { get; set; }

        public int DateAppealSubmittedActualHighlight { get; set; }

        public int DateAppealValidatedActualHighlight { get; set; }

        public int DateOfAppealDecisionNoticeForecastHighlight { get; set; }

        public int DateOfAppealDecisionNoticeActualHighlight { get; set; }

        public int PlanningPermissionLimitedToASpecificTimeAndExpiryPeriodHighlight { get; set; }

        public int PlanningPermissionExpiryDateActualHighlight { get; set; }
    }
}