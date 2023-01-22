using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace task2fromcode.Migrations
{
    /// <inheritdoc />
    public partial class v11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "workid",
                table: "employees",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "manageid",
                table: "Departments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_employees_workid",
                table: "employees",
                column: "workid");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_manageid",
                table: "Departments",
                column: "manageid",
                unique: true,
                filter: "[manageid] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_employees_manageid",
                table: "Departments",
                column: "manageid",
                principalTable: "employees",
                principalColumn: "SSN");

            migrationBuilder.AddForeignKey(
                name: "FK_employees_Departments_workid",
                table: "employees",
                column: "workid",
                principalTable: "Departments",
                principalColumn: "Dnum");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departments_employees_manageid",
                table: "Departments");

            migrationBuilder.DropForeignKey(
                name: "FK_employees_Departments_workid",
                table: "employees");

            migrationBuilder.DropIndex(
                name: "IX_employees_workid",
                table: "employees");

            migrationBuilder.DropIndex(
                name: "IX_Departments_manageid",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "workid",
                table: "employees");

            migrationBuilder.DropColumn(
                name: "manageid",
                table: "Departments");
        }
    }
}
