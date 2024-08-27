using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EsteticaAvanzada.Migrations
{
    /// <inheritdoc />
    public partial class Escalas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EscalaFizpatrick",
                table: "AnalisisEsteticos",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EscalaGoglau",
                table: "AnalisisEsteticos",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EscalaFizpatrick",
                table: "AnalisisEsteticos");

            migrationBuilder.DropColumn(
                name: "EscalaGoglau",
                table: "AnalisisEsteticos");
        }
    }
}
