using Microsoft.EntityFrameworkCore.Migrations;

namespace projectAPI.Migrations
{
    public partial class manyChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bus_Maintenance_MaintenanceId",
                table: "Bus");

            migrationBuilder.DropIndex(
                name: "IX_Bus_MaintenanceId",
                table: "Bus");

            migrationBuilder.DropColumn(
                name: "MaintenanceId",
                table: "Bus");

            migrationBuilder.AddColumn<int>(
                name: "BusId",
                table: "Maintenance",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Maintenance_BusId",
                table: "Maintenance",
                column: "BusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Maintenance_Bus_BusId",
                table: "Maintenance",
                column: "BusId",
                principalTable: "Bus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Maintenance_Bus_BusId",
                table: "Maintenance");

            migrationBuilder.DropIndex(
                name: "IX_Maintenance_BusId",
                table: "Maintenance");

            migrationBuilder.DropColumn(
                name: "BusId",
                table: "Maintenance");

            migrationBuilder.AddColumn<int>(
                name: "MaintenanceId",
                table: "Bus",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bus_MaintenanceId",
                table: "Bus",
                column: "MaintenanceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bus_Maintenance_MaintenanceId",
                table: "Bus",
                column: "MaintenanceId",
                principalTable: "Maintenance",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
