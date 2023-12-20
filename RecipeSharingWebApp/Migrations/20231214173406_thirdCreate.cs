using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecipeSharingWebApp.Migrations
{
    /// <inheritdoc />
    public partial class thirdCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a857bedc-67ff-4e5d-b72c-7b977f63a980", "AQAAAAIAAYagAAAAEFOR3kxafc5+HgjUsT0ift/Ug71cdagIL/YnvYd6J1mVk6N6M6t+HlJw7HyWDaBP4g==", "e85c3173-1874-499e-91ab-545b760382a4" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "63f705ca-105f-48b8-85e2-492831a40ae3", "AQAAAAIAAYagAAAAEOe4myF9vesuHHrNaZ3iZYX/NWpRNoqWmbY/2Qj4nKquXIQ/ugf8C9v7tYZV6Ui8+Q==", "71e5b3a3-ffc1-42e2-ad37-dccfa9b63bba" });
        }
    }
}
