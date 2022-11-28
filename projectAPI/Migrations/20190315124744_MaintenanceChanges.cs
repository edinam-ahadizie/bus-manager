using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace projectAPI.Migrations
{
    public partial class MaintenanceChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Maintenance",
                table: "Bus");

            migrationBuilder.AddColumn<DateTime>(
                name: "TripDate",
                table: "Trips",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "MaintenanceId",
                table: "Bus",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Maintenance",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MaintenanceType = table.Column<string>(nullable: false),
                    MaintenanceCost = table.Column<int>(nullable: false),
                    MaintenanceDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Maintenance", x => x.Id);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bus_Maintenance_MaintenanceId",
                table: "Bus");

            migrationBuilder.DropTable(
                name: "Maintenance");

            migrationBuilder.DropIndex(
                name: "IX_Bus_MaintenanceId",
                table: "Bus");

            migrationBuilder.DropColumn(
                name: "TripDate",
                table: "Trips");

            migrationBuilder.DropColumn(
                name: "MaintenanceId",
                table: "Bus");

            migrationBuilder.AddColumn<int>(
                name: "Maintenance",
                table: "Bus",
                nullable: false,
                defaultValue: 0);
        }
    }
}
