using EsteticaAvanzada.Data.Entidades;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EsteticaAvanzada.Models
{
    public class CapilarViewModel : TratamientoCapilar
    {
        public IEnumerable<SelectListItem>? Pacientes { get; set; }

        public Imagenes? Imagenes { get; set; }

        public List<Imagenes> Fotos { get; set; } = new List<Imagenes>();
    }
}