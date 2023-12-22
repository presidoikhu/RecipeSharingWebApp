using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecipeSharingWebApp.Migrations
{
    /// <inheritdoc />
    public partial class eightCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CommentTitle",
                table: "Comments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8c4dba33-c67d-4985-9ae6-ad2885aa113c", "AQAAAAIAAYagAAAAECW98FO6XDzBqFVmRrRTBa17LPTZZEN+XuX59kqy/8TsQGyyExE7H9DlOx1dJ5v7iQ==", "ebf291ba-a1c1-4fa9-8924-fe4b36d8ecc5" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CommentTitle",
                table: "Comments");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "720717b2-d741-4e4b-8b0c-ec07abdd015e", "AQAAAAIAAYagAAAAEPnjBsgjxMpDI3NYTtiQU8AOlJoowuPv/F0ohZz+6cvCgElqyEP3oyVzpy3EBXN4Ag==", "f73a3096-fb19-4903-8eee-63066bfdba2e" });
        }
    }
}
