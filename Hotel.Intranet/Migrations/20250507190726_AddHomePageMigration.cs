using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hotel.Intranet.Migrations
{
    /// <inheritdoc />
    public partial class AddHomePageMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HomePageId",
                table: "Room",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HomePageId",
                table: "Atraction",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "HomePage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BannerIdMedia = table.Column<int>(type: "int", nullable: true),
                    Naglowek = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Tagi = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: false),
                    GrafikaIdMedia = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomePage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HomePage_Media_BannerIdMedia",
                        column: x => x.BannerIdMedia,
                        principalTable: "Media",
                        principalColumn: "IdMedia");
                    table.ForeignKey(
                        name: "FK_HomePage_Media_GrafikaIdMedia",
                        column: x => x.GrafikaIdMedia,
                        principalTable: "Media",
                        principalColumn: "IdMedia");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Room_HomePageId",
                table: "Room",
                column: "HomePageId");

            migrationBuilder.CreateIndex(
                name: "IX_Atraction_HomePageId",
                table: "Atraction",
                column: "HomePageId");

            migrationBuilder.CreateIndex(
                name: "IX_HomePage_BannerIdMedia",
                table: "HomePage",
                column: "BannerIdMedia");

            migrationBuilder.CreateIndex(
                name: "IX_HomePage_GrafikaIdMedia",
                table: "HomePage",
                column: "GrafikaIdMedia");

            migrationBuilder.AddForeignKey(
                name: "FK_Atraction_HomePage_HomePageId",
                table: "Atraction",
                column: "HomePageId",
                principalTable: "HomePage",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Room_HomePage_HomePageId",
                table: "Room",
                column: "HomePageId",
                principalTable: "HomePage",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Atraction_HomePage_HomePageId",
                table: "Atraction");

            migrationBuilder.DropForeignKey(
                name: "FK_Room_HomePage_HomePageId",
                table: "Room");

            migrationBuilder.DropTable(
                name: "HomePage");

            migrationBuilder.DropIndex(
                name: "IX_Room_HomePageId",
                table: "Room");

            migrationBuilder.DropIndex(
                name: "IX_Atraction_HomePageId",
                table: "Atraction");

            migrationBuilder.DropColumn(
                name: "HomePageId",
                table: "Room");

            migrationBuilder.DropColumn(
                name: "HomePageId",
                table: "Atraction");
        }
    }
}
