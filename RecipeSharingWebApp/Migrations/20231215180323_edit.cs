using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecipeSharingWebApp.Migrations
{
    /// <inheritdoc />
    public partial class edit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsFavorite",
                table: "Recipes",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "58ab6da8-8ae5-40e3-a0e9-d4108f842b52", "AQAAAAIAAYagAAAAEFLEM1AUwG8LeLnmh07dcRakIq3EK/YsbILGOjEO8/bD1mryyeL/70p9IRPFOJifBA==", "8f400880-7e0b-4d91-b8e3-6fd7fa8a9a74" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsFavorite",
                table: "Recipes",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ca6733e9-c801-4089-a1bd-bd154a39cc07", "AQAAAAIAAYagAAAAEE8gpFuj2FkIzc0DJt7ur4SvINTTXVOhKi5L0EteLY+dP3VjM1fGnV2Am/dRoh3GIg==", "f4720c2c-f375-4d61-a9b1-ac63f0549ec9" });
        }
    }
}
