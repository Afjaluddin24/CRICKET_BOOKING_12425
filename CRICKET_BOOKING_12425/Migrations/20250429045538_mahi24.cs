using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRICKET_BOOKING_12425.Migrations
{
    /// <inheritdoc />
    public partial class mahi24 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "New",
                columns: table => new
                {
                    NewsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Imgs = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Publisheddate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sore = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TournamentId = table.Column<int>(type: "int", nullable: true),
                    AdminMasterId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_New", x => x.NewsId);
                    table.ForeignKey(
                        name: "FK_New_AdminMasters_AdminMasterId",
                        column: x => x.AdminMasterId,
                        principalTable: "AdminMasters",
                        principalColumn: "AdminMasterId");
                    table.ForeignKey(
                        name: "FK_New_Tournaments_TournamentId",
                        column: x => x.TournamentId,
                        principalTable: "Tournaments",
                        principalColumn: "TournamentId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_New_AdminMasterId",
                table: "New",
                column: "AdminMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_New_TournamentId",
                table: "New",
                column: "TournamentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "New");
        }
    }
}
