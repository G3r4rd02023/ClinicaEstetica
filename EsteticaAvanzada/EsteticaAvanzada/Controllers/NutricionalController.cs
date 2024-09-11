using EsteticaAvanzada.Data;
using EsteticaAvanzada.Data.Entidades;
using EsteticaAvanzada.Models;
using EsteticaAvanzada.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EsteticaAvanzada.Controllers
{
    public class NutricionalController : Controller
    {
        private readonly DataContext _context;
        private readonly IServicioLista _lista;

        public NutricionalController(DataContext context, IServicioLista lista)
        {
            _context = context;
            _lista = lista;
        }

        public async Task<IActionResult> Index()
        {
            var nutricional = await _context.HistoriaNutricional
                .Include(h => h.Paciente)
                .ToListAsync();

            return View(nutricional);
        }

        public async Task<IActionResult> Create()
        {
            var pacientes = await _lista!.GetListaPacientes();
            if (pacientes == null)
            {
                TempData["AlertMessage"] = "No se encontraron pacientes";
            }

            NutricionalViewModel model = new()
            {
                Pacientes = pacientes,
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(NutricionalViewModel model)
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

                MedidasCorporales medidas = new()
                {
                    CinturaInicio = model.MedidasCorporales!.CinturaInicio,
                    CinturaMedio = model.MedidasCorporales!.CinturaMedio,
                    CinturaFinal = model.MedidasCorporales!.CinturaFinal,
                    CaderaInicio = model.MedidasCorporales!.CaderaInicio,
                    CaderaMedio = model.MedidasCorporales!.CaderaMedio,
                    CaderaFinal = model.MedidasCorporales!.CaderaFinal,
                    AbdomenInicio = model.MedidasCorporales!.AbdomenInicio,
                    AbdomenMedio = model.MedidasCorporales!.AbdomenMedio,
                    AbdomenFinal = model.MedidasCorporales!.AbdomenFinal,
                    BrazoDerInicio = model.MedidasCorporales!.BrazoDerInicio,
                    BrazoDerMedio = model.MedidasCorporales!.BrazoDerMedio,
                    BrazoDerFinal = model.MedidasCorporales!.BrazoDerFinal,
                    BrazoIzqInicio = model.MedidasCorporales!.BrazoIzqInicio,
                    BrazoIzqMedio = model.MedidasCorporales!.BrazoIzqMedio,
                    BrazoIzqFinal = model.MedidasCorporales!.BrazoIzqFinal,
                    MusloDerInicio = model.MedidasCorporales!.MusloDerInicio,
                    MusloDerMedio = model.MedidasCorporales!.MusloDerMedio,
                    MusloDerFinal = model.MedidasCorporales!.MusloDerFinal,
                    MusloIzqInicio = model.MedidasCorporales!.MusloIzqInicio,
                    MusloIzqMedio = model.MedidasCorporales!.MusloIzqMedio,
                    MusloIzqFinal = model.MedidasCorporales!.MusloIzqFinal,
                    Paciente = paciente,
                    PacienteId = paciente.Id
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
                _context.MedidasCorporales.Add(medidas);
                await _context.SaveChangesAsync();

                HistoriaNutricional historia = new()
                {
                    Paciente = paciente,
                    AntecedentesInmunoAlergicos = model.AntecedentesInmunoAlergicos,
                    AntecedentesPatologicos = model.AntecedentesPatologicos,
                    Diagnostico = model.Diagnostico,
                    IMC = model.IMC,
                    Medicamentos = model.Medicamentos,
                    MedidasCorporales = medidas,
                    SesionesProgramadas = sesiones,
                    Peso = model.Peso,
                    PlanTratamiento = model.PlanTratamiento,
                    Procedimientos = model.Procedimientos,
                    Talla = model.Talla,
                };
                _context.HistoriaNutricional.Add(historia);
                await _context.SaveChangesAsync();
                TempData["AlertMessage"] = "Datos ingresados exitosamente!!!";
                return RedirectToAction("Index");
            }
            model.Pacientes = await _lista.GetListaPacientes();
            return View(model);
        }

        public async Task<IActionResult> Details(int id)
        {
            var nutricional = await _context.HistoriaNutricional
                .Include(n => n.Paciente)
                .Include(n => n.MedidasCorporales)
                .Include(n => n.SesionesProgramadas)
                .FirstOrDefaultAsync(n => n.Id == id);

            if (nutricional == null)
            {
                return NotFound();
            }

            return View(nutricional);
        }

        [HttpPost]
        public async Task<IActionResult> Details(HistoriaNutricional nutricional)
        {
            if (ModelState.IsValid)
            {
                using var transaction = await _context.Database.BeginTransactionAsync();

                try
                {
                    if (nutricional.MedidasCorporales != null)
                    {
                        var existingMedidas = await _context.MedidasCorporales
                            .FirstOrDefaultAsync(mc => mc.Id == nutricional.MedidasCorporales.Id);

                        if (existingMedidas != null)
                        {
                            nutricional.MedidasCorporales.Id = existingMedidas.Id;
                            nutricional.MedidasCorporales.PacienteId = nutricional.Paciente!.Id;
                            _context.Entry(existingMedidas).CurrentValues.SetValues(nutricional.MedidasCorporales);
                        }
                        else
                        {
                            nutricional.MedidasCorporales.PacienteId = nutricional.Paciente!.Id;
                            _context.MedidasCorporales.Add(nutricional.MedidasCorporales);
                        }
                    }
                    if (nutricional.SesionesProgramadas != null)
                    {
                        var existingSesiones = await _context.SesionesProgramadas
                            .FirstOrDefaultAsync(mc => mc.Id == nutricional.SesionesProgramadas.Id);

                        if (existingSesiones != null)
                        {
                            nutricional.SesionesProgramadas.Id = existingSesiones.Id;
                            nutricional.SesionesProgramadas.PacienteId = nutricional.Paciente!.Id;
                            _context.Entry(existingSesiones).CurrentValues.SetValues(nutricional.SesionesProgramadas);
                        }
                        else
                        {
                            nutricional.SesionesProgramadas.PacienteId = nutricional.Paciente!.Id;
                            _context.SesionesProgramadas.Add(nutricional.SesionesProgramadas);
                        }
                    }
                    await _context.SaveChangesAsync();
                    await transaction.CommitAsync();

                    TempData["AlertMessage"] = "El historial nutricional del paciente se actualizo exitosamente!!!";
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    TempData["ErrorMessage"] = $"Error al actualizar datos de paciente: {ex.Message}. Intente nuevamente.";
                    return View(nutricional);
                }
            }
            TempData["ErrorMessage"] = "Error al actualizar datos de paciente, intente nuevamente";
            return View(nutricional);
        }
    }
}