using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionTicketP6.Data.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Produits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produits", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SystemesExploitation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom_OS = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemesExploitation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Versions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Numero_Version = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    IdProduit = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Versions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Versions_Produits_IdProduit",
                        column: x => x.IdProduit,
                        principalTable: "Produits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Compatibilites",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdVersion = table.Column<int>(type: "int", nullable: false),
                    IdOs = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compatibilites", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Compatibilites_SystemesExploitation_IdOs",
                        column: x => x.IdOs,
                        principalTable: "SystemesExploitation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Compatibilites_Versions_IdVersion",
                        column: x => x.IdVersion,
                        principalTable: "Versions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date_Creation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Date_Resolution = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Statut = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Probleme = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Resolution = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdVersion = table.Column<int>(type: "int", nullable: false),
                    IdOs = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tickets_SystemesExploitation_IdOs",
                        column: x => x.IdOs,
                        principalTable: "SystemesExploitation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tickets_Versions_IdVersion",
                        column: x => x.IdVersion,
                        principalTable: "Versions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Compatibilites_IdOs",
                table: "Compatibilites",
                column: "IdOs");

            migrationBuilder.CreateIndex(
                name: "IX_Compatibilites_IdVersion",
                table: "Compatibilites",
                column: "IdVersion");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_IdOs",
                table: "Tickets",
                column: "IdOs");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_IdVersion",
                table: "Tickets",
                column: "IdVersion");

            migrationBuilder.CreateIndex(
                name: "IX_Versions_IdProduit",
                table: "Versions",
                column: "IdProduit");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Compatibilites");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "SystemesExploitation");

            migrationBuilder.DropTable(
                name: "Versions");

            migrationBuilder.DropTable(
                name: "Produits");
        }
    }
}
