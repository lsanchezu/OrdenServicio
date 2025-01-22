using Minsur.OrdenServicio.DTO;
using Minsur.OrdenServicio.DTO.Body;
using System;
using System.Collections.Generic;
using System.Text;

namespace Minsur.OrdenServicio.ApiServiceController.Interface
{
    public interface ISolicitudOrdenServicioApiServiceController
    {
        PaginationResponse<SolicitudOrdenServicioDto> Consultar(PaginationRequest<FiltroSolicitudDto> paginationRequest);
        TransactionResponse RegistrarSolicitud(SolicitudOrdenServicioTransactionRequest oSolicitudOrdenServicioTransactionRequest);
        SolicitudOrdenServicioDto ObtenerSolicitudOrdenServicioPorId(int idSolicicitudContratacion, UsuarioDto oUsuarioDto);
        SolicitudArchivoAdjuntoDto ObtenerArchivoAdjuntoPorId(int idArchivoAdjunto);
        ListaSolicitudArchivoAdjuntoDto ObtenerArchivosAdjuntosPorSolicitud(int idSolicicitudContratacion);
        TransactionResponse RegistrarSolicitudvalidacion(SolicitudValidacionDto oSolicitudValidacionDto);
        TransactionResponse RegistrarSolicitudRecomendacion(SolicitudRecomendacionDto oSolicitudRecomendacionDto);
        TransactionResponse RegistrarSolicitudAutorizacion(SolicitudAutorizacionDto oSolicitudAutorizacionDto);
        ListaSolicitudOrdenServicioExportDto ConsultarExport(FiltroSolicitudDto oFiltroSolicitud);
        ListaSolicitudOrdenServicioExportDto ConsultarExportPorSolicitud(FiltroSolicitudDto oFiltroSolicitud);
        ListaSolicitudOrdenServicioExportDto ConsultarExportPorProveedor(FiltroSolicitudDto oFiltroSolicitud);
        DashboardResponse ObtenerDashboard(FiltroSolicitudDto oFiltroSolicitud);
        ListaSolicitudOrdenServicioDto ConsultarPendientesPorUsuario(int idUsuario);
        TransactionResponse GenerarPdf(SolicitudOrdenServicioDto oSolicitudOrdenServicioDto);
    }
}
