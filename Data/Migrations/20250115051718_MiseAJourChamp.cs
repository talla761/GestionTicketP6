using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionTicketP6.Data.Migrations
{
    /// <inheritdoc />
    public partial class MiseAJourChamp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Numero_Version",
                table: "Versions",
                newName: "NumeroVersion");

            migrationBuilder.RenameColumn(
                name: "Nom_OS",
                table: "SystemesExploitation",
                newName: "NomOS");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NumeroVersion",
                table: "Versions",
                newName: "Numero_Version");

            migrationBuilder.RenameColumn(
                name: "NomOS",
                table: "SystemesExploitation",
                newName: "Nom_OS");
        }
    }
}
