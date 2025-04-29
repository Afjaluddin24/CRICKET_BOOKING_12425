using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRICKET_BOOKING_12425.Migrations
{
    /// <inheritdoc />
    public partial class viratafjal24 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_New_AdminMasters_AdminMasterId",
                table: "New");

            migrationBuilder.DropForeignKey(
                name: "FK_New_Tournaments_TournamentId",
                table: "New");

            migrationBuilder.DropPrimaryKey(
                name: "PK_New",
                table: "New");

            migrationBuilder.RenameTable(
                name: "New",
                newName: "News");

            migrationBuilder.RenameIndex(
                name: "IX_New_TournamentId",
                table: "News",
                newName: "IX_News_TournamentId");

            migrationBuilder.RenameIndex(
                name: "IX_New_AdminMasterId",
                table: "News",
                newName: "IX_News_AdminMasterId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_News",
                table: "News",
                column: "NewsId");

            migrationBuilder.AddForeignKey(
                name: "FK_News_AdminMasters_AdminMasterId",
                table: "News",
                column: "AdminMasterId",
                principalTable: "AdminMasters",
                principalColumn: "AdminMasterId");

            migrationBuilder.AddForeignKey(
                name: "FK_News_Tournaments_TournamentId",
                table: "News",
                column: "TournamentId",
                principalTable: "Tournaments",
                principalColumn: "TournamentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_News_AdminMasters_AdminMasterId",
                table: "News");

            migrationBuilder.DropForeignKey(
                name: "FK_News_Tournaments_TournamentId",
                table: "News");

            migrationBuilder.DropPrimaryKey(
                name: "PK_News",
                table: "News");

            migrationBuilder.RenameTable(
                name: "News",
                newName: "New");

            migrationBuilder.RenameIndex(
                name: "IX_News_TournamentId",
                table: "New",
                newName: "IX_New_TournamentId");

            migrationBuilder.RenameIndex(
                name: "IX_News_AdminMasterId",
                table: "New",
                newName: "IX_New_AdminMasterId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_New",
                table: "New",
                column: "NewsId");

            migrationBuilder.AddForeignKey(
                name: "FK_New_AdminMasters_AdminMasterId",
                table: "New",
                column: "AdminMasterId",
                principalTable: "AdminMasters",
                principalColumn: "AdminMasterId");

            migrationBuilder.AddForeignKey(
                name: "FK_New_Tournaments_TournamentId",
                table: "New",
                column: "TournamentId",
                principalTable: "Tournaments",
                principalColumn: "TournamentId");
        }
    }
}
