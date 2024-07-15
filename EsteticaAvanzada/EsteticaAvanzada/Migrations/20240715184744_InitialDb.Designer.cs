﻿// <auto-generated />
using System;
using EsteticaAvanzada.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EsteticaAvanzada.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20240715184744_InitialDb")]
    partial class InitialDb
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EsteticaAvanzada.Data.Entidades.AntecedentesQuirurgicos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Cirugia")
                        .HasColumnType("bit");

                    b.Property<bool>("ImplantesEsteticos")
                        .HasColumnType("bit");

                    b.Property<string>("Observaciones")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("PacienteId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PacienteId");

                    b.ToTable("AntecedentesQuirurgicos");
                });

            modelBuilder.Entity("EsteticaAvanzada.Data.Entidades.DiagnosticoTratamiento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Diagnostico")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("FirmaAutorizacion")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("PacienteId")
                        .HasColumnType("int");

                    b.Property<string>("Tratamiento")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("PacienteId");

                    b.ToTable("DiagnosticosTratamientos");
                });

            modelBuilder.Entity("EsteticaAvanzada.Data.Entidades.EstadoSalud", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Abortos")
                        .HasColumnType("int");

                    b.Property<string>("AlergiaAnestesicos")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("AlergiaCosmeticos")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<bool>("AlergiaMedicamentos")
                        .HasColumnType("bit");

                    b.Property<string>("AlergiaOtros")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("AlergiaPerfumes")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<bool>("AltGlandular")
                        .HasColumnType("bit");

                    b.Property<bool>("AltHormonales")
                        .HasColumnType("bit");

                    b.Property<bool>("AntOncologicos")
                        .HasColumnType("bit");

                    b.Property<bool>("CaidaCabello")
                        .HasColumnType("bit");

                    b.Property<bool>("Cancer")
                        .HasColumnType("bit");

                    b.Property<bool>("Cardiacos")
                        .HasColumnType("bit");

                    b.Property<string>("CardiacosEspecificar")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<bool>("Convulsiones")
                        .HasColumnType("bit");

                    b.Property<bool>("Diabetes")
                        .HasColumnType("bit");

                    b.Property<bool>("Digestivos")
                        .HasColumnType("bit");

                    b.Property<string>("DigestivosEspecificar")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<bool>("Edemas")
                        .HasColumnType("bit");

                    b.Property<bool>("Embarazos")
                        .HasColumnType("bit");

                    b.Property<bool>("Estreñimiento")
                        .HasColumnType("bit");

                    b.Property<DateTime>("FechaUltimaMenstruacion")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Hipertension")
                        .HasColumnType("bit");

                    b.Property<bool>("Hipoglucemia")
                        .HasColumnType("bit");

                    b.Property<bool>("LactanciaMaterna")
                        .HasColumnType("bit");

                    b.Property<bool>("LentesContacto")
                        .HasColumnType("bit");

                    b.Property<string>("MedicamentosActuales")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("MetodoAnticonceptivo")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("OtrosPadecimientos")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("PacienteId")
                        .HasColumnType("int");

                    b.Property<int>("Partos")
                        .HasColumnType("int");

                    b.Property<bool>("PortaMarcapasos")
                        .HasColumnType("bit");

                    b.Property<bool>("ProtesisMetalicas")
                        .HasColumnType("bit");

                    b.Property<bool>("Respiratorios")
                        .HasColumnType("bit");

                    b.Property<string>("RespiratoriosEspecificar")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<bool>("Sincope")
                        .HasColumnType("bit");

                    b.Property<bool>("Tiroides")
                        .HasColumnType("bit");

                    b.Property<string>("TiroidesEspecificar")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("PacienteId");

                    b.ToTable("EstadoSalud");
                });

            modelBuilder.Entity("EsteticaAvanzada.Data.Entidades.Imagenes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("FechaSubida")
                        .HasColumnType("datetime2");

                    b.Property<string>("NombreArchivo")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("PacienteId")
                        .HasColumnType("int");

                    b.Property<string>("RutaArchivo")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("PacienteId");

                    b.ToTable("Imagenes");
                });

            modelBuilder.Entity("EsteticaAvanzada.Data.Entidades.MedidasCorporales", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("AbdomenFinal")
                        .HasColumnType("decimal(5,2)");

                    b.Property<decimal>("AbdomenInicio")
                        .HasColumnType("decimal(5,2)");

                    b.Property<decimal>("AbdomenMedio")
                        .HasColumnType("decimal(5,2)");

                    b.Property<decimal>("BrazoDerFinal")
                        .HasColumnType("decimal(5,2)");

                    b.Property<decimal>("BrazoDerInicio")
                        .HasColumnType("decimal(5,2)");

                    b.Property<decimal>("BrazoDerMedio")
                        .HasColumnType("decimal(5,2)");

                    b.Property<decimal>("BrazoIzqFinal")
                        .HasColumnType("decimal(5,2)");

                    b.Property<decimal>("BrazoIzqInicio")
                        .HasColumnType("decimal(5,2)");

                    b.Property<decimal>("BrazoIzqMedio")
                        .HasColumnType("decimal(5,2)");

                    b.Property<decimal>("BustoFinal")
                        .HasColumnType("decimal(5,2)");

                    b.Property<decimal>("BustoInicio")
                        .HasColumnType("decimal(5,2)");

                    b.Property<decimal>("ButoMedio")
                        .HasColumnType("decimal(5,2)");

                    b.Property<decimal>("CaderaFinal")
                        .HasColumnType("decimal(5,2)");

                    b.Property<decimal>("CaderaInicio")
                        .HasColumnType("decimal(5,2)");

                    b.Property<decimal>("CaderaMedio")
                        .HasColumnType("decimal(5,2)");

                    b.Property<decimal>("CinturaFinal")
                        .HasColumnType("decimal(5,2)");

                    b.Property<decimal>("CinturaInicio")
                        .HasColumnType("decimal(5,2)");

                    b.Property<decimal>("CinturaMedio")
                        .HasColumnType("decimal(5,2)");

                    b.Property<decimal>("MusloDerFinal")
                        .HasColumnType("decimal(5,2)");

                    b.Property<decimal>("MusloDerInicio")
                        .HasColumnType("decimal(5,2)");

                    b.Property<decimal>("MusloDerMedio")
                        .HasColumnType("decimal(5,2)");

                    b.Property<decimal>("MusloIzqFinal")
                        .HasColumnType("decimal(5,2)");

                    b.Property<decimal>("MusloIzqInicio")
                        .HasColumnType("decimal(5,2)");

                    b.Property<decimal>("MusloIzqMedio")
                        .HasColumnType("decimal(5,2)");

                    b.Property<int>("PacienteId")
                        .HasColumnType("int");

                    b.Property<decimal>("PantorillaDerFinal")
                        .HasColumnType("decimal(5,2)");

                    b.Property<decimal>("PantorillaIzqFinal")
                        .HasColumnType("decimal(5,2)");

                    b.Property<decimal>("PantorrillaDerInicio")
                        .HasColumnType("decimal(5,2)");

                    b.Property<decimal>("PantorrillaDerMedio")
                        .HasColumnType("decimal(5,2)");

                    b.Property<decimal>("PantorrillaIzqInicio")
                        .HasColumnType("decimal(5,2)");

                    b.Property<decimal>("PantorrillaIzqMedio")
                        .HasColumnType("decimal(5,2)");

                    b.HasKey("Id");

                    b.HasIndex("PacienteId");

                    b.ToTable("MedidasCorporales");
                });

            modelBuilder.Entity("EsteticaAvanzada.Data.Entidades.MotivoConsulta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Acne")
                        .HasColumnType("bit");

                    b.Property<bool>("AdiposidadLocalizada")
                        .HasColumnType("bit");

                    b.Property<bool>("Arrugas")
                        .HasColumnType("bit");

                    b.Property<bool>("Celulitis")
                        .HasColumnType("bit");

                    b.Property<bool>("CuidadoPiel")
                        .HasColumnType("bit");

                    b.Property<bool>("Envejecimiento")
                        .HasColumnType("bit");

                    b.Property<bool>("Estrias")
                        .HasColumnType("bit");

                    b.Property<bool>("Flacidez")
                        .HasColumnType("bit");

                    b.Property<bool>("Manchas")
                        .HasColumnType("bit");

                    b.Property<string>("Otros")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("PacienteId")
                        .HasColumnType("int");

                    b.Property<bool>("Rosacea")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("PacienteId");

                    b.ToTable("MotivoConsultas");
                });

            modelBuilder.Entity("EsteticaAvanzada.Data.Entidades.Paciente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Contacto")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Correo")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime>("FechaNacimiento")
                        .HasColumnType("datetime2");

                    b.Property<string>("NombrePaciente")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Sexo")
                        .IsRequired()
                        .HasMaxLength(1)
                        .HasColumnType("nvarchar(1)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Pacientes");
                });

            modelBuilder.Entity("EsteticaAvanzada.Data.Entidades.SesionesProgramadas", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("PacienteId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Sesion10Fecha")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Sesion1Fecha")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Sesion2Fecha")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Sesion3Fecha")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Sesion4Fecha")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Sesion5Fecha")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Sesion6Fecha")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Sesion7Fecha")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Sesion8Fecha")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Sesion9Fecha")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("PacienteId");

                    b.ToTable("SesionesProgramadas");
                });

            modelBuilder.Entity("EsteticaAvanzada.Data.Entidades.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Contraseña")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Correo")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<string>("NombreCompleto")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Rol")
                        .HasColumnType("int");

                    b.Property<string>("URLFoto")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("EsteticaAvanzada.Data.Entidades.AntecedentesQuirurgicos", b =>
                {
                    b.HasOne("EsteticaAvanzada.Data.Entidades.Paciente", "Paciente")
                        .WithMany()
                        .HasForeignKey("PacienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Paciente");
                });

            modelBuilder.Entity("EsteticaAvanzada.Data.Entidades.DiagnosticoTratamiento", b =>
                {
                    b.HasOne("EsteticaAvanzada.Data.Entidades.Paciente", "Paciente")
                        .WithMany()
                        .HasForeignKey("PacienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Paciente");
                });

            modelBuilder.Entity("EsteticaAvanzada.Data.Entidades.EstadoSalud", b =>
                {
                    b.HasOne("EsteticaAvanzada.Data.Entidades.Paciente", "Paciente")
                        .WithMany()
                        .HasForeignKey("PacienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Paciente");
                });

            modelBuilder.Entity("EsteticaAvanzada.Data.Entidades.Imagenes", b =>
                {
                    b.HasOne("EsteticaAvanzada.Data.Entidades.Paciente", "Paciente")
                        .WithMany()
                        .HasForeignKey("PacienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Paciente");
                });

            modelBuilder.Entity("EsteticaAvanzada.Data.Entidades.MedidasCorporales", b =>
                {
                    b.HasOne("EsteticaAvanzada.Data.Entidades.Paciente", "Paciente")
                        .WithMany()
                        .HasForeignKey("PacienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Paciente");
                });

            modelBuilder.Entity("EsteticaAvanzada.Data.Entidades.MotivoConsulta", b =>
                {
                    b.HasOne("EsteticaAvanzada.Data.Entidades.Paciente", "Paciente")
                        .WithMany()
                        .HasForeignKey("PacienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Paciente");
                });

            modelBuilder.Entity("EsteticaAvanzada.Data.Entidades.SesionesProgramadas", b =>
                {
                    b.HasOne("EsteticaAvanzada.Data.Entidades.Paciente", "Paciente")
                        .WithMany()
                        .HasForeignKey("PacienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Paciente");
                });
#pragma warning restore 612, 618
        }
    }
}
