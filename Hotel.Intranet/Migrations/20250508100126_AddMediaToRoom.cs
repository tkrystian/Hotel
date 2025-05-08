using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hotel.Intranet.Migrations
{
    /// <inheritdoc />
    public partial class AddMediaToRoom : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Room_Media_MediaIdMedia",
                table: "Room");

            migrationBuilder.RenameColumn(
                name: "MediaIdMedia",
                table: "Room",
                newName: "MediaId");

            migrationBuilder.RenameIndex(
                name: "IX_Room_MediaIdMedia",
                table: "Room",
                newName: "IX_Room_MediaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Room_Media_MediaId",
                table: "Room",
                column: "MediaId",
                principalTable: "Media",
                principalColumn: "IdMedia");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Room_Media_MediaId",
                table: "Room");

            migrationBuilder.RenameColumn(
                name: "MediaId",
                table: "Room",
                newName: "MediaIdMedia");

            migrationBuilder.RenameIndex(
                name: "IX_Room_MediaId",
                table: "Room",
                newName: "IX_Room_MediaIdMedia");

            migrationBuilder.AddForeignKey(
                name: "FK_Room_Media_MediaIdMedia",
                table: "Room",
                column: "MediaIdMedia",
                principalTable: "Media",
                principalColumn: "IdMedia");
        }
    }
}
