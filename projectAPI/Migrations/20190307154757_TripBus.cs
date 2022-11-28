using Microsoft.EntityFrameworkCore.Migrations;

namespace projectAPI.Migrations
{
    public partial class TripBus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Driver_Bus_BusId",
                table: "Driver");

            migrationBuilder.DropForeignKey(
                name: "FK_Trips_Driver_DriverId",
                table: "Trips");

            migrationBuilder.DropColumn(
                name: "DriverName",
                table: "Bus");

            migrationBuilder.AlterColumn<int>(
                name: "DriverId",
                table: "Trips",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BusId",
                table: "Driver",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Driver_Bus_BusId",
                table: "Driver",
                column: "BusId",
                principalTable: "Bus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Trips_Driver_DriverId",
                table: "Trips",
                column: "DriverId",
                principalTable: "Driver",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Driver_Bus_BusId",
                table: "Driver");

            migrationBuilder.DropForeignKey(
                name: "FK_Trips_Driver_DriverId",
                table: "Trips");

            migrationBuilder.AlterColumn<int>(
                name: "DriverId",
                table: "Trips",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "BusId",
                table: "Driver",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<string>(
                name: "DriverName",
                table: "Bus",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Driver_Bus_BusId",
                table: "Driver",
                column: "BusId",
                principalTable: "Bus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Trips_Driver_DriverId",
                table: "Trips",
                column: "DriverId",
                principalTable: "Driver",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
