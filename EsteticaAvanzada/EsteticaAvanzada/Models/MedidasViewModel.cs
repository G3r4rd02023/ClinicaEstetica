using EsteticaAvanzada.Data.Entidades;

namespace EsteticaAvanzada.Models
{
    public class MedidasViewModel
    {
        public Paciente? Paciente { get; set; }

        public MedidasCorporales? MedidasCorporales { get; set; }
        
        public SesionesProgramadas? SesionesProgramadas { get; set; }

        public DiagnosticoTratamiento? DiagnosticoTratamiento { get; set; }
    }
}
