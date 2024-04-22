using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Dfe.ManageFreeSchoolProjects.Data
{
    public partial class MfspContext : DbContext
    {
        public virtual DbSet<Entities.Existing.Opens> Opens { get; set; }
    }
}

namespace Dfe.ManageFreeSchoolProjects.Data.Entities.Existing
{
    public partial class Opens : IAuditable
    {
        public string PRid { get; set; }

        public string Rid { get; set; }

        public string CurrentStatusCaseNote { get; set; }

        public DateTime? CurrentStatusDateOfLatestCaseNote { get; set; }

        public string CurrentStatusIntervention { get; set; }

        public string CurrentStatusEfaTerritoryConcernLevel { get; set; }

        public string CurrentStatusDueDiligenceConcerns { get; set; }

        public string CurrentStatusFinancialConcerns { get; set; }

        public string CurrentStatusPrincipalSameAsOnOpening { get; set; }

        public string CurrentStatusGovernanceAndCompliance { get; set; }

        public string CurrentStatusIrregularity { get; set; }

        public string OpenPupilNumbersCapacityAgreedInPreOpening { get; set; }

        public string OpenPupilNumbersFundedNumberForTheCurrentAcademicYear { get; set; }

        public string OpenPupilNumbersViabilityThresholdForTheCurrentAcademicYear { get; set; }

        public string OpenPupilNumbersEfaRingRoundPupilNumbers { get; set; }

        public DateTime? OpenPupilNumbersDateEfaRingRoundPupilNumbersUpdated { get; set; }

        public string OpenPupilNumbersCurrentPupilsOnRoll { get; set; }

        public DateTime? OpenPupilNumbersCensusDate { get; set; }

        public string OpenPupilNumbersFull { get; set; }

        public string OpenPupilNumbersNorAsOfFundedNumber { get; set; }

        public string OpenPupilNumbersApplicationsYr10ForTheComingYear { get; set; }

        public string OpenPupilNumbersApplicationsYr12ForTheComingYear { get; set; }

        public string OpenPupilNumbersAcceptedApplicationsYr10ForNextYear { get; set; }

        public string OpenPupilNumbersAcceptedApplicationsYr12ForNextYear { get; set; }

        public string OpenPupilNumbersFundedNumberForTheComingYear { get; set; }

        public string OpenPupilNumbersViabilityThresholdForTheComingYear { get; set; }

        public string OpenPupilNumbersReception { get; set; }

        public string OpenPupilNumbersYear1 { get; set; }

        public string OpenPupilNumbersYear2 { get; set; }

        public string OpenPupilNumbersYear3 { get; set; }

        public string OpenPupilNumbersYear4 { get; set; }

        public string OpenPupilNumbersYear5 { get; set; }

        public string OpenPupilNumbersYear6 { get; set; }

        public string OpenPupilNumbersYrY6Total { get; set; }

        public string OpenPupilNumbersYear7 { get; set; }

        public string OpenPupilNumbersYear8 { get; set; }

        public string OpenPupilNumbersYear9 { get; set; }

        public string OpenPupilNumbersYear10 { get; set; }

        public string OpenPupilNumbersYear11 { get; set; }

        public string OpenPupilNumbersY7Y11Total { get; set; }

        public string OpenPupilNumbersYear12 { get; set; }

        public string OpenPupilNumbersYear13 { get; set; }

        public string OpenPupilNumbersYear14 { get; set; }

        public string OpenPupilNumbersY12Y14Total { get; set; }

        public string OpenPupilNumbersTotal { get; set; }

        public string FinancialChecksMostRecentAuditedAccountsReceivedOnTime { get; set; }

        public string FinancialChecksFinancialStatementsSubmittedByLastDeadline { get; set; }

        public string FinancialChecksFinancialStatementsQualified { get; set; }

        public string FinancialChecksRegularityOpinionQualified { get; set; }

        public string FinancialChecksProjectDevelopmentGrantFinalReturnReceived { get; set; }

        public string FinancialChecksBudgetReturnSubmittedByLastDeadline { get; set; }

        public string FinancialChecksFmgsReturnSubmittedByLastDeadline { get; set; }

        public string FinancialChecksMindedToIssueFnti { get; set; }

        public string FinancialChecksFinancialNoticeToImproveIssued { get; set; }

        public string FinancialChecksTotalOutstandingPna { get; set; }

        public string FinancialChecksAdditionalDebtDeficit { get; set; }

        public string FinancialChecksTotalRevenueLiabilities { get; set; }
    }
}