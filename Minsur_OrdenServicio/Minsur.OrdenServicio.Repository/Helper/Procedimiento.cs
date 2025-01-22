namespace Minsur.OrdenServicio.Repository.Helper
{
    public class Procedimiento
    {
        public struct Solicitud
        {
            public const string Usp_Ins_SolicitudOrdenServicio = "[Solicitud].[Usp_Ins_SolicitudOrdenServicio]";
            public const string Usp_Consultar_SolicitudOrdenServicio = "[Solicitud].[Usp_Consultar_SolicitudOrdenServicio]";
            public const string Usp_Sel_SolicitudOrdenServicio_Por_Id = "[Solicitud].[Usp_Sel_SolicitudOrdenServicio_Por_Id]";
            public const string Usp_Sel_SolicitudProveedorContratista = "[Solicitud].[Usp_Sel_SolicitudProveedorContratista]";
            public const string Usp_Sel_SolicitudDocumento = "[Solicitud].[Usp_Sel_SolicitudDocumento]";
            public const string Usp_Sel_SolicitudArchivoAdjunto_Por_IdSolicitudDocumento = "[Solicitud].[Usp_Sel_SolicitudArchivoAdjunto_Por_IdSolicitudDocumento]";
            public const string Usp_Sel_SolicitudArchivoAdjunto_Por_Id = "[Solicitud].[Usp_Sel_SolicitudArchivoAdjunto_Por_Id]";
            public const string Usp_Sel_SolicitudArchivoAdjunto_Por_IdSolicitudOrdenServicio = "[Solicitud].[Usp_Sel_SolicitudArchivoAdjunto_Por_IdSolicitudOrdenServicio]";
            public const string Usp_Sel_SolicitudAutorizacion = "[Solicitud].[Usp_Sel_SolicitudAutorizacion]";

            public const string Usp_Ins_SolicitudValidacion = "[Solicitud].[Usp_Ins_SolicitudValidacion]";
            public const string Usp_Ins_SolicitudRecomendacion = "[Solicitud].[Usp_Ins_SolicitudRecomendacion]";
            public const string Usp_Ins_SolicitudAutorizacion = "[Solicitud].[Usp_Ins_SolicitudAutorizacion]";
            public const string Usp_Validar_Area_Funcional_Proyecto = "[Solicitud].[Usp_Validar_Area_Funcional_Proyecto]";
            public const string Usp_Validar_Control_Proyecto = "[Solicitud].[Usp_Validar_Control_Proyecto]";
            public const string Usp_Sel_Gobernaza_Aprobacion_Por_Solicitud = "[Solicitud].[Usp_Sel_Gobernaza_Aprobacion_Por_Solicitud]";
            public const string Usp_Validar_GobernanzaProyectoUsuario = "[Solicitud].[Usp_Validar_GobernanzaProyectoUsuario]";
            public const string Usp_Sel_Gobernanza_Por_Proyecto = "[Solicitud].[Usp_Sel_Gobernanza_Por_Proyecto]";
            public const string Usp_Sel_Usuario_SolicitudContrato = "[Solicitud].[Usp_Sel_Usuario_SolicitudContrato]";
            public const string Usp_Sel_Usuario_ControlProyecto_Procura_Por_Solicitud = "[Solicitud].[Usp_Sel_Usuario_ControlProyecto_Procura_Por_Solicitud]";
            public const string Usp_Sel_Usuario_Autorizacion_Por_Solicitud = "[Solicitud].[Usp_Sel_Usuario_Autorizacion_Por_Solicitud]";
            public const string Usp_Ins_SolicitudOrdenServicioEmail = "[Solicitud].[Usp_Ins_SolicitudOrdenServicioEmail]";
            public const string Usp_Export_SolicitudOrdenServicio = "[Solicitud].[Usp_Export_SolicitudOrdenServicio]";
            public const string Usp_Export_SolicitudOrdenServicio_Por_Proveedor = "[Solicitud].[Usp_Export_SolicitudOrdenServicio_Por_Proveedor]";
            public const string Usp_Consultar_SolicitudOrdenServicio_Export = "[Solicitud].[Usp_Consultar_SolicitudOrdenServicio_Export]";
            public const string Usp_Dashboard_SolicitudOrdenServicio = "[Solicitud].[Usp_Dashboard_SolicitudOrdenServicio]";
            public const string Usp_Dashboard_Regularizacion = "[Solicitud].[Usp_Dashboard_Regularizacion]";
            public const string Usp_Consultar_Pendientes_Por_Usuario = "[Solicitud].[Usp_Consultar_Pendientes_Por_Usuario]";
        }

        public struct Maestro
        {
            public const string Usp_Sel_AreaFuncional = "[Maestro].[Usp_Sel_AreaFuncional]";
            public const string Usp_Sel_Compania = "[Maestro].[Usp_Sel_Compania]";
            public const string Usp_Sel_FaseProyecto = "[Maestro].[Usp_Sel_FaseProyecto]";
            public const string Usp_Sel_FuenteContrato = "[Maestro].[Usp_Sel_FuenteContrato]";
            public const string Usp_Sel_Moneda = "[Maestro].[Usp_Sel_Moneda]";
            public const string Usp_Sel_Proyecto = "[Maestro].[Usp_Sel_Proyecto]";
            public const string Usp_Sel_Proyecto_Por_Usuario = "[Maestro].[Usp_Sel_Proyecto_Por_Usuario]";
            public const string Usp_Sel_TipoDocumento = "[Maestro].[Usp_Sel_TipoDocumento]";
            public const string Usp_Sel_Pais = "[Maestro].[Usp_Sel_Pais]";
            public const string Usp_Sel_Estado_Por_IdGrupo = "[Maestro].[Usp_Sel_Estado_Por_IdGrupo]";
            public const string Usp_Sel_Gobernanza_Por_Id = "[Maestro].[Usp_Sel_Gobernanza_Por_Id]";
            public const string Usp_Sel_EmailParametro_Por_Id = "[Maestro].[Usp_Sel_EmailParametro_Por_Id]";
            public const string Usp_Sel_Tipo = "[Maestro].[Usp_Sel_Tipo]";
        }

        public struct Administracion
        {
            public const string Usp_Sel_Companias = "[Maestro].[Usp_Sel_Companias]";
            public const string Usp_Sel_Proyecto_Por_Compania = "[Maestro].[Usp_Sel_Proyecto_Por_Compania]";
            public const string Usp_Sel_Disciplina = "[Maestro].[Usp_Sel_Disciplina]";
            public const string Usp_Sel_Disciplinas_Activas = "[Maestro].[Usp_Sel_Disciplinas_Activas]";
            public const string Usp_Sel_ConfiguracionGobernanza_Por_Proyecto = "[Configuracion].[Usp_Sel_ConfiguracionGobernanza_Por_Proyecto]";
            public const string Usp_Sel_ConfiguracionProyecto_Por_usuario = "[Configuracion].[Usp_Sel_ConfiguracionProyecto_Por_usuario]";
            public const string Usp_Sel_Roles_De_Gobernanza_Por_Proyecto = "[Configuracion].[Usp_Sel_Roles_De_Gobernanza_Por_Proyecto]";
            public const string Usp_Sel_Roles_De_Gobernanza_Configurados = "[Configuracion].[Usp_Sel_Roles_De_Gobernanza_Configurados]";
            public const string Usp_Sel_Roles_De_Disciplina_Configurados = "[Configuracion].[Usp_Sel_Roles_De_Disciplina_Configurados]";
            
            public const string Usp_Ins_Compania = "[Maestro].[Usp_Ins_Compania]";
            public const string Usp_Ins_Proyecto = "[Maestro].[Usp_Ins_Proyecto]";
            public const string Usp_Ins_Disciplina = "[Maestro].[Usp_Ins_Disciplina]";

            public const string Usp_Upd_Compania = "[Maestro].[Usp_Upd_Compania]";
            public const string Usp_Upd_Proyecto = "[Maestro].[Usp_Upd_Proyecto]";
            public const string Usp_Upd_Disciplina = "[Maestro].[Usp_Upd_Disciplina]";

            public const string Usp_Guardar_ConfiguracionGobernanza = "[Configuracion].[Usp_Guardar_ConfiguracionGobernanza]";
            public const string Usp_Guardar_ConfiguracionUsuarioProyecto = "[Configuracion].[Usp_Guardar_ConfiguracionUsuarioProyecto]";
            public const string Usp_Guardar_ConfiguracionRol = "[Configuracion].[Usp_Guardar_ConfiguracionRol]";

        }
        public struct Seguridad
        {
            public const string Usp_Sel_Usuarios = "[Seguridad].[Usp_Sel_Usuarios]";
            public const string Usp_Sel_NombreUsuarios = "[Seguridad].[Usp_Sel_NombreUsuarios]";
            public const string Usp_Sel_Usuario_Por_Correo = "[Seguridad].[Usp_Sel_Usuario_Por_Correo]";
            public const string Usp_Sel_Usuario_Por_Codigo_O_Correo = "[Seguridad].[Usp_Sel_Usuario_Por_Codigo_O_Correo]";
            public const string Usp_Sel_Roles = "[Seguridad].[Usp_Sel_Roles]";

            public const string Usp_Ins_Usuario = "[Seguridad].[Usp_Ins_Usuario]";
            public const string Usp_Upd_Usuario = "[Seguridad].[Usp_Upd_Usuario]";
        }

    }
}
