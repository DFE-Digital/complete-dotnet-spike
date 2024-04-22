using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dfe.ManageFreeSchoolProjects.Data.Migrations
{
    /// <inheritdoc />
    public partial class RemoveMAAFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MAACommentsOnDecisionToApprove",
                table: "Milestones");

            migrationBuilder.DropColumn(
                name: "MAASharepointLink",
                table: "Milestones");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MAACommentsOnDecisionToApprove",
                table: "Milestones",
                type: "varchar(999)",
                unicode: false,
                maxLength: 999,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MAASharepointLink",
                table: "Milestones",
                type: "varchar(500)",
                unicode: false,
                maxLength: 500,
                nullable: true);
        }
    }
}
