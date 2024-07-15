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
    }
}
