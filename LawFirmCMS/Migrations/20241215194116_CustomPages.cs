using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LawFirmCMS.Migrations
{
    /// <inheritdoc />
    public partial class CustomPages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PageElements_Pages_CustomPageId",
                table: "PageElements");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pages",
                table: "Pages");

            migrationBuilder.RenameTable(
                name: "Pages",
                newName: "CustomPages");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CustomPages",
                table: "CustomPages",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PageElements_CustomPages_CustomPageId",
                table: "PageElements",
                column: "CustomPageId",
                principalTable: "CustomPages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PageElements_CustomPages_CustomPageId",
                table: "PageElements");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CustomPages",
                table: "CustomPages");

            migrationBuilder.RenameTable(
                name: "CustomPages",
                newName: "Pages");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pages",
                table: "Pages",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PageElements_Pages_CustomPageId",
                table: "PageElements",
                column: "CustomPageId",
                principalTable: "Pages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
