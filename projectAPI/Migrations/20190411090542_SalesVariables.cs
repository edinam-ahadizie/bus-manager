using Microsoft.EntityFrameworkCore.Migrations;

namespace projectAPI.Migrations
{
    public partial class SalesVariables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Busnum",
                table: "Sales",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Drivername",
                table: "Sales",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Busnum",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "Drivername",
                table: "Sales");
        }
    }
}
