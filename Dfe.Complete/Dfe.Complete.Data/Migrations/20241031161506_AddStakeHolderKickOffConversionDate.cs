using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dfe.Complete.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddStakeHolderKickOffConversionDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "stakeholder_kick_off_conversion_date",
                schema: "complete",
                table: "conversion_tasks_data",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "stakeholder_kick_off_conversion_date",
                schema: "complete",
                table: "conversion_tasks_data");
        }
    }
}
