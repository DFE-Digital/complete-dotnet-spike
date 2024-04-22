using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dfe.ManageFreeSchoolProjects.Data.Migrations
{
    /// <inheritdoc />
    public partial class GenerateMigrationRenameTaylor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FsgPreOpeningMilestonesMfadTayloredAModelFundingAgreement",
                table: "Milestones",
                newName: "FsgPreOpeningMilestonesMfadTailoredAModelFundingAgreement");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FsgPreOpeningMilestonesMfadTailoredAModelFundingAgreement",
                table: "Milestones",
                newName: "FsgPreOpeningMilestonesMfadTayloredAModelFundingAgreement");
        }
    }
}
