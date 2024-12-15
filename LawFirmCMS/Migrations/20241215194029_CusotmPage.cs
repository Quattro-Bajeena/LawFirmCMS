using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LawFirmCMS.Migrations
{
    /// <inheritdoc />
    public partial class CustomPage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PageElements_Pages_PageId",
                table: "PageElements");

            migrationBuilder.RenameColumn(
                name: "PageId",
                table: "PageElements",
                newName: "CustomPageId");

            migrationBuilder.RenameIndex(
                name: "IX_PageElements_PageId",
                table: "PageElements",
                newName: "IX_PageElements_CustomPageId");

            migrationBuilder.AddForeignKey(
                name: "FK_PageElements_Pages_CustomPageId",
                table: "PageElements",
                column: "CustomPageId",
                principalTable: "Pages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PageElements_Pages_CustomPageId",
                table: "PageElements");

            migrationBuilder.RenameColumn(
                name: "CustomPageId",
                table: "PageElements",
                newName: "PageId");

            migrationBuilder.RenameIndex(
                name: "IX_PageElements_CustomPageId",
                table: "PageElements",
                newName: "IX_PageElements_PageId");

            migrationBuilder.AddForeignKey(
                name: "FK_PageElements_Pages_PageId",
                table: "PageElements",
                column: "PageId",
                principalTable: "Pages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
