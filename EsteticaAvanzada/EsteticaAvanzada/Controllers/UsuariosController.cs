using EsteticaAvanzada.Data;
using EsteticaAvanzada.Data.Entidades;
using EsteticaAvanzada.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EsteticaAvanzada.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly IServicioUsuario _servicioUsuario;
        private readonly DataContext _context;

        public UsuariosController(IServicioUsuario servicioUsuario, DataContext context)
        {
            _servicioUsuario = servicioUsuario;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Usuarios.ToListAsync());
        }

        public IActionResult Create()
        {
            Usuario usuario = new()
            {
                FechaCreacion = DateTime.Now,
                Rol = TipoUsuario.Administrador
            };
            return View(usuario);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Usuario usuario)
        {
            await _servicioUsuario.GuardarUsuario(usuario);
            return RedirectToAction("Index", "Usuarios");
        }

        public async Task<IActionResult> Edit(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return View(usuario);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Usuario usuario)
        {
            usuario.Contraseña = BCrypt.Net.BCrypt.HashPassword(usuario.Contraseña);
            _context.Update(usuario);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Usuarios");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }
            _context.Remove(usuario);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", "Usuarios");
        }
    }
}