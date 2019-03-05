using Microsoft.EntityFrameworkCore.Migrations;

namespace Weather.Migrations
{
    public partial class UpdatedDataSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "SavedLocations",
                keyColumn: "SavedLocationId",
                keyValue: 2L,
                columns: new[] { "CityName", "Longitude" },
                values: new object[] { "Haryana", 76.0856 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "SavedLocations",
                keyColumn: "SavedLocationId",
                keyValue: 2L,
                columns: new[] { "CityName", "Longitude" },
                values: new object[] { "New Delhi", 29.0588 });
        }
    }
}
