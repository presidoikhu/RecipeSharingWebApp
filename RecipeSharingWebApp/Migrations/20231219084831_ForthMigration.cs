using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecipeSharingWebApp.Migrations
{
    /// <inheritdoc />
    public partial class ForthMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Favorites",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RecipeId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Favorites", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "57d92fac-11e3-4189-8020-5ce5bc5c4fcb", "AQAAAAIAAYagAAAAEEU4QKRBztnIr8QyvwIanmQPjcXauaso5FLVpKWxGJn8KYpygGDMqrfKDa48F0WBig==", "2ae0618c-d933-415e-b7cf-bb1e4608f54c" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Favorites");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "58ab6da8-8ae5-40e3-a0e9-d4108f842b52", "AQAAAAIAAYagAAAAEFLEM1AUwG8LeLnmh07dcRakIq3EK/YsbILGOjEO8/bD1mryyeL/70p9IRPFOJifBA==", "8f400880-7e0b-4d91-b8e3-6fd7fa8a9a74" });
        }
    }
}
