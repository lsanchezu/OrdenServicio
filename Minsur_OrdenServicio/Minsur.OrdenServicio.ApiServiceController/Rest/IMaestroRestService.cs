using SolicitudContext = Minsur.OrdenServicio.DTO;
using SolicitudContextBody = Minsur.OrdenServicio.DTO.Body;
using Refit;
using System.Threading.Tasks;

namespace Minsur.OrdenServicio.ApiServiceController.Rest
{
    [Headers("Accept: application/json")]
    public interface IMaestroRestService
    {
        [Get("/api/maestro/solicitud/{idUsuario}")]
        Task<SolicitudContextBody.MaestroSolicitudResponse> ObtenerMaestroSolicitud(int idUsuario);

        [Get("/api/maestro/proyectos/")]
        Task<SolicitudContext.ListaProyectoDto> ListarProyectoPorUsuario(int idUsuario, int idCompania);
    }
}
