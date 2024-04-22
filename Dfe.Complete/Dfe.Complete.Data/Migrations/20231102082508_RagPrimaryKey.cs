using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dfe.ManageFreeSchoolProjects.Data.Migrations
{
    /// <inheritdoc />
    public partial class RagPrimaryKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "RID",
                schema: "dbo",
                table: "RAG",
                type: "varchar(11)",
                unicode: false,
                maxLength: 11,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(11)",
                oldUnicode: false,
                oldMaxLength: 11,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_RAG",
                schema: "dbo",
                table: "RAG",
                column: "RID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_RAG",
                schema: "dbo",
                table: "RAG");

            migrationBuilder.AlterColumn<string>(
                name: "RID",
                schema: "dbo",
                table: "RAG",
                type: "varchar(11)",
                unicode: false,
                maxLength: 11,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(11)",
                oldUnicode: false,
                oldMaxLength: 11);
        }
    }
}
