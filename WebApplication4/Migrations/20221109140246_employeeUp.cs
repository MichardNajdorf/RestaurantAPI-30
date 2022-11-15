using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication4.Migrations
{
    public partial class employeeUp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "WorkExperience",
                table: "Employees",
                newName: "Work Experience");

            migrationBuilder.RenameColumn(
                name: "BirthDate",
                table: "Employees",
                newName: "Birth date");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Work Experience",
                table: "Employees",
                newName: "WorkExperience");

            migrationBuilder.RenameColumn(
                name: "Birth date",
                table: "Employees",
                newName: "BirthDate");
        }
    }
}
