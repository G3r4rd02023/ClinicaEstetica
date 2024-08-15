using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EsteticaAvanzada.Migrations
{
    /// <inheritdoc />
    public partial class Zonas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Lado",
                table: "JuvedermAplicaciones");

            migrationBuilder.DropColumn(
                name: "VolumenDiluicion",
                table: "BotoxAplicaciones");

            migrationBuilder.RenameColumn(
                name: "FechaCaducidad",
                table: "BotoxAplicaciones",
                newName: "ProximaSesion");

            migrationBuilder.AddColumn<string>(
                name: "Observaciones",
                table: "JuvedermAplicaciones",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ZonasTratamiento",
                table: "JuvedermAplicaciones",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Observaciones",
                table: "BotoxAplicaciones",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ZonasAplicadas",
                table: "BotoxAplicaciones",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Observaciones",
                table: "JuvedermAplicaciones");

            migrationBuilder.DropColumn(
                name: "ZonasTratamiento",
                table: "JuvedermAplicaciones");

            migrationBuilder.DropColumn(
                name: "Observaciones",
                table: "BotoxAplicaciones");

            migrationBuilder.DropColumn(
                name: "ZonasAplicadas",
                table: "BotoxAplicaciones");

            migrationBuilder.RenameColumn(
                name: "ProximaSesion",
                table: "BotoxAplicaciones",
                newName: "FechaCaducidad");

            migrationBuilder.AddColumn<string>(
                name: "Lado",
                table: "JuvedermAplicaciones",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "VolumenDiluicion",
                table: "BotoxAplicaciones",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }
    }
}
