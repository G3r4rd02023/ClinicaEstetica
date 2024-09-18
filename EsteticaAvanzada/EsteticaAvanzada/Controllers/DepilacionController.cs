using EsteticaAvanzada.Data;
using EsteticaAvanzada.Data.Entidades;
using EsteticaAvanzada.Models;
using EsteticaAvanzada.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EsteticaAvanzada.Controllers
{
    public class DepilacionController : Controller
    {
        private readonly DataContext _context;
        private readonly IServicioLista _lista;

        public DepilacionController(DataContext context, IServicioLista lista)
        {
            _context = context;
            _lista = lista;
        }

        public async Task<IActionResult> Index()
        {
            var depilacion = await _context.DepilacionLaser
               .Include(h => h.Paciente)
               .ToListAsync();

            return View(depilacion);
        }

        public async Task<IActionResult> Create()
        {
            var pacientes = await _lista!.GetListaPacientes();
            if (pacientes == null)
            {
                TempData["AlertMessage"] = "No se encontraron pacientes";
            }

            DepilacionViewModel model = new()
            {
                Pacientes = pacientes,
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(DepilacionViewModel model)
        {
            if (ModelState.IsValid)
            {
                var paciente = await _context.Pacientes.FindAsync(model.PacienteId);
                if (paciente == null)
                {
                    return NotFound();
                }

                SesionesProgramadas sesiones = new()
                {
                    PacienteId = paciente.Id,
                    Paciente = paciente,
                    Sesion1Fecha = model.SesionesProgramadas!.Sesion1Fecha,
                    Sesion1Comentario = model.SesionesProgramadas!.Sesion1Comentario,
                    Sesion2Fecha = model.SesionesProgramadas!.Sesion2Fecha,
                    Sesion2Comentario = model.SesionesProgramadas!.Sesion2Comentario,
                    Sesion3Fecha = model.SesionesProgramadas.Sesion3Fecha,
                    Sesion3Comentario = model.SesionesProgramadas!.Sesion3Comentario,
                    Sesion4Fecha = model.SesionesProgramadas!.Sesion4Fecha,
                    Sesion4Comentario = model.SesionesProgramadas!.Sesion4Comentario,
                    Sesion5Fecha = model.SesionesProgramadas!.Sesion5Fecha,
                    Sesion5Comentario = model.SesionesProgramadas!.Sesion5Comentario,
                    Sesion6Fecha = model.SesionesProgramadas!.Sesion6Fecha,
                    Sesion6Comentario = model.SesionesProgramadas!.Sesion6Comentario,
                    Sesion7Fecha = model.SesionesProgramadas!.Sesion7Fecha,
                    Sesion7Comentario = model.SesionesProgramadas!.Sesion7Comentario,
                    Sesion8Fecha = model.SesionesProgramadas!.Sesion8Fecha,
                    Sesion8Comentario = model.SesionesProgramadas!.Sesion8Comentario,
                    Sesion9Fecha = model.SesionesProgramadas!.Sesion9Fecha,
                    Sesion9Comentario = model.SesionesProgramadas!.Sesion9Comentario,
                    Sesion10Fecha = model.SesionesProgramadas!.Sesion10Fecha,
                    Sesion10Comentario = model.SesionesProgramadas!.Sesion10Comentario,
                    Sesion11Fecha = model.SesionesProgramadas!.Sesion11Fecha,
                    Sesion11Comentario = model.SesionesProgramadas!.Sesion11Comentario,
                    Sesion12Fecha = model.SesionesProgramadas!.Sesion12Fecha,
                    Sesion12Comentario = model.SesionesProgramadas!.Sesion12Comentario,
                };

                List<DateTime?> fechasSesiones = new List<DateTime?>
                    {
                        model.SesionesProgramadas.Sesion1Fecha,
                        model.SesionesProgramadas.Sesion1Fecha!.Value.AddDays(3),
                        model.SesionesProgramadas.Sesion1Fecha!.Value.AddDays(6),
                        model.SesionesProgramadas.Sesion1Fecha!.Value.AddDays(9),
                        model.SesionesProgramadas.Sesion1Fecha!.Value.AddDays(12),
                        model.SesionesProgramadas.Sesion1Fecha!.Value.AddDays(15),
                        model.SesionesProgramadas.Sesion1Fecha!.Value.AddDays(18),
                        model.SesionesProgramadas.Sesion1Fecha!.Value.AddDays(21),
                        model.SesionesProgramadas.Sesion1Fecha!.Value.AddDays(24),
                        model.SesionesProgramadas.Sesion1Fecha!.Value.AddDays(27),
                        model.SesionesProgramadas.Sesion1Fecha!.Value.AddDays(30),
                        model.SesionesProgramadas.Sesion1Fecha!.Value.AddDays(33),
                    };
                foreach (var fecha in fechasSesiones)
                {
                    if (fecha != DateTime.MinValue)
                    {
                        var nuevaCita = new Cita
                        {
                            Paciente = paciente, // Relaciona la cita con el paciente existente
                            Fecha = (DateTime)fecha!,
                            Titulo = "Sesión :" + paciente.NombrePaciente,
                            Descripcion = $"Cita: {paciente.NombrePaciente}",
                        };

                        _context.Citas.Add(nuevaCita);
                    }
                }
                _context.SesionesProgramadas.Add(sesiones);
                await _context.SaveChangesAsync();

                DepilacionLaser depilacion = new()
                {
                    Acne = model.Acne,
                    ActividadFisica = model.ActividadFisica,
                    Alcoholismo = model.Alcoholismo,
                    AntecedentesPatologicos = model.AntecedentesPatologicos,
                    Axila = model.Axila,
                    SeAutomedica = model.SeAutomedica,
                    Bigote = model.Bigote,
                    Bikini = model.Bikini,
                    BrazoCompleto = model.BrazoCompleto,
                    MedioBrazo = model.MedioBrazo,
                    Manchas = model.Manchas,
                    MediaCara = model.MediaCara,
                    MediaPierna = model.MediaPierna,
                    Medicamentos = model.Medicamentos,
                    MesesEmbarazo = model.MesesEmbarazo,
                    MotivoConsulta = model.MotivoConsulta,
                    FechaUltimaMenstruacion = model.FechaUltimaMenstruacion,
                    FechaUltimaExposicionSolar = model.FechaUltimaExposicionSolar,
                    Forunculos = model.Forunculos,
                    CantidadHijos = model.CantidadHijos,
                    CaraCompleta = model.CaraCompleta,
                    Cicatrices = model.Cicatrices,
                    PiernaCompleta = model.PiernaCompleta,
                    Paciente = paciente,
                    Pasatiempos = model.Pasatiempos,
                    Psoriasis = model.Psoriasis,
                    SesionesProgramadas = sesiones,
                    Drogas = model.Drogas,
                    Eccemas = model.Eccemas,
                    Embarazada = model.Embarazada,
                    Espalda = model.Espalda,
                    Gluteos = model.Gluteos,
                    Observaciones = model.Observaciones,
                    Quistes = model.Quistes,
                    Tabaquismo = model.Tabaquismo,
                    Verrugas = model.Verrugas,
                    Vitiligio = model.Vitiligio,
                };
                _context.DepilacionLaser.Add(depilacion);
                await _context.SaveChangesAsync();
                TempData["AlertMessage"] = "Datos ingresados exitosamente!!!";
                return RedirectToAction("Index");
            }
            model.Pacientes = await _lista.GetListaPacientes();
            return View(model);
        }

        public async Task<IActionResult> Details(int id)
        {
            var depilacion = await _context.DepilacionLaser
                .Include(n => n.Paciente)
                .Include(n => n.SesionesProgramadas)
                .FirstOrDefaultAsync(n => n.Id == id);

            if (depilacion == null)
            {
                return NotFound();
            }

            return View(depilacion);
        }

        [HttpPost]
        public async Task<IActionResult> Details(DepilacionLaser depilacion)
        {
            if (ModelState.IsValid)
            {
                using var transaction = await _context.Database.BeginTransactionAsync();

                try
                {
                    // Actualizar el objeto "DepilacionLaser"
                    var existingDepilacion = await _context.DepilacionLaser
                        .FirstOrDefaultAsync(d => d.Id == depilacion.Id);

                    if (existingDepilacion != null)
                    {
                        // Actualiza los campos de "DepilacionLaser"
                        _context.Entry(existingDepilacion).CurrentValues.SetValues(depilacion);
                    }

                    if (depilacion.SesionesProgramadas != null)
                    {
                        var existingSesiones = await _context.SesionesProgramadas
                            .FirstOrDefaultAsync(mc => mc.Id == depilacion.SesionesProgramadas.Id);

                        if (existingSesiones != null)
                        {
                            depilacion.SesionesProgramadas.Id = existingSesiones.Id;
                            depilacion.SesionesProgramadas.PacienteId = depilacion.Paciente!.Id;
                            _context.Entry(existingSesiones).CurrentValues.SetValues(depilacion.SesionesProgramadas);
                        }
                        else
                        {
                            depilacion.SesionesProgramadas.PacienteId = depilacion.Paciente!.Id;
                            _context.SesionesProgramadas.Add(depilacion.SesionesProgramadas);
                        }
                    }

                    await _context.SaveChangesAsync();
                    await transaction.CommitAsync();

                    TempData["AlertMessage"] = "Los datos del paciente se actualizaron exitosamente!!!";
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    TempData["ErrorMessage"] = $"Error al actualizar datos de paciente: {ex.Message}. Intente nuevamente.";
                    return View(depilacion);
                }
            }
            TempData["ErrorMessage"] = "Error al actualizar datos de paciente, intente nuevamente";
            return View(depilacion);
        }
    }
}