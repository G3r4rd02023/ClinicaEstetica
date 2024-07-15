using EsteticaAvanzada.Data.Entidades;
using Microsoft.EntityFrameworkCore;

namespace EsteticaAvanzada.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;

        public SeedDb(DataContext context)
        {
            _context = context;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await ValidarUsuariosAsync("Admin", "superadmin@example.hn", "123456", TipoUsuario.Administrador);
        }

        private async Task<Usuario> ValidarUsuariosAsync(string nombreCompleto, string correo, string clave, TipoUsuario rol)
        {
            var usuarioExistente = await _context.Usuarios.FirstOrDefaultAsync(u => u.Correo == correo);
            if (usuarioExistente != null)
            {
                return usuarioExistente;
            }

            Usuario usuario = new()
            {              
                NombreCompleto = nombreCompleto,                
                Correo = correo,
                Contraseña = clave,               
                Rol = rol,
                FechaCreacion = DateTime.Now,               
            };

            usuario.Contraseña = BCrypt.Net.BCrypt.HashPassword(usuario.Contraseña);

            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
            return usuario;
        }
    }
}
