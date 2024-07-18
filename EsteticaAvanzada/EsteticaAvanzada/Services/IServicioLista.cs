using Microsoft.AspNetCore.Mvc.Rendering;

namespace EsteticaAvanzada.Services
{
    public interface IServicioLista
    {
        Task<IEnumerable<SelectListItem>> GetListaPacientes();

    }
}
