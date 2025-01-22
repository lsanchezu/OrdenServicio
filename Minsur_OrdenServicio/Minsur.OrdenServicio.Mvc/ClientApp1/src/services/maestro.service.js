import ApiService from './api.service';
import {URL_MAESTRO} from '../constants/api.contants';

export default {
    obtenerMaestroSolicitud(){
        return ApiService.get(URL_MAESTRO.MaestroSolicitud);
    },
    obtenerMaestroConsulta(){
        return ApiService.get(URL_MAESTRO.MaestroConsulta);
    },
    listarProyectoPorUsuario(filtroCompania){
        return ApiService.query(
            URL_MAESTRO.ListarProyectoPorUsuario,
            { params: filtroCompania }
          );
    },
}