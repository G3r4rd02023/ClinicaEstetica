using EsteticaAvanzada.Data.Entidades;
using System.ComponentModel.DataAnnotations;

namespace EsteticaAvanzada.Models
{
    public class HistorialViewModel
    {

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? Fecha { get; set; } = DateTime.Today;
        public Paciente? Paciente { get; set; }
        public MotivoConsulta? MotivoConsulta { get; set; }
        public EstadoSalud? EstadoSalud { get; set; }
        public AntecedentesQuirurgicos? AntecedentesQuirurgicos { get; set; }
        public AntecedentesFamiliares? AntecedentesFamiliares { get; set; }
        public Habitos? Habitos { get; set; }

    }
}
