using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LawFirmCMS.Migrations
{
    /// <inheritdoc />
    public partial class Group : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PageElements_CustomPages_CustomPageId",
                table: "PageElements");

            migrationBuilder.RenameColumn(
                name: "CustomPageId",
                table: "PageElements",
                newName: "PageId");

            migrationBuilder.RenameIndex(
                name: "IX_PageElements_CustomPageId",
                table: "PageElements",
                newName: "IX_PageElements_PageId");

            migrationBuilder.AddColumn<bool>(
                name: "IsGroup",
                table: "CustomPages",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "ParentId",
                table: "CustomPages",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CustomPages_ParentId",
                table: "CustomPages",
                column: "ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomPages_CustomPages_ParentId",
                table: "CustomPages",
                column: "ParentId",
                principalTable: "CustomPages",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PageElements_CustomPages_PageId",
                table: "PageElements",
                column: "PageId",
                principalTable: "CustomPages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomPages_CustomPages_ParentId",
                table: "CustomPages");

            migrationBuilder.DropForeignKey(
                name: "FK_PageElements_CustomPages_PageId",
                table: "PageElements");

            migrationBuilder.DropIndex(
                name: "IX_CustomPages_ParentId",
                table: "CustomPages");

            migrationBuilder.DropColumn(
                name: "IsGroup",
                table: "CustomPages");

            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "CustomPages");

            migrationBuilder.RenameColumn(
                name: "PageId",
                table: "PageElements",
                newName: "CustomPageId");

            migrationBuilder.RenameIndex(
                name: "IX_PageElements_PageId",
                table: "PageElements",
                newName: "IX_PageElements_CustomPageId");

            migrationBuilder.AddForeignKey(
                name: "FK_PageElements_CustomPages_CustomPageId",
                table: "PageElements",
                column: "CustomPageId",
                principalTable: "CustomPages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
