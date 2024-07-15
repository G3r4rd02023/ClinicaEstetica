using EsteticaAvanzada.Data.Entidades;
using Microsoft.EntityFrameworkCore;

namespace EsteticaAvanzada.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<AntecedentesQuirurgicos> AntecedentesQuirurgicos { get; set; }
        public DbSet<DiagnosticoTratamiento> DiagnosticosTratamientos { get; set; }
        public DbSet<EstadoSalud> EstadoSalud { get; set; }
        public DbSet<Imagenes> Imagenes { get; set; }
        public DbSet<MedidasCorporales> MedidasCorporales { get; set; }
        public DbSet<MotivoConsulta> MotivoConsultas { get; set; }
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<SesionesProgramadas> SesionesProgramadas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

    }
}
