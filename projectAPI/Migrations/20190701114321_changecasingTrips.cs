using Microsoft.EntityFrameworkCore.Migrations;

namespace projectAPI.Migrations
{
    public partial class changecasingTrips : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TripMaintenanceType",
                table: "Trips",
                newName: "TripMaintenancetype");

            migrationBuilder.RenameColumn(
                name: "TripMaintenanceCost",
                table: "Trips",
                newName: "TripMaintenancecost");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TripMaintenancetype",
                table: "Trips",
                newName: "TripMaintenanceType");

            migrationBuilder.RenameColumn(
                name: "TripMaintenancecost",
                table: "Trips",
                newName: "TripMaintenanceCost");
        }
    }
}
