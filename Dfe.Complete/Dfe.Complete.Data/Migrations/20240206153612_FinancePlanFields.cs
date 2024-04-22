using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dfe.ManageFreeSchoolProjects.Data.Migrations
{
    /// <inheritdoc />
    public partial class FinancePlanFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IsPlanSavedInWorkplacesFolder",
                table: "Milestones",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LAAgreedPupilNumbers",
                table: "Milestones",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RPACoverType",
                table: "Milestones",
                type: "varchar(100)",
                unicode: false,
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RPAStartDate",
                table: "Milestones",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TrustOptInRPA",
                table: "Milestones",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPlanSavedInWorkplacesFolder",
                table: "Milestones");

            migrationBuilder.DropColumn(
                name: "LAAgreedPupilNumbers",
                table: "Milestones");

            migrationBuilder.DropColumn(
                name: "RPACoverType",
                table: "Milestones");

            migrationBuilder.DropColumn(
                name: "RPAStartDate",
                table: "Milestones");

            migrationBuilder.DropColumn(
                name: "TrustOptInRPA",
                table: "Milestones");
        }
    }
}
