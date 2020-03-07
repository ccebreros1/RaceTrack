using Microsoft.EntityFrameworkCore.Migrations;

namespace RaceTrack.Migrations
{
    public partial class SecondVersion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OwnerName",
                table: "Vehicle",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VehicleAlias",
                table: "Vehicle",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OwnerName",
                table: "Vehicle");

            migrationBuilder.DropColumn(
                name: "VehicleAlias",
                table: "Vehicle");
        }
    }
}
