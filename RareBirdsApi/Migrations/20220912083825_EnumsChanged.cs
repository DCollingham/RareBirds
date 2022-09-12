using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RareBirdsApi.Migrations
{
    public partial class EnumsChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Rarity",
                table: "Birds",
                type: "nvarchar(24)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Birds",
                keyColumn: "Id",
                keyValue: 1,
                column: "Rarity",
                value: "Red");

            migrationBuilder.InsertData(
                table: "Birds",
                columns: new[] { "Id", "Genus", "NickName", "Rarity", "Species" },
                values: new object[] { 2, "Cuculus", "Cuckoo", "Red", "canorus" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Birds",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.AlterColumn<int>(
                name: "Rarity",
                table: "Birds",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(24)");

            migrationBuilder.UpdateData(
                table: "Birds",
                keyColumn: "Id",
                keyValue: 1,
                column: "Rarity",
                value: 0);
        }
    }
}
