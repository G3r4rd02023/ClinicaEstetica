using EsteticaAvanzada.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EsteticaAvanzada.Data.Entidades;

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

    }
}
