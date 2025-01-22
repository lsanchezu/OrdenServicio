export const ID_TOKEN_KEY = "tk_s_c_s"
export const URL_MAESTRO = {
   MaestroSolicitud : 'Maestro/ObtenerMaestroSolicitud',
   MaestroConsulta : 'Maestro/ObtenerMaestroConsulta',
   ListarProyectoPorUsuario : 'Maestro/ListarProyectoPorUsuario'
}

export const URL_SOLICITUD = {
    Login: "/SolicitudOrdenServicio/Login",
    NuevaSolicitud: "SolicitudOrdenServicio/ObtenerNuevaSolicitud",
    RegistrarSolicitud: "SolicitudOrdenServicio/RegistrarSolicitud",
    ConsultarSolicitud: "SolicitudOrdenServicio/ConsultarSolicitud",
    ObtenerSolicitudPorId: "SolicitudOrdenServicio/ObtenerSolicitudPorId",
    DescargarArchivo: "SolicitudOrdenServicio/DescargarArchivo",
    DescargarTodo: "SolicitudOrdenServicio/DescargarTodo",
    RegistrarSolicitudValidacion: "SolicitudOrdenServicio/RegistrarSolicitudValidacion",
    RegistrarSolicitudRecomendacion: "SolicitudOrdenServicio/RegistrarSolicitudRecomendacion",
    RegistrarSolicitudAutorizacion: "SolicitudOrdenServicio/RegistrarSolicitudAutorizacion",
    ObtenerDashboard: "SolicitudOrdenServicio/ObtenerDashboard",
    ConsultarExport: "SolicitudOrdenServicio/ConsultarExportPorSolicitud",
    ConsultarPendientesPorUsuario: "SolicitudOrdenServicio/ConsultarPendientesPorUsuario"
}

export const URL_ADMINISTRACION = {
    ObtenerCompanias: "Administracion/ObtenerCompanias",
    RegistrarCompania: "Administracion/RegistrarCompania",
    EditarCompania: "Administracion/EditarCompania",
    ObtenerProyectosPorCompania: "Administracion/ObtenerProyectosPorCompania",
    RegistrarProyecto: "Administracion/RegistrarProyecto",
    EditarProyecto: "Administracion/EditarProyecto",
    ObtenerDisciplinas: "Administracion/ObtenerDisciplinas",
    RegistrarDisciplina: "Administracion/RegistrarDisciplina",
    EditarDisciplina: "Administracion/EditarDisciplina",
    ObtenerConfiguracionGobernanzaPorProyecto: "Administracion/ObtenerConfiguracionGobernanzaPorProyecto",
    GuardarConfiguracionGobernanzaPorProyecto: "Administracion/GuardarConfiguracionGobernanzaPorProyecto",
    ObtenerUsuarios: "Administracion/ObtenerUsuarios",
    EditarUsuario: "Administracion/EditarUsuario",
    ObtenerListaConfiguracionUsuarioProyecto: "Administracion/ObtenerListaConfiguracionUsuarioProyecto",
    RegistrarUsuario: "Administracion/RegistrarUsuario",
    ObtenerRoles: "Administracion/obtenerRoles",
    GuardarConfiguracionUsuarioProyecto: "Administracion/GuardarConfiguracionUsuarioProyecto",
    ObtenerListaConfiguracionRol: "Administracion/ObtenerListaConfiguracionRol",
    ObtenerUsuarioPorCorreo: "Administracion/ObtenerUsuarioPorCorreo",
    GuardarConfiguracionRol: "Administracion/GuardarConfiguracionRol"
}
