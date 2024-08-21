using EsteticaAvanzada.Data;
using EsteticaAvanzada.Data.Entidades;
using EsteticaAvanzada.Models;
using EsteticaAvanzada.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EsteticaAvanzada.Controllers
{
    [Authorize]
    public class BotoxController : Controller
    {
        private readonly DataContext _context;
        private readonly IServicioLista _lista;

        public BotoxController(DataContext context, IServicioLista lista)
        {
            _context = context;
            _lista = lista;
        }

        public async Task<IActionResult> Index()
        {
            var botoxAplicaciones = await _context.BotoxAplicaciones
                .Include(b => b.PlanAplicacion!)
                .ThenInclude(b => b.Paciente)
                .ToListAsync();
            return View(botoxAplicaciones);
        }

        public async Task<IActionResult> Create()
        {
            var pacientes = await _lista!.GetListaPacientes();
            if (pacientes == null)
            {
                TempData["AlertMessage"] = "No se encontraron pacientes";
            }

            PlanAplicacionViewModel model = new()
            {
                Pacientes = pacientes,
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(PlanAplicacionViewModel model)
        {
            if (ModelState.IsValid)
            {
                var paciente = await _context.Pacientes.FindAsync(model.PlanAplicacion!.PacienteId);
                if (paciente == null)
                {
                    return NotFound();
                }

                // Crear el objeto PlanAplicacion
                PlanAplicacion plan = new()
                {
                    Paciente = paciente,
                    PacienteId = paciente.Id,
                    RetornoEvaluacionFecha = model.PlanAplicacion!.RetornoEvaluacionHora,
                    RetornoEvaluacionHora = model.PlanAplicacion!.RetornoEvaluacionHora,
                    FechaAplicacionBotox = model.PlanAplicacion.FechaAplicacionBotox,
                    FechaAplicacionJuvederm = model.PlanAplicacion!.FechaAplicacionJuvederm,
                    NuevaAplicacionFecha = model.PlanAplicacion!.NuevaAplicacionFecha
                };

                // Guardar PlanAplicacion para obtener su ID
                _context.PlanAplicacion.Add(plan);
                await _context.SaveChangesAsync(); // Aquí se genera el ID del plan

                // Crear el objeto Cita asociado al plan

                // Crear el objeto BotoxAplicacion asociado al plan
                BotoxAplicacion botox = new()
                {
                    PlanAplicacion = plan,
                    PlanAplicacionId = plan.Id, // Ahora que el ID está disponible
                    Corrugador = model.BotoxAplicacion!.Corrugador,
                    ProximaSesion = model.BotoxAplicacion!.ProximaSesion,
                    ZonasAplicadas = model.BotoxAplicacion!.ZonasAplicadas,
                    Frontal = model.BotoxAplicacion!.Frontal,
                    Mentoniano = model.BotoxAplicacion!.Mentoniano,
                    Nasal = model.BotoxAplicacion.Nasal,
                    NumeroLote = model.BotoxAplicacion!.NumeroLote,
                    OrbicularLabios = model.BotoxAplicacion!.OrbicularLabios,
                    OrbicularOjos = model.BotoxAplicacion.OrbicularOjos,
                    Otras = model.BotoxAplicacion.Otras,
                    Procerus = model.BotoxAplicacion.Procerus,
                    TotalUnidadesInyectadas = model.BotoxAplicacion.TotalUnidadesInyectadas,
                    Observaciones = model.BotoxAplicacion.Observaciones
                };

                // Añadir las entidades restantes

                _context.BotoxAplicaciones.Add(botox);

                Cita cita = new()
                {
                    Paciente = paciente,
                    Fecha = model.BotoxAplicacion.ProximaSesion,
                    Descripcion = "Aplicación:" + paciente.NombrePaciente,
                    Titulo = "Nueva Aplicación"
                };

                _context.Citas.Add(cita);
                // Guardar cambios
                await _context.SaveChangesAsync();

                TempData["AlertMessage"] = "Datos ingresados exitosamente!!!";
                return RedirectToAction("Index");
            }

            // En caso de error, cargar la lista de pacientes nuevamente
            model.Pacientes = await _lista.GetListaPacientes();
            return View(model);
        }

        public async Task<IActionResult> Details(int id)
        {
            var botox = await _context.BotoxAplicaciones.FindAsync(id);

            if (botox == null)
            {
                TempData["ErrorMessage"] = "Botox no encontrado";
            }

            return View(botox);
        }
    }
}