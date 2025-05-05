using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hotel.Intranet.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Page",
                columns: table => new
                {
                    IdStrony = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LinkTytul = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Tytul = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Tresc = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: false),
                    Pozycja = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Page", x => x.IdStrony);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    IdUzytkownika = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rola = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Imie = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Nazwisko = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Haslo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.IdUzytkownika);
                });

            migrationBuilder.CreateTable(
                name: "Media",
                columns: table => new
                {
                    IdMedia = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    FileType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    RelatedObjectType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PageIdStrony = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Media", x => x.IdMedia);
                    table.ForeignKey(
                        name: "FK_Media_Page_PageIdStrony",
                        column: x => x.PageIdStrony,
                        principalTable: "Page",
                        principalColumn: "IdStrony");
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    IdWiadomosci = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Temat = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Tresc = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: false),
                    DataWyslania = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NadawcaId = table.Column<int>(type: "int", nullable: false),
                    OdbiorcaId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    UserIdUzytkownika = table.Column<int>(type: "int", nullable: true),
                    UserIdUzytkownika1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.IdWiadomosci);
                    table.ForeignKey(
                        name: "FK_Messages_User_UserIdUzytkownika",
                        column: x => x.UserIdUzytkownika,
                        principalTable: "User",
                        principalColumn: "IdUzytkownika");
                    table.ForeignKey(
                        name: "FK_Messages_User_UserIdUzytkownika1",
                        column: x => x.UserIdUzytkownika1,
                        principalTable: "User",
                        principalColumn: "IdUzytkownika");
                });

            migrationBuilder.CreateTable(
                name: "Reservation",
                columns: table => new
                {
                    IdRezerwacji = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataRozpoczecia = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataZakonczenia = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TypRezerwacji = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UzytkownikId = table.Column<int>(type: "int", nullable: false),
                    UserIdUzytkownika = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservation", x => x.IdRezerwacji);
                    table.ForeignKey(
                        name: "FK_Reservation_User_UserIdUzytkownika",
                        column: x => x.UserIdUzytkownika,
                        principalTable: "User",
                        principalColumn: "IdUzytkownika");
                });

            migrationBuilder.CreateTable(
                name: "Atraction",
                columns: table => new
                {
                    IdAtrakcji = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: false),
                    Cena = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MediaIdMedia = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atraction", x => x.IdAtrakcji);
                    table.ForeignKey(
                        name: "FK_Atraction_Media_MediaIdMedia",
                        column: x => x.MediaIdMedia,
                        principalTable: "Media",
                        principalColumn: "IdMedia");
                });

            migrationBuilder.CreateTable(
                name: "Room",
                columns: table => new
                {
                    IdPokoju = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Typ = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Numer = table.Column<int>(type: "int", nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: false),
                    LiczbaOsob = table.Column<int>(type: "int", nullable: false),
                    Cena = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MediaIdMedia = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Room", x => x.IdPokoju);
                    table.ForeignKey(
                        name: "FK_Room_Media_MediaIdMedia",
                        column: x => x.MediaIdMedia,
                        principalTable: "Media",
                        principalColumn: "IdMedia");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Atraction_MediaIdMedia",
                table: "Atraction",
                column: "MediaIdMedia");

            migrationBuilder.CreateIndex(
                name: "IX_Media_PageIdStrony",
                table: "Media",
                column: "PageIdStrony");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_UserIdUzytkownika",
                table: "Messages",
                column: "UserIdUzytkownika");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_UserIdUzytkownika1",
                table: "Messages",
                column: "UserIdUzytkownika1");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_UserIdUzytkownika",
                table: "Reservation",
                column: "UserIdUzytkownika");

            migrationBuilder.CreateIndex(
                name: "IX_Room_MediaIdMedia",
                table: "Room",
                column: "MediaIdMedia");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Atraction");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "Reservation");

            migrationBuilder.DropTable(
                name: "Room");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Media");

            migrationBuilder.DropTable(
                name: "Page");
        }
    }
}
