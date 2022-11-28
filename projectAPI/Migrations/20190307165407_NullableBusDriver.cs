using Microsoft.EntityFrameworkCore.Migrations;

namespace projectAPI.Migrations
{
    public partial class NullableBusDriver : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Driver_Bus_BusId",
                table: "Driver");

            migrationBuilder.AlterColumn<int>(
                name: "BusId",
                table: "Driver",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Driver_Bus_BusId",
                table: "Driver",
                column: "BusId",
                principalTable: "Bus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Driver_Bus_BusId",
                table: "Driver");

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
        }
    }
}
