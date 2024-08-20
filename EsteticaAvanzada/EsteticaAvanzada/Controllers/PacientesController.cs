using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using EsteticaAvanzada.Data;
using EsteticaAvanzada.Data.Entidades;
using EsteticaAvanzada.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;



namespace EsteticaAvanzada.Controllers
{
    [Authorize]
    public class PacientesController : Controller
    {
        private readonly DataContext _context;
        private readonly Cloudinary _cloudinary;

        public PacientesController(DataContext context, Cloudinary cloudinary)
        {
            _context = context;
            _cloudinary = cloudinary;
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
            if (paciente == null)
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
            var antecedentesFamiliares = await _context.AntecedentesFamiliares.Where(af => af.PacienteId == id).FirstOrDefaultAsync();
            var habitos = await _context.Habitos.Where(h => h.PacienteId == id).FirstOrDefaultAsync();
            var imagenes = await _context.Imagenes.Where(i => i.PacienteId == paciente!.Id).FirstOrDefaultAsync();
            var fotos = await _context.Imagenes.ToListAsync();
            var fotosPaciente = fotos.Where(f => f.PacienteId == paciente!.Id);

            var model = new HistorialViewModel
            {
                Paciente = paciente,
                MotivoConsulta = motivoConsulta,
                EstadoSalud = estadoSalud,
                AntecedentesQuirurgicos = antecedentesQuirurgicos,
                AntecedentesFamiliares = antecedentesFamiliares,
                Habitos = habitos,
                Imagenes = imagenes,
                Fotos = fotosPaciente.ToList()
            };

            return View(model);

        }

        [HttpPost]
        public async Task<IActionResult> Details(HistorialViewModel model, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                using var transaction = await _context.Database.BeginTransactionAsync();

                try
                {

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

                    if (model.AntecedentesFamiliares != null)
                    {
                        var existingAntecedentesFamiliares = await _context.AntecedentesFamiliares
                            .FirstOrDefaultAsync(aq => aq.PacienteId == model.Paciente!.Id);

                        if (existingAntecedentesFamiliares != null)
                        {
                            model.AntecedentesFamiliares.Id = existingAntecedentesFamiliares.Id;
                            model.AntecedentesFamiliares.PacienteId = model.Paciente!.Id;
                            _context.Entry(existingAntecedentesFamiliares).CurrentValues.SetValues(model.AntecedentesFamiliares);
                        }
                        else
                        {
                            model.AntecedentesFamiliares.PacienteId = model.Paciente!.Id;
                            _context.AntecedentesFamiliares.Add(model.AntecedentesFamiliares);
                        }
                    }

                    if (model.Habitos != null)
                    {
                        var existingHabitos = await _context.Habitos
                            .FirstOrDefaultAsync(aq => aq.PacienteId == model.Paciente!.Id);

                        if (existingHabitos != null)
                        {
                            model.Habitos.Id = existingHabitos.Id;
                            model.Habitos.PacienteId = model.Paciente!.Id;
                            _context.Entry(existingHabitos).CurrentValues.SetValues(model.Habitos);
                        }
                        else
                        {
                            model.Habitos.PacienteId = model.Paciente!.Id;
                            _context.Habitos.Add(model.Habitos);
                        }
                    }

                    model.Imagenes ??= new Imagenes();

                    if(file != null)
                    {
                        var uploadParams = new ImageUploadParams()
                        {
                            File = new FileDescription(file!.FileName, file.OpenReadStream()),
                            AssetFolder = "drakeydiaz"
                        };

                        var uploadResult = await _cloudinary.UploadAsync(uploadParams);
                        var urlImagen = uploadResult.SecureUrl.ToString();

                        model.Imagenes!.NombreArchivo = file.FileName;
                        model.Imagenes.RutaArchivo = urlImagen;
                        model.Imagenes.PacienteId = model.Paciente!.Id;
                        _context.Imagenes.Add(model.Imagenes);
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

        public async Task<IActionResult> MedidasCorporales(int id)
        {
            var paciente = await _context.Pacientes.FindAsync(id);
            var medidasCorporales = await _context.MedidasCorporales.Where(mc => mc.PacienteId == id).FirstOrDefaultAsync();
            var sesionesProgramadas = await _context.SesionesProgramadas.Where(mc => mc.PacienteId == id).FirstOrDefaultAsync();
            var diagnosticoTratamientos = await _context.DiagnosticosTratamientos.Where(mc => mc.PacienteId == id).FirstOrDefaultAsync();
            var model = new MedidasViewModel
            {
                Paciente = paciente,
                MedidasCorporales = medidasCorporales,
                SesionesProgramadas = sesionesProgramadas,
                DiagnosticoTratamiento = diagnosticoTratamientos
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> MedidasCorporales(MedidasViewModel model)
        {
            if (ModelState.IsValid)
            {
                using var transaction = await _context.Database.BeginTransactionAsync();

                try
                {
                    if (model.MedidasCorporales != null)
                    {
                        var existingMedidasCorporales = await _context.MedidasCorporales
                            .FirstOrDefaultAsync(mc => mc.PacienteId == model.Paciente!.Id);

                        if (existingMedidasCorporales != null)
                        {
                            model.MedidasCorporales.Id = existingMedidasCorporales.Id;
                            model.MedidasCorporales.PacienteId = model.Paciente!.Id;
                            _context.Entry(existingMedidasCorporales).CurrentValues.SetValues(model.MedidasCorporales);
                        }
                        else
                        {
                            model.MedidasCorporales.PacienteId = model.Paciente!.Id;
                            _context.MedidasCorporales.Add(model.MedidasCorporales);
                        }
                    }

                    if (model.SesionesProgramadas != null)
                    {
                        var existingSesionesProgramadas = await _context.SesionesProgramadas
                            .FirstOrDefaultAsync(mc => mc.PacienteId == model.Paciente!.Id);

                        if (existingSesionesProgramadas != null)
                        {
                            model.SesionesProgramadas.Id = existingSesionesProgramadas.Id;
                            model.SesionesProgramadas.PacienteId = model.Paciente!.Id;
                            _context.Entry(existingSesionesProgramadas).CurrentValues.SetValues(model.SesionesProgramadas);
                        }
                        else
                        {
                            model.SesionesProgramadas.PacienteId = model.Paciente!.Id;
                            _context.SesionesProgramadas.Add(model.SesionesProgramadas);
                        }
                    }

                    if (model.DiagnosticoTratamiento != null)
                    {
                        var existingDiagnosticoTratamiento = await _context.DiagnosticosTratamientos
                            .FirstOrDefaultAsync(mc => mc.PacienteId == model.Paciente!.Id);

                        if (existingDiagnosticoTratamiento != null)
                        {
                            model.DiagnosticoTratamiento.Id = existingDiagnosticoTratamiento.Id;
                            model.DiagnosticoTratamiento.PacienteId = model.Paciente!.Id;
                            _context.Entry(existingDiagnosticoTratamiento).CurrentValues.SetValues(model.DiagnosticoTratamiento);
                        }
                        else
                        {
                            model.DiagnosticoTratamiento.PacienteId = model.Paciente!.Id;
                            _context.DiagnosticosTratamientos.Add(model.DiagnosticoTratamiento);
                        }
                    }

                    await _context.SaveChangesAsync();
                    await transaction.CommitAsync();

                    TempData["AlertMessage"] = "La informacion del paciente se actualizo exitosamente!!!";
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

        public async Task<IActionResult> PlanAplicacion(int id)
        {
            var paciente = await _context.Pacientes.FindAsync(id);
            var planAplicacion = await _context.PlanAplicacion.Where(mc => mc.PacienteId == id).FirstOrDefaultAsync();
            if (planAplicacion == null)
            {
                var nuevoPlan = new PlanAplicacion
                {
                    Paciente = paciente,
                    PacienteId = paciente!.Id,
                    FechaAplicacionBotox = DateTime.Now,
                    FechaAplicacionJuvederm = DateTime.Now,
                    NuevaAplicacionFecha = DateTime.Now,
                    RetornoEvaluacionFecha = DateTime.Now,
                    RetornoEvaluacionHora = DateTime.Now,
                };
                _context.PlanAplicacion.Add(nuevoPlan);
                await _context.SaveChangesAsync();
                planAplicacion = nuevoPlan;
            }

            var botoxAplicacion = await _context.BotoxAplicaciones.Where(mc => mc.PlanAplicacionId == planAplicacion!.Id).FirstOrDefaultAsync();
            var juvedermAplicacion = await _context.JuvedermAplicaciones.Where(mc => mc.PlanAplicacionId == planAplicacion!.Id).FirstOrDefaultAsync();
            var model = new PlanAplicacionViewModel
            {
                Paciente = paciente,
                PlanAplicacion = planAplicacion,
                BotoxAplicacion = botoxAplicacion,
                JuvedermAplicacion = juvedermAplicacion
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> PlanAplicacion(PlanAplicacionViewModel model)
        {
            if (ModelState.IsValid)
            {
                using var transaction = await _context.Database.BeginTransactionAsync();
                try
                {
                    if (model.PlanAplicacion != null)
                    {
                        var existingPlanAplicacion = await _context.PlanAplicacion
                            .FirstOrDefaultAsync(p => p.PacienteId == model.Paciente!.Id);

                        if (existingPlanAplicacion != null)
                        {
                            model.PlanAplicacion.Id = existingPlanAplicacion.Id;
                            model.PlanAplicacion.PacienteId = model.Paciente!.Id;
                            _context.Entry(existingPlanAplicacion).CurrentValues.SetValues(model.PlanAplicacion);
                        }
                        else
                        {
                            model.PlanAplicacion.PacienteId = model.Paciente!.Id;
                            _context.PlanAplicacion.Add(model.PlanAplicacion);
                        }
                    }

                    if (model.BotoxAplicacion != null)
                    {
                        var existingBotox = await _context.BotoxAplicaciones
                            .FirstOrDefaultAsync(p => p.PlanAplicacionId == model.PlanAplicacion!.Id);

                        if (existingBotox != null)
                        {
                            model.BotoxAplicacion.Id = existingBotox.Id;
                            model.BotoxAplicacion.PlanAplicacionId = model.PlanAplicacion!.Id;
                            _context.Entry(existingBotox).CurrentValues.SetValues(model.BotoxAplicacion);
                        }
                        else
                        {
                            model.BotoxAplicacion.PlanAplicacionId = model.PlanAplicacion!.Id;
                            _context.BotoxAplicaciones.Add(model.BotoxAplicacion);
                        }
                    }

                    if (model.JuvedermAplicacion != null)
                    {
                        var existingJuvederm = await _context.JuvedermAplicaciones
                            .FirstOrDefaultAsync(p => p.PlanAplicacionId == model.PlanAplicacion!.Id);

                        if (existingJuvederm != null)
                        {
                            model.JuvedermAplicacion.Id = existingJuvederm.Id;
                            model.JuvedermAplicacion.PlanAplicacionId = model.PlanAplicacion!.Id;
                            _context.Entry(existingJuvederm).CurrentValues.SetValues(model.JuvedermAplicacion);
                        }
                        else
                        {
                            model.JuvedermAplicacion.PlanAplicacionId = model.PlanAplicacion!.Id;
                            _context.JuvedermAplicaciones.Add(model.JuvedermAplicacion);
                        }
                    }
                    await _context.SaveChangesAsync();
                    await transaction.CommitAsync();

                    TempData["AlertMessage"] = "El plan de aplicacion del paciente se actualizo exitosamente!!!";
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    TempData["ErrorMessage"] = $"Error al actualizar el plan de aplicacion: {ex.Message}. Intente nuevamente.";
                    return View(model);
                }
            }
            TempData["ErrorMessage"] = "Error al actualizar el plan de aplicacion, intente nuevamente";
            return View(model);
        }

        public async Task<IActionResult> FichaTecnicaFacial(int id)
        {
            var paciente = await _context.Pacientes.FindAsync(id);
            var datosEsteticos = await _context.DatosEsteticos.Where(mc => mc.PacienteId == paciente!.Id).FirstOrDefaultAsync();
            var analisisEstetico = await _context.AnalisisEsteticos.Where(mc => mc.PacienteId == paciente!.Id).FirstOrDefaultAsync();
            var imagenes = await _context.Imagenes.Where(i => i.PacienteId == paciente!.Id).FirstOrDefaultAsync();
            var fotos = await _context.Imagenes.ToListAsync();
            var fotosPaciente = fotos.Where(f => f.PacienteId == paciente!.Id);

            var model = new EsteticosViewModel()
            {
                Paciente = paciente,
                DatosEsteticos = datosEsteticos,
                AnalisisEsteticos = analisisEstetico,
                Imagenes = imagenes,
                Fotos = fotosPaciente.ToList()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> FichaTecnicaFacial(EsteticosViewModel model, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                using var transaction = await _context.Database.BeginTransactionAsync();

                try
                {
                    if (model.DatosEsteticos != null)
                    {
                        var existingDatos = await _context.DatosEsteticos
                            .FirstOrDefaultAsync(d => d.PacienteId == model.Paciente!.Id);

                        if (existingDatos != null)
                        {
                            model.DatosEsteticos.Id = existingDatos.Id;
                            model.DatosEsteticos.PacienteId = model.Paciente!.Id;
                            _context.Entry(existingDatos).CurrentValues.SetValues(model.DatosEsteticos);
                        }
                        else
                        {
                            model.DatosEsteticos.PacienteId = model.Paciente!.Id;
                            _context.DatosEsteticos.Add(model.DatosEsteticos);
                        }

                        if (model.AnalisisEsteticos != null)
                        {
                            var existingAnalisis = await _context.AnalisisEsteticos
                                .FirstOrDefaultAsync(d => d.PacienteId == model.Paciente!.Id);

                            if (existingAnalisis != null)
                            {
                                model.AnalisisEsteticos.Id = existingAnalisis.Id;
                                model.AnalisisEsteticos.PacienteId = model.Paciente!.Id;
                                _context.Entry(existingAnalisis).CurrentValues.SetValues(model.AnalisisEsteticos);
                            }
                            else
                            {
                                model.AnalisisEsteticos.PacienteId = model.Paciente!.Id;
                                _context.AnalisisEsteticos.Add(model.AnalisisEsteticos);
                            }
                        }


                        model.Imagenes ??= new Imagenes();

                        if(file != null)
                        {
                            var uploadParams = new ImageUploadParams()
                            {
                                File = new FileDescription(file.FileName, file.OpenReadStream()),
                                AssetFolder = "drakeydiaz"
                            };

                            var uploadResult = await _cloudinary.UploadAsync(uploadParams);
                            var urlImagen = uploadResult.SecureUrl.ToString();

                            model.Imagenes!.NombreArchivo = file.FileName;
                            model.Imagenes.RutaArchivo = urlImagen;
                            model.Imagenes.PacienteId = model.Paciente!.Id;
                            _context.Imagenes.Add(model.Imagenes);
                        }
                       
                        await _context.SaveChangesAsync();
                        await transaction.CommitAsync();
                        TempData["AlertMessage"] = "La datos del paciente se actualizaron exitosamente!!!";
                        return RedirectToAction("Index");
                    }
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
