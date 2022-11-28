using Microsoft.EntityFrameworkCore.Migrations;

namespace projectAPI.Migrations
{
    public partial class Newupdatedtrip : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Passengers",
                table: "Trips",
                newName: "TripSales");

            migrationBuilder.RenameColumn(
                name: "Cost",
                table: "Trips",
                newName: "TripProfit");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TripSales",
                table: "Trips",
                newName: "Passengers");

            migrationBuilder.RenameColumn(
                name: "TripProfit",
                table: "Trips",
                newName: "Cost");
        }
    }
}
