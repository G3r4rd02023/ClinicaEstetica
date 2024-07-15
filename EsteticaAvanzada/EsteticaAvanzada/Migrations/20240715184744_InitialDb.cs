using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EsteticaAvanzada.Migrations
{
    /// <inheritdoc />
    public partial class InitialDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pacientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombrePaciente = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Correo = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Contacto = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Sexo = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreCompleto = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Correo = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Contraseña = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    URLFoto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rol = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AntecedentesQuirurgicos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PacienteId = table.Column<int>(type: "int", nullable: false),
                    ImplantesEsteticos = table.Column<bool>(type: "bit", nullable: false),
                    Cirugia = table.Column<bool>(type: "bit", nullable: false),
                    Observaciones = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AntecedentesQuirurgicos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AntecedentesQuirurgicos_Pacientes_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Pacientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DiagnosticosTratamientos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PacienteId = table.Column<int>(type: "int", nullable: false),
                    Diagnostico = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Tratamiento = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    FirmaAutorizacion = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiagnosticosTratamientos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DiagnosticosTratamientos_Pacientes_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Pacientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EstadoSalud",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PacienteId = table.Column<int>(type: "int", nullable: false),
                    AlergiaMedicamentos = table.Column<bool>(type: "bit", nullable: false),
                    AlergiaAnestesicos = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    AlergiaCosmeticos = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    AlergiaPerfumes = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    AlergiaOtros = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Diabetes = table.Column<bool>(type: "bit", nullable: false),
                    Respiratorios = table.Column<bool>(type: "bit", nullable: false),
                    RespiratoriosEspecificar = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Cardiacos = table.Column<bool>(type: "bit", nullable: false),
                    CardiacosEspecificar = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Digestivos = table.Column<bool>(type: "bit", nullable: false),
                    DigestivosEspecificar = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Estreñimiento = table.Column<bool>(type: "bit", nullable: false),
                    Edemas = table.Column<bool>(type: "bit", nullable: false),
                    CaidaCabello = table.Column<bool>(type: "bit", nullable: false),
                    PortaMarcapasos = table.Column<bool>(type: "bit", nullable: false),
                    ProtesisMetalicas = table.Column<bool>(type: "bit", nullable: false),
                    LentesContacto = table.Column<bool>(type: "bit", nullable: false),
                    AntOncologicos = table.Column<bool>(type: "bit", nullable: false),
                    Tiroides = table.Column<bool>(type: "bit", nullable: false),
                    TiroidesEspecificar = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Convulsiones = table.Column<bool>(type: "bit", nullable: false),
                    Hipertension = table.Column<bool>(type: "bit", nullable: false),
                    Hipoglucemia = table.Column<bool>(type: "bit", nullable: false),
                    Sincope = table.Column<bool>(type: "bit", nullable: false),
                    OtrosPadecimientos = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    MedicamentosActuales = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Embarazos = table.Column<bool>(type: "bit", nullable: false),
                    Partos = table.Column<int>(type: "int", nullable: false),
                    Abortos = table.Column<int>(type: "int", nullable: false),
                    LactanciaMaterna = table.Column<bool>(type: "bit", nullable: false),
                    FechaUltimaMenstruacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MetodoAnticonceptivo = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    AltGlandular = table.Column<bool>(type: "bit", nullable: false),
                    AltHormonales = table.Column<bool>(type: "bit", nullable: false),
                    Cancer = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadoSalud", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EstadoSalud_Pacientes_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Pacientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Imagenes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PacienteId = table.Column<int>(type: "int", nullable: false),
                    NombreArchivo = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    RutaArchivo = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    FechaSubida = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Imagenes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Imagenes_Pacientes_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Pacientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MedidasCorporales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PacienteId = table.Column<int>(type: "int", nullable: false),
                    CinturaInicio = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    CinturaMedio = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    CinturaFinal = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    BustoInicio = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    ButoMedio = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    BustoFinal = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    CaderaInicio = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    CaderaMedio = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    CaderaFinal = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    AbdomenInicio = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    AbdomenMedio = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    AbdomenFinal = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    BrazoDerInicio = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    BrazoDerMedio = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    BrazoDerFinal = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    BrazoIzqInicio = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    BrazoIzqMedio = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    BrazoIzqFinal = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    MusloDerInicio = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    MusloDerMedio = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    MusloDerFinal = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    MusloIzqInicio = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    MusloIzqMedio = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    MusloIzqFinal = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    PantorrillaDerInicio = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    PantorrillaDerMedio = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    PantorillaDerFinal = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    PantorrillaIzqInicio = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    PantorrillaIzqMedio = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    PantorillaIzqFinal = table.Column<decimal>(type: "decimal(5,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedidasCorporales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedidasCorporales_Pacientes_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Pacientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MotivoConsultas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PacienteId = table.Column<int>(type: "int", nullable: false),
                    Envejecimiento = table.Column<bool>(type: "bit", nullable: false),
                    Acne = table.Column<bool>(type: "bit", nullable: false),
                    AdiposidadLocalizada = table.Column<bool>(type: "bit", nullable: false),
                    CuidadoPiel = table.Column<bool>(type: "bit", nullable: false),
                    Arrugas = table.Column<bool>(type: "bit", nullable: false),
                    Rosacea = table.Column<bool>(type: "bit", nullable: false),
                    Flacidez = table.Column<bool>(type: "bit", nullable: false),
                    Manchas = table.Column<bool>(type: "bit", nullable: false),
                    Celulitis = table.Column<bool>(type: "bit", nullable: false),
                    Estrias = table.Column<bool>(type: "bit", nullable: false),
                    Otros = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MotivoConsultas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MotivoConsultas_Pacientes_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Pacientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SesionesProgramadas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PacienteId = table.Column<int>(type: "int", nullable: false),
                    Sesion1Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Sesion2Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Sesion3Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Sesion4Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Sesion5Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Sesion6Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Sesion7Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Sesion8Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Sesion9Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Sesion10Fecha = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SesionesProgramadas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SesionesProgramadas_Pacientes_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Pacientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AntecedentesQuirurgicos_PacienteId",
                table: "AntecedentesQuirurgicos",
                column: "PacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_DiagnosticosTratamientos_PacienteId",
                table: "DiagnosticosTratamientos",
                column: "PacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_EstadoSalud_PacienteId",
                table: "EstadoSalud",
                column: "PacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Imagenes_PacienteId",
                table: "Imagenes",
                column: "PacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_MedidasCorporales_PacienteId",
                table: "MedidasCorporales",
                column: "PacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_MotivoConsultas_PacienteId",
                table: "MotivoConsultas",
                column: "PacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_SesionesProgramadas_PacienteId",
                table: "SesionesProgramadas",
                column: "PacienteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AntecedentesQuirurgicos");

            migrationBuilder.DropTable(
                name: "DiagnosticosTratamientos");

            migrationBuilder.DropTable(
                name: "EstadoSalud");

            migrationBuilder.DropTable(
                name: "Imagenes");

            migrationBuilder.DropTable(
                name: "MedidasCorporales");

            migrationBuilder.DropTable(
                name: "MotivoConsultas");

            migrationBuilder.DropTable(
                name: "SesionesProgramadas");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Pacientes");
        }
    }
}
