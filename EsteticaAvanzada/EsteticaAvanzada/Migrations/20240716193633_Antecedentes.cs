using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EsteticaAvanzada.Migrations
{
    /// <inheritdoc />
    public partial class Antecedentes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AntOncologicosEspecificar",
                table: "EstadoSalud",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AntOncologicosEspecificar",
                table: "EstadoSalud");
        }
    }
}
