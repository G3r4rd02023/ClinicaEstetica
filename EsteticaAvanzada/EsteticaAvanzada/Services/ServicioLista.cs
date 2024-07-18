using EsteticaAvanzada.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;

namespace EsteticaAvanzada.Services
{
    public class ServicioLista : IServicioLista
    {
        private readonly DataContext _context;

        public ServicioLista(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SelectListItem>> GetListaPacientes()
        {
            var pacientes = await _context.Pacientes.ToListAsync();

            var listaPacientes = pacientes!.Select(e => new SelectListItem
            {
                Value = e.Id.ToString(),
                Text = e.NombrePaciente
            }).ToList();

            listaPacientes.Insert(0, new SelectListItem
            {
                Value = "",
                Text = "Seleccione un Paciente"
            });
            return listaPacientes;
        }
    }
}
