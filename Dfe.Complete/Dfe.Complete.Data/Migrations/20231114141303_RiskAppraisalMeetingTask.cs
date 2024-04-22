using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dfe.ManageFreeSchoolProjects.Data.Migrations
{
    /// <inheritdoc />
    public partial class RiskAppraisalMeetingTask : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RiskAppraisalMeetingTask",
                schema: "mfsp",
                columns: table => new
                {
                    RID = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "RiskAppraisalMeetingTaskHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", "mfsp")
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart"),
                    MeetingCompleted = table.Column<bool>(type: "bit", nullable: true)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "RiskAppraisalMeetingTaskHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", "mfsp")
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart"),
                    ForecastDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "RiskAppraisalMeetingTaskHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", "mfsp")
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart"),
                    ActualDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "RiskAppraisalMeetingTaskHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", "mfsp")
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart"),
                    CommentOnDecision = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "RiskAppraisalMeetingTaskHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", "mfsp")
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart"),
                    ReasonNotApplicable = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "RiskAppraisalMeetingTaskHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", "mfsp")
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart"),
                    PeriodEnd = table.Column<DateTime>(type: "datetime2", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "RiskAppraisalMeetingTaskHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", "mfsp")
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart"),
                    PeriodStart = table.Column<DateTime>(type: "datetime2", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "RiskAppraisalMeetingTaskHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", "mfsp")
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RiskAppraisalMeetingTask", x => x.RID);
                })
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "RiskAppraisalMeetingTaskHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "mfsp")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RiskAppraisalMeetingTask",
                schema: "mfsp")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "RiskAppraisalMeetingTaskHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "mfsp")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart");
        }
    }
}
