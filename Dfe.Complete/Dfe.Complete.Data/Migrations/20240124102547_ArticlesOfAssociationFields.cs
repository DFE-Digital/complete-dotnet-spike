using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dfe.ManageFreeSchoolProjects.Data.Migrations
{
    /// <inheritdoc />
    public partial class ArticlesOfAssociationFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "MAAArrangementsMatchGovernancePlans",
                table: "Milestones",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "MAAChairHaveSubmittedConfirmation",
                table: "Milestones",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "MAACheckedSubmittedArticlesMatch",
                table: "Milestones",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "MAACommentsOnDecisionToApprove",
                table: "Milestones",
                type: "varchar(100)",
                unicode: false,
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MAASharepointLink",
                table: "Milestones",
                type: "varchar(100)",
                unicode: false,
                maxLength: 100,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MAAArrangementsMatchGovernancePlans",
                table: "Milestones");

            migrationBuilder.DropColumn(
                name: "MAAChairHaveSubmittedConfirmation",
                table: "Milestones");

            migrationBuilder.DropColumn(
                name: "MAACheckedSubmittedArticlesMatch",
                table: "Milestones");

            migrationBuilder.DropColumn(
                name: "MAACommentsOnDecisionToApprove",
                table: "Milestones");

            migrationBuilder.DropColumn(
                name: "MAASharepointLink",
                table: "Milestones");
        }
    }
}
