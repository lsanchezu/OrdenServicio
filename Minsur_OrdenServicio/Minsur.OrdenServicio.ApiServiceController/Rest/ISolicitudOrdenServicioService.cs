using SolicitudContext = Minsur.OrdenServicio.DTO;
using SolicitudContextBody = Minsur.OrdenServicio.DTO.Body;
using Refit;
using System.Threading.Tasks;

namespace Minsur.OrdenServicio.ApiServiceController.Rest
{
    [Headers("Accept: application/json")]
    public interface ISolicitudOrdenServicioService
    {
        [Get("/api/solicitud-ordenservicio/solicitudes")]
        Task<SolicitudContextBody.PaginationResponse<SolicitudContext.SolicitudOrdenServicioDto>> Consultar([Query] SolicitudContextBody.PaginationRequest<SolicitudContext.FiltroSolicitudDto> paginationReques);
        
        [Post("/api/solicitud-ordenservicio/solicitudes")]
        Task<SolicitudContextBody.TransactionResponse> RegistrarSolicitud([Body]SolicitudContextBody.SolicitudOrdenServicioTransactionRequest oSolicitudOrdenServicioTransactionRequest);

        [Get("/api/solicitud-ordenservicio/solicitudes/{id}")]
        Task<SolicitudContext.SolicitudOrdenServicioDto> ObtenerSolicitudOrdenServicioPorId(int id, [Query] SolicitudContext.UsuarioDto oUsuarioDto);

        [Get("/api/solicitud-ordenservicio/solicitudes/archivos/{id}")]
        Task<SolicitudContext.SolicitudArchivoAdjuntoDto> ObtenerArchivoAdjuntoPorId(int id);

        [Get("/api/solicitud-ordenservicio/solicitudes/{id}/archivos")]
        Task<SolicitudContext.ListaSolicitudArchivoAdjuntoDto> ObtenerArchivosAdjuntosPorSolicitud(int id);

        [Post("/api/solicitud-ordenservicio/solicitudes/validacion")]
        Task<SolicitudContextBody.TransactionResponse> RegistrarSolicitudvalidacion([Body]SolicitudContext.SolicitudValidacionDto oSolicitudValidacionDto);

        [Post("/api/solicitud-ordenservicio/solicitudes/recomendacion")]
        Task<SolicitudContextBody.TransactionResponse> RegistrarSolicitudRecomendacion([Body]SolicitudContext.SolicitudRecomendacionDto oSolicitudRecomendacionDto);

        [Post("/api/solicitud-ordenservicio/solicitudes/autorizacion")]
        Task<SolicitudContextBody.TransactionResponse> RegistrarSolicitudAutorizacion([Body]SolicitudContext.SolicitudAutorizacionDto oSolicitudAutorizacionDto);

        [Get("/api/solicitud-ordenservicio/solicitudes/export")]
        Task<SolicitudContext.ListaSolicitudOrdenServicioExportDto> ConsultarExport([Query] SolicitudContext.FiltroSolicitudDto oFiltroSolicitudDto);

        [Get("/api/solicitud-ordenservicio/solicitudes/export-por-solicitud")]
        Task<SolicitudContext.ListaSolicitudOrdenServicioExportDto> ConsultarExportPorSolicitud([Query] SolicitudContext.FiltroSolicitudDto oFiltroSolicitudDto);

        [Get("/api/solicitud-ordenservicio/solicitudes/export-por-proveedor")]
        Task<SolicitudContext.ListaSolicitudOrdenServicioExportDto> ConsultarExportPorProveedor([Query] SolicitudContext.FiltroSolicitudDto oFiltroSolicitudDto);
        
        [Get("/api/solicitud-ordenservicio/solicitudes/dashboard")]
        Task<SolicitudContextBody.DashboardResponse> ObtenerDashboard([Query] SolicitudContext.FiltroSolicitudDto oFiltroSolicitudDto);

        [Get("/api/solicitud-ordenservicio/solicitudes/{idUsuario}/pendientes")]
        Task<SolicitudContext.ListaSolicitudOrdenServicioDto> ConsultarPendientesPorUsuario(int idUsuario);

        [Post("/api/solicitud-ordenservicio/reportes/generar")]
        Task<SolicitudContextBody.TransactionResponse> GenerarPdf([Body]SolicitudContext.SolicitudOrdenServicioDto oSolicitudOrdenServicioDto);
    }

}
