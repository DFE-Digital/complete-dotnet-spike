using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dfe.ManageFreeSchoolProjects.Data.Migrations
{
    /// <inheritdoc />
    public partial class sharepointFieldRemovedFromMilestones : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FSG Pre Opening Milestones. Sharepoint Link",
                table: "Milestones");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FSG Pre Opening Milestones. Sharepoint Link",
                table: "Milestones",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);
        }
    }
}
