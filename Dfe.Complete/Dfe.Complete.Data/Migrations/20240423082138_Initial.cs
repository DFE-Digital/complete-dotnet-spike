using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dfe.Complete.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "complete");

            migrationBuilder.CreateTable(
                name: "ar_internal_metadata",
                schema: "complete",
                columns: table => new
                {
                    key = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: false),
                    value = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2(6)", precision: 6, nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2(6)", precision: 6, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ar_inter__DFD83CAE19B4E06F", x => x.key);
                });

            migrationBuilder.CreateTable(
                name: "conversion_tasks_data",
                schema: "complete",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    handover_review = table.Column<bool>(type: "bit", nullable: true),
                    handover_notes = table.Column<bool>(type: "bit", nullable: true),
                    handover_meeting = table.Column<bool>(type: "bit", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2(6)", precision: 6, nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2(6)", precision: 6, nullable: false),
                    stakeholder_kick_off_introductory_emails = table.Column<bool>(type: "bit", nullable: true),
                    stakeholder_kick_off_local_authority_proforma = table.Column<bool>(type: "bit", nullable: true),
                    stakeholder_kick_off_setup_meeting = table.Column<bool>(type: "bit", nullable: true),
                    stakeholder_kick_off_meeting = table.Column<bool>(type: "bit", nullable: true),
                    conversion_grant_check_vendor_account = table.Column<bool>(type: "bit", nullable: true),
                    conversion_grant_payment_form = table.Column<bool>(type: "bit", nullable: true),
                    conversion_grant_send_information = table.Column<bool>(type: "bit", nullable: true),
                    conversion_grant_share_payment_date = table.Column<bool>(type: "bit", nullable: true),
                    land_questionnaire_received = table.Column<bool>(type: "bit", nullable: true),
                    land_questionnaire_cleared = table.Column<bool>(type: "bit", nullable: true),
                    land_questionnaire_signed = table.Column<bool>(type: "bit", nullable: true),
                    land_questionnaire_saved = table.Column<bool>(type: "bit", nullable: true),
                    land_registry_received = table.Column<bool>(type: "bit", nullable: true),
                    land_registry_cleared = table.Column<bool>(type: "bit", nullable: true),
                    land_registry_saved = table.Column<bool>(type: "bit", nullable: true),
                    supplemental_funding_agreement_received = table.Column<bool>(type: "bit", nullable: true),
                    supplemental_funding_agreement_cleared = table.Column<bool>(type: "bit", nullable: true),
                    supplemental_funding_agreement_signed = table.Column<bool>(type: "bit", nullable: true),
                    supplemental_funding_agreement_saved = table.Column<bool>(type: "bit", nullable: true),
                    supplemental_funding_agreement_sent = table.Column<bool>(type: "bit", nullable: true),
                    supplemental_funding_agreement_signed_secretary_state = table.Column<bool>(type: "bit", nullable: true),
                    church_supplemental_agreement_received = table.Column<bool>(type: "bit", nullable: true),
                    church_supplemental_agreement_cleared = table.Column<bool>(type: "bit", nullable: true),
                    church_supplemental_agreement_signed = table.Column<bool>(type: "bit", nullable: true),
                    church_supplemental_agreement_signed_diocese = table.Column<bool>(type: "bit", nullable: true),
                    church_supplemental_agreement_saved = table.Column<bool>(type: "bit", nullable: true),
                    church_supplemental_agreement_sent = table.Column<bool>(type: "bit", nullable: true),
                    church_supplemental_agreement_signed_secretary_state = table.Column<bool>(type: "bit", nullable: true),
                    master_funding_agreement_received = table.Column<bool>(type: "bit", nullable: true),
                    master_funding_agreement_cleared = table.Column<bool>(type: "bit", nullable: true),
                    master_funding_agreement_signed = table.Column<bool>(type: "bit", nullable: true),
                    master_funding_agreement_saved = table.Column<bool>(type: "bit", nullable: true),
                    master_funding_agreement_sent = table.Column<bool>(type: "bit", nullable: true),
                    master_funding_agreement_signed_secretary_state = table.Column<bool>(type: "bit", nullable: true),
                    articles_of_association_received = table.Column<bool>(type: "bit", nullable: true),
                    articles_of_association_cleared = table.Column<bool>(type: "bit", nullable: true),
                    articles_of_association_signed = table.Column<bool>(type: "bit", nullable: true),
                    articles_of_association_saved = table.Column<bool>(type: "bit", nullable: true),
                    deed_of_variation_received = table.Column<bool>(type: "bit", nullable: true),
                    deed_of_variation_cleared = table.Column<bool>(type: "bit", nullable: true),
                    deed_of_variation_signed = table.Column<bool>(type: "bit", nullable: true),
                    deed_of_variation_saved = table.Column<bool>(type: "bit", nullable: true),
                    deed_of_variation_sent = table.Column<bool>(type: "bit", nullable: true),
                    deed_of_variation_signed_secretary_state = table.Column<bool>(type: "bit", nullable: true),
                    trust_modification_order_received = table.Column<bool>(type: "bit", nullable: true),
                    trust_modification_order_sent_legal = table.Column<bool>(type: "bit", nullable: true),
                    trust_modification_order_cleared = table.Column<bool>(type: "bit", nullable: true),
                    trust_modification_order_saved = table.Column<bool>(type: "bit", nullable: true),
                    direction_to_transfer_received = table.Column<bool>(type: "bit", nullable: true),
                    direction_to_transfer_cleared = table.Column<bool>(type: "bit", nullable: true),
                    direction_to_transfer_signed = table.Column<bool>(type: "bit", nullable: true),
                    direction_to_transfer_saved = table.Column<bool>(type: "bit", nullable: true),
                    single_worksheet_complete = table.Column<bool>(type: "bit", nullable: true),
                    single_worksheet_approve = table.Column<bool>(type: "bit", nullable: true),
                    single_worksheet_send = table.Column<bool>(type: "bit", nullable: true),
                    school_completed_emailed = table.Column<bool>(type: "bit", nullable: true),
                    school_completed_saved = table.Column<bool>(type: "bit", nullable: true),
                    redact_and_send_redact = table.Column<bool>(type: "bit", nullable: true),
                    redact_and_send_save_redaction = table.Column<bool>(type: "bit", nullable: true),
                    redact_and_send_send_redaction = table.Column<bool>(type: "bit", nullable: true),
                    update_esfa_update = table.Column<bool>(type: "bit", nullable: true),
                    receive_grant_payment_certificate_save_certificate = table.Column<bool>(type: "bit", nullable: true),
                    one_hundred_and_twenty_five_year_lease_email = table.Column<bool>(type: "bit", nullable: true),
                    one_hundred_and_twenty_five_year_lease_receive = table.Column<bool>(type: "bit", nullable: true),
                    one_hundred_and_twenty_five_year_lease_save_lease = table.Column<bool>(type: "bit", nullable: true),
                    subleases_received = table.Column<bool>(type: "bit", nullable: true),
                    subleases_cleared = table.Column<bool>(type: "bit", nullable: true),
                    subleases_signed = table.Column<bool>(type: "bit", nullable: true),
                    subleases_saved = table.Column<bool>(type: "bit", nullable: true),
                    subleases_email_signed = table.Column<bool>(type: "bit", nullable: true),
                    subleases_receive_signed = table.Column<bool>(type: "bit", nullable: true),
                    subleases_save_signed = table.Column<bool>(type: "bit", nullable: true),
                    tenancy_at_will_email_signed = table.Column<bool>(type: "bit", nullable: true),
                    tenancy_at_will_receive_signed = table.Column<bool>(type: "bit", nullable: true),
                    tenancy_at_will_save_signed = table.Column<bool>(type: "bit", nullable: true),
                    commercial_transfer_agreement_email_signed = table.Column<bool>(type: "bit", nullable: true),
                    commercial_transfer_agreement_receive_signed = table.Column<bool>(type: "bit", nullable: true),
                    commercial_transfer_agreement_save_signed = table.Column<bool>(type: "bit", nullable: true),
                    share_information_email = table.Column<bool>(type: "bit", nullable: true),
                    redact_and_send_send_solicitors = table.Column<bool>(type: "bit", nullable: true),
                    articles_of_association_not_applicable = table.Column<bool>(type: "bit", nullable: true),
                    church_supplemental_agreement_not_applicable = table.Column<bool>(type: "bit", nullable: true),
                    deed_of_variation_not_applicable = table.Column<bool>(type: "bit", nullable: true),
                    direction_to_transfer_not_applicable = table.Column<bool>(type: "bit", nullable: true),
                    master_funding_agreement_not_applicable = table.Column<bool>(type: "bit", nullable: true),
                    one_hundred_and_twenty_five_year_lease_not_applicable = table.Column<bool>(type: "bit", nullable: true),
                    subleases_not_applicable = table.Column<bool>(type: "bit", nullable: true),
                    tenancy_at_will_not_applicable = table.Column<bool>(type: "bit", nullable: true),
                    trust_modification_order_not_applicable = table.Column<bool>(type: "bit", nullable: true),
                    stakeholder_kick_off_check_provisional_conversion_date = table.Column<bool>(type: "bit", nullable: true),
                    conversion_grant_not_applicable = table.Column<bool>(type: "bit", nullable: true),
                    sponsored_support_grant_payment_amount = table.Column<bool>(type: "bit", nullable: true),
                    sponsored_support_grant_payment_form = table.Column<bool>(type: "bit", nullable: true),
                    sponsored_support_grant_send_information = table.Column<bool>(type: "bit", nullable: true),
                    sponsored_support_grant_inform_trust = table.Column<bool>(type: "bit", nullable: true),
                    sponsored_support_grant_not_applicable = table.Column<bool>(type: "bit", nullable: true),
                    handover_not_applicable = table.Column<bool>(type: "bit", nullable: true),
                    academy_details_name = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    risk_protection_arrangement_option = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    check_accuracy_of_higher_needs_confirm_number = table.Column<bool>(type: "bit", nullable: true),
                    check_accuracy_of_higher_needs_confirm_published_number = table.Column<bool>(type: "bit", nullable: true),
                    complete_notification_of_change_not_applicable = table.Column<bool>(type: "bit", nullable: true),
                    complete_notification_of_change_tell_local_authority = table.Column<bool>(type: "bit", nullable: true),
                    complete_notification_of_change_check_document = table.Column<bool>(type: "bit", nullable: true),
                    complete_notification_of_change_send_document = table.Column<bool>(type: "bit", nullable: true),
                    sponsored_support_grant_type = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    proposed_capacity_of_the_academy_not_applicable = table.Column<bool>(type: "bit", nullable: true),
                    proposed_capacity_of_the_academy_reception_to_six_years = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    proposed_capacity_of_the_academy_seven_to_eleven_years = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    proposed_capacity_of_the_academy_twelve_or_above_years = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    receive_grant_payment_certificate_date_received = table.Column<DateTime>(type: "date", nullable: true),
                    receive_grant_payment_certificate_check_certificate = table.Column<bool>(type: "bit", nullable: true),
                    confirm_date_academy_opened_date_opened = table.Column<DateTime>(type: "date", nullable: true),
                    risk_protection_arrangement_reason = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__conversi__3213E83F5864AE8A", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "events",
                schema: "complete",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    user_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    eventable_type = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    eventable_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    grouping = table.Column<int>(type: "int", nullable: true),
                    message = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2(6)", precision: 6, nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2(6)", precision: 6, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__events__3213E83F15C45895", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "gias_establishments",
                schema: "complete",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    urn = table.Column<int>(type: "int", nullable: true),
                    ukprn = table.Column<int>(type: "int", nullable: true),
                    name = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    establishment_number = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    local_authority_name = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    local_authority_code = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    region_name = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    region_code = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    type_name = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    type_code = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    age_range_lower = table.Column<int>(type: "int", nullable: true),
                    age_range_upper = table.Column<int>(type: "int", nullable: true),
                    phase_name = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    phase_code = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    diocese_name = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    diocese_code = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    parliamentary_constituency_name = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    parliamentary_constituency_code = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    address_street = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    address_locality = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    address_additional = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    address_town = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    address_county = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    address_postcode = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    url = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2(6)", precision: 6, nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2(6)", precision: 6, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__gias_est__3213E83FA2A1F9EF", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "gias_groups",
                schema: "complete",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    ukprn = table.Column<int>(type: "int", nullable: true),
                    unique_group_identifier = table.Column<int>(type: "int", nullable: true),
                    group_identifier = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    original_name = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    companies_house_number = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    address_street = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    address_locality = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    address_additional = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    address_town = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    address_county = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    address_postcode = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2(6)", precision: 6, nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2(6)", precision: 6, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__gias_gro__3213E83F9E44E2E2", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "local_authorities",
                schema: "complete",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    name = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: false),
                    code = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: false),
                    address_1 = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: false),
                    address_2 = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    address_3 = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    address_town = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    address_county = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    address_postcode = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2(6)", precision: 6, nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2(6)", precision: 6, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__local_au__3213E83F2525D5E8", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "schema_migrations",
                schema: "complete",
                columns: table => new
                {
                    version = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__schema_m__79B5C94C4C13779A", x => x.version);
                });

            migrationBuilder.CreateTable(
                name: "significant_date_histories",
                schema: "complete",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    revised_date = table.Column<DateTime>(type: "date", nullable: true),
                    previous_date = table.Column<DateTime>(type: "date", nullable: true),
                    project_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2(6)", precision: 6, nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2(6)", precision: 6, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__signific__3213E83F4D572112", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "transfer_tasks_data",
                schema: "complete",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    created_at = table.Column<DateTime>(type: "datetime2(6)", precision: 6, nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2(6)", precision: 6, nullable: false),
                    handover_review = table.Column<bool>(type: "bit", nullable: true),
                    handover_notes = table.Column<bool>(type: "bit", nullable: true),
                    handover_meeting = table.Column<bool>(type: "bit", nullable: true),
                    handover_not_applicable = table.Column<bool>(type: "bit", nullable: true),
                    stakeholder_kick_off_introductory_emails = table.Column<bool>(type: "bit", nullable: true),
                    stakeholder_kick_off_setup_meeting = table.Column<bool>(type: "bit", nullable: true),
                    stakeholder_kick_off_meeting = table.Column<bool>(type: "bit", nullable: true),
                    master_funding_agreement_received = table.Column<bool>(type: "bit", nullable: true),
                    master_funding_agreement_cleared = table.Column<bool>(type: "bit", nullable: true),
                    master_funding_agreement_signed = table.Column<bool>(type: "bit", nullable: true),
                    master_funding_agreement_saved = table.Column<bool>(type: "bit", nullable: true),
                    master_funding_agreement_signed_secretary_state = table.Column<bool>(type: "bit", nullable: true),
                    master_funding_agreement_not_applicable = table.Column<bool>(type: "bit", nullable: true),
                    deed_of_novation_and_variation_received = table.Column<bool>(type: "bit", nullable: true),
                    deed_of_novation_and_variation_cleared = table.Column<bool>(type: "bit", nullable: true),
                    deed_of_novation_and_variation_signed_outgoing_trust = table.Column<bool>(type: "bit", nullable: true),
                    deed_of_novation_and_variation_signed_incoming_trust = table.Column<bool>(type: "bit", nullable: true),
                    deed_of_novation_and_variation_saved = table.Column<bool>(type: "bit", nullable: true),
                    deed_of_novation_and_variation_signed_secretary_state = table.Column<bool>(type: "bit", nullable: true),
                    deed_of_novation_and_variation_save_after_sign = table.Column<bool>(type: "bit", nullable: true),
                    articles_of_association_received = table.Column<bool>(type: "bit", nullable: true),
                    articles_of_association_cleared = table.Column<bool>(type: "bit", nullable: true),
                    articles_of_association_signed = table.Column<bool>(type: "bit", nullable: true),
                    articles_of_association_saved = table.Column<bool>(type: "bit", nullable: true),
                    articles_of_association_not_applicable = table.Column<bool>(type: "bit", nullable: true),
                    commercial_transfer_agreement_confirm_agreed = table.Column<bool>(type: "bit", nullable: true),
                    commercial_transfer_agreement_confirm_signed = table.Column<bool>(type: "bit", nullable: true),
                    commercial_transfer_agreement_save_confirmation_emails = table.Column<bool>(type: "bit", nullable: true),
                    supplemental_funding_agreement_received = table.Column<bool>(type: "bit", nullable: true),
                    supplemental_funding_agreement_cleared = table.Column<bool>(type: "bit", nullable: true),
                    supplemental_funding_agreement_saved = table.Column<bool>(type: "bit", nullable: true),
                    deed_of_variation_received = table.Column<bool>(type: "bit", nullable: true),
                    deed_of_variation_cleared = table.Column<bool>(type: "bit", nullable: true),
                    deed_of_variation_signed = table.Column<bool>(type: "bit", nullable: true),
                    deed_of_variation_saved = table.Column<bool>(type: "bit", nullable: true),
                    deed_of_variation_sent = table.Column<bool>(type: "bit", nullable: true),
                    deed_of_variation_signed_secretary_state = table.Column<bool>(type: "bit", nullable: true),
                    deed_of_variation_not_applicable = table.Column<bool>(type: "bit", nullable: true),
                    land_consent_letter_drafted = table.Column<bool>(type: "bit", nullable: true),
                    land_consent_letter_signed = table.Column<bool>(type: "bit", nullable: true),
                    land_consent_letter_sent = table.Column<bool>(type: "bit", nullable: true),
                    land_consent_letter_saved = table.Column<bool>(type: "bit", nullable: true),
                    land_consent_letter_not_applicable = table.Column<bool>(type: "bit", nullable: true),
                    rpa_policy_confirm = table.Column<bool>(type: "bit", nullable: true),
                    form_m_received_form_m = table.Column<bool>(type: "bit", nullable: true),
                    form_m_received_title_plans = table.Column<bool>(type: "bit", nullable: true),
                    form_m_cleared = table.Column<bool>(type: "bit", nullable: true),
                    form_m_signed = table.Column<bool>(type: "bit", nullable: true),
                    form_m_saved = table.Column<bool>(type: "bit", nullable: true),
                    church_supplemental_agreement_received = table.Column<bool>(type: "bit", nullable: true),
                    church_supplemental_agreement_cleared = table.Column<bool>(type: "bit", nullable: true),
                    church_supplemental_agreement_signed_incoming_trust = table.Column<bool>(type: "bit", nullable: true),
                    church_supplemental_agreement_signed_diocese = table.Column<bool>(type: "bit", nullable: true),
                    church_supplemental_agreement_saved_after_signing_by_trust_diocese = table.Column<bool>(type: "bit", nullable: true),
                    church_supplemental_agreement_signed_secretary_state = table.Column<bool>(type: "bit", nullable: true),
                    church_supplemental_agreement_saved_after_signing_by_secretary_state = table.Column<bool>(type: "bit", nullable: true),
                    church_supplemental_agreement_not_applicable = table.Column<bool>(type: "bit", nullable: true),
                    deed_of_termination_for_the_master_funding_agreement_received = table.Column<bool>(type: "bit", nullable: true),
                    deed_of_termination_for_the_master_funding_agreement_cleared = table.Column<bool>(type: "bit", nullable: true),
                    deed_of_termination_for_the_master_funding_agreement_signed = table.Column<bool>(type: "bit", nullable: true),
                    deed_of_termination_for_the_master_funding_agreement_saved_academy_and_outgoing_trust_sharepoint = table.Column<bool>(type: "bit", nullable: true),
                    deed_of_termination_for_the_master_funding_agreement_contact_financial_reporting_team = table.Column<bool>(type: "bit", nullable: true),
                    deed_of_termination_for_the_master_funding_agreement_signed_secretary_state = table.Column<bool>(type: "bit", nullable: true),
                    deed_of_termination_for_the_master_funding_agreement_saved_in_academy_sharepoint_folder = table.Column<bool>(type: "bit", nullable: true),
                    deed_of_termination_for_the_master_funding_agreement_not_applicable = table.Column<bool>(type: "bit", nullable: true),
                    deed_termination_church_agreement_received = table.Column<bool>(type: "bit", nullable: true),
                    deed_termination_church_agreement_cleared = table.Column<bool>(type: "bit", nullable: true),
                    deed_termination_church_agreement_signed_outgoing_trust = table.Column<bool>(type: "bit", nullable: true),
                    deed_termination_church_agreement_signed_diocese = table.Column<bool>(type: "bit", nullable: true),
                    deed_termination_church_agreement_saved = table.Column<bool>(type: "bit", nullable: true),
                    deed_termination_church_agreement_signed_secretary_state = table.Column<bool>(type: "bit", nullable: true),
                    deed_termination_church_agreement_saved_after_signing_by_secretary_state = table.Column<bool>(type: "bit", nullable: true),
                    deed_termination_church_agreement_not_applicable = table.Column<bool>(type: "bit", nullable: true),
                    closure_or_transfer_declaration_not_applicable = table.Column<bool>(type: "bit", nullable: true),
                    closure_or_transfer_declaration_received = table.Column<bool>(type: "bit", nullable: true),
                    closure_or_transfer_declaration_cleared = table.Column<bool>(type: "bit", nullable: true),
                    closure_or_transfer_declaration_saved = table.Column<bool>(type: "bit", nullable: true),
                    closure_or_transfer_declaration_sent = table.Column<bool>(type: "bit", nullable: true),
                    confirm_incoming_trust_has_completed_all_actions_emailed = table.Column<bool>(type: "bit", nullable: true),
                    confirm_incoming_trust_has_completed_all_actions_saved = table.Column<bool>(type: "bit", nullable: true),
                    redact_and_send_documents_send_to_esfa = table.Column<bool>(type: "bit", nullable: true),
                    redact_and_send_documents_redact = table.Column<bool>(type: "bit", nullable: true),
                    redact_and_send_documents_saved = table.Column<bool>(type: "bit", nullable: true),
                    redact_and_send_documents_send_to_funding_team = table.Column<bool>(type: "bit", nullable: true),
                    redact_and_send_documents_send_to_solicitors = table.Column<bool>(type: "bit", nullable: true),
                    request_new_urn_and_record_not_applicable = table.Column<bool>(type: "bit", nullable: true),
                    request_new_urn_and_record_complete = table.Column<bool>(type: "bit", nullable: true),
                    request_new_urn_and_record_receive = table.Column<bool>(type: "bit", nullable: true),
                    request_new_urn_and_record_give = table.Column<bool>(type: "bit", nullable: true),
                    inadequate_ofsted = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))"),
                    financial_safeguarding_governance_issues = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))"),
                    outgoing_trust_to_close = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))"),
                    bank_details_changing_yes_no = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))"),
                    check_and_confirm_financial_information_not_applicable = table.Column<bool>(type: "bit", nullable: true),
                    check_and_confirm_financial_information_academy_surplus_deficit = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    check_and_confirm_financial_information_trust_surplus_deficit = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    confirm_date_academy_transferred_date_transferred = table.Column<DateTime>(type: "date", nullable: true),
                    sponsored_support_grant_not_applicable = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))"),
                    sponsored_support_grant_type = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    declaration_of_expenditure_certificate_date_received = table.Column<DateTime>(type: "date", nullable: true),
                    declaration_of_expenditure_certificate_correct = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))"),
                    declaration_of_expenditure_certificate_saved = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))"),
                    declaration_of_expenditure_certificate_not_applicable = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__transfer__3213E83F06874456", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                schema: "complete",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    email = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2(6)", precision: 6, nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2(6)", precision: 6, nullable: false),
                    manage_team = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))"),
                    add_new_project = table.Column<bool>(type: "bit", nullable: false),
                    first_name = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    last_name = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    active_directory_user_id = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    assign_to_project = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))"),
                    manage_user_accounts = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))"),
                    active_directory_user_group_ids = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    team = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    deactivated_at = table.Column<DateTime>(type: "datetime2(6)", precision: 6, nullable: true),
                    manage_conversion_urns = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))"),
                    manage_local_authorities = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))"),
                    latest_session = table.Column<DateTime>(type: "datetime2(6)", precision: 6, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__users__3213E83FDA9FBF89", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "projects",
                schema: "complete",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    urn = table.Column<int>(type: "int", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2(6)", precision: 6, nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2(6)", precision: 6, nullable: false),
                    team_leader_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    incoming_trust_ukprn = table.Column<int>(type: "int", nullable: true),
                    regional_delivery_officer_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    caseworker_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    assigned_at = table.Column<DateTime>(type: "datetime2(6)", precision: 6, nullable: true),
                    advisory_board_date = table.Column<DateTime>(type: "date", nullable: true),
                    advisory_board_conditions = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    establishment_sharepoint_link = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    completed_at = table.Column<DateTime>(type: "datetime2(6)", precision: 6, nullable: true),
                    incoming_trust_sharepoint_link = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    type = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    assigned_to_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    significant_date = table.Column<DateTime>(type: "date", nullable: true),
                    significant_date_provisional = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((1))"),
                    directive_academy_order = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))"),
                    region = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    academy_urn = table.Column<int>(type: "int", nullable: true),
                    tasks_data_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    tasks_data_type = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    funding_agreement_contact_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    outgoing_trust_ukprn = table.Column<int>(type: "int", nullable: true),
                    team = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    two_requires_improvement = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))"),
                    outgoing_trust_sharepoint_link = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    all_conditions_met = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))"),
                    main_contact_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    establishment_main_contact_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    incoming_trust_main_contact_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    outgoing_trust_main_contact_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    new_trust_reference_number = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    new_trust_name = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    chair_of_governors_contact_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    state = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__projects__3213E83F41C861A2", x => x.id);
                    table.ForeignKey(
                        name: "fk_rails_246548228c",
                        column: x => x.caseworker_id,
                        principalSchema: "complete",
                        principalTable: "users",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_rails_990d8727b5",
                        column: x => x.team_leader_id,
                        principalSchema: "complete",
                        principalTable: "users",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_rails_9cf9d80ba9",
                        column: x => x.assigned_to_id,
                        principalSchema: "complete",
                        principalTable: "users",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_rails_bba1c6b145",
                        column: x => x.regional_delivery_officer_id,
                        principalSchema: "complete",
                        principalTable: "users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "contacts",
                schema: "complete",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    project_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    name = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: false),
                    title = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: false),
                    email = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    phone = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2(6)", precision: 6, nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2(6)", precision: 6, nullable: false),
                    category = table.Column<int>(type: "int", nullable: false),
                    organisation_name = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    type = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    local_authority_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    establishment_urn = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__contacts__3213E83FCB461086", x => x.id);
                    table.ForeignKey(
                        name: "fk_rails_b0485f0dbc",
                        column: x => x.project_id,
                        principalSchema: "complete",
                        principalTable: "projects",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "notes",
                schema: "complete",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    body = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    project_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    user_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2(6)", precision: 6, nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2(6)", precision: 6, nullable: false),
                    task_identifier = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    significant_date_history_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__notes__3213E83FA7601CD0", x => x.id);
                    table.ForeignKey(
                        name: "fk_rails_7f2323ad43",
                        column: x => x.user_id,
                        principalSchema: "complete",
                        principalTable: "users",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_rails_99e097b079",
                        column: x => x.project_id,
                        principalSchema: "complete",
                        principalTable: "projects",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_contacts_project_id",
                schema: "complete",
                table: "contacts",
                column: "project_id");

            migrationBuilder.CreateIndex(
                name: "IX_notes_project_id",
                schema: "complete",
                table: "notes",
                column: "project_id");

            migrationBuilder.CreateIndex(
                name: "IX_notes_user_id",
                schema: "complete",
                table: "notes",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_projects_assigned_to_id",
                schema: "complete",
                table: "projects",
                column: "assigned_to_id");

            migrationBuilder.CreateIndex(
                name: "IX_projects_caseworker_id",
                schema: "complete",
                table: "projects",
                column: "caseworker_id");

            migrationBuilder.CreateIndex(
                name: "IX_projects_regional_delivery_officer_id",
                schema: "complete",
                table: "projects",
                column: "regional_delivery_officer_id");

            migrationBuilder.CreateIndex(
                name: "IX_projects_team_leader_id",
                schema: "complete",
                table: "projects",
                column: "team_leader_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ar_internal_metadata",
                schema: "complete");

            migrationBuilder.DropTable(
                name: "contacts",
                schema: "complete");

            migrationBuilder.DropTable(
                name: "conversion_tasks_data",
                schema: "complete");

            migrationBuilder.DropTable(
                name: "events",
                schema: "complete");

            migrationBuilder.DropTable(
                name: "gias_establishments",
                schema: "complete");

            migrationBuilder.DropTable(
                name: "gias_groups",
                schema: "complete");

            migrationBuilder.DropTable(
                name: "local_authorities",
                schema: "complete");

            migrationBuilder.DropTable(
                name: "notes",
                schema: "complete");

            migrationBuilder.DropTable(
                name: "schema_migrations",
                schema: "complete");

            migrationBuilder.DropTable(
                name: "significant_date_histories",
                schema: "complete");

            migrationBuilder.DropTable(
                name: "transfer_tasks_data",
                schema: "complete");

            migrationBuilder.DropTable(
                name: "projects",
                schema: "complete");

            migrationBuilder.DropTable(
                name: "users",
                schema: "complete");
        }
    }
}
