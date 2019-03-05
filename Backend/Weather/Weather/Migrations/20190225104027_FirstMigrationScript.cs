using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Weather.Migrations
{
    public partial class FirstMigrationScript : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SavedLocations",
                columns: table => new
                {
                    SavedLocationId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CityName = table.Column<string>(nullable: true),
                    Latitude = table.Column<long>(nullable: false),
                    Longitude = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SavedLocations", x => x.SavedLocationId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Mobile = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "UserLocations",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId1 = table.Column<long>(nullable: true),
                    SavedLocationId1 = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLocations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserLocations_SavedLocations_SavedLocationId1",
                        column: x => x.SavedLocationId1,
                        principalTable: "SavedLocations",
                        principalColumn: "SavedLocationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserLocations_Users_UserId1",
                        column: x => x.UserId1,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserLocations_SavedLocationId1",
                table: "UserLocations",
                column: "SavedLocationId1");

            migrationBuilder.CreateIndex(
                name: "IX_UserLocations_UserId1",
                table: "UserLocations",
                column: "UserId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserLocations");

            migrationBuilder.DropTable(
                name: "SavedLocations");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
