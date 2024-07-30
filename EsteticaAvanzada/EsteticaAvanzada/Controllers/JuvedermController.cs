using EsteticaAvanzada.Data;
using EsteticaAvanzada.Data.Entidades;
using EsteticaAvanzada.Models;
using EsteticaAvanzada.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EsteticaAvanzada.Controllers
{
    public class JuvedermController : Controller
    {
        private readonly DataContext _context;
        private readonly IServicioLista _lista;

        public JuvedermController(DataContext context, IServicioLista lista)
        {
            _context = context;
            _lista = lista;
        }

        public async Task<IActionResult> Index()
        {
            var juvedermAplicaciones = await _context.JuvedermAplicaciones
                .Include(b => b.PlanAplicacion!)
                .ThenInclude(b => b.Paciente)
                .ToListAsync();
            return View(juvedermAplicaciones);
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

                JuvedermAplicacion juvederm = new()
                {
                    PlanAplicacion = plan,
                    PlanAplicacionId = plan.Id,
                    Codigo= model.JuvedermAplicacion!.Codigo,
                    Lado = model.JuvedermAplicacion!.Lado,
                    Producto = model.JuvedermAplicacion!.Producto,
                    VolumenML = model.JuvedermAplicacion!.VolumenML,                                                            
                };

                _context.PlanAplicacion.Add(plan);
                _context.JuvedermAplicaciones.Add(juvederm);
                await _context.SaveChangesAsync();
                TempData["AlertMessage"] = "Datos ingresados exitosamente!!!";
                return RedirectToAction("Index");
            }
            model.Pacientes = await _lista.GetListaPacientes();
            return View(model);
        }
    }
}

