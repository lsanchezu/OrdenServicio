using SeguridadContext = Minsur.OrdenServicio.DTO.Seguridad;
using Refit;
using System.Threading.Tasks;

namespace Minsur.OrdenServicio.ApiServiceController.Rest
{
    [Headers("Accept: application/json")]
    public interface ISeguridadService
    {
        [Get("/api/seguridad/usuarios")]
        Task<SeguridadContext.PaginationResponse<SeguridadContext.UsuarioDto>> ObtenerUsuarios([Query] SeguridadContext.PaginationRequest<SeguridadContext.FiltroUsuarioDto> oPaginationRequest);
        
        [Put("/api/seguridad/usuarios")]
        Task<SeguridadContext.TransactionResponse> EditarUsuario(int id, SeguridadContext.UsuarioDto oUsuarioDto);

        [Post("/api/seguridad/usuarios")]
        Task<SeguridadContext.TransactionResponse> RegistrarUsuario(SeguridadContext.UsuarioDto oUsuarioDto);

        [Get("/api/seguridad/usernames")]
        Task<SeguridadContext.ListaUsuarioDto> ObtenerNombreUsuarios();

        [Get("/api/seguridad/usuario/{correo}")]
        Task<SeguridadContext.UsuarioDto> ObtenerUsuarioPorCorreo(string correo);

        [Get("/api/seguridad/roles")]
        Task<SeguridadContext.ListaRolDto> ObtenerRoles();
    }
}
