using Microsoft.EntityFrameworkCore.Migrations;

namespace projectAPI.Migrations
{
    public partial class drvertosales : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DriverId",
                table: "Sales",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sales_DriverId",
                table: "Sales",
                column: "DriverId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_Driver_DriverId",
                table: "Sales",
                column: "DriverId",
                principalTable: "Driver",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sales_Driver_DriverId",
                table: "Sales");

            migrationBuilder.DropIndex(
                name: "IX_Sales_DriverId",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "DriverId",
                table: "Sales");
        }
    }
}
