using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EsteticaAvanzada.Migrations
{
    /// <inheritdoc />
    public partial class Depilacion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Sesion10Comentario",
                table: "SesionesProgramadas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Sesion11Comentario",
                table: "SesionesProgramadas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Sesion11Fecha",
                table: "SesionesProgramadas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Sesion12Comentario",
                table: "SesionesProgramadas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Sesion12Fecha",
                table: "SesionesProgramadas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Sesion1Comentario",
                table: "SesionesProgramadas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Sesion2Comentario",
                table: "SesionesProgramadas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Sesion3Comentario",
                table: "SesionesProgramadas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Sesion4Comentario",
                table: "SesionesProgramadas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Sesion5Comentario",
                table: "SesionesProgramadas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Sesion6Comentario",
                table: "SesionesProgramadas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Sesion7Comentario",
                table: "SesionesProgramadas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Sesion8Comentario",
                table: "SesionesProgramadas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Sesion9Comentario",
                table: "SesionesProgramadas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Profesion",
                table: "Pacientes",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Sesion10Comentario",
                table: "SesionesProgramadas");

            migrationBuilder.DropColumn(
                name: "Sesion11Comentario",
                table: "SesionesProgramadas");

            migrationBuilder.DropColumn(
                name: "Sesion11Fecha",
                table: "SesionesProgramadas");

            migrationBuilder.DropColumn(
                name: "Sesion12Comentario",
                table: "SesionesProgramadas");

            migrationBuilder.DropColumn(
                name: "Sesion12Fecha",
                table: "SesionesProgramadas");

            migrationBuilder.DropColumn(
                name: "Sesion1Comentario",
                table: "SesionesProgramadas");

            migrationBuilder.DropColumn(
                name: "Sesion2Comentario",
                table: "SesionesProgramadas");

            migrationBuilder.DropColumn(
                name: "Sesion3Comentario",
                table: "SesionesProgramadas");

            migrationBuilder.DropColumn(
                name: "Sesion4Comentario",
                table: "SesionesProgramadas");

            migrationBuilder.DropColumn(
                name: "Sesion5Comentario",
                table: "SesionesProgramadas");

            migrationBuilder.DropColumn(
                name: "Sesion6Comentario",
                table: "SesionesProgramadas");

            migrationBuilder.DropColumn(
                name: "Sesion7Comentario",
                table: "SesionesProgramadas");

            migrationBuilder.DropColumn(
                name: "Sesion8Comentario",
                table: "SesionesProgramadas");

            migrationBuilder.DropColumn(
                name: "Sesion9Comentario",
                table: "SesionesProgramadas");

            migrationBuilder.DropColumn(
                name: "Profesion",
                table: "Pacientes");
        }
    }
}
