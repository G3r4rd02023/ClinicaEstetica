using EsteticaAvanzada.Data.Entidades;

namespace EsteticaAvanzada.Services
{
    public interface IServicioUsuario
    {
        Task<Usuario> ObtenerUsuario(string correo, string clave);
        Task<Usuario> GuardarUsuario(Usuario usuario);

    }
}
