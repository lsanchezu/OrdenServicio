export default {
    "SET_LOADING" (state, activo) {
        state.loading = activo
    },
    "REGISTRAR_SOLICITUD" (state, solicitud)  {
        state.listaSolicitud.push(solicitud);
    },
    "ACTUALIZAR_SOLICITUD" (state, solicitud)  {
        const item = state.listaSolicitud.find(item => item.correlativo === solicitud.correlativo);
        Object.assign(item, solicitud);
    }
}