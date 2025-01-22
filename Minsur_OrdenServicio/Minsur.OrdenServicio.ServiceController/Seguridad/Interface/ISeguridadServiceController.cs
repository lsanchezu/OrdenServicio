using Minsur.OrdenServicio.DTO;
using SeguridadPerfil = Komatsu.Core.Seguridad.ServicioPerfil;

namespace Minsur.OrdenServicio.ServiceController.Seguridad.Interface
{
    public interface ISeguridadServiceController
    {
        UsuarioDto AuthenticateUser(string usuario, string contrasena);
        SeguridadPerfil.ListaMenu ObtenerSitemapPorUsuario(string nombreUsuario, int idAplicacion, int idRol);
    }
}
