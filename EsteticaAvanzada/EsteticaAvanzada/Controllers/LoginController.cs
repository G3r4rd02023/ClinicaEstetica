using EsteticaAvanzada.Data;
using EsteticaAvanzada.Data.Entidades;
using EsteticaAvanzada.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EsteticaAvanzada.Controllers
{
    public class LoginController : Controller
    {
        private readonly DataContext _context;
        private readonly IServicioUsuario _servicioUsuario;

        public LoginController(DataContext context, IServicioUsuario servicioUsuario)
        {
            _context = context;
            _servicioUsuario = servicioUsuario;
        }

        public IActionResult IniciarSesion()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> IniciarSesion(string correo, string clave)
        {
            Usuario usuarioEncontrado = await _servicioUsuario.ObtenerUsuario(correo, clave);

            if (usuarioEncontrado == null)
            {
                TempData["ErrorMessage"] = "Usuario o clave incorrectos, Intente nuevamente";
                return View();
            }

            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, usuarioEncontrado.NombreCompleto)
                //new Claim("FotoPerfil", usuarioEncontrado.URLFoto!),
            };

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            AuthenticationProperties properties = new AuthenticationProperties()
            {
                AllowRefresh = true,
            };

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                properties
                );

            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> CerrarSesion()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("IniciarSesion", "Login");
        }
    }
}