using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hotel.Intranet.Migrations
{
    /// <inheritdoc />
    public partial class AddMediaToAtraction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Atraction_Media_MediaIdMedia",
                table: "Atraction");

            migrationBuilder.RenameColumn(
                name: "MediaIdMedia",
                table: "Atraction",
                newName: "MediaId");

            migrationBuilder.RenameIndex(
                name: "IX_Atraction_MediaIdMedia",
                table: "Atraction",
                newName: "IX_Atraction_MediaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Atraction_Media_MediaId",
                table: "Atraction",
                column: "MediaId",
                principalTable: "Media",
                principalColumn: "IdMedia");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Atraction_Media_MediaId",
                table: "Atraction");

            migrationBuilder.RenameColumn(
                name: "MediaId",
                table: "Atraction",
                newName: "MediaIdMedia");

            migrationBuilder.RenameIndex(
                name: "IX_Atraction_MediaId",
                table: "Atraction",
                newName: "IX_Atraction_MediaIdMedia");

            migrationBuilder.AddForeignKey(
                name: "FK_Atraction_Media_MediaIdMedia",
                table: "Atraction",
                column: "MediaIdMedia",
                principalTable: "Media",
                principalColumn: "IdMedia");
        }
    }
}
