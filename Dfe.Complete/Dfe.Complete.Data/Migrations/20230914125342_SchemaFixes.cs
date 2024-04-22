using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dfe.ManageFreeSchoolProjects.Data.Migrations
{
    /// <inheritdoc />
    public partial class SchemaFixes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.RenameTable(
                name: "WFA",
                newName: "WFA",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Term_Visits_UTCs",
                newName: "Term_Visits_UTCs",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Term_Visits",
                newName: "Term_Visits",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Technical_QA",
                newName: "Technical_QA",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Report_Server_Url",
                newName: "Report_Server_Url",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Regional Framework",
                newName: "Regional Framework",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "RAGTEMP_RATINGS",
                newName: "RAGTEMP_RATINGS",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "RAGTEMP_BUDGET",
                newName: "RAGTEMP_BUDGET",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "RAG",
                newName: "RAG",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Property_QA",
                newName: "Property_QA",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "PR",
                newName: "PR",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "PORF",
                newName: "PORF",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "PO",
                newName: "PO",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Planning_QA",
                newName: "Planning_QA",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Perf_FSG_Local",
                newName: "Perf_FSG_Local",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Perf_FSG",
                newName: "Perf_FSG",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "PDGL",
                newName: "PDGL",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "PDFD_Archive",
                newName: "PDFD_Archive",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "PDFD",
                newName: "PDFD",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Ofsted_FSG",
                newName: "Ofsted_FSG",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Ofsted_Archive",
                newName: "Ofsted_Archive",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "LA_Data",
                newName: "LA_Data",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "KPI",
                newName: "KPI",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "KAI",
                newName: "KAI",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "FS_KIM",
                newName: "FS_KIM",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "FAL",
                newName: "FAL",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "constructData",
                newName: "constructData",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "BS",
                newName: "BS",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "BR",
                newName: "BR",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Basic_Need",
                newName: "Basic_Need",
                newSchema: "dbo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "WFA",
                schema: "dbo",
                newName: "WFA");

            migrationBuilder.RenameTable(
                name: "Term_Visits_UTCs",
                schema: "dbo",
                newName: "Term_Visits_UTCs");

            migrationBuilder.RenameTable(
                name: "Term_Visits",
                schema: "dbo",
                newName: "Term_Visits");

            migrationBuilder.RenameTable(
                name: "Technical_QA",
                schema: "dbo",
                newName: "Technical_QA");

            migrationBuilder.RenameTable(
                name: "Report_Server_Url",
                schema: "dbo",
                newName: "Report_Server_Url");

            migrationBuilder.RenameTable(
                name: "Regional Framework",
                schema: "dbo",
                newName: "Regional Framework");

            migrationBuilder.RenameTable(
                name: "RAGTEMP_RATINGS",
                schema: "dbo",
                newName: "RAGTEMP_RATINGS");

            migrationBuilder.RenameTable(
                name: "RAGTEMP_BUDGET",
                schema: "dbo",
                newName: "RAGTEMP_BUDGET");

            migrationBuilder.RenameTable(
                name: "RAG",
                schema: "dbo",
                newName: "RAG");

            migrationBuilder.RenameTable(
                name: "Property_QA",
                schema: "dbo",
                newName: "Property_QA");

            migrationBuilder.RenameTable(
                name: "PR",
                schema: "dbo",
                newName: "PR");

            migrationBuilder.RenameTable(
                name: "PORF",
                schema: "dbo",
                newName: "PORF");

            migrationBuilder.RenameTable(
                name: "PO",
                schema: "dbo",
                newName: "PO");

            migrationBuilder.RenameTable(
                name: "Planning_QA",
                schema: "dbo",
                newName: "Planning_QA");

            migrationBuilder.RenameTable(
                name: "Perf_FSG_Local",
                schema: "dbo",
                newName: "Perf_FSG_Local");

            migrationBuilder.RenameTable(
                name: "Perf_FSG",
                schema: "dbo",
                newName: "Perf_FSG");

            migrationBuilder.RenameTable(
                name: "PDGL",
                schema: "dbo",
                newName: "PDGL");

            migrationBuilder.RenameTable(
                name: "PDFD_Archive",
                schema: "dbo",
                newName: "PDFD_Archive");

            migrationBuilder.RenameTable(
                name: "PDFD",
                schema: "dbo",
                newName: "PDFD");

            migrationBuilder.RenameTable(
                name: "Ofsted_FSG",
                schema: "dbo",
                newName: "Ofsted_FSG");

            migrationBuilder.RenameTable(
                name: "Ofsted_Archive",
                schema: "dbo",
                newName: "Ofsted_Archive");

            migrationBuilder.RenameTable(
                name: "LA_Data",
                schema: "dbo",
                newName: "LA_Data");

            migrationBuilder.RenameTable(
                name: "KPI",
                schema: "dbo",
                newName: "KPI");

            migrationBuilder.RenameTable(
                name: "KAI",
                schema: "dbo",
                newName: "KAI");

            migrationBuilder.RenameTable(
                name: "FS_KIM",
                schema: "dbo",
                newName: "FS_KIM");

            migrationBuilder.RenameTable(
                name: "FAL",
                schema: "dbo",
                newName: "FAL");

            migrationBuilder.RenameTable(
                name: "constructData",
                schema: "dbo",
                newName: "constructData");

            migrationBuilder.RenameTable(
                name: "BS",
                schema: "dbo",
                newName: "BS");

            migrationBuilder.RenameTable(
                name: "BR",
                schema: "dbo",
                newName: "BR");

            migrationBuilder.RenameTable(
                name: "Basic_Need",
                schema: "dbo",
                newName: "Basic_Need");
        }
    }
}
