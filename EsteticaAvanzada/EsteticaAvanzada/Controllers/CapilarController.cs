using CloudinaryDotNet.Actions;
using CloudinaryDotNet;
using EsteticaAvanzada.Data;
using EsteticaAvanzada.Data.Entidades;
using EsteticaAvanzada.Models;
using EsteticaAvanzada.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EsteticaAvanzada.Controllers
{
    public class CapilarController : Controller
    {
        private readonly DataContext _context;
        private readonly IServicioLista _lista;
        private readonly Cloudinary _cloudinary;

        public CapilarController(DataContext context, IServicioLista lista, Cloudinary cloudinary)
        {
            _context = context;
            _lista = lista;
            _cloudinary = cloudinary;
        }

        public async Task<IActionResult> Index()
        {
            var capilar = await _context.TratamientoCapilar
                .Include(h => h.Paciente)
                .ToListAsync();

            return View(capilar);
        }

        public async Task<IActionResult> Create()
        {
            var pacientes = await _lista!.GetListaPacientes();
            if (pacientes == null)
            {
                TempData["AlertMessage"] = "No se encontraron pacientes";
            }

            CapilarViewModel model = new()
            {
                Pacientes = pacientes,
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CapilarViewModel model)
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

                TratamientoCapilar tratamiento = new()
                {
                    Paciente = paciente,
                    AntecedentesInmunoAlergicos = model.AntecedentesInmunoAlergicos,
                    AntecedentesPatologicos = model.AntecedentesPatologicos,
                    AntecedentesQuirurgicos = model.AntecedentesQuirurgicos,
                    Diagnostico = model.Diagnostico,
                    MotivoConsulta = model.MotivoConsulta,
                    PlanTratamiento = model.PlanTratamiento,
                    SesionesProgramadas = sesiones
                };
                _context.TratamientoCapilar.Add(tratamiento);
                await _context.SaveChangesAsync();
                TempData["AlertMessage"] = "Datos ingresados exitosamente!!!";
                return RedirectToAction("Index");
            }
            model.Pacientes = await _lista.GetListaPacientes();
            return View(model);
        }

        public async Task<IActionResult> Details(int id)
        {
            var tratamiento = await _context.TratamientoCapilar
                .Include(n => n.Paciente)
                .Include(n => n.SesionesProgramadas)
                .FirstOrDefaultAsync(n => n.Id == id);

            if (tratamiento == null)
            {
                return NotFound();
            }

            var imagenes = await _context.Imagenes.Where(i => i.PacienteId == tratamiento!.Paciente!.Id).FirstOrDefaultAsync();
            var fotos = await _context.Imagenes.ToListAsync();
            var fotosPaciente = fotos.Where(f => f.PacienteId == tratamiento!.Paciente!.Id
                                   && f.NombreArchivo!.StartsWith("capilar_"));

            var model = new CapilarViewModel()
            {
                Diagnostico = tratamiento.Diagnostico,
                PlanTratamiento = tratamiento.PlanTratamiento,
                Paciente = tratamiento.Paciente,
                SesionesProgramadas = tratamiento.SesionesProgramadas,
                Imagenes = imagenes,
                Fotos = fotosPaciente.ToList()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Details(CapilarViewModel model, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                using var transaction = await _context.Database.BeginTransactionAsync();

                try
                {
                    if (model.SesionesProgramadas != null)
                    {
                        var existingSesiones = await _context.SesionesProgramadas
                            .FirstOrDefaultAsync(mc => mc.Id == model.SesionesProgramadas.Id);

                        if (existingSesiones != null)
                        {
                            model.SesionesProgramadas.Id = existingSesiones.Id;
                            model.SesionesProgramadas.PacienteId = model.Paciente!.Id;
                            _context.Entry(existingSesiones).CurrentValues.SetValues(model.SesionesProgramadas);
                        }
                        else
                        {
                            model.SesionesProgramadas.PacienteId = model.Paciente!.Id;
                            _context.SesionesProgramadas.Add(model.SesionesProgramadas);
                        }
                    }

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

                        model.Imagenes!.NombreArchivo = "capilar_" + file.FileName;
                        model.Imagenes.RutaArchivo = urlImagen;
                        model.Imagenes.PacienteId = model.Paciente!.Id;
                        _context.Imagenes.Add(model.Imagenes);
                    }

                    await _context.SaveChangesAsync();
                    await transaction.CommitAsync();

                    TempData["AlertMessage"] = "El historial de tratamiento del paciente se actualizo exitosamente!!!";
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