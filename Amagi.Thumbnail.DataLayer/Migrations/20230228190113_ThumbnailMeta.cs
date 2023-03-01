using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Amagi.Thumbnail.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class ThumbnailMeta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Thumbnail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ThumbnailMetaId = table.Column<int>(type: "int", nullable: false),
                    ThumbnailImage = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Thumbnail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Thumbnail_Thumbnails_ThumbnailMetaId",
                        column: x => x.ThumbnailMetaId,
                        principalTable: "Thumbnails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Thumbnail_ThumbnailMetaId",
                table: "Thumbnail",
                column: "ThumbnailMetaId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Thumbnail");
        }
    }
}
