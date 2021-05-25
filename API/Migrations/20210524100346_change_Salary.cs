using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class change_Salary : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "salary",
                table: "TB_M_Person",
                newName: "Salary");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Salary",
                table: "TB_M_Person",
                newName: "salary");
        }
    }
}
