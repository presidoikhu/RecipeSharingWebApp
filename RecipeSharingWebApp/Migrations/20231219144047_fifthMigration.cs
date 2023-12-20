using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecipeSharingWebApp.Migrations
{
    /// <inheritdoc />
    public partial class fifthMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RecipeTitle",
                table: "Favorites",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f054bb32-8cca-4515-bf7e-c582f663decb", "AQAAAAIAAYagAAAAEKgT7Vmjt1Phc3tTHuE5wdTXxZHtI74PptkwB+nFZQNT2rIz6icObbQ1bipCEkXPZw==", "57c76654-e01d-4490-8b3d-a8551e570276" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RecipeTitle",
                table: "Favorites");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "57d92fac-11e3-4189-8020-5ce5bc5c4fcb", "AQAAAAIAAYagAAAAEEU4QKRBztnIr8QyvwIanmQPjcXauaso5FLVpKWxGJn8KYpygGDMqrfKDa48F0WBig==", "2ae0618c-d933-415e-b7cf-bb1e4608f54c" });
        }
    }
}
