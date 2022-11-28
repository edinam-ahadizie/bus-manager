using Microsoft.EntityFrameworkCore.Migrations;

namespace projectAPI.Migrations
{
    public partial class ChangeUpperCase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "registrationYear",
                table: "Bus",
                newName: "RegistrationYear");

            migrationBuilder.RenameColumn(
                name: "maintenance",
                table: "Bus",
                newName: "Maintenance");

            migrationBuilder.RenameColumn(
                name: "driverName",
                table: "Bus",
                newName: "DriverName");

            migrationBuilder.RenameColumn(
                name: "capacity",
                table: "Bus",
                newName: "Capacity");

            migrationBuilder.RenameColumn(
                name: "busType",
                table: "Bus",
                newName: "BusType");

            migrationBuilder.RenameColumn(
                name: "busNumber",
                table: "Bus",
                newName: "BusNumber");

            migrationBuilder.AlterColumn<int>(
                name: "Maintenance",
                table: "Bus",
                nullable: false,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<string>(
                name: "DriverName",
                table: "Bus",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BusNumber",
                table: "Bus",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RegistrationYear",
                table: "Bus",
                newName: "registrationYear");

            migrationBuilder.RenameColumn(
                name: "Maintenance",
                table: "Bus",
                newName: "maintenance");

            migrationBuilder.RenameColumn(
                name: "DriverName",
                table: "Bus",
                newName: "driverName");

            migrationBuilder.RenameColumn(
                name: "Capacity",
                table: "Bus",
                newName: "capacity");

            migrationBuilder.RenameColumn(
                name: "BusType",
                table: "Bus",
                newName: "busType");

            migrationBuilder.RenameColumn(
                name: "BusNumber",
                table: "Bus",
                newName: "busNumber");

            migrationBuilder.AlterColumn<long>(
                name: "maintenance",
                table: "Bus",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "driverName",
                table: "Bus",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "busNumber",
                table: "Bus",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
