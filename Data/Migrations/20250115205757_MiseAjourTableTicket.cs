using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionTicketP6.Data.Migrations
{
    /// <inheritdoc />
    public partial class MiseAjourTableTicket : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Date_Resolution",
                table: "Tickets",
                newName: "DateResolution");

            migrationBuilder.RenameColumn(
                name: "Date_Creation",
                table: "Tickets",
                newName: "DateCreation");

            migrationBuilder.AlterColumn<string>(
                name: "Resolution",
                table: "Tickets",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateResolution",
                table: "Tickets",
                newName: "Date_Resolution");

            migrationBuilder.RenameColumn(
                name: "DateCreation",
                table: "Tickets",
                newName: "Date_Creation");

            migrationBuilder.AlterColumn<string>(
                name: "Resolution",
                table: "Tickets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
