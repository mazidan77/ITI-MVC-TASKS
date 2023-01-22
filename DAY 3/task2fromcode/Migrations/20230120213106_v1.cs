using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace task2fromcode.Migrations
{
    /// <inheritdoc />
    public partial class v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Dnum = table.Column<int>(type: "int", nullable: false),
                    DName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Dnum);
                });

            migrationBuilder.CreateTable(
                name: "employees",
                columns: table => new
                {
                    SSN = table.Column<int>(type: "int", nullable: false),
                    Fname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Mname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Lname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    sex = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    salary = table.Column<int>(type: "int", nullable: true),
                    Bdate = table.Column<DateTime>(type: "date", nullable: true),
                    superid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employees", x => x.SSN);
                    table.ForeignKey(
                        name: "FK_employees_employees_superid",
                        column: x => x.superid,
                        principalTable: "employees",
                        principalColumn: "SSN");
                });

            migrationBuilder.CreateTable(
                name: "DLocations",
                columns: table => new
                {
                    Dlocation = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Dnum = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DLocations", x => new { x.Dlocation, x.Dnum });
                    table.ForeignKey(
                        name: "FK_DLocations_Departments_Dnum",
                        column: x => x.Dnum,
                        principalTable: "Departments",
                        principalColumn: "Dnum",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Pnumber = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DepartmentDnum = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Pnumber);
                    table.ForeignKey(
                        name: "FK_Projects_Departments_DepartmentDnum",
                        column: x => x.DepartmentDnum,
                        principalTable: "Departments",
                        principalColumn: "Dnum");
                });

            migrationBuilder.CreateTable(
                name: "Dependents",
                columns: table => new
                {
                    name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EmployeeSSN = table.Column<int>(type: "int", nullable: false),
                    sex = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Bdate = table.Column<DateTime>(type: "date", nullable: true),
                    relationship = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dependents", x => new { x.name, x.EmployeeSSN });
                    table.ForeignKey(
                        name: "FK_Dependents_employees_EmployeeSSN",
                        column: x => x.EmployeeSSN,
                        principalTable: "employees",
                        principalColumn: "SSN",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorksFor",
                columns: table => new
                {
                    ESSN = table.Column<int>(type: "int", nullable: false),
                    Pnum = table.Column<int>(type: "int", nullable: false),
                    hour = table.Column<int>(type: "int", nullable: true),
                    ProjectPnumber = table.Column<int>(type: "int", nullable: false),
                    superid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorksFor", x => new { x.ESSN, x.Pnum });
                    table.ForeignKey(
                        name: "FK_WorksFor_Projects_ProjectPnumber",
                        column: x => x.ProjectPnumber,
                        principalTable: "Projects",
                        principalColumn: "Pnumber",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorksFor_employees_superid",
                        column: x => x.superid,
                        principalTable: "employees",
                        principalColumn: "SSN");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dependents_EmployeeSSN",
                table: "Dependents",
                column: "EmployeeSSN");

            migrationBuilder.CreateIndex(
                name: "IX_DLocations_Dnum",
                table: "DLocations",
                column: "Dnum");

            migrationBuilder.CreateIndex(
                name: "IX_employees_superid",
                table: "employees",
                column: "superid");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_DepartmentDnum",
                table: "Projects",
                column: "DepartmentDnum");

            migrationBuilder.CreateIndex(
                name: "IX_WorksFor_ProjectPnumber",
                table: "WorksFor",
                column: "ProjectPnumber");

            migrationBuilder.CreateIndex(
                name: "IX_WorksFor_superid",
                table: "WorksFor",
                column: "superid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dependents");

            migrationBuilder.DropTable(
                name: "DLocations");

            migrationBuilder.DropTable(
                name: "WorksFor");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "employees");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
