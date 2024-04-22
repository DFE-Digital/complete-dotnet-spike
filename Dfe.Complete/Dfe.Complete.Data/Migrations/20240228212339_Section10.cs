using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dfe.ManageFreeSchoolProjects.Data.Migrations
{
    /// <inheritdoc />
    public partial class Section10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "FsgPreOpeningMilestonesScrFulfilsSection10StatutoryDuty",
                table: "Milestones",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "FsgPreOpeningMilestonesScrReceived",
                table: "Milestones",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "FsgPreOpeningMilestonesScrSavedFindingsInWorkplacesFolder",
                table: "Milestones",
                type: "bit",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FsgPreOpeningMilestonesScrFulfilsSection10StatutoryDuty",
                table: "Milestones");

            migrationBuilder.DropColumn(
                name: "FsgPreOpeningMilestonesScrReceived",
                table: "Milestones");

            migrationBuilder.DropColumn(
                name: "FsgPreOpeningMilestonesScrSavedFindingsInWorkplacesFolder",
                table: "Milestones");
        }
    }
}
