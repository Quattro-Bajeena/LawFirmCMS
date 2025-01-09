using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LawFirmCMS.Migrations
{
    /// <inheritdoc />
    public partial class Admin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Boss", "Expertise", "IsDeleted", "Login", "Name", "PasswordHash", "Picture", "Surname" },
                values: new object[] { -1, true, null, false, "admin", "Admin", new byte[] { 243, 130, 113, 232, 45, 22, 9, 95, 121, 209, 56, 49, 115, 176, 181, 19, 20, 81, 7, 88, 223, 126, 248, 1, 2, 37, 166, 170, 148, 180, 63, 110, 39, 237, 221, 170, 169, 135, 129, 66, 118, 181, 60, 68, 120, 8, 102, 26, 67, 182, 12, 68, 170, 54, 141, 219, 243, 167, 37, 183, 203, 104, 174, 179 }, null, "Admin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: -1);
        }
    }
}
