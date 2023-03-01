using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Amagi.Thumbnail.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class ThumbnailMeta2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Thumbnail_Thumbnails_ThumbnailMetaId",
                table: "Thumbnail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Thumbnails",
                table: "Thumbnails");

            migrationBuilder.RenameTable(
                name: "Thumbnails",
                newName: "ThumbnailMeta");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ThumbnailMeta",
                table: "ThumbnailMeta",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Thumbnail_ThumbnailMeta_ThumbnailMetaId",
                table: "Thumbnail",
                column: "ThumbnailMetaId",
                principalTable: "ThumbnailMeta",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Thumbnail_ThumbnailMeta_ThumbnailMetaId",
                table: "Thumbnail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ThumbnailMeta",
                table: "ThumbnailMeta");

            migrationBuilder.RenameTable(
                name: "ThumbnailMeta",
                newName: "Thumbnails");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Thumbnails",
                table: "Thumbnails",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Thumbnail_Thumbnails_ThumbnailMetaId",
                table: "Thumbnail",
                column: "ThumbnailMetaId",
                principalTable: "Thumbnails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
