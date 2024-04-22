using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dfe.ManageFreeSchoolProjects.Data.Migrations
{
    /// <inheritdoc />
    public partial class UserOneToManyProjects : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserProject",
                schema: "mfsp");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "KPI",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_KPI_UserId",
                table: "KPI",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_KPI_User_UserId",
                table: "KPI",
                column: "UserId",
                principalSchema: "mfsp",
                principalTable: "User",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KPI_User_UserId",
                table: "KPI");

            migrationBuilder.DropIndex(
                name: "IX_KPI_UserId",
                table: "KPI");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "KPI");

            migrationBuilder.CreateTable(
                name: "UserProject",
                schema: "mfsp",
                columns: table => new
                {
                    Rid = table.Column<string>(type: "varchar(11)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProject", x => new { x.Rid, x.UserId });
                    table.ForeignKey(
                        name: "FK_UserProject_KPI_Rid",
                        column: x => x.Rid,
                        principalTable: "KPI",
                        principalColumn: "RID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserProject_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "mfsp",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserProject_UserId",
                schema: "mfsp",
                table: "UserProject",
                column: "UserId");
        }
    }
}
