using System;
using System.Collections.Generic;
using Dfe.Complete.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dfe.Complete.Data.Configuration
{
    public partial class ProjectConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.HasKey(e => e.Id).HasName("PK__projects__3213E83F41C861A2");
            builder.ToTable("projects", "complete");

            builder.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("id");
            builder.Property(e => e.AcademyUrn).HasColumnName("academy_urn");
            builder.Property(e => e.AdvisoryBoardConditions).HasColumnName("advisory_board_conditions");
            builder.Property(e => e.AdvisoryBoardDate)
                .HasColumnType("date")
                .HasColumnName("advisory_board_date");
            builder.Property(e => e.AllConditionsMet)
                .HasDefaultValueSql("((0))")
                .HasColumnName("all_conditions_met");
            builder.Property(e => e.AssignedAt)
                .HasPrecision(6)
                .HasColumnName("assigned_at");
            builder.Property(e => e.AssignedToId).HasColumnName("assigned_to_id");
            builder.Property(e => e.CaseworkerId).HasColumnName("caseworker_id");
            builder.Property(e => e.ChairOfGovernorsContactId).HasColumnName("chair_of_governors_contact_id");
            builder.Property(e => e.CompletedAt)
                .HasPrecision(6)
                .HasColumnName("completed_at");
            builder.Property(e => e.CreatedAt)
                .HasPrecision(6)
                .HasColumnName("created_at");
            builder.Property(e => e.DirectiveAcademyOrder)
                .HasDefaultValueSql("((0))")
                .HasColumnName("directive_academy_order");
            builder.Property(e => e.EstablishmentMainContactId).HasColumnName("establishment_main_contact_id");
            builder.Property(e => e.EstablishmentSharepointLink).HasColumnName("establishment_sharepoint_link");
            builder.Property(e => e.FundingAgreementContactId).HasColumnName("funding_agreement_contact_id");
            builder.Property(e => e.IncomingTrustMainContactId).HasColumnName("incoming_trust_main_contact_id");
            builder.Property(e => e.IncomingTrustSharepointLink).HasColumnName("incoming_trust_sharepoint_link");
            builder.Property(e => e.IncomingTrustUkprn).HasColumnName("incoming_trust_ukprn");
            builder.Property(e => e.MainContactId).HasColumnName("main_contact_id");
            builder.Property(e => e.NewTrustName)
                .HasMaxLength(4000)
                .HasColumnName("new_trust_name");
            builder.Property(e => e.NewTrustReferenceNumber)
                .HasMaxLength(4000)
                .HasColumnName("new_trust_reference_number");
            builder.Property(e => e.OutgoingTrustMainContactId).HasColumnName("outgoing_trust_main_contact_id");
            builder.Property(e => e.OutgoingTrustSharepointLink).HasColumnName("outgoing_trust_sharepoint_link");
            builder.Property(e => e.OutgoingTrustUkprn).HasColumnName("outgoing_trust_ukprn");
            builder.Property(e => e.Region)
                .HasMaxLength(4000)
                .HasColumnName("region");
            builder.Property(e => e.RegionalDeliveryOfficerId).HasColumnName("regional_delivery_officer_id");
            builder.Property(e => e.SignificantDate)
                .HasColumnType("date")
                .HasColumnName("significant_date");
            builder.Property(e => e.SignificantDateProvisional)
                .HasDefaultValueSql("((1))")
                .HasColumnName("significant_date_provisional");
            builder.Property(e => e.State).HasColumnName("state");
            builder.Property(e => e.TasksDataId).HasColumnName("tasks_data_id");
            builder.Property(e => e.TasksDataType)
                .HasMaxLength(4000)
                .HasColumnName("tasks_data_type");
            builder.Property(e => e.Team)
                .HasMaxLength(4000)
                .HasColumnName("team");
            builder.Property(e => e.TeamLeaderId).HasColumnName("team_leader_id");
            builder.Property(e => e.TwoRequiresImprovement)
                .HasDefaultValueSql("((0))")
                .HasColumnName("two_requires_improvement");
            builder.Property(e => e.Type)
                .HasMaxLength(4000)
                .HasColumnName("type");
            builder.Property(e => e.UpdatedAt)
                .HasPrecision(6)
                .HasColumnName("updated_at");
            builder.Property(e => e.Urn).HasColumnName("urn");

        }
    }

}
