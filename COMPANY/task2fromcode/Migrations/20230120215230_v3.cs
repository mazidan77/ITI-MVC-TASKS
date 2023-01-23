using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace task2fromcode.Migrations
{
    /// <inheritdoc />
    public partial class v3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorksFor_Projects_ProjectPnumber",
                table: "WorksFor");

            migrationBuilder.DropForeignKey(
                name: "FK_WorksFor_employees_superid",
                table: "WorksFor");

            migrationBuilder.DropIndex(
                name: "IX_WorksFor_ProjectPnumber",
                table: "WorksFor");

            migrationBuilder.DropIndex(
                name: "IX_WorksFor_superid",
                table: "WorksFor");

            migrationBuilder.DropColumn(
                name: "ProjectPnumber",
                table: "WorksFor");

            migrationBuilder.DropColumn(
                name: "superid",
                table: "WorksFor");

            migrationBuilder.CreateIndex(
                name: "IX_WorksFor_Pnum",
                table: "WorksFor",
                column: "Pnum");

            migrationBuilder.AddForeignKey(
                name: "FK_WorksFor_Projects_Pnum",
                table: "WorksFor",
                column: "Pnum",
                principalTable: "Projects",
                principalColumn: "Pnumber",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorksFor_employees_ESSN",
                table: "WorksFor",
                column: "ESSN",
                principalTable: "employees",
                principalColumn: "SSN",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorksFor_Projects_Pnum",
                table: "WorksFor");

            migrationBuilder.DropForeignKey(
                name: "FK_WorksFor_employees_ESSN",
                table: "WorksFor");

            migrationBuilder.DropIndex(
                name: "IX_WorksFor_Pnum",
                table: "WorksFor");

            migrationBuilder.AddColumn<int>(
                name: "ProjectPnumber",
                table: "WorksFor",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "superid",
                table: "WorksFor",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_WorksFor_ProjectPnumber",
                table: "WorksFor",
                column: "ProjectPnumber");

            migrationBuilder.CreateIndex(
                name: "IX_WorksFor_superid",
                table: "WorksFor",
                column: "superid");

            migrationBuilder.AddForeignKey(
                name: "FK_WorksFor_Projects_ProjectPnumber",
                table: "WorksFor",
                column: "ProjectPnumber",
                principalTable: "Projects",
                principalColumn: "Pnumber",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorksFor_employees_superid",
                table: "WorksFor",
                column: "superid",
                principalTable: "employees",
                principalColumn: "SSN");
        }
    }
}
