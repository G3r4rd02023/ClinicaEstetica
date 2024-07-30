using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EsteticaAvanzada.Migrations
{
    /// <inheritdoc />
    public partial class DatosEsteticos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AltGlandular",
                table: "EstadoSalud");

            migrationBuilder.DropColumn(
                name: "AltHormonales",
                table: "EstadoSalud");

            migrationBuilder.DropColumn(
                name: "Cancer",
                table: "EstadoSalud");

            migrationBuilder.AlterColumn<string>(
                name: "TiroidesEspecificar",
                table: "EstadoSalud",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Artritis",
                table: "EstadoSalud",
                type: "bit",
                maxLength: 255,
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Cesareas",
                table: "EstadoSalud",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "AnalisisEsteticos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PacienteId = table.Column<int>(type: "int", nullable: false),
                    PielNormal = table.Column<bool>(type: "bit", nullable: false),
                    PielMixta = table.Column<bool>(type: "bit", nullable: false),
                    PielHidratada = table.Column<bool>(type: "bit", nullable: false),
                    PielDesvitalizada = table.Column<bool>(type: "bit", nullable: false),
                    PielSeca = table.Column<bool>(type: "bit", nullable: false),
                    PielGrasa = table.Column<bool>(type: "bit", nullable: false),
                    DeshidratacionLeve = table.Column<bool>(type: "bit", nullable: false),
                    DeshidratacionMedio = table.Column<bool>(type: "bit", nullable: false),
                    DeshidratacionAlta = table.Column<bool>(type: "bit", nullable: false),
                    Nevus = table.Column<bool>(type: "bit", nullable: false),
                    Macula = table.Column<bool>(type: "bit", nullable: false),
                    Acne = table.Column<bool>(type: "bit", nullable: false),
                    Cicatrices = table.Column<bool>(type: "bit", nullable: false),
                    Telangiectasias = table.Column<bool>(type: "bit", nullable: false),
                    EspecifiqueOtros = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    PorosAbiertos = table.Column<bool>(type: "bit", nullable: false),
                    PorosContraidos = table.Column<bool>(type: "bit", nullable: false),
                    PorosSemivisibles = table.Column<bool>(type: "bit", nullable: false),
                    TexturaFina = table.Column<bool>(type: "bit", nullable: false),
                    TexturaMediana = table.Column<bool>(type: "bit", nullable: false),
                    TexturaGruesa = table.Column<bool>(type: "bit", nullable: false),
                    ComedonesBlancos = table.Column<bool>(type: "bit", nullable: false),
                    ComedonesNegros = table.Column<bool>(type: "bit", nullable: false),
                    ComedonesNinguno = table.Column<bool>(type: "bit", nullable: false),
                    OrbicularesOjos = table.Column<bool>(type: "bit", nullable: false),
                    Nasogenianos = table.Column<bool>(type: "bit", nullable: false),
                    Frontales = table.Column<bool>(type: "bit", nullable: false),
                    Labios = table.Column<bool>(type: "bit", nullable: false),
                    ProductosUsados = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    DiagnosticoEstetico = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ObjetivosTratamiento = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    TratamientoProposito = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Observaciones = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ConsentimientoInformado = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnalisisEsteticos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnalisisEsteticos_Pacientes_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Pacientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AntecedentesFamiliares",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PacienteId = table.Column<int>(type: "int", nullable: false),
                    Diabetes = table.Column<bool>(type: "bit", nullable: false),
                    Cancer = table.Column<bool>(type: "bit", nullable: false),
                    Asma = table.Column<bool>(type: "bit", nullable: false),
                    Otro = table.Column<bool>(type: "bit", nullable: false),
                    HTA = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AntecedentesFamiliares", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AntecedentesFamiliares_Pacientes_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Pacientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DatosEsteticos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PacienteId = table.Column<int>(type: "int", nullable: false),
                    Menton = table.Column<bool>(type: "bit", nullable: false),
                    Mejillas = table.Column<bool>(type: "bit", nullable: false),
                    Nariz = table.Column<bool>(type: "bit", nullable: false),
                    NingunImplante = table.Column<bool>(type: "bit", nullable: false),
                    Blefaroplastia = table.Column<bool>(type: "bit", nullable: false),
                    Rinoplastia = table.Column<bool>(type: "bit", nullable: false),
                    Otoplastia = table.Column<bool>(type: "bit", nullable: false),
                    Lifting = table.Column<bool>(type: "bit", nullable: false),
                    Bichectomia = table.Column<bool>(type: "bit", nullable: false),
                    Septoplastia = table.Column<bool>(type: "bit", nullable: false),
                    NingunaCirugia = table.Column<bool>(type: "bit", nullable: false),
                    Botox = table.Column<bool>(type: "bit", nullable: false),
                    Plasma = table.Column<bool>(type: "bit", nullable: false),
                    VitaminaC = table.Column<bool>(type: "bit", nullable: false),
                    AcidoHialuronico = table.Column<bool>(type: "bit", nullable: false),
                    NingunProcedimiento = table.Column<bool>(type: "bit", nullable: false),
                    HaceCuantoTiempo = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DatosEsteticos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DatosEsteticos_Pacientes_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Pacientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Habitos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PacienteId = table.Column<int>(type: "int", nullable: false),
                    Alcohol = table.Column<bool>(type: "bit", nullable: false),
                    Tabaco = table.Column<bool>(type: "bit", nullable: false),
                    UltimaIngesta = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Frecuencia = table.Column<int>(type: "int", nullable: false),
                    Drogas = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    PracticaDeporte = table.Column<bool>(type: "bit", nullable: false),
                    EspecifiqueDeporte = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    HorasSueño = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Habitos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Habitos_Pacientes_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Pacientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnalisisEsteticos_PacienteId",
                table: "AnalisisEsteticos",
                column: "PacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_AntecedentesFamiliares_PacienteId",
                table: "AntecedentesFamiliares",
                column: "PacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_DatosEsteticos_PacienteId",
                table: "DatosEsteticos",
                column: "PacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Habitos_PacienteId",
                table: "Habitos",
                column: "PacienteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnalisisEsteticos");

            migrationBuilder.DropTable(
                name: "AntecedentesFamiliares");

            migrationBuilder.DropTable(
                name: "DatosEsteticos");

            migrationBuilder.DropTable(
                name: "Habitos");

            migrationBuilder.DropColumn(
                name: "Artritis",
                table: "EstadoSalud");

            migrationBuilder.DropColumn(
                name: "Cesareas",
                table: "EstadoSalud");

            migrationBuilder.AlterColumn<string>(
                name: "TiroidesEspecificar",
                table: "EstadoSalud",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "AltGlandular",
                table: "EstadoSalud",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "AltHormonales",
                table: "EstadoSalud",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Cancer",
                table: "EstadoSalud",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
