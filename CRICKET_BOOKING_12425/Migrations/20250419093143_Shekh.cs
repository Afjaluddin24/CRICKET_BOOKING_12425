using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRICKET_BOOKING_12425.Migrations
{
    /// <inheritdoc />
    public partial class Shekh : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cricket_Matches",
                columns: table => new
                {
                    CricketMatchesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TournamentId = table.Column<int>(type: "int", nullable: true),
                    BookingTeamsId = table.Column<int>(type: "int", nullable: true),
                    TeamA = table.Column<int>(type: "int", nullable: true),
                    TeamB = table.Column<int>(type: "int", nullable: true),
                    MatchDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Venue = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Match_type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Match_status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClubName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdminMasterId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cricket_Matches", x => x.CricketMatchesId);
                    table.ForeignKey(
                        name: "FK_Cricket_Matches_AdminMasters_AdminMasterId",
                        column: x => x.AdminMasterId,
                        principalTable: "AdminMasters",
                        principalColumn: "AdminMasterId");
                    table.ForeignKey(
                        name: "FK_Cricket_Matches_BookingsTeams_BookingTeamsId",
                        column: x => x.BookingTeamsId,
                        principalTable: "BookingsTeams",
                        principalColumn: "BookingTeamsId");
                    table.ForeignKey(
                        name: "FK_Cricket_Matches_Tournaments_TournamentId",
                        column: x => x.TournamentId,
                        principalTable: "Tournaments",
                        principalColumn: "TournamentId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cricket_Matches_AdminMasterId",
                table: "Cricket_Matches",
                column: "AdminMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_Cricket_Matches_BookingTeamsId",
                table: "Cricket_Matches",
                column: "BookingTeamsId");

            migrationBuilder.CreateIndex(
                name: "IX_Cricket_Matches_TournamentId",
                table: "Cricket_Matches",
                column: "TournamentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cricket_Matches");
        }
    }
}
