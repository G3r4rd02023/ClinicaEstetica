using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using EsteticaAvanzada.Data;
using EsteticaAvanzada.Data.Entidades;
using EsteticaAvanzada.Models;
using EsteticaAvanzada.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rotativa.AspNetCore;

namespace EsteticaAvanzada.Controllers
{
    [Authorize]
    public class JuvedermController : Controller
    {
        private readonly DataContext _context;
        private readonly IServicioLista _lista;
        private readonly Cloudinary _cloudinary;

        public JuvedermController(DataContext context, IServicioLista lista, Cloudinary cloudinary)
        {
            _context = context;
            _lista = lista;
            _cloudinary = cloudinary;
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
                    Codigo = model.JuvedermAplicacion!.Codigo,
                    ZonasTratamiento = model.JuvedermAplicacion!.ZonasTratamiento,
                    Producto = model.JuvedermAplicacion!.Producto,
                    VolumenML = model.JuvedermAplicacion!.VolumenML,
                    Observaciones = model.JuvedermAplicacion.Observaciones
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

        public async Task<IActionResult> Details(int id)
        {
            var juvederm = await _context.JuvedermAplicaciones.
                Include(b => b.PlanAplicacion)
                .ThenInclude(p => p!.Paciente)
                .Where(b => b.Id == id)
                .FirstOrDefaultAsync();

            if (juvederm == null)
            {
                TempData["ErrorMessage"] = "Registro no encontrado";
            }

            var botox = await _context.BotoxAplicaciones.
                Include(b => b.PlanAplicacion)
                .ThenInclude(p => p!.Paciente)
                .Where(b => b.Id == id)
                .FirstOrDefaultAsync();

            if (botox == null)
            {
                TempData["ErrorMessage"] = "Botox no encontrado";
            }

            var imagenes = await _context.Imagenes.Where(i => i.PacienteId == juvederm!.PlanAplicacion!.Paciente!.Id).FirstOrDefaultAsync();
            var fotos = await _context.Imagenes.ToListAsync();
            var fotosPaciente = fotos.Where(f => f.PacienteId == juvederm!.PlanAplicacion!.Paciente!.Id
                                   && f.NombreArchivo!.StartsWith("fillers_"));

            var model = new PlanAplicacionViewModel()
            {
                BotoxAplicacion = botox,
                JuvedermAplicacion = juvederm,
                Paciente = juvederm!.PlanAplicacion!.Paciente,
                PlanAplicacion = juvederm!.PlanAplicacion,
                Imagenes = imagenes,
                Fotos = fotosPaciente.ToList()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Details(PlanAplicacionViewModel model, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                using var transaction = await _context.Database.BeginTransactionAsync();

                try
                {
                    model.Imagenes ??= new Imagenes();

                    if (file != null)
                    {
                        var uploadParams = new ImageUploadParams()
                        {
                            File = new FileDescription(file.FileName, file.OpenReadStream()),
                            AssetFolder = "drakeydiaz"
                        };

                        var uploadResult = await _cloudinary.UploadAsync(uploadParams);
                        var urlImagen = uploadResult.SecureUrl.ToString();

                        model.Imagenes!.NombreArchivo = "fillers_" + file.FileName;
                        model.Imagenes.RutaArchivo = urlImagen;
                        model.Imagenes.PacienteId = model.Paciente!.Id;
                        _context.Imagenes.Add(model.Imagenes);
                    }

                    await _context.SaveChangesAsync();
                    await transaction.CommitAsync();

                    TempData["AlertMessage"] = "El plan de aplicacion (fillers) del paciente se actualizo exitosamente!!!";
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

        public async Task<IActionResult> PDFRellenos(int id)
        {
            var paciente = await _context.Pacientes.FindAsync(id);

            if (paciente == null)
            {
                return NotFound();
            }

            return new ViewAsPdf("PDFRellenos", paciente)
            {
                FileName = $"Rellenos {paciente!.NombrePaciente}.pdf",
                PageOrientation = Rotativa.AspNetCore.Options.Orientation.Portrait,
                PageSize = Rotativa.AspNetCore.Options.Size.A4
            };
        }

        public async Task<IActionResult> PDFHilosTensores(int id)
        {
            var paciente = await _context.Pacientes.FindAsync(id);

            if (paciente == null)
            {
                return NotFound();
            }

            return new ViewAsPdf("PDFHilosTensores", paciente)
            {
                FileName = $"HilosTensores {paciente!.NombrePaciente}.pdf",
                PageOrientation = Rotativa.AspNetCore.Options.Orientation.Portrait,
                PageSize = Rotativa.AspNetCore.Options.Size.A4
            };
        }
    }
}