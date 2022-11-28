using Microsoft.EntityFrameworkCore.Migrations;

namespace projectAPI.Migrations
{
    public partial class NewSuff : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DriverId",
                table: "Trips",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsStandby",
                table: "Trips",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Picture",
                table: "Driver",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Trips_DriverId",
                table: "Trips",
                column: "DriverId");

            migrationBuilder.AddForeignKey(
                name: "FK_Trips_Driver_DriverId",
                table: "Trips",
                column: "DriverId",
                principalTable: "Driver",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trips_Driver_DriverId",
                table: "Trips");

            migrationBuilder.DropIndex(
                name: "IX_Trips_DriverId",
                table: "Trips");

            migrationBuilder.DropColumn(
                name: "DriverId",
                table: "Trips");

            migrationBuilder.DropColumn(
                name: "IsStandby",
                table: "Trips");

            migrationBuilder.DropColumn(
                name: "Picture",
                table: "Driver");
        }
    }
}
