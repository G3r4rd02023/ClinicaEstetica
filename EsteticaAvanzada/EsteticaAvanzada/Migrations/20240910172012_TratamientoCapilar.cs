using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EsteticaAvanzada.Migrations
{
    /// <inheritdoc />
    public partial class TratamientoCapilar : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DepilacionLaser",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PacienteId = table.Column<int>(type: "int", nullable: true),
                    MotivoConsulta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AntecedentesPatologicos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaUltimaMenstruacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaUltimaExposicionSolar = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Medicamentos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Manchas = table.Column<bool>(type: "bit", nullable: false),
                    Verrugas = table.Column<bool>(type: "bit", nullable: false),
                    Vitiligio = table.Column<bool>(type: "bit", nullable: false),
                    Cicatrices = table.Column<bool>(type: "bit", nullable: false),
                    Quistes = table.Column<bool>(type: "bit", nullable: false),
                    Psoriasis = table.Column<bool>(type: "bit", nullable: false),
                    Eccemas = table.Column<bool>(type: "bit", nullable: false),
                    Forunculos = table.Column<bool>(type: "bit", nullable: false),
                    Acne = table.Column<bool>(type: "bit", nullable: false),
                    Observaciones = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tabaquismo = table.Column<bool>(type: "bit", nullable: false),
                    Alcoholismo = table.Column<bool>(type: "bit", nullable: false),
                    Drogas = table.Column<bool>(type: "bit", nullable: false),
                    ActividadFisica = table.Column<bool>(type: "bit", nullable: false),
                    SeAutomedica = table.Column<bool>(type: "bit", nullable: false),
                    Pasatiempos = table.Column<bool>(type: "bit", nullable: false),
                    Embarazada = table.Column<bool>(type: "bit", nullable: false),
                    MesesEmbarazo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CantidadHijos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MediaCara = table.Column<bool>(type: "bit", nullable: false),
                    CaraCompleta = table.Column<bool>(type: "bit", nullable: false),
                    Bigote = table.Column<bool>(type: "bit", nullable: false),
                    Axila = table.Column<bool>(type: "bit", nullable: false),
                    MedioBrazo = table.Column<bool>(type: "bit", nullable: false),
                    BrazoCompleto = table.Column<bool>(type: "bit", nullable: false),
                    MediaPierna = table.Column<bool>(type: "bit", nullable: false),
                    PiernaCompleta = table.Column<bool>(type: "bit", nullable: false),
                    Bikini = table.Column<bool>(type: "bit", nullable: false),
                    Gluteos = table.Column<bool>(type: "bit", nullable: false),
                    Espalda = table.Column<bool>(type: "bit", nullable: false),
                    SesionesProgramadasId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepilacionLaser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DepilacionLaser_Pacientes_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Pacientes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DepilacionLaser_SesionesProgramadas_SesionesProgramadasId",
                        column: x => x.SesionesProgramadasId,
                        principalTable: "SesionesProgramadas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "HistoriaNutricional",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PacienteId = table.Column<int>(type: "int", nullable: true),
                    AntecedentesPatologicos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Medicamentos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AntecedentesInmunoAlergicos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Procedimientos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Peso = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    Talla = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    IMC = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    Diagnostico = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlanTratamiento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MedidasCorporalesId = table.Column<int>(type: "int", nullable: true),
                    SesionesProgramadasId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoriaNutricional", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HistoriaNutricional_MedidasCorporales_MedidasCorporalesId",
                        column: x => x.MedidasCorporalesId,
                        principalTable: "MedidasCorporales",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HistoriaNutricional_Pacientes_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Pacientes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HistoriaNutricional_SesionesProgramadas_SesionesProgramadasId",
                        column: x => x.SesionesProgramadasId,
                        principalTable: "SesionesProgramadas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TratamientoCapilar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PacienteId = table.Column<int>(type: "int", nullable: true),
                    AntecedentesPatologicos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AntecedentesInmunoAlergicos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AntecedentesQuirurgicos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MotivoConsulta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Diagnostico = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlanTratamiento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SesionesProgramadasId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TratamientoCapilar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TratamientoCapilar_Pacientes_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Pacientes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TratamientoCapilar_SesionesProgramadas_SesionesProgramadasId",
                        column: x => x.SesionesProgramadasId,
                        principalTable: "SesionesProgramadas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DepilacionLaser_PacienteId",
                table: "DepilacionLaser",
                column: "PacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_DepilacionLaser_SesionesProgramadasId",
                table: "DepilacionLaser",
                column: "SesionesProgramadasId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoriaNutricional_MedidasCorporalesId",
                table: "HistoriaNutricional",
                column: "MedidasCorporalesId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoriaNutricional_PacienteId",
                table: "HistoriaNutricional",
                column: "PacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoriaNutricional_SesionesProgramadasId",
                table: "HistoriaNutricional",
                column: "SesionesProgramadasId");

            migrationBuilder.CreateIndex(
                name: "IX_TratamientoCapilar_PacienteId",
                table: "TratamientoCapilar",
                column: "PacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_TratamientoCapilar_SesionesProgramadasId",
                table: "TratamientoCapilar",
                column: "SesionesProgramadasId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DepilacionLaser");

            migrationBuilder.DropTable(
                name: "HistoriaNutricional");

            migrationBuilder.DropTable(
                name: "TratamientoCapilar");
        }
    }
}
