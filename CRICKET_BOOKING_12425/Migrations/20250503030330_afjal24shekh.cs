using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRICKET_BOOKING_12425.Migrations
{
    /// <inheritdoc />
    public partial class afjal24shekh : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MaineAdmins",
                columns: table => new
                {
                    MaineAdminId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Logo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MapAdress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaineAdmins", x => x.MaineAdminId);
                });

            migrationBuilder.CreateTable(
                name: "AdminNews",
                columns: table => new
                {
                    AdminNewsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imag = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaineAdminId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminNews", x => x.AdminNewsId);
                    table.ForeignKey(
                        name: "FK_AdminNews_MaineAdmins_MaineAdminId",
                        column: x => x.MaineAdminId,
                        principalTable: "MaineAdmins",
                        principalColumn: "MaineAdminId");
                });

            migrationBuilder.CreateTable(
                name: "AdminTeams",
                columns: table => new
                {
                    AdminteamsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imgs = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaineAdminId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminTeams", x => x.AdminteamsId);
                    table.ForeignKey(
                        name: "FK_AdminTeams_MaineAdmins_MaineAdminId",
                        column: x => x.MaineAdminId,
                        principalTable: "MaineAdmins",
                        principalColumn: "MaineAdminId");
                });

            migrationBuilder.CreateTable(
                name: "AdminVideos",
                columns: table => new
                {
                    AdminVideoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Video = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaineAdminId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminVideos", x => x.AdminVideoId);
                    table.ForeignKey(
                        name: "FK_AdminVideos_MaineAdmins_MaineAdminId",
                        column: x => x.MaineAdminId,
                        principalTable: "MaineAdmins",
                        principalColumn: "MaineAdminId");
                });

            migrationBuilder.CreateTable(
                name: "Contact",
                columns: table => new
                {
                    ContactId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaineAdminId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contact", x => x.ContactId);
                    table.ForeignKey(
                        name: "FK_Contact_MaineAdmins_MaineAdminId",
                        column: x => x.MaineAdminId,
                        principalTable: "MaineAdmins",
                        principalColumn: "MaineAdminId");
                });

            migrationBuilder.CreateTable(
                name: "HeaderImgs",
                columns: table => new
                {
                    HeaderImgId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imgs = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaineAdminId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HeaderImgs", x => x.HeaderImgId);
                    table.ForeignKey(
                        name: "FK_HeaderImgs_MaineAdmins_MaineAdminId",
                        column: x => x.MaineAdminId,
                        principalTable: "MaineAdmins",
                        principalColumn: "MaineAdminId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdminNews_MaineAdminId",
                table: "AdminNews",
                column: "MaineAdminId");

            migrationBuilder.CreateIndex(
                name: "IX_AdminTeams_MaineAdminId",
                table: "AdminTeams",
                column: "MaineAdminId");

            migrationBuilder.CreateIndex(
                name: "IX_AdminVideos_MaineAdminId",
                table: "AdminVideos",
                column: "MaineAdminId");

            migrationBuilder.CreateIndex(
                name: "IX_Contact_MaineAdminId",
                table: "Contact",
                column: "MaineAdminId");

            migrationBuilder.CreateIndex(
                name: "IX_HeaderImgs_MaineAdminId",
                table: "HeaderImgs",
                column: "MaineAdminId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdminNews");

            migrationBuilder.DropTable(
                name: "AdminTeams");

            migrationBuilder.DropTable(
                name: "AdminVideos");

            migrationBuilder.DropTable(
                name: "Contact");

            migrationBuilder.DropTable(
                name: "HeaderImgs");

            migrationBuilder.DropTable(
                name: "MaineAdmins");
        }
    }
}
