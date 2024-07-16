using EsteticaAvanzada.Data.Entidades;

namespace EsteticaAvanzada.Models
{
    public class HistorialViewModel
    {
        public Paciente? Paciente { get; set; }

        public MotivoConsulta? MotivoConsulta { get; set; }

        public EstadoSalud? EstadoSalud { get; set; }

        public AntecedentesQuirurgicos? AntecedentesQuirurgicos { get; set; }

    }
}
