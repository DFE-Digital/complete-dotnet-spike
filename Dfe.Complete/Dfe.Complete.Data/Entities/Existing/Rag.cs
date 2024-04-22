using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Dfe.ManageFreeSchoolProjects.Data
{
    public partial class MfspContext : DbContext
    {
        public virtual DbSet<Entities.Existing.Rag> Rag { get; set; }
    }
}

namespace Dfe.ManageFreeSchoolProjects.Data.Entities.Existing
{
    public partial class Rag : IAuditable
    {
        public string PRid { get; set; }

        public string Rid { get; set; }

        public string RagRatingsPipelineFreeSchoolsJointRiskCategory { get; set; }

        public string RagRatingsReasonForJointRiskCategory { get; set; }

        public string RagRatingsOverallRagRating { get; set; }

        public string RagRatingsOverallRagSummary { get; set; }

        public string RagRatingsProjectRecommendation { get; set; }

        public string RagRatingsRscStocktakeRecommendationSummary { get; set; }

        public string RagRatingsAssessmentCondition1 { get; set; }

        public string RagRatingsHasCondition1BeenMet { get; set; }

        public string RagRatingsAssessmentCondition2 { get; set; }

        public string RagRatingsHasCondition2BeenMet { get; set; }

        public string RagRatingsAssessmentCondition3 { get; set; }

        public string RagRatingsHasCondition3BeenMet { get; set; }

        public string RagRatingsAssessmentCondition4 { get; set; }

        public string RagRatingsHasCondition4BeenMet { get; set; }

        public string RagRatingsAssessmentCondition5 { get; set; }

        public string RagRatingsHasCondition5BeenMet { get; set; }

        public string RagRatingsAssessmentCondition6 { get; set; }

        public string RagRatingsHasCondition6BeenMet { get; set; }

        public string RagRatingsAssessmentCondition7 { get; set; }

        public string RagRatingsHasCondition7BeenMet { get; set; }

        public string RagRatingsAssessmentCondition8 { get; set; }

        public string RagRatingsHasCondition8BeenMet { get; set; }

        public string RagRatingsAllAssessmentConditionsMet { get; set; }

        public string RagRatingsPupilRecruitmentRagRating { get; set; }

        public string RagRatingsGovernanceAndSuitabilityRagRating { get; set; }

        public string RagRatingsLocalContextRagRating { get; set; }

        public string RagRatingsEducationRag { get; set; }

        public string RagRatingsInclusivityIssue { get; set; }

        public string RagRatingsSummaryOfInclusivityIssue { get; set; }

        public string RagRatingsFinancesRagRating { get; set; }

        public string RagRatingsFinanceRagSummary { get; set; }

        public string RagRatingsLinkToRiskAssessmentMatrix { get; set; }

        public string RagRatingsOverallRomRagRating { get; set; }
    }
}