using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dfe.ManageFreeSchoolProjects.Data.Migrations
{
    /// <inheritdoc />
    public partial class NewDraftGovernancePlanFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsPlanSavedInWorkplacesFolder",
                table: "Milestones",
                newName: "FinancePlanSavedInWorkplacesFolder");

            migrationBuilder.AddColumn<bool>(
                name: "DraftGovernancePlanAndAssessmentSharedWithEsfa",
                table: "Milestones",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "DraftGovernancePlanAndAssessmentSharedWithExpert",
                table: "Milestones",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "DraftGovernancePlanAssessedUsingTemplate",
                table: "Milestones",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "DraftGovernancePlanDocumentsSavedInWorkplacesFolder",
                table: "Milestones",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "DraftGovernancePlanFedBackToTrust",
                table: "Milestones",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DraftGovernancePlanReceivedDate",
                table: "Milestones",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "DraftGovernancePlanReceivedFromTrust",
                table: "Milestones",
                type: "bit",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DraftGovernancePlanAndAssessmentSharedWithEsfa",
                table: "Milestones");

            migrationBuilder.DropColumn(
                name: "DraftGovernancePlanAndAssessmentSharedWithExpert",
                table: "Milestones");

            migrationBuilder.DropColumn(
                name: "DraftGovernancePlanAssessedUsingTemplate",
                table: "Milestones");

            migrationBuilder.DropColumn(
                name: "DraftGovernancePlanDocumentsSavedInWorkplacesFolder",
                table: "Milestones");

            migrationBuilder.DropColumn(
                name: "DraftGovernancePlanFedBackToTrust",
                table: "Milestones");

            migrationBuilder.DropColumn(
                name: "DraftGovernancePlanReceivedDate",
                table: "Milestones");

            migrationBuilder.DropColumn(
                name: "DraftGovernancePlanReceivedFromTrust",
                table: "Milestones");

            migrationBuilder.RenameColumn(
                name: "FinancePlanSavedInWorkplacesFolder",
                table: "Milestones",
                newName: "IsPlanSavedInWorkplacesFolder");
        }
    }
}
