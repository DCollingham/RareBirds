using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RareBirdsApi.Migrations
{
    public partial class Inital : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Birds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NickName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Genus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Species = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rarity = table.Column<string>(type: "nvarchar(24)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Birds", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sightings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateSighted = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Longditude = table.Column<double>(type: "float", nullable: false),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    BirdId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sightings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sightings_Birds_BirdId",
                        column: x => x.BirdId,
                        principalTable: "Birds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Birds",
                columns: new[] { "Id", "Genus", "NickName", "Rarity", "Species" },
                values: new object[] { 1, "Perdix", "Grey Patridge", "Red", "Perdix" });

            migrationBuilder.InsertData(
                table: "Birds",
                columns: new[] { "Id", "Genus", "NickName", "Rarity", "Species" },
                values: new object[] { 2, "Cuculus", "Cuckoo", "Red", "Canorus" });

            migrationBuilder.InsertData(
                table: "Sightings",
                columns: new[] { "Id", "BirdId", "DateSighted", "Latitude", "Longditude" },
                values: new object[] { 1, 1, new DateTime(2022, 9, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), -4.1638948895306491, 50.960933075310408 });

            migrationBuilder.InsertData(
                table: "Sightings",
                columns: new[] { "Id", "BirdId", "DateSighted", "Latitude", "Longditude" },
                values: new object[] { 2, 1, new DateTime(2022, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), -5.1638948895306491, 51.960933075310408 });

            migrationBuilder.CreateIndex(
                name: "IX_Sightings_BirdId",
                table: "Sightings",
                column: "BirdId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sightings");

            migrationBuilder.DropTable(
                name: "Birds");
        }
    }
}
