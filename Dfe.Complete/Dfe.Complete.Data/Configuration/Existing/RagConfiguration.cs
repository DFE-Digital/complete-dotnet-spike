using Dfe.ManageFreeSchoolProjects.Data.Entities;
using Dfe.ManageFreeSchoolProjects.Data.Entities.Existing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dfe.ManageFreeSchoolProjects.Data.Configuration.Existing
{
    public partial class RagConfiguration : IEntityTypeConfiguration< Rag>
	{
		public void Configure(EntityTypeBuilder<Rag> builder)
		{
            builder.HasKey(e => e.Rid);

            builder
                .ToTable("RAG", "dbo", e => e.IsTemporal());

            builder.Property(e => e.PRid)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasColumnName("p_rid");
            builder.Property(e => e.RagRatingsAllAssessmentConditionsMet)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Rag Ratings.All assessment conditions met");
            builder.Property(e => e.RagRatingsAssessmentCondition1)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Rag Ratings.Assessment condition 1");
            builder.Property(e => e.RagRatingsAssessmentCondition2)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Rag Ratings.Assessment condition 2");
            builder.Property(e => e.RagRatingsAssessmentCondition3)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Rag Ratings.Assessment condition 3");
            builder.Property(e => e.RagRatingsAssessmentCondition4)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Rag Ratings.Assessment condition 4");
            builder.Property(e => e.RagRatingsAssessmentCondition5)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Rag Ratings.Assessment condition 5");
            builder.Property(e => e.RagRatingsAssessmentCondition6)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Rag Ratings.Assessment condition 6");
            builder.Property(e => e.RagRatingsAssessmentCondition7)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Rag Ratings.Assessment condition 7");
            builder.Property(e => e.RagRatingsAssessmentCondition8)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Rag Ratings.Assessment condition 8");
            builder.Property(e => e.RagRatingsEducationRag)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Rag Ratings.Education RAG");
            builder.Property(e => e.RagRatingsFinanceRagSummary)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("Rag Ratings.Finance RAG summary");
            builder.Property(e => e.RagRatingsEducationRagSummary)
                 .HasMaxLength(1000)
                 .IsUnicode(false)
                 .HasColumnName("Rag Ratings.Education RAG summary");
            builder.Property(e => e.RagRatingsFinancesRagRating)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("Rag Ratings.Finances RAG rating");
            builder.Property(e => e.RagRatingsGovernanceAndSuitabilityRagRating)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Rag Ratings.Governance and Suitability RAG rating");
            builder.Property(e => e.RagRatingsGovernanceAndSuitabilityRagSummary)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("Rag Ratings.Governance and Suitability RAG summary");
            builder.Property(e => e.RagRatingsHasCondition1BeenMet)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("Rag Ratings.Has condition 1 been met?");
            builder.Property(e => e.RagRatingsHasCondition2BeenMet)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Rag Ratings.Has condition 2 been met?");
            builder.Property(e => e.RagRatingsHasCondition3BeenMet)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Rag Ratings.Has condition 3 been met?");
            builder.Property(e => e.RagRatingsHasCondition4BeenMet)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Rag Ratings.Has condition 4 been met?");
            builder.Property(e => e.RagRatingsHasCondition5BeenMet)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Rag Ratings.Has condition 5 been met?");
            builder.Property(e => e.RagRatingsHasCondition6BeenMet)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Rag Ratings.Has condition 6 been met?");
            builder.Property(e => e.RagRatingsHasCondition7BeenMet)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Rag Ratings.Has condition 7 been met?");
            builder.Property(e => e.RagRatingsHasCondition8BeenMet)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Rag Ratings.Has condition 8 been met?");
            builder.Property(e => e.RagRatingsInclusivityIssue)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Rag Ratings.Inclusivity Issue");
            builder.Property(e => e.RagRatingsLinkToRiskAssessmentMatrix)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Rag Ratings.Link to Risk Assessment Matrix");
            builder.Property(e => e.RagRatingsLocalContextRagRating)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Rag Ratings.Local context RAG rating");
            builder.Property(e => e.RagRatingsOverallRagRating)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Rag Ratings.Overall RAG rating");
            builder.Property(e => e.RagRatingsOverallRagSummary)
                .HasMaxLength(5000)
                .IsUnicode(false)
                .HasColumnName("Rag Ratings.Overall RAG summary");
            builder.Property(e => e.RagRatingsOverallRomRagRating)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Rag Ratings.Overall ROM RAG rating");
            builder.Property(e => e.RagRatingsPipelineFreeSchoolsJointRiskCategory)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Rag Ratings.Pipeline Free Schools Joint Risk Category");
            builder.Property(e => e.RagRatingsProjectRecommendation)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Rag Ratings.Project recommendation");
            builder.Property(e => e.RagRatingsPupilRecruitmentRagRating)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Rag Ratings.Pupil recruitment RAG rating");
            builder.Property(e => e.RagRatingsReasonForJointRiskCategory)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Rag Ratings.Reason for Joint Risk Category");
            builder.Property(e => e.RagRatingsRscStocktakeRecommendationSummary)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("Rag Ratings.RSC stocktake recommendation summary");
            builder.Property(e => e.RagRatingsSummaryOfInclusivityIssue)
                .HasMaxLength(999)
                .IsUnicode(false)
                .HasColumnName("Rag Ratings.Summary of inclusivity issue");
            builder.Property(e => e.Rid)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasColumnName("RID");
            builder.Property(e => e.RagRatingsRiskAppraisalFormSharepointLink)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("Rag Ratings.Risk Appraisal Form Sharepoint Link");

            AuditConfiguration.Apply(builder);
        }
	}

}
