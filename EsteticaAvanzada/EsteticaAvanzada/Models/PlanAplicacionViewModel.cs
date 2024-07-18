using EsteticaAvanzada.Data.Entidades;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations.Schema;

namespace EsteticaAvanzada.Models
{
    public class PlanAplicacionViewModel
    {
        public Paciente? Paciente { get; set; }
        public PlanAplicacion? PlanAplicacion { get; set; }
        public BotoxAplicacion? BotoxAplicacion { get; set; }
        public JuvedermAplicacion? JuvedermAplicacion{ get; set; }     
        public IEnumerable<SelectListItem>? Pacientes { get; set; }
      

    }
}
