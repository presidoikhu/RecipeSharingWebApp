using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecipeSharingWebApp.Migrations
{
    /// <inheritdoc />
    public partial class SecondCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RecipeId",
                table: "Categories",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "63f705ca-105f-48b8-85e2-492831a40ae3", "AQAAAAIAAYagAAAAEOe4myF9vesuHHrNaZ3iZYX/NWpRNoqWmbY/2Qj4nKquXIQ/ugf8C9v7tYZV6Ui8+Q==", "71e5b3a3-ffc1-42e2-ad37-dccfa9b63bba" });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_RecipeId",
                table: "Categories",
                column: "RecipeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Recipes_RecipeId",
                table: "Categories",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Recipes_RecipeId",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_RecipeId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "RecipeId",
                table: "Categories");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bf4218dd-744b-43f6-b7b0-f6e9b22eb32a", "AQAAAAIAAYagAAAAEClj8V0usy+KiAjtscgtRyOYd/RYRALqF3n5tpJpcWqy3bIuBePQh/jmh9VKQ9uz3A==", "8eae3bd2-58e3-4f28-9620-9e83e4786937" });
        }
    }
}
