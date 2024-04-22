using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dfe.ManageFreeSchoolProjects.Data.Migrations
{
    /// <inheritdoc />
    public partial class NewFieldsForMfad : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "FsgPreOpeningMilestonesMfadDraftedFaHealthCheck",
                table: "Milestones",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "FsgPreOpeningMilestonesMfadSavedFaDocumentsInWorkspacesFolder",
                table: "Milestones",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "FsgPreOpeningMilestonesMfadSharedFaWithTheTrust",
                table: "Milestones",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "FsgPreOpeningMilestonesMfadTayloredAModelFundingAgreement",
                table: "Milestones",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FsgPreOpeningMilestonesMfadTrustAgreesWithModelFa",
                table: "Milestones",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FsgPreOpeningMilestonesMfadDraftedFaHealthCheck",
                table: "Milestones");

            migrationBuilder.DropColumn(
                name: "FsgPreOpeningMilestonesMfadSavedFaDocumentsInWorkspacesFolder",
                table: "Milestones");

            migrationBuilder.DropColumn(
                name: "FsgPreOpeningMilestonesMfadSharedFaWithTheTrust",
                table: "Milestones");

            migrationBuilder.DropColumn(
                name: "FsgPreOpeningMilestonesMfadTayloredAModelFundingAgreement",
                table: "Milestones");

            migrationBuilder.DropColumn(
                name: "FsgPreOpeningMilestonesMfadTrustAgreesWithModelFa",
                table: "Milestones");
        }
    }
}
