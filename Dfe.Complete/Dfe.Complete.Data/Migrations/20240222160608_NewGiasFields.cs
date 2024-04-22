using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dfe.ManageFreeSchoolProjects.Data.Migrations
{
    /// <inheritdoc />
    public partial class NewGiasFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "FSG Pre Opening Milestones.GIASApplicationFormSent",
                table: "Milestones",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "FSG Pre Opening Milestones.GIASCheckedTrustInformation",
                table: "Milestones",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "FSG Pre Opening Milestones.GIASSavedToWorkspaces",
                table: "Milestones",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "FSG Pre Opening Milestones.GIASURNSent",
                table: "Milestones",
                type: "bit",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FSG Pre Opening Milestones.GIASApplicationFormSent",
                table: "Milestones");

            migrationBuilder.DropColumn(
                name: "FSG Pre Opening Milestones.GIASCheckedTrustInformation",
                table: "Milestones");

            migrationBuilder.DropColumn(
                name: "FSG Pre Opening Milestones.GIASSavedToWorkspaces",
                table: "Milestones");

            migrationBuilder.DropColumn(
                name: "FSG Pre Opening Milestones.GIASURNSent",
                table: "Milestones");
        }
    }
}
