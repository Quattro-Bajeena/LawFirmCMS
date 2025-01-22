using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LawFirmCMS.Migrations
{
    /// <inheritdoc />
    public partial class DefaultPage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "CustomPages",
                columns: new[] { "Id", "IsDeleted", "IsGroup", "ParentId", "Path", "Title" },
                values: new object[] { -1, false, false, null, "Home", "Home" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CustomPages",
                keyColumn: "Id",
                keyValue: -1);
        }
    }
}
