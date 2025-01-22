import ApiService from './api.service';
import { URL_SOLICITUD } from '../constants/api.contants';


export default {
    obtenerSiteMap() {
        return ApiService.get('Auth/ObtenerSitemap');
    },
    obtenerNuevaSolicitud() {
        return ApiService.get(URL_SOLICITUD.NuevaSolicitud);
    },
    registrarSolicitud(solicitud) {
        return ApiService.post(URL_SOLICITUD.RegistrarSolicitud, solicitud, true);
    },
    consultarSolicitud(filtroSolicitud) {
        return ApiService.query(
            URL_SOLICITUD.ConsultarSolicitud,
            { params: filtroSolicitud }
        );
    },
    obtenerSolicitud(idSolicitudOrdenServicio) {
        return ApiService.query(
            URL_SOLICITUD.ObtenerSolicitudPorId,
            { params: idSolicitudOrdenServicio }
        );
    },
    registrarSolicitudValidacion(solicitudValidacion) {
        return ApiService.post(URL_SOLICITUD.RegistrarSolicitudValidacion, solicitudValidacion, false);
    },
    registrarSolicitudRecomendacion(solicitudRecomendacion) {
        return ApiService.post(URL_SOLICITUD.RegistrarSolicitudRecomendacion, solicitudRecomendacion, false);
    },
    registrarSolicitudAutorizacion(solicitudAutorizacion) {
        return ApiService.post(URL_SOLICITUD.RegistrarSolicitudAutorizacion, solicitudAutorizacion, false);
    },
    obtenerDashboard(filtroSolicitud) {
        return ApiService.query(
            URL_SOLICITUD.ObtenerDashboard,
            { params: filtroSolicitud }
        );
    },
    consultarSolicitudExport(filtroSolicitud) {
        return ApiService.query(
            URL_SOLICITUD.ConsultarExport,
            { params: filtroSolicitud }
        );
    },
    consultarPendientesPorUsuario() {
        return ApiService.get(URL_SOLICITUD.ConsultarPendientesPorUsuario);
    },
}