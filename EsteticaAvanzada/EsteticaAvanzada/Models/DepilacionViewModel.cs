using EsteticaAvanzada.Data.Entidades;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EsteticaAvanzada.Models
{
    public class DepilacionViewModel : DepilacionLaser
    {
        public IEnumerable<SelectListItem>? Pacientes { get; set; }
    }
}