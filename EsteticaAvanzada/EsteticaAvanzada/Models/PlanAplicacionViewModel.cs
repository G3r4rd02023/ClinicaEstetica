using EsteticaAvanzada.Data.Entidades;

namespace EsteticaAvanzada.Models
{
    public class PlanAplicacionViewModel
    {
        public Paciente? Paciente { get; set; }
        public PlanAplicacion? PlanAplicacion { get; set; }
        public BotoxAplicacion? BotoxAplicacion { get; set; }
        public JuvedermAplicacion? JuvedermAplicacion{ get; set; }

    }
}
