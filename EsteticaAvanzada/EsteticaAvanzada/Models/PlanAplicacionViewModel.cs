using EsteticaAvanzada.Data.Entidades;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EsteticaAvanzada.Models
{
    public class PlanAplicacionViewModel
    {
        public Paciente? Paciente { get; set; }
        public PlanAplicacion? PlanAplicacion { get; set; }
        public BotoxAplicacion? BotoxAplicacion { get; set; }
        public JuvedermAplicacion? JuvedermAplicacion { get; set; }
        public IEnumerable<SelectListItem>? Pacientes { get; set; }
        public Imagenes? Imagenes { get; set; }
        public List<Imagenes> Fotos { get; set; } = new List<Imagenes>();
    }
}