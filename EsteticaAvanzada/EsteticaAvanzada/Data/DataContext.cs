using EsteticaAvanzada.Data.Entidades;
using Microsoft.EntityFrameworkCore;

namespace EsteticaAvanzada.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<AnalisisEstetico> AnalisisEsteticos { get; set; }
        public DbSet<AntecedentesFamiliares> AntecedentesFamiliares { get; set; }
        public DbSet<AntecedentesQuirurgicos> AntecedentesQuirurgicos { get; set; }
        public DbSet<BotoxAplicacion> BotoxAplicaciones { get; set; }
        public DbSet<Cita> Citas { get; set; }
        public DbSet<DatosEsteticos> DatosEsteticos { get; set; }
        public DbSet<DiagnosticoTratamiento> DiagnosticosTratamientos { get; set; }
        public DbSet<EstadoSalud> EstadoSalud { get; set; }
        public DbSet<Habitos> Habitos { get; set; }
        public DbSet<Imagenes> Imagenes { get; set; }
        public DbSet<JuvedermAplicacion> JuvedermAplicaciones { get; set; }
        public DbSet<MedidasCorporales> MedidasCorporales { get; set; }
        public DbSet<MotivoConsulta> MotivoConsultas { get; set; }
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<PlanAplicacion> PlanAplicacion { get; set; }
        public DbSet<SesionesProgramadas> SesionesProgramadas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
    }
}