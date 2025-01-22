using Minsur.OrdenServicio.DTO.Seguridad;

namespace Minsur.OrdenServicio.ApiServiceController.Interface.Seguridad
{
    public interface ISeguridadApiServiceController
    {
        PaginationResponse<UsuarioDto> ObtenerUsuarios(PaginationRequest<FiltroUsuarioDto> oPaginationRequest);
        TransactionResponse EditarUsuario(int id, UsuarioDto oUsuarioDto);
        TransactionResponse RegistrarUsuario(UsuarioDto oUsuarioDto);
        ListaUsuarioDto ObtenerNombreUsuarios();
        UsuarioDto ObtenerUsuarioPorCorreo(string correo);
        ListaRolDto ObtenerRoles();
    }
}
