using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Dfe.ManageFreeSchoolProjects.Data
{
    public partial class MfspContext : DbContext
    {
        public virtual DbSet<Entities.Existing.Planning> Planning { get; set; }
    }
}

namespace Dfe.ManageFreeSchoolProjects.Data.Entities.Existing
{
    public partial class Planning
    {
        public string PRid { get; set; }

        public string Rid { get; set; }

        public string PlanningRecordIsThisTheMainPlanningRecord { get; set; }

        public string PlanningRecordStorePlanningRecordId { get; set; }

        public string PlanningRecordPlanningLeadComments { get; set; }

        public string PlanningRecordPlanningRisk { get; set; }

        public string PlanningRecordSiteId { get; set; }

        public string PlanningRecordPrNameOfSite { get; set; }

        public bool? PlanningRecordNameManualOverwrite { get; set; }

        public string PlanningRecordAddressOfSite { get; set; }

        public bool? PlanningRecordAddressManualOverwrite { get; set; }

        public string PlanningRecordPostcodeOfSite { get; set; }

        public bool? PlanningRecordPostcodeManualOverwrite { get; set; }

        public string PlanningRecordLocalPlanningAuthority { get; set; }

        public string PlanningRecordPlanningAppraisalCompleted { get; set; }

        public DateTime? PlanningRecordDatePlanningAppraisalCompletedActual { get; set; }

        public string PlanningRecordIsPlanningPermissionRequired { get; set; }

        public string PlanningRecordTypeOfPlanningRequired { get; set; }

        public DateTime? PlanningRecordDateLetterSentToLocalPlanningAuthorityForecast { get; set; }

        public DateTime? PlanningRecordDateLetterSentToLocalPlanningAuthorityActual { get; set; }

        public DateTime? PlanningRecordClassCExpiryDateActual { get; set; }

        public string PlanningRecordDescriptionOfDevelopment { get; set; }

        public string PlanningRecordLpaApplicationReference { get; set; }

        public DateTime? PlanningRecordDatePlanningApplicationSubmittedForecast { get; set; }

        public DateTime? PlanningRecordDatePlanningApplicationSubmittedActual { get; set; }

        public DateTime? PlanningRecordDatePlanningApplicationValidatedActual { get; set; }

        public DateTime? PlanningRecordDateOfStatutoryDeterminationActual { get; set; }

        public DateTime? PlanningRecordDateOfPlanningDecisionNoticeForecast { get; set; }

        public DateTime? PlanningRecordDateOfPlanningDecisionNoticeActual { get; set; }

        public string PlanningRecordPlanningDecision { get; set; }

        public string PlanningRecordWasPlanningSecuredInTimeForSchoolRequirements { get; set; }

        public DateTime? PlanningRecordJrChallengePeriodFinishedActual { get; set; }

        public string PlanningRecordAppealRequired { get; set; }

        public string PlanningRecordAppealProcedure { get; set; }

        public DateTime? PlanningRecordDateAppealSubmittedForecast { get; set; }

        public DateTime? PlanningRecordDateAppealSubmittedActual { get; set; }

        public DateTime? PlanningRecordDateAppealValidatedActual { get; set; }

        public DateTime? PlanningRecordDateOfAppealDecisionNoticeForecast { get; set; }

        public DateTime? PlanningRecordDateOfAppealDecisionNoticeActual { get; set; }

        public string PlanningRecordAppealDecision { get; set; }

        public string PlanningRecordPlanningPermissionLimitedToASpecificTimeAndExpiryPeriod { get; set; }

        public DateTime? PlanningRecordPrPlanningPermissionExpiryDateActual { get; set; }
    }
}