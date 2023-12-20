using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecipeSharingWebApp.Migrations
{
    /// <inheritdoc />
    public partial class fourthMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsFavorite",
                table: "Recipes",
                type: "bit",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ca6733e9-c801-4089-a1bd-bd154a39cc07", "AQAAAAIAAYagAAAAEE8gpFuj2FkIzc0DJt7ur4SvINTTXVOhKi5L0EteLY+dP3VjM1fGnV2Am/dRoh3GIg==", "f4720c2c-f375-4d61-a9b1-ac63f0549ec9" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsFavorite",
                table: "Recipes");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a857bedc-67ff-4e5d-b72c-7b977f63a980", "AQAAAAIAAYagAAAAEFOR3kxafc5+HgjUsT0ift/Ug71cdagIL/YnvYd6J1mVk6N6M6t+HlJw7HyWDaBP4g==", "e85c3173-1874-499e-91ab-545b760382a4" });
        }
    }
}
