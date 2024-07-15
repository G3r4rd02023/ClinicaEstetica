using EsteticaAvanzada.Data;
using EsteticaAvanzada.Data.Entidades;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace EsteticaAvanzada.Services
{
    public class ServicioUsuario : IServicioUsuario
    {
        private readonly DataContext _context;
       

        public ServicioUsuario(DataContext context)
        {
            _context = context;           
        }

        public async Task<Usuario> ObtenerUsuario(string correo, string clave)
        {
            Usuario? usuario = await _context.Usuarios.Where(u => u.Correo == correo).FirstOrDefaultAsync();

            if (usuario != null && BCrypt.Net.BCrypt.Verify(clave, usuario.Contraseña))
            {
                return usuario;
            }

            return null!;
        }


        public async Task<Usuario> GuardarUsuario(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
            return usuario;
        }
    }
}









































































































































































