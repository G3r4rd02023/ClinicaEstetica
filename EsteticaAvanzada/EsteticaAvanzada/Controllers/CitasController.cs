using EsteticaAvanzada.Data;
using EsteticaAvanzada.Data.Entidades;
using EsteticaAvanzada.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace EsteticaAvanzada.Controllers
{
    public class CitasController : Controller
    {
        private readonly DataContext _context;
        private readonly IServicioLista _lista;

        public CitasController(DataContext context, IServicioLista lista)
        {
            _context = context;
            _lista = lista;
        }

        public IActionResult Calendar()
        {
            List<Cita> eventos = _context.Citas.ToList();
            List<object> items = new List<object>();

            foreach (Cita evento in eventos)
            {
                var item = new
                {
                    id = evento.Id,
                    title = evento.Titulo,
                    start = evento.Fecha,
                    end = evento.Fecha.AddHours(1)
                };
                items.Add(item);
            }

            ViewBag.Eventos = JsonConvert.SerializeObject(items);
            return View();
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Citas
                .Include(c => c.Paciente)
                .ToListAsync());
        }

        public async Task<IActionResult> Create()
        {
            var pacientes = await _lista!.GetListaPacientes();
            if (pacientes == null)
            {
                TempData["AlertMessage"] = "No se encontraron pacientes";
            }

            Cita cita = new()
            {
                Pacientes = pacientes,
            };

            return View(cita);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Cita cita)
        {
            if (ModelState.IsValid)
            {
                var paciente = _context.Pacientes.FirstOrDefault(c => c.Id == cita.PacienteId);
                var nuevaCita = new Cita()
                {
                    PacienteId = cita.PacienteId,
                    Paciente = paciente,
                    Fecha = cita.Fecha,
                    Descripcion = cita.Descripcion,
                    Titulo = cita.Titulo,
                };
                _context.Add(nuevaCita);
                await _context.SaveChangesAsync();
                TempData["AlertMessage"] = "Cita creada exitosamente!!!";
                return RedirectToAction("Index");
            }
            return View(cita);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var cita = await _context.Citas
            .Include(c => c.Paciente)
            .FirstOrDefaultAsync(c => c.Id == id);

            if (cita == null)
            {
                TempData["AlertMessage"] = "Cita no encontrada";
                return RedirectToAction("Index");
            }

            var pacientes = await _lista!.GetListaPacientes();
            if (pacientes == null)
            {
                TempData["AlertMessage"] = "No se encontraron pacientes";
                return RedirectToAction("Index");
            }

            cita.Pacientes = pacientes;

            return View(cita);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Cita cita)
        {
            if (id != cita.Id)
            {
                TempData["AlertMessage"] = "ID de la cita no coincide";
                return RedirectToAction("Index");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var paciente = _context.Pacientes.FirstOrDefault(c => c.Id == cita.PacienteId);

                    var citaExistente = await _context.Citas.FindAsync(id);
                    if (citaExistente != null)
                    {
                        citaExistente.PacienteId = cita.PacienteId;
                        citaExistente.Paciente = paciente;
                        citaExistente.Fecha = cita.Fecha;
                        citaExistente.Descripcion = cita.Descripcion;
                        citaExistente.Titulo = cita.Titulo;

                        _context.Update(citaExistente);
                        await _context.SaveChangesAsync();
                        TempData["AlertMessage"] = "Cita actualizada exitosamente!!!";
                    }
                    else
                    {
                        TempData["AlertMessage"] = "Cita no encontrada";
                    }
                }
                catch (Exception)
                {
                    TempData["AlertMessage"] = "Ocurrió un error al actualizar la cita";
                }

                return RedirectToAction("Index");
            }

            cita.Pacientes = await _lista!.GetListaPacientes();
            return View(cita);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var cita = await _context.Citas.FindAsync(id);
            if (cita == null)
            {
                return NotFound();
            }

            _context.Citas.Remove(cita);
            await _context.SaveChangesAsync();
            TempData["AlertMessage"] = "La cita fue cancelada exitosamente!!!";
            return RedirectToAction(nameof(Index));
        }
    }
}