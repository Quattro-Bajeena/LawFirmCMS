using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LawFirmCMS.Migrations
{
    /// <inheritdoc />
    public partial class Employee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Boss", "Expertise", "IsDeleted", "Login", "Name", "PasswordHash", "Picture", "Surname" },
                values: new object[] { -2, false, null, false, "employee", "Employee", new byte[] { 128, 163, 1, 212, 67, 116, 71, 55, 181, 208, 199, 199, 132, 76, 101, 6, 142, 196, 16, 34, 11, 202, 119, 202, 6, 95, 44, 188, 62, 99, 92, 157, 239, 21, 208, 174, 233, 33, 63, 157, 102, 36, 241, 222, 247, 17, 247, 171, 195, 179, 72, 81, 219, 19, 234, 85, 10, 80, 179, 217, 108, 72, 52, 213 }, null, "Employee" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: -2);
        }
    }
}
