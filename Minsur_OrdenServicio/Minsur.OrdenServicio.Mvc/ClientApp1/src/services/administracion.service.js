import ApiService from './api.service';
import { URL_ADMINISTRACION } from '../constants/api.contants';

// Simular tiempo de respuesta 
const sleep = (ms) => (response) =>
    new Promise(resolve => setTimeout(() => resolve(response), ms));

export default {
    obtenerCompanias() {
        return ApiService.get(URL_ADMINISTRACION.ObtenerCompanias);
    },
    registrarCompania(compania) {
        return ApiService.post(URL_ADMINISTRACION.RegistrarCompania, compania, false);
    },
    editarCompania(compania) {
        return ApiService.update(URL_ADMINISTRACION.EditarCompania, compania.idCompania, compania);
    },
    obtenerProyectosPorCompania(idCompania) {
        return ApiService.query(URL_ADMINISTRACION.ObtenerProyectosPorCompania, { params: idCompania });
    },
    registrarProyecto(proyecto) {
        return ApiService.post(URL_ADMINISTRACION.RegistrarProyecto, proyecto, false);
    },
    editarProyecto(proyecto) {
        return ApiService.update(URL_ADMINISTRACION.EditarProyecto, proyecto.idProyecto, proyecto);
    },
    obtenerDisciplinas() {
        return ApiService.get(URL_ADMINISTRACION.ObtenerDisciplinas);
    },
    registrarDisciplina(disciplina) {
        return ApiService.post(URL_ADMINISTRACION.RegistrarDisciplina, disciplina, false);
    },
    editarDisciplina(disciplina) {
        return ApiService.update(URL_ADMINISTRACION.EditarDisciplina, disciplina.idDisciplina, disciplina);
    },
    obtenerConfiguracionGobernanzaPorProyecto(idProyecto) {
        return ApiService.query(URL_ADMINISTRACION.ObtenerConfiguracionGobernanzaPorProyecto, { params: idProyecto });
    },
    guardarConfiguracionGobernanzaPorProyecto(gobernanzaRequest) {
        return ApiService.post(URL_ADMINISTRACION.GuardarConfiguracionGobernanzaPorProyecto, gobernanzaRequest, false);
    },
    obtenerUsuarios(filtroUsuario) {
        return ApiService.query(URL_ADMINISTRACION.ObtenerUsuarios, { params: filtroUsuario })
    },
    editarUsuario(usuario) {
        return ApiService.update(URL_ADMINISTRACION.EditarUsuario, usuario.idUsuario, usuario);
    },
    obtenerListaConfiguracionUsuarioProyecto(filtroUsuarioProyecto) {
        return ApiService.query(URL_ADMINISTRACION.ObtenerListaConfiguracionUsuarioProyecto, { params: filtroUsuarioProyecto });
    },
    registrarUsuario(usuario) {
        return ApiService.post(URL_ADMINISTRACION.RegistrarUsuario, usuario, false);
    },
    obtenerRoles(){
        return ApiService.get(URL_ADMINISTRACION.ObtenerRoles)
    },
    guardarConfiguracionUsuarioProyecto(configuracionUsuarioProyectoRequest) {
        return ApiService.post(URL_ADMINISTRACION.GuardarConfiguracionUsuarioProyecto, configuracionUsuarioProyectoRequest, false);
    },
    obtenerListaConfiguracionRol(idProyecto) {
        return ApiService.query(URL_ADMINISTRACION.ObtenerListaConfiguracionRol, { params: idProyecto });
    },
    obtenerUsuarioPorCorreo(correo) {
        return ApiService.query(URL_ADMINISTRACION.ObtenerUsuarioPorCorreo, { params: correo })
    },
    guardarConfiguracionRol(gestionRolRequest){
        return ApiService.post(URL_ADMINISTRACION.GuardarConfiguracionRol, gestionRolRequest, false);
    }

}