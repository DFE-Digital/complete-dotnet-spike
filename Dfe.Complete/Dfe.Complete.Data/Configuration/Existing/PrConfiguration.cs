using System;
using System.Collections.Generic;
using Dfe.ManageFreeSchoolProjects.Data.Entities.Existing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dfe.ManageFreeSchoolProjects.Data.Configuration.Existing
{
	public partial class PrConfiguration : IEntityTypeConfiguration< Pr>
	{
		public void Configure(EntityTypeBuilder<Pr> builder)
		{
            builder.ToTable("PR", "dbo", e => e.IsTemporal());

            builder.HasKey(e => e.Rid);

            builder.Property(e => e.PRid)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasColumnName("p_rid");
            builder.Property(e => e.PreregistrationContactNotes)
                .IsUnicode(false)
                .HasColumnName("Preregistration.Contact notes");
            builder.Property(e => e.PreregistrationDateOfLastContactWithApplicant)
                .HasColumnType("date")
                .HasColumnName("Preregistration.Date of last contact with applicant");
            builder.Property(e => e.PreregistrationDateSubmitted)
                .HasColumnType("date")
                .HasColumnName("Preregistration.Date submitted");
            builder.Property(e => e.PreregistrationDoYouAlreadyRunOneOrMoreFreeSchoolsAcademiesOrHaveAnyInThePipeline)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Preregistration.Do you already run one or more free schools/academies or have any in the pipeline? ");
            builder.Property(e => e.PreregistrationEmailOfLeadApplicant)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Preregistration.Email of lead applicant");
            builder.Property(e => e.PreregistrationEmailOfPersonSubmittingFormIfNotLeadApplicant)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Preregistration.Email of person submitting form (if not lead applicant)");
            builder.Property(e => e.PreregistrationHowManyFreeSchoolsAreYouApplyingForInThisWave)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Preregistration.How many free schools are you applying for in this wave?");
            builder.Property(e => e.PreregistrationIsThisAReApplicationIEAnApplicationThatWasPreviouslyUnsuccessful)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Preregistration.Is this a re-application i.e. an application that was previously unsuccessful? ");
            builder.Property(e => e.PreregistrationLeadSponsorId)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("Preregistration.Lead sponsor ID");
            builder.Property(e => e.PreregistrationLeadSponsorName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Preregistration.Lead sponsor name");
            builder.Property(e => e.PreregistrationNameOfLeadApplicant)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Preregistration.Name of lead applicant");
            builder.Property(e => e.PreregistrationNameOfPersonSubmittingFormIfNotLeadApplicant)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Preregistration.Name of person submitting form (if not lead applicant)");
            builder.Property(e => e.PreregistrationProposedTrustName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Preregistration.Proposed trust name");
            builder.Property(e => e.PreregistrationReferenceNumber)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Preregistration.Reference number");
            builder.Property(e => e.PreregistrationStaticLinkToTrustPageOnKim)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Preregistration.Static link to trust page on KIM");
            builder.Property(e => e.PreregistrationTelephoneNumberOfLeadApplicant)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Preregistration.Telephone number of lead applicant");
            builder.Property(e => e.PreregistrationTelephoneOfPersonSubmittingFormIfNotLeadApplicant)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Preregistration.Telephone of person submitting form (if not lead applicant)");
            builder.Property(e => e.PreregistrationTrustId)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("Preregistration.Trust ID");
            builder.Property(e => e.PreregistrationTrustName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Preregistration.Trust name");
            builder.Property(e => e.PreregistrationTypeOfGroup)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Preregistration.Type of group");
            builder.Property(e => e.PreregistrationTypeOfGroupOther)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Preregistration.Type of group other");
            builder.Property(e => e.PreregistrationWhichWaveDoYouIntendToApplyFor)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Preregistration.Which wave do you intend to apply for?");
            builder.Property(e => e.Rid)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasColumnName("RID");

		}
	}

}
