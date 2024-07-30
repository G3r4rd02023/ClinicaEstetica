using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EsteticaAvanzada.Migrations
{
    /// <inheritdoc />
    public partial class Hospitalizaciones : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "HispitalizacionesEspecificar",
                table: "AntecedentesQuirurgicos",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Hospitalizaciones",
                table: "AntecedentesQuirurgicos",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HispitalizacionesEspecificar",
                table: "AntecedentesQuirurgicos");

            migrationBuilder.DropColumn(
                name: "Hospitalizaciones",
                table: "AntecedentesQuirurgicos");
        }
    }
}
