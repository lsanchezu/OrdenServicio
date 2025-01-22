using Minsur.OrdenServicio.DTO;
using Minsur.OrdenServicio.DTO.Body;
using System;
using System.Collections.Generic;
using System.Text;

namespace Minsur.OrdenServicio.ApiServiceController.Interface
{
    public interface IMaestroApiServiceController
    {
        MaestroSolicitudResponse ObtenerMaestroSolicitud(int idUsuario);
        ListaProyectoDto ListarProyectoPorUsuario(int idUsuario, int idCompania);
    }
}
