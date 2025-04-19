using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRICKET_BOOKING_12425.Migrations
{
    /// <inheritdoc />
    public partial class virat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cricket_Matches_AdminMasters_AdminMasterId",
                table: "Cricket_Matches");

            migrationBuilder.DropForeignKey(
                name: "FK_Cricket_Matches_BookingsTeams_BookingTeamsId",
                table: "Cricket_Matches");

            migrationBuilder.DropForeignKey(
                name: "FK_Cricket_Matches_Tournaments_TournamentId",
                table: "Cricket_Matches");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cricket_Matches",
                table: "Cricket_Matches");

            migrationBuilder.RenameTable(
                name: "Cricket_Matches",
                newName: "CricketMatches");

            migrationBuilder.RenameIndex(
                name: "IX_Cricket_Matches_TournamentId",
                table: "CricketMatches",
                newName: "IX_CricketMatches_TournamentId");

            migrationBuilder.RenameIndex(
                name: "IX_Cricket_Matches_BookingTeamsId",
                table: "CricketMatches",
                newName: "IX_CricketMatches_BookingTeamsId");

            migrationBuilder.RenameIndex(
                name: "IX_Cricket_Matches_AdminMasterId",
                table: "CricketMatches",
                newName: "IX_CricketMatches_AdminMasterId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CricketMatches",
                table: "CricketMatches",
                column: "CricketMatchesId");

            migrationBuilder.AddForeignKey(
                name: "FK_CricketMatches_AdminMasters_AdminMasterId",
                table: "CricketMatches",
                column: "AdminMasterId",
                principalTable: "AdminMasters",
                principalColumn: "AdminMasterId");

            migrationBuilder.AddForeignKey(
                name: "FK_CricketMatches_BookingsTeams_BookingTeamsId",
                table: "CricketMatches",
                column: "BookingTeamsId",
                principalTable: "BookingsTeams",
                principalColumn: "BookingTeamsId");

            migrationBuilder.AddForeignKey(
                name: "FK_CricketMatches_Tournaments_TournamentId",
                table: "CricketMatches",
                column: "TournamentId",
                principalTable: "Tournaments",
                principalColumn: "TournamentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CricketMatches_AdminMasters_AdminMasterId",
                table: "CricketMatches");

            migrationBuilder.DropForeignKey(
                name: "FK_CricketMatches_BookingsTeams_BookingTeamsId",
                table: "CricketMatches");

            migrationBuilder.DropForeignKey(
                name: "FK_CricketMatches_Tournaments_TournamentId",
                table: "CricketMatches");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CricketMatches",
                table: "CricketMatches");

            migrationBuilder.RenameTable(
                name: "CricketMatches",
                newName: "Cricket_Matches");

            migrationBuilder.RenameIndex(
                name: "IX_CricketMatches_TournamentId",
                table: "Cricket_Matches",
                newName: "IX_Cricket_Matches_TournamentId");

            migrationBuilder.RenameIndex(
                name: "IX_CricketMatches_BookingTeamsId",
                table: "Cricket_Matches",
                newName: "IX_Cricket_Matches_BookingTeamsId");

            migrationBuilder.RenameIndex(
                name: "IX_CricketMatches_AdminMasterId",
                table: "Cricket_Matches",
                newName: "IX_Cricket_Matches_AdminMasterId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cricket_Matches",
                table: "Cricket_Matches",
                column: "CricketMatchesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cricket_Matches_AdminMasters_AdminMasterId",
                table: "Cricket_Matches",
                column: "AdminMasterId",
                principalTable: "AdminMasters",
                principalColumn: "AdminMasterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cricket_Matches_BookingsTeams_BookingTeamsId",
                table: "Cricket_Matches",
                column: "BookingTeamsId",
                principalTable: "BookingsTeams",
                principalColumn: "BookingTeamsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cricket_Matches_Tournaments_TournamentId",
                table: "Cricket_Matches",
                column: "TournamentId",
                principalTable: "Tournaments",
                principalColumn: "TournamentId");
        }
    }
}
