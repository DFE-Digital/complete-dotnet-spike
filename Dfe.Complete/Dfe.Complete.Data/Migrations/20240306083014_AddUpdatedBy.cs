using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dfe.ManageFreeSchoolProjects.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddUpdatedBy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UpdatedByUserId",
                schema: "mfsp",
                table: "Tasks",
                type: "int",
                nullable: true)
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "TasksHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "mfsp")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart");

            migrationBuilder.AddColumn<int>(
                name: "UpdatedByUserId",
                schema: "mfsp",
                table: "RiskAppraisalMeetingTask",
                type: "int",
                nullable: true)
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "RiskAppraisalMeetingTaskHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "mfsp")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart");

            migrationBuilder.AddColumn<int>(
                name: "UpdatedByUserId",
                schema: "dbo",
                table: "RAG",
                type: "int",
                nullable: true)
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "RAGHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "dbo")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart");

            migrationBuilder.AddColumn<int>(
                name: "UpdatedByUserId",
                schema: "dbo",
                table: "Property",
                type: "int",
                nullable: true)
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "PropertyHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "dbo")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart");

            migrationBuilder.AddColumn<int>(
                name: "UpdatedByUserId",
                schema: "dbo",
                table: "PO",
                type: "int",
                nullable: true)
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "POHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "dbo")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart");

            migrationBuilder.AddColumn<int>(
                name: "UpdatedByUserId",
                schema: "dbo",
                table: "Opens",
                type: "int",
                nullable: true)
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "OpensHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "dbo")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart");

            migrationBuilder.AddColumn<int>(
                name: "UpdatedByUserId",
                schema: "dbo",
                table: "Ofsted_FSG",
                type: "int",
                nullable: true)
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "Ofsted_FSGHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "dbo")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart");

            migrationBuilder.AddColumn<int>(
                name: "UpdatedByUserId",
                schema: "dbo",
                table: "Milestones",
                type: "int",
                nullable: true)
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "MilestonesHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "dbo")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart");

            migrationBuilder.AddColumn<int>(
                name: "UpdatedByUserId",
                schema: "dbo",
                table: "KPI",
                type: "int",
                nullable: true)
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "KPIHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "dbo")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart");

            migrationBuilder.AddColumn<int>(
                name: "UpdatedByUserId",
                schema: "dbo",
                table: "KAI",
                type: "int",
                nullable: true)
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "KAIHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "dbo")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart");

            migrationBuilder.AddColumn<int>(
                name: "UpdatedByUserId",
                schema: "dbo",
                table: "FS_KIM",
                type: "int",
                nullable: true)
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "FS_KIMHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "dbo")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart");

            migrationBuilder.AddColumn<int>(
                name: "UpdatedByUserId",
                schema: "dbo",
                table: "constructData",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UpdatedByUserId",
                schema: "dbo",
                table: "BS",
                type: "int",
                nullable: true)
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "BSHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "dbo")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_UpdatedByUserId",
                schema: "mfsp",
                table: "Tasks",
                column: "UpdatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_RiskAppraisalMeetingTask_UpdatedByUserId",
                schema: "mfsp",
                table: "RiskAppraisalMeetingTask",
                column: "UpdatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_RAG_UpdatedByUserId",
                schema: "dbo",
                table: "RAG",
                column: "UpdatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Property_UpdatedByUserId",
                schema: "dbo",
                table: "Property",
                column: "UpdatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PO_UpdatedByUserId",
                schema: "dbo",
                table: "PO",
                column: "UpdatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Opens_UpdatedByUserId",
                schema: "dbo",
                table: "Opens",
                column: "UpdatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Ofsted_FSG_UpdatedByUserId",
                schema: "dbo",
                table: "Ofsted_FSG",
                column: "UpdatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Milestones_UpdatedByUserId",
                schema: "dbo",
                table: "Milestones",
                column: "UpdatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_KPI_UpdatedByUserId",
                schema: "dbo",
                table: "KPI",
                column: "UpdatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_KAI_UpdatedByUserId",
                schema: "dbo",
                table: "KAI",
                column: "UpdatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_FS_KIM_UpdatedByUserId",
                schema: "dbo",
                table: "FS_KIM",
                column: "UpdatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_constructData_UpdatedByUserId",
                schema: "dbo",
                table: "constructData",
                column: "UpdatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_BS_UpdatedByUserId",
                schema: "dbo",
                table: "BS",
                column: "UpdatedByUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_BS_User_UpdatedByUserId",
                schema: "dbo",
                table: "BS",
                column: "UpdatedByUserId",
                principalSchema: "mfsp",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_constructData_User_UpdatedByUserId",
                schema: "dbo",
                table: "constructData",
                column: "UpdatedByUserId",
                principalSchema: "mfsp",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FS_KIM_User_UpdatedByUserId",
                schema: "dbo",
                table: "FS_KIM",
                column: "UpdatedByUserId",
                principalSchema: "mfsp",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_KAI_User_UpdatedByUserId",
                schema: "dbo",
                table: "KAI",
                column: "UpdatedByUserId",
                principalSchema: "mfsp",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_KPI_User_UpdatedByUserId",
                schema: "dbo",
                table: "KPI",
                column: "UpdatedByUserId",
                principalSchema: "mfsp",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Milestones_User_UpdatedByUserId",
                schema: "dbo",
                table: "Milestones",
                column: "UpdatedByUserId",
                principalSchema: "mfsp",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ofsted_FSG_User_UpdatedByUserId",
                schema: "dbo",
                table: "Ofsted_FSG",
                column: "UpdatedByUserId",
                principalSchema: "mfsp",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Opens_User_UpdatedByUserId",
                schema: "dbo",
                table: "Opens",
                column: "UpdatedByUserId",
                principalSchema: "mfsp",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PO_User_UpdatedByUserId",
                schema: "dbo",
                table: "PO",
                column: "UpdatedByUserId",
                principalSchema: "mfsp",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Property_User_UpdatedByUserId",
                schema: "dbo",
                table: "Property",
                column: "UpdatedByUserId",
                principalSchema: "mfsp",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RAG_User_UpdatedByUserId",
                schema: "dbo",
                table: "RAG",
                column: "UpdatedByUserId",
                principalSchema: "mfsp",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RiskAppraisalMeetingTask_User_UpdatedByUserId",
                schema: "mfsp",
                table: "RiskAppraisalMeetingTask",
                column: "UpdatedByUserId",
                principalSchema: "mfsp",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_User_UpdatedByUserId",
                schema: "mfsp",
                table: "Tasks",
                column: "UpdatedByUserId",
                principalSchema: "mfsp",
                principalTable: "User",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BS_User_UpdatedByUserId",
                schema: "dbo",
                table: "BS");

            migrationBuilder.DropForeignKey(
                name: "FK_constructData_User_UpdatedByUserId",
                schema: "dbo",
                table: "constructData");

            migrationBuilder.DropForeignKey(
                name: "FK_FS_KIM_User_UpdatedByUserId",
                schema: "dbo",
                table: "FS_KIM");

            migrationBuilder.DropForeignKey(
                name: "FK_KAI_User_UpdatedByUserId",
                schema: "dbo",
                table: "KAI");

            migrationBuilder.DropForeignKey(
                name: "FK_KPI_User_UpdatedByUserId",
                schema: "dbo",
                table: "KPI");

            migrationBuilder.DropForeignKey(
                name: "FK_Milestones_User_UpdatedByUserId",
                schema: "dbo",
                table: "Milestones");

            migrationBuilder.DropForeignKey(
                name: "FK_Ofsted_FSG_User_UpdatedByUserId",
                schema: "dbo",
                table: "Ofsted_FSG");

            migrationBuilder.DropForeignKey(
                name: "FK_Opens_User_UpdatedByUserId",
                schema: "dbo",
                table: "Opens");

            migrationBuilder.DropForeignKey(
                name: "FK_PO_User_UpdatedByUserId",
                schema: "dbo",
                table: "PO");

            migrationBuilder.DropForeignKey(
                name: "FK_Property_User_UpdatedByUserId",
                schema: "dbo",
                table: "Property");

            migrationBuilder.DropForeignKey(
                name: "FK_RAG_User_UpdatedByUserId",
                schema: "dbo",
                table: "RAG");

            migrationBuilder.DropForeignKey(
                name: "FK_RiskAppraisalMeetingTask_User_UpdatedByUserId",
                schema: "mfsp",
                table: "RiskAppraisalMeetingTask");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_User_UpdatedByUserId",
                schema: "mfsp",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_UpdatedByUserId",
                schema: "mfsp",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_RiskAppraisalMeetingTask_UpdatedByUserId",
                schema: "mfsp",
                table: "RiskAppraisalMeetingTask");

            migrationBuilder.DropIndex(
                name: "IX_RAG_UpdatedByUserId",
                schema: "dbo",
                table: "RAG");

            migrationBuilder.DropIndex(
                name: "IX_Property_UpdatedByUserId",
                schema: "dbo",
                table: "Property");

            migrationBuilder.DropIndex(
                name: "IX_PO_UpdatedByUserId",
                schema: "dbo",
                table: "PO");

            migrationBuilder.DropIndex(
                name: "IX_Opens_UpdatedByUserId",
                schema: "dbo",
                table: "Opens");

            migrationBuilder.DropIndex(
                name: "IX_Ofsted_FSG_UpdatedByUserId",
                schema: "dbo",
                table: "Ofsted_FSG");

            migrationBuilder.DropIndex(
                name: "IX_Milestones_UpdatedByUserId",
                schema: "dbo",
                table: "Milestones");

            migrationBuilder.DropIndex(
                name: "IX_KPI_UpdatedByUserId",
                schema: "dbo",
                table: "KPI");

            migrationBuilder.DropIndex(
                name: "IX_KAI_UpdatedByUserId",
                schema: "dbo",
                table: "KAI");

            migrationBuilder.DropIndex(
                name: "IX_FS_KIM_UpdatedByUserId",
                schema: "dbo",
                table: "FS_KIM");

            migrationBuilder.DropIndex(
                name: "IX_constructData_UpdatedByUserId",
                schema: "dbo",
                table: "constructData");

            migrationBuilder.DropIndex(
                name: "IX_BS_UpdatedByUserId",
                schema: "dbo",
                table: "BS");

            migrationBuilder.DropColumn(
                name: "UpdatedByUserId",
                schema: "mfsp",
                table: "Tasks")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "TasksHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "mfsp")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart");

            migrationBuilder.DropColumn(
                name: "UpdatedByUserId",
                schema: "mfsp",
                table: "RiskAppraisalMeetingTask")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "RiskAppraisalMeetingTaskHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "mfsp")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart");

            migrationBuilder.DropColumn(
                name: "UpdatedByUserId",
                schema: "dbo",
                table: "RAG")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "RAGHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "dbo")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart");

            migrationBuilder.DropColumn(
                name: "UpdatedByUserId",
                schema: "dbo",
                table: "Property")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "PropertyHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "dbo")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart");

            migrationBuilder.DropColumn(
                name: "UpdatedByUserId",
                schema: "dbo",
                table: "PO")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "POHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "dbo")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart");

            migrationBuilder.DropColumn(
                name: "UpdatedByUserId",
                schema: "dbo",
                table: "Opens")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "OpensHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "dbo")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart");

            migrationBuilder.DropColumn(
                name: "UpdatedByUserId",
                schema: "dbo",
                table: "Ofsted_FSG")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "Ofsted_FSGHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "dbo")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart");

            migrationBuilder.DropColumn(
                name: "UpdatedByUserId",
                schema: "dbo",
                table: "Milestones")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "MilestonesHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "dbo")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart");

            migrationBuilder.DropColumn(
                name: "UpdatedByUserId",
                schema: "dbo",
                table: "KPI")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "KPIHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "dbo")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart");

            migrationBuilder.DropColumn(
                name: "UpdatedByUserId",
                schema: "dbo",
                table: "KAI")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "KAIHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "dbo")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart");

            migrationBuilder.DropColumn(
                name: "UpdatedByUserId",
                schema: "dbo",
                table: "FS_KIM")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "FS_KIMHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "dbo")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart");

            migrationBuilder.DropColumn(
                name: "UpdatedByUserId",
                schema: "dbo",
                table: "constructData");

            migrationBuilder.DropColumn(
                name: "UpdatedByUserId",
                schema: "dbo",
                table: "BS")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "BSHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "dbo")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart");
        }
    }
}
