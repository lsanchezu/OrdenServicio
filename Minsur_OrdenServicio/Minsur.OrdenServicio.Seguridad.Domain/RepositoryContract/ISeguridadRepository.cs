using Minsur.OrdenServicio.Seguridad.Domain.Entities;

namespace Minsur.OrdenServicio.Seguridad.Domain.RepositoryContract
{
    public interface ISeguridadRepository
    {
        ListaUsuario ObtenerUsuarios(FiltroUsuario oFiltroUsuario, Paginacion oPaginacion);
        void EditarUsuario(Usuario oUsuario);
        void RegistrarUsuario(Usuario oUsuario);
        ListaUsuario ObtenerNombreUsuarios();
        Usuario ObtenerUsuarioPorCorreo(string correo);
        Usuario ObtenerUsuarioPorCodigo(string codigoUsuario, string correo);
        ListaRol ObtenerRoles();
    }
}
