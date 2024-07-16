using EsteticaAvanzada.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EsteticaAvanzada.Data.Entidades;
using EsteticaAvanzada.Models;

namespace EsteticaAvanzada.Controllers
{
    public class PacientesController : Controller
    {
        private readonly DataContext _context;

        public PacientesController(DataContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var pacientes = await _context.Pacientes.ToListAsync();
            return View(pacientes);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Paciente paciente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(paciente);
                await _context.SaveChangesAsync();
                TempData["AlertMessage"] = "Paciente ingresado exitosamente!!!";
                return RedirectToAction("Index");
            }
            return View(paciente);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var paciente = await _context.Pacientes.SingleOrDefaultAsync(p => p.Id == id);
            if(paciente == null)
            {
                TempData["ErrorMessage"] = "Paciente no encontrado";
                return View();
            }

            return View(paciente);
           
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Paciente paciente)
        {
            if (ModelState.IsValid)
            {
                _context.Update(paciente);
                await _context.SaveChangesAsync();
                TempData["AlertMessage"] = "Los datos del paciente se actualizaron exitosamente!!!";
                return RedirectToAction("Index");
            }
            TempData["ErrorMessage"] = "Error al actualizar datos de paciente, intente nuevamente";
            return View(paciente);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var paciente = await _context.Pacientes.FindAsync(id);
            if (paciente == null)
            {
                return NotFound();
            }

            _context.Pacientes.Remove(paciente);
            await _context.SaveChangesAsync();
            TempData["AlertMessage"] = "El paciente fue eliminado exitosamente!!!";
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int id)
        {
            var paciente = await _context.Pacientes.FindAsync(id);
            var motivoConsulta = await _context.MotivoConsultas.Where(mc => mc.PacienteId == id).FirstOrDefaultAsync();
            var estadoSalud = await _context.EstadoSalud.Where(es => es.PacienteId == id).FirstOrDefaultAsync();
            var antecedentesQuirurgicos = await _context.AntecedentesQuirurgicos.Where(aq => aq.PacienteId == id).FirstOrDefaultAsync();

            var model = new HistorialViewModel
            {
                Paciente = paciente,
                MotivoConsulta = motivoConsulta,
                EstadoSalud = estadoSalud,
                AntecedentesQuirurgicos = antecedentesQuirurgicos
            };

            return View(model);

        }

        [HttpPost]
        public async Task<IActionResult> Details(HistorialViewModel model)
        {
            if (ModelState.IsValid)
            {
                using var transaction = await _context.Database.BeginTransactionAsync();

                try
                {
                    //if (model.Paciente != null)
                    //{
                    //    _context.Update(model.Paciente);
                    //}

                    if (model.MotivoConsulta != null)
                    {
                        var existingMotivoConsulta = await _context.MotivoConsultas
                            .FirstOrDefaultAsync(mc => mc.PacienteId == model.Paciente!.Id);

                        if (existingMotivoConsulta != null)
                        {
                            model.MotivoConsulta.Id = existingMotivoConsulta.Id;
                            model.MotivoConsulta.PacienteId = model.Paciente!.Id;
                            _context.Entry(existingMotivoConsulta).CurrentValues.SetValues(model.MotivoConsulta);
                        }
                        else
                        {
                            model.MotivoConsulta.PacienteId = model.Paciente!.Id;
                            _context.MotivoConsultas.Add(model.MotivoConsulta);
                        }
                    }

                    if (model.EstadoSalud != null)
                    {
                        var existingEstadoSalud = await _context.EstadoSalud
                            .FirstOrDefaultAsync(es => es.PacienteId == model.Paciente!.Id);

                        if (existingEstadoSalud != null)
                        {
                            model.EstadoSalud.Id = existingEstadoSalud.Id;
                            model.EstadoSalud.PacienteId = model.Paciente!.Id;
                            _context.Entry(existingEstadoSalud).CurrentValues.SetValues(model.EstadoSalud);
                        }
                        else
                        {
                            model.EstadoSalud.PacienteId = model.Paciente!.Id;
                            _context.EstadoSalud.Add(model.EstadoSalud);
                        }
                    }

                    if (model.AntecedentesQuirurgicos != null)
                    {
                        var existingAntecedentesQuirurgicos = await _context.AntecedentesQuirurgicos
                            .FirstOrDefaultAsync(aq => aq.PacienteId == model.Paciente!.Id);

                        if (existingAntecedentesQuirurgicos != null)
                        {
                            model.AntecedentesQuirurgicos.Id = existingAntecedentesQuirurgicos.Id;
                            model.AntecedentesQuirurgicos.PacienteId = model.Paciente!.Id;
                            _context.Entry(existingAntecedentesQuirurgicos).CurrentValues.SetValues(model.AntecedentesQuirurgicos);
                        }
                        else
                        {
                            model.AntecedentesQuirurgicos.PacienteId = model.Paciente!.Id;
                            _context.AntecedentesQuirurgicos.Add(model.AntecedentesQuirurgicos);
                        }
                    }

                    await _context.SaveChangesAsync();
                    await transaction.CommitAsync();

                    TempData["AlertMessage"] = "El historial clinico del paciente se actualizo exitosamente!!!";
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    TempData["ErrorMessage"] = $"Error al actualizar datos de paciente: {ex.Message}. Intente nuevamente.";                   
                    return View(model);
                }
            }
            TempData["ErrorMessage"] = "Error al actualizar datos de paciente, intente nuevamente";
            return View(model);
        }


    }
}
