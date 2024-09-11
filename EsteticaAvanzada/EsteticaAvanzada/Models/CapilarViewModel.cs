using EsteticaAvanzada.Data.Entidades;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EsteticaAvanzada.Models
{
    public class CapilarViewModel : TratamientoCapilar
    {
        public IEnumerable<SelectListItem>? Pacientes { get; set; }
    }
}