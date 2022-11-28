using Microsoft.EntityFrameworkCore.Migrations;

namespace projectAPI.Migrations
{
    public partial class ModifiedTripDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TripMaintenanceCost",
                table: "Trips",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TripMaintenanceType",
                table: "Trips",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TripWeek",
                table: "Trips",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TripMaintenanceCost",
                table: "Trips");

            migrationBuilder.DropColumn(
                name: "TripMaintenanceType",
                table: "Trips");

            migrationBuilder.DropColumn(
                name: "TripWeek",
                table: "Trips");
        }
    }
}
