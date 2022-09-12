using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RareBirdsApi.Migrations
{
    public partial class AddedSampleBird : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Birds",
                columns: new[] { "Id", "Genus", "NickName", "Rarity", "Species" },
                values: new object[] { 1, "Perdix", "Grey Patridge", 0, "Perdix" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Birds",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
