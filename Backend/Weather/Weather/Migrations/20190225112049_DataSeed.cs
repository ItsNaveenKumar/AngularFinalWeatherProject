using Microsoft.EntityFrameworkCore.Migrations;

namespace Weather.Migrations
{
    public partial class DataSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserLocations_SavedLocations_SavedLocationId1",
                table: "UserLocations");

            migrationBuilder.DropForeignKey(
                name: "FK_UserLocations_Users_UserId1",
                table: "UserLocations");

            migrationBuilder.DropIndex(
                name: "IX_UserLocations_SavedLocationId1",
                table: "UserLocations");

            migrationBuilder.DropIndex(
                name: "IX_UserLocations_UserId1",
                table: "UserLocations");

            migrationBuilder.DropColumn(
                name: "SavedLocationId1",
                table: "UserLocations");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "UserLocations");

            migrationBuilder.AddColumn<long>(
                name: "SavedLocationId",
                table: "UserLocations",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "UserId",
                table: "UserLocations",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AlterColumn<double>(
                name: "Longitude",
                table: "SavedLocations",
                nullable: false,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<double>(
                name: "Latitude",
                table: "SavedLocations",
                nullable: false,
                oldClrType: typeof(long));

            migrationBuilder.InsertData(
                table: "SavedLocations",
                columns: new[] { "SavedLocationId", "CityName", "Latitude", "Longitude" },
                values: new object[,]
                {
                    { 1L, "New Delhi", 28.6139, 77.209 },
                    { 2L, "New Delhi", 29.0588, 29.0588 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Email", "Mobile", "Name", "Password" },
                values: new object[,]
                {
                    { 1L, "naveen@gmail.com", 7053207025L, "Naveen", "asdfghjkl" },
                    { 2L, "giriraj@gmail.com", 9899320302L, "Giriraj", "asdfghjkl" }
                });

            migrationBuilder.InsertData(
                table: "UserLocations",
                columns: new[] { "Id", "SavedLocationId", "UserId" },
                values: new object[] { 1L, 1L, 1L });

            migrationBuilder.InsertData(
                table: "UserLocations",
                columns: new[] { "Id", "SavedLocationId", "UserId" },
                values: new object[] { 2L, 2L, 2L });

            migrationBuilder.CreateIndex(
                name: "IX_UserLocations_SavedLocationId",
                table: "UserLocations",
                column: "SavedLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLocations_UserId",
                table: "UserLocations",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserLocations_SavedLocations_SavedLocationId",
                table: "UserLocations",
                column: "SavedLocationId",
                principalTable: "SavedLocations",
                principalColumn: "SavedLocationId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserLocations_Users_UserId",
                table: "UserLocations",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserLocations_SavedLocations_SavedLocationId",
                table: "UserLocations");

            migrationBuilder.DropForeignKey(
                name: "FK_UserLocations_Users_UserId",
                table: "UserLocations");

            migrationBuilder.DropIndex(
                name: "IX_UserLocations_SavedLocationId",
                table: "UserLocations");

            migrationBuilder.DropIndex(
                name: "IX_UserLocations_UserId",
                table: "UserLocations");

            migrationBuilder.DeleteData(
                table: "UserLocations",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "UserLocations",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "SavedLocations",
                keyColumn: "SavedLocationId",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "SavedLocations",
                keyColumn: "SavedLocationId",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2L);

            migrationBuilder.DropColumn(
                name: "SavedLocationId",
                table: "UserLocations");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "UserLocations");

            migrationBuilder.AddColumn<long>(
                name: "SavedLocationId1",
                table: "UserLocations",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "UserId1",
                table: "UserLocations",
                nullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "Longitude",
                table: "SavedLocations",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<long>(
                name: "Latitude",
                table: "SavedLocations",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.CreateIndex(
                name: "IX_UserLocations_SavedLocationId1",
                table: "UserLocations",
                column: "SavedLocationId1");

            migrationBuilder.CreateIndex(
                name: "IX_UserLocations_UserId1",
                table: "UserLocations",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_UserLocations_SavedLocations_SavedLocationId1",
                table: "UserLocations",
                column: "SavedLocationId1",
                principalTable: "SavedLocations",
                principalColumn: "SavedLocationId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserLocations_Users_UserId1",
                table: "UserLocations",
                column: "UserId1",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
