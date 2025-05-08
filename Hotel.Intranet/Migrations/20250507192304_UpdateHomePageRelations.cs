using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hotel.Intranet.Migrations
{
    /// <inheritdoc />
    public partial class UpdateHomePageRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HomePage_Media_BannerIdMedia",
                table: "HomePage");

            migrationBuilder.DropForeignKey(
                name: "FK_HomePage_Media_GrafikaIdMedia",
                table: "HomePage");

            migrationBuilder.RenameColumn(
                name: "GrafikaIdMedia",
                table: "HomePage",
                newName: "GrafikaId");

            migrationBuilder.RenameColumn(
                name: "BannerIdMedia",
                table: "HomePage",
                newName: "BannerId");

            migrationBuilder.RenameIndex(
                name: "IX_HomePage_GrafikaIdMedia",
                table: "HomePage",
                newName: "IX_HomePage_GrafikaId");

            migrationBuilder.RenameIndex(
                name: "IX_HomePage_BannerIdMedia",
                table: "HomePage",
                newName: "IX_HomePage_BannerId");

            migrationBuilder.AddForeignKey(
                name: "FK_HomePage_Media_BannerId",
                table: "HomePage",
                column: "BannerId",
                principalTable: "Media",
                principalColumn: "IdMedia");

            migrationBuilder.AddForeignKey(
                name: "FK_HomePage_Media_GrafikaId",
                table: "HomePage",
                column: "GrafikaId",
                principalTable: "Media",
                principalColumn: "IdMedia");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HomePage_Media_BannerId",
                table: "HomePage");

            migrationBuilder.DropForeignKey(
                name: "FK_HomePage_Media_GrafikaId",
                table: "HomePage");

            migrationBuilder.RenameColumn(
                name: "GrafikaId",
                table: "HomePage",
                newName: "GrafikaIdMedia");

            migrationBuilder.RenameColumn(
                name: "BannerId",
                table: "HomePage",
                newName: "BannerIdMedia");

            migrationBuilder.RenameIndex(
                name: "IX_HomePage_GrafikaId",
                table: "HomePage",
                newName: "IX_HomePage_GrafikaIdMedia");

            migrationBuilder.RenameIndex(
                name: "IX_HomePage_BannerId",
                table: "HomePage",
                newName: "IX_HomePage_BannerIdMedia");

            migrationBuilder.AddForeignKey(
                name: "FK_HomePage_Media_BannerIdMedia",
                table: "HomePage",
                column: "BannerIdMedia",
                principalTable: "Media",
                principalColumn: "IdMedia");

            migrationBuilder.AddForeignKey(
                name: "FK_HomePage_Media_GrafikaIdMedia",
                table: "HomePage",
                column: "GrafikaIdMedia",
                principalTable: "Media",
                principalColumn: "IdMedia");
        }
    }
}
