using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EsteticaAvanzada.Migrations
{
    /// <inheritdoc />
    public partial class PlanAplicacion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DNI",
                table: "Pacientes",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "PlanAplicacion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PacienteId = table.Column<int>(type: "int", nullable: false),
                    FechaAplicacionBotox = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaAplicacionJuvederm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RetornoEvaluacionFecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RetornoEvaluacionHora = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NuevaAplicacionFecha = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanAplicacion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlanAplicacion_Pacientes_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Pacientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BotoxAplicaciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlanAplicacionId = table.Column<int>(type: "int", nullable: false),
                    Frontal = table.Column<bool>(type: "bit", nullable: false),
                    Corrugador = table.Column<bool>(type: "bit", nullable: false),
                    Procerus = table.Column<bool>(type: "bit", nullable: false),
                    OrbicularOjos = table.Column<bool>(type: "bit", nullable: false),
                    Nasal = table.Column<bool>(type: "bit", nullable: false),
                    OrbicularLabios = table.Column<bool>(type: "bit", nullable: false),
                    Mentoniano = table.Column<bool>(type: "bit", nullable: false),
                    Otras = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    TotalUnidadesInyectadas = table.Column<int>(type: "int", nullable: false),
                    FechaCaducidad = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NumeroLote = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    VolumenDiluicion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BotoxAplicaciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BotoxAplicaciones_PlanAplicacion_PlanAplicacionId",
                        column: x => x.PlanAplicacionId,
                        principalTable: "PlanAplicacion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JuvedermAplicaciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlanAplicacionId = table.Column<int>(type: "int", nullable: false),
                    Lado = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Codigo = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    VolumenML = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    Producto = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JuvedermAplicaciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JuvedermAplicaciones_PlanAplicacion_PlanAplicacionId",
                        column: x => x.PlanAplicacionId,
                        principalTable: "PlanAplicacion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BotoxAplicaciones_PlanAplicacionId",
                table: "BotoxAplicaciones",
                column: "PlanAplicacionId");

            migrationBuilder.CreateIndex(
                name: "IX_JuvedermAplicaciones_PlanAplicacionId",
                table: "JuvedermAplicaciones",
                column: "PlanAplicacionId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanAplicacion_PacienteId",
                table: "PlanAplicacion",
                column: "PacienteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BotoxAplicaciones");

            migrationBuilder.DropTable(
                name: "JuvedermAplicaciones");

            migrationBuilder.DropTable(
                name: "PlanAplicacion");

            migrationBuilder.DropColumn(
                name: "DNI",
                table: "Pacientes");
        }
    }
}
