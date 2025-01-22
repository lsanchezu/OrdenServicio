using Minsur.OrdenServicio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Minsur.OrdenServicio.Domain.RepositoryContract.Solicitud
{
    public interface ISolicitudOrdenServicioRepository
    {
        int Registrar(XmlDocument oXmlDocument, out string codigoSolicitud);
        ListaSolicitudOrdenServicio Consultar(FiltroSolicitud oFiltroReporte, Paginacion oPaginacion);
        SolicitudOrdenServicio ObtenerSolicitudPorId(int idSolicitudOrdenServicio);
        ListaSolicitudProveedorContratista ObtenerListaSolicitudProveedorContratistaPorIdSolicitud(int idSolicitudOrdenServicio);
        ListaSolicitudDocumento ObtenerListaSolicitudDocumentoPorIdSolicitud(int idSolicitudOrdenServicio);
        ListaSolicitudArchivoAdjunto ObtenerListaSolicitudArchivoAdjunto(int idSolicitudDocumento);
        SolicitudArchivoAdjunto ObtenerArchivoAdjuntoPorId(int idSolicitudArchivoAdjunto);
        ListaSolicitudArchivoAdjunto ObtenerListaArchivoAdjuntoPorSolicitud(int idSolicitudOrdenServicio);
        ListaSolicitudAutorizacion obtenerListaSolicitudAutorizacion(int idSolicitudOrdenServicio);
        void RegistrarSolicitudValidacion(SolicitudOrdenServicio oSolicitudOrdenServicio);
        void RegistrarSolicitudRecomendacion(SolicitudRecomendacion oSolicitudRecomendacio);
        void RegistrarSolicitudAutorizacion(SolicitudOrdenServicio oSolicitudOrdenServicio, XmlDocument SolicitudOrdenServicioXml);
        bool ValidarAreaFuncionalProyecto(int idAreaFuncional, int idProyecto, int idUsuario);
        bool ValidarControlProyecto(int idProyecto, int idUsuario, bool flagProcura);
        Gobernanza ObtenerGobernanzaAprobacionPorSolicitud(int IdSolicitudOrdenServicio);
        ListaGobernanza ListarGobernanzaPorProyecto(int idProyecto);
        bool ValidarGobernanzaProyectoUsuario(int idProyecto, int idGobernaza, int idUsuario);
        Usuario ObtenerUsuarioSolicitudPorIdSolicitudContrato(int idSolicitudContratoServicio);
        List<Usuario> ObtenerListaUsuarioControlProyectoProcuraPorSolicitud(int idSolicitudContratoServicio, bool FlagProcuraContrato);
        List<Usuario> ObtenerListaUsuarioAutorizacionPorSolicitud(int idSolicitudContratoServicio);
        int RegistrarSolicitudOrdenServicioEmail(SolicitudOrdenServicioEmail oSolicitudOrdenServicioEmail);
        ListaSolicitudOrdenServicioExport ConsultarExport(FiltroSolicitud oFiltroSolicitud);
        ListaSolicitudOrdenServicioExport ConsultarExportPorSolicitud(FiltroSolicitud oFiltroSolicitud);
        ListaSolicitudOrdenServicioExport ConsultarExportPorProveedor(FiltroSolicitud oFiltroSolicitud);
        SolicitudOrdenServicioDashboard ObtenerDashboard(FiltroSolicitud oFiltroSolicitud);
        ListaSolicitudRegularizacion ObtenerDashboardSolicitudRegularizacion(FiltroSolicitud oFiltroSolicitud);
        ListaSolicitudOrdenServicio ConsultarPendientesPorUsuario(int idUsuario);
    }
}
