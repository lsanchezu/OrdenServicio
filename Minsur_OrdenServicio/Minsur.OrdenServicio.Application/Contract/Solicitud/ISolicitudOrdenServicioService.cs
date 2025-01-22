using Minsur.OrdenServicio.DTO;
using Minsur.OrdenServicio.DTO.Body;
using System;
using System.Collections.Generic;
using System.Text;

namespace Minsur.OrdenServicio.Application.Contract.Solicitud
{
    public interface ISolicitudOrdenServicioService
    {
        TransactionResponse RegistrarSolicitud(SolicitudOrdenServicioTransactionRequest oSolicitudOrdenServicioTransactionRequest);
        PaginationResponse<SolicitudOrdenServicioDto> Consultar(PaginationRequest<FiltroSolicitudDto> paginationRequest);
        SolicitudOrdenServicioDto ObtenerSolicitudOrdenServicioPorId(int idSolicitudOrdenServicio, UsuarioDto oUsuarioDto);
        SolicitudArchivoAdjuntoDto ObtenerArchivoAdjuntoPorId(int idSolicitudArchivoAdjunto);
        ListaSolicitudArchivoAdjuntoDto ObtenerArchivosAdjuntosPorSolicitud(int idSolicitudOrdenServicio);
        TransactionResponse RegistrarSolicitudvalidacion(SolicitudValidacionDto oSolicitudValidacionDto);
        TransactionResponse RegistrarSolicitudRecomendacion(SolicitudRecomendacionDto oSolicitudRecomendacionDto);
        TransactionResponse RegistrarSolicitudAutorizacion(SolicitudAutorizacionDto oSolicitudAutorizacionDto);
        ListaSolicitudOrdenServicioExportDto ConsultarExport(FiltroSolicitudDto oFiltroSolicitud);
        ListaSolicitudOrdenServicioExportDto ConsultarExportPorSolicitud(FiltroSolicitudDto oFiltroSolicitudDto);
        ListaSolicitudOrdenServicioExportDto ConsultarExportPorProveedor(FiltroSolicitudDto oFiltroSolicitudDto);
        DashboardResponse ObtenerDashboard(FiltroSolicitudDto oFiltroSolicitud);
        ListaSolicitudOrdenServicioDto ConsultarPendientesPorUsuario(int idUsuario);
    }
}
