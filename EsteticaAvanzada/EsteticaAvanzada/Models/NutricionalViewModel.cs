using EsteticaAvanzada.Data.Entidades;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EsteticaAvanzada.Models
{
    public class NutricionalViewModel : HistoriaNutricional
    {
        public IEnumerable<SelectListItem>? Pacientes { get; set; }
    }
}