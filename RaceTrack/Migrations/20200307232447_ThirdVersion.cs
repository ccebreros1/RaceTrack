using Microsoft.EntityFrameworkCore.Migrations;

namespace RaceTrack.Migrations
{
    public partial class ThirdVersion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AcceptableLift",
                table: "Vehicle");

            migrationBuilder.DropColumn(
                name: "AcceptableTireWear",
                table: "Vehicle");

            migrationBuilder.DropColumn(
                name: "HasTowStrap",
                table: "Vehicle");

            migrationBuilder.AddColumn<bool>(
                name: "AcceptableLift",
                table: "RaceVehicle",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "AcceptableTireWear",
                table: "RaceVehicle",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HasTowStrap",
                table: "RaceVehicle",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AcceptableLift",
                table: "RaceVehicle");

            migrationBuilder.DropColumn(
                name: "AcceptableTireWear",
                table: "RaceVehicle");

            migrationBuilder.DropColumn(
                name: "HasTowStrap",
                table: "RaceVehicle");

            migrationBuilder.AddColumn<bool>(
                name: "AcceptableLift",
                table: "Vehicle",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "AcceptableTireWear",
                table: "Vehicle",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HasTowStrap",
                table: "Vehicle",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
