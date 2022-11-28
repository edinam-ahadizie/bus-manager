using Microsoft.EntityFrameworkCore.Migrations;

namespace projectAPI.Migrations
{
    public partial class BusTripIssues : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trips_Bus_BusId",
                table: "Trips");

            migrationBuilder.AlterColumn<int>(
                name: "BusId",
                table: "Trips",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Trips_Bus_BusId",
                table: "Trips",
                column: "BusId",
                principalTable: "Bus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trips_Bus_BusId",
                table: "Trips");

            migrationBuilder.AlterColumn<int>(
                name: "BusId",
                table: "Trips",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Trips_Bus_BusId",
                table: "Trips",
                column: "BusId",
                principalTable: "Bus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
