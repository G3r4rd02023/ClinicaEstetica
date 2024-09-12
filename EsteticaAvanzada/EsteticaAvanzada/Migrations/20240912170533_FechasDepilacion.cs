using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EsteticaAvanzada.Migrations
{
    /// <inheritdoc />
    public partial class FechasDepilacion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DepilacionLaser_Pacientes_PacienteId",
                table: "DepilacionLaser");

            migrationBuilder.DropForeignKey(
                name: "FK_TratamientoCapilar_Pacientes_PacienteId",
                table: "TratamientoCapilar");

            migrationBuilder.AlterColumn<int>(
                name: "PacienteId",
                table: "TratamientoCapilar",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PacienteId",
                table: "DepilacionLaser",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaUltimaMenstruacion",
                table: "DepilacionLaser",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaUltimaExposicionSolar",
                table: "DepilacionLaser",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddForeignKey(
                name: "FK_DepilacionLaser_Pacientes_PacienteId",
                table: "DepilacionLaser",
                column: "PacienteId",
                principalTable: "Pacientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TratamientoCapilar_Pacientes_PacienteId",
                table: "TratamientoCapilar",
                column: "PacienteId",
                principalTable: "Pacientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DepilacionLaser_Pacientes_PacienteId",
                table: "DepilacionLaser");

            migrationBuilder.DropForeignKey(
                name: "FK_TratamientoCapilar_Pacientes_PacienteId",
                table: "TratamientoCapilar");

            migrationBuilder.AlterColumn<int>(
                name: "PacienteId",
                table: "TratamientoCapilar",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "PacienteId",
                table: "DepilacionLaser",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaUltimaMenstruacion",
                table: "DepilacionLaser",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaUltimaExposicionSolar",
                table: "DepilacionLaser",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DepilacionLaser_Pacientes_PacienteId",
                table: "DepilacionLaser",
                column: "PacienteId",
                principalTable: "Pacientes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TratamientoCapilar_Pacientes_PacienteId",
                table: "TratamientoCapilar",
                column: "PacienteId",
                principalTable: "Pacientes",
                principalColumn: "Id");
        }
    }
}
