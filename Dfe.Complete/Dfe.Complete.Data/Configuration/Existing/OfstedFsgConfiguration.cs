using System;
using System.Collections.Generic;
using Dfe.ManageFreeSchoolProjects.Data.Entities;
using Dfe.ManageFreeSchoolProjects.Data.Entities.Existing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dfe.ManageFreeSchoolProjects.Data.Configuration.Existing
{
	public partial class OfstedFsgConfiguration : IEntityTypeConfiguration< OfstedFsg>
	{
		public void Configure(EntityTypeBuilder<OfstedFsg> builder)
		{
            builder.ToTable("Ofsted_FSG", "dbo", e => e.IsTemporal());

            builder.HasKey(e => e.Rid);

            builder.Property(e => e.EducationalEstablishmentAddressPostcode)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Educational Establishment.Address postcode");
            builder.Property(e => e.EducationalEstablishmentConstituency)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Educational Establishment.Constituency");
            builder.Property(e => e.EducationalEstablishmentDateClosed)
                .HasColumnType("date")
                .HasColumnName("Educational Establishment.Date Closed");
            builder.Property(e => e.EducationalEstablishmentDistrict)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Educational Establishment.District");
            builder.Property(e => e.EducationalEstablishmentLaestab)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Educational Establishment.LAESTAB");
            builder.Property(e => e.EducationalEstablishmentLocalAuthority)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Educational Establishment.Local authority");
            builder.Property(e => e.EducationalEstablishmentOpenDate)
                .HasColumnType("date")
                .HasColumnName("Educational Establishment.Open date");
            builder.Property(e => e.EducationalEstablishmentRegion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Educational Establishment.Region");
            builder.Property(e => e.EducationalEstablishmentRscRegion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Educational Establishment.RSC Region");
            builder.Property(e => e.EducationalEstablishmentSchoolName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Educational Establishment.School name");
            builder.Property(e => e.EducationalEstablishmentSchoolPhase)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Educational Establishment.School phase");
            builder.Property(e => e.EducationalEstablishmentSchoolType)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Educational Establishment.School type");
            builder.Property(e => e.EducationalEstablishmentStatus)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Educational Establishment.Status");
            builder.Property(e => e.EducationalEstablishmentUrn)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Educational Establishment.URN");
            builder.Property(e => e.LocalAuthority)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Local authority");
            builder.Property(e => e.OfstedDataModerationDate)
                .HasColumnType("date")
                .HasColumnName("Ofsted Data.Moderation date");
            builder.Property(e => e.OfstedDataModerationDateL)
                .HasColumnType("date")
                .HasColumnName("Ofsted Data.Moderation date L");
            builder.Property(e => e.OfstedDataNumberOfMonthsInCategory4)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Ofsted Data.Number of months in Category 4");
            builder.Property(e => e.OfstedDataNumberOfMonthsInCategory4L)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Ofsted Data.Number of months in Category 4 L");
            builder.Property(e => e.OfstedDataOfstedSection5CategoryOfConcern)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Ofsted Data.Ofsted section 5 Category Of Concern");
            builder.Property(e => e.OfstedDataOfstedSection5CategoryOfConcernL)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Ofsted Data.Ofsted section 5 Category Of Concern L");
            builder.Property(e => e.OfstedDataOfstedSection5DateInCategory4)
                .HasColumnType("date")
                .HasColumnName("Ofsted Data.Ofsted section 5 Date in Category 4");
            builder.Property(e => e.OfstedDataOfstedSection5DateInCategory4L)
                .HasColumnType("date")
                .HasColumnName("Ofsted Data.Ofsted section 5 Date in Category 4 L");
            builder.Property(e => e.OfstedDataOfstedSection5DateOutOfCategory4)
                .HasColumnType("date")
                .HasColumnName("Ofsted Data.Ofsted section 5 Date out of Category 4");
            builder.Property(e => e.OfstedDataOfstedSection5DateOutOfCategory4L)
                .HasColumnType("date")
                .HasColumnName("Ofsted Data.Ofsted section 5 Date out of Category 4 L");
            builder.Property(e => e.OfstedDataOfstedSection5EffectivenessLeadershipAndManagement)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Ofsted Data.Ofsted section 5 Effectiveness leadership and management");
            builder.Property(e => e.OfstedDataOfstedSection5InspectionDate)
                .HasColumnType("date")
                .HasColumnName("Ofsted Data.Ofsted section 5 inspection date");
            builder.Property(e => e.OfstedDataOfstedSection5InspectionDateL)
                .HasColumnType("date")
                .HasColumnName("Ofsted Data.Ofsted section 5 inspection date L");
            builder.Property(e => e.OfstedDataOfstedSection5OutcomesForChildrenAndLearners)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Ofsted Data.Ofsted section 5 Outcomes for children and learners");
            builder.Property(e => e.OfstedDataOfstedSection5OverallEffectiveness)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Ofsted Data.Ofsted section 5 Overall effectiveness");
            builder.Property(e => e.OfstedDataOfstedSection5OverallEffectivenessL)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Ofsted Data.Ofsted section 5 Overall effectiveness L");
            builder.Property(e => e.OfstedDataOfstedSection5PersonalDevelopmentBehaviourAndWelfare)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Ofsted Data.Ofsted section 5 Personal development, behaviour and welfare");
            builder.Property(e => e.OfstedDataOfstedSection5QualityOfTeachingLearningAndAssessment)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Ofsted Data.Ofsted section 5 Quality of teaching, learning and assessment");
            builder.Property(e => e.OfstedDataOfstedSection5SixthFormProvision)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Ofsted Data.Ofsted section 5 Sixth form provision");
            builder.Property(e => e.OfstedDataOfstedSection8InspectionDate)
                .HasColumnType("date")
                .HasColumnName("Ofsted Data.Ofsted section 8 inspection date");
            builder.Property(e => e.OfstedDataOfstedSection8Judgement)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Ofsted Data.Ofsted section 8 judgement");
            builder.Property(e => e.OfstedDataPreviousOfstedSection5InspectionDate)
                .HasColumnType("date")
                .HasColumnName("Ofsted Data.Previous Ofsted section 5 inspection date");
            builder.Property(e => e.OfstedDataPreviousOfstedSection5InspectionDateL)
                .HasColumnType("date")
                .HasColumnName("Ofsted Data.Previous Ofsted section 5 inspection date L");
            builder.Property(e => e.OfstedDataPreviousOfstedSection5OverallEffectiveness)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Ofsted Data.Previous Ofsted section 5 Overall effectiveness");
            builder.Property(e => e.OfstedDataPreviousOfstedSection5OverallEffectivenessL)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Ofsted Data.Previous Ofsted section 5 Overall effectiveness L");
            builder.Property(e => e.PRid)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasColumnName("p_rid");
            builder.Property(e => e.Phase)
                .IsRequired()
                .HasMaxLength(3)
                .IsUnicode(false);
            builder.Property(e => e.ProjectUrn)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("Project URN");
            builder.Property(e => e.Rid)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasColumnName("RID");

            AuditConfiguration.Apply(builder);
        }
	}

}
