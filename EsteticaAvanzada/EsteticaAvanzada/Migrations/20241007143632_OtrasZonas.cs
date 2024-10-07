using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EsteticaAvanzada.Migrations
{
    /// <inheritdoc />
    public partial class OtrasZonas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EspecifiqueZona",
                table: "DepilacionLaser",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "OtraZona",
                table: "DepilacionLaser",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EspecifiqueZona",
                table: "DepilacionLaser");

            migrationBuilder.DropColumn(
                name: "OtraZona",
                table: "DepilacionLaser");
        }
    }
}
