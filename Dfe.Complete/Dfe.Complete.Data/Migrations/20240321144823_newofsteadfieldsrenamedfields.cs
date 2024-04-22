using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dfe.ManageFreeSchoolProjects.Data.Migrations
{
    /// <inheritdoc />
    public partial class newofsteadfieldsrenamedfields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Fsg Pre Opening Milestones.Ofsted And Trust Liaison Details Confirmed",
                schema: "dbo",
                table: "Milestones",
                newName: "Fsg Pre Opening Milestones. Ofsted And Trust Liaison Details Confirmed")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "MilestonesHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "dbo")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart");

            migrationBuilder.RenameColumn(
                name: "Fsg Pre Opening Milestones. Milestones Shared Outcome With Trust",
                schema: "dbo",
                table: "Milestones",
                newName: "Fsg Pre Opening Milestones. Shared Outcome With Trust")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "MilestonesHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "dbo")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart");

            migrationBuilder.RenameColumn(
                name: "Fsg Pre Opening Milestones. Milestones Proposed To Open On Gias",
                schema: "dbo",
                table: "Milestones",
                newName: "Fsg Pre Opening Milestones. Proposed To Open On Gias")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "MilestonesHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "dbo")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart");

            migrationBuilder.RenameColumn(
                name: "Fsg Pre Opening Milestones. Milestones Process Details Provided",
                schema: "dbo",
                table: "Milestones",
                newName: "Fsg Pre Opening Milestones. Process Details Provided")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "MilestonesHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "dbo")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart");

            migrationBuilder.RenameColumn(
                name: "Fsg Pre Opening Milestones. Milestones Inspection Block Decided",
                schema: "dbo",
                table: "Milestones",
                newName: "Fsg Pre Opening Milestones. Inspection Block Decided")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "MilestonesHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "dbo")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart");

            migrationBuilder.RenameColumn(
                name: "Fsg Pre Opening Milestones. Milestones Documents And G6 Saved To Workspaces",
                schema: "dbo",
                table: "Milestones",
                newName: "Fsg Pre Opening Milestones. Documents And G6 Saved To Workplaces")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "MilestonesHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "dbo")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Fsg Pre Opening Milestones. Shared Outcome With Trust",
                schema: "dbo",
                table: "Milestones",
                newName: "Fsg Pre Opening Milestones. Milestones Shared Outcome With Trust")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "MilestonesHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "dbo")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart");

            migrationBuilder.RenameColumn(
                name: "Fsg Pre Opening Milestones. Proposed To Open On Gias",
                schema: "dbo",
                table: "Milestones",
                newName: "Fsg Pre Opening Milestones. Milestones Proposed To Open On Gias")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "MilestonesHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "dbo")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart");

            migrationBuilder.RenameColumn(
                name: "Fsg Pre Opening Milestones. Process Details Provided",
                schema: "dbo",
                table: "Milestones",
                newName: "Fsg Pre Opening Milestones. Milestones Process Details Provided")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "MilestonesHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "dbo")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart");

            migrationBuilder.RenameColumn(
                name: "Fsg Pre Opening Milestones. Ofsted And Trust Liaison Details Confirmed",
                schema: "dbo",
                table: "Milestones",
                newName: "Fsg Pre Opening Milestones.Ofsted And Trust Liaison Details Confirmed")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "MilestonesHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "dbo")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart");

            migrationBuilder.RenameColumn(
                name: "Fsg Pre Opening Milestones. Inspection Block Decided",
                schema: "dbo",
                table: "Milestones",
                newName: "Fsg Pre Opening Milestones. Milestones Inspection Block Decided")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "MilestonesHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "dbo")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart");

            migrationBuilder.RenameColumn(
                name: "Fsg Pre Opening Milestones. Documents And G6 Saved To Workplaces",
                schema: "dbo",
                table: "Milestones",
                newName: "Fsg Pre Opening Milestones. Milestones Documents And G6 Saved To Workspaces")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "MilestonesHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "dbo")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart");
        }
    }
}
