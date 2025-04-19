using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRICKET_BOOKING_12425.Migrations
{
    /// <inheritdoc />
    public partial class Afjal24 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdminMasters",
                columns: table => new
                {
                    AdminMasterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CubName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Logo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Map = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EstabishDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminMasters", x => x.AdminMasterId);
                });

            migrationBuilder.CreateTable(
                name: "BookingsLimets",
                columns: table => new
                {
                    BookingLimetId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookingPerson = table.Column<int>(type: "int", nullable: true),
                    AdminMasterId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingsLimets", x => x.BookingLimetId);
                    table.ForeignKey(
                        name: "FK_BookingsLimets_AdminMasters_AdminMasterId",
                        column: x => x.AdminMasterId,
                        principalTable: "AdminMasters",
                        principalColumn: "AdminMasterId");
                });

            migrationBuilder.CreateTable(
                name: "Tournaments",
                columns: table => new
                {
                    TournamentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TournamentName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StarDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TournamentType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Logo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BookingLimetId = table.Column<int>(type: "int", nullable: true),
                    AdminMasterId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tournaments", x => x.TournamentId);
                    table.ForeignKey(
                        name: "FK_Tournaments_AdminMasters_AdminMasterId",
                        column: x => x.AdminMasterId,
                        principalTable: "AdminMasters",
                        principalColumn: "AdminMasterId");
                    table.ForeignKey(
                        name: "FK_Tournaments_BookingsLimets_BookingLimetId",
                        column: x => x.BookingLimetId,
                        principalTable: "BookingsLimets",
                        principalColumn: "BookingLimetId");
                });

            migrationBuilder.CreateTable(
                name: "BookingsTeams",
                columns: table => new
                {
                    BookingTeamsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TournamentId = table.Column<int>(type: "int", nullable: false),
                    TeamsName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CricHeroesUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CaptainName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VCaptainName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VContactNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Logo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BookingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AdminMasterId = table.Column<int>(type: "int", nullable: true),
                    BookingLimetId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingsTeams", x => x.BookingTeamsId);
                    table.ForeignKey(
                        name: "FK_BookingsTeams_AdminMasters_AdminMasterId",
                        column: x => x.AdminMasterId,
                        principalTable: "AdminMasters",
                        principalColumn: "AdminMasterId");
                    table.ForeignKey(
                        name: "FK_BookingsTeams_BookingsLimets_BookingLimetId",
                        column: x => x.BookingLimetId,
                        principalTable: "BookingsLimets",
                        principalColumn: "BookingLimetId");
                    table.ForeignKey(
                        name: "FK_BookingsTeams_Tournaments_TournamentId",
                        column: x => x.TournamentId,
                        principalTable: "Tournaments",
                        principalColumn: "TournamentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PoiteTables",
                columns: table => new
                {
                    PoiteTableId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookingTeamsId = table.Column<int>(type: "int", nullable: true),
                    PlayMatch = table.Column<int>(type: "int", nullable: true),
                    WinMatch = table.Column<int>(type: "int", nullable: true),
                    LostMatch = table.Column<int>(type: "int", nullable: true),
                    Poite = table.Column<double>(type: "float", nullable: true),
                    TournamentId = table.Column<int>(type: "int", nullable: true),
                    AdminMasterId = table.Column<int>(type: "int", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PoiteTables", x => x.PoiteTableId);
                    table.ForeignKey(
                        name: "FK_PoiteTables_AdminMasters_AdminMasterId",
                        column: x => x.AdminMasterId,
                        principalTable: "AdminMasters",
                        principalColumn: "AdminMasterId");
                    table.ForeignKey(
                        name: "FK_PoiteTables_BookingsTeams_BookingTeamsId",
                        column: x => x.BookingTeamsId,
                        principalTable: "BookingsTeams",
                        principalColumn: "BookingTeamsId");
                    table.ForeignKey(
                        name: "FK_PoiteTables_Tournaments_TournamentId",
                        column: x => x.TournamentId,
                        principalTable: "Tournaments",
                        principalColumn: "TournamentId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookingsLimets_AdminMasterId",
                table: "BookingsLimets",
                column: "AdminMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_BookingsTeams_AdminMasterId",
                table: "BookingsTeams",
                column: "AdminMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_BookingsTeams_BookingLimetId",
                table: "BookingsTeams",
                column: "BookingLimetId");

            migrationBuilder.CreateIndex(
                name: "IX_BookingsTeams_TournamentId",
                table: "BookingsTeams",
                column: "TournamentId");

            migrationBuilder.CreateIndex(
                name: "IX_PoiteTables_AdminMasterId",
                table: "PoiteTables",
                column: "AdminMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_PoiteTables_BookingTeamsId",
                table: "PoiteTables",
                column: "BookingTeamsId");

            migrationBuilder.CreateIndex(
                name: "IX_PoiteTables_TournamentId",
                table: "PoiteTables",
                column: "TournamentId");

            migrationBuilder.CreateIndex(
                name: "IX_Tournaments_AdminMasterId",
                table: "Tournaments",
                column: "AdminMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_Tournaments_BookingLimetId",
                table: "Tournaments",
                column: "BookingLimetId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PoiteTables");

            migrationBuilder.DropTable(
                name: "BookingsTeams");

            migrationBuilder.DropTable(
                name: "Tournaments");

            migrationBuilder.DropTable(
                name: "BookingsLimets");

            migrationBuilder.DropTable(
                name: "AdminMasters");
        }
    }
}
