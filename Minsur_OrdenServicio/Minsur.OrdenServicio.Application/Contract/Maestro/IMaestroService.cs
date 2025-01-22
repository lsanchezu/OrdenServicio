using Minsur.OrdenServicio.DTO;
using Minsur.OrdenServicio.DTO.Body;
using System;
using System.Collections.Generic;
using System.Text;

namespace Minsur.OrdenServicio.Application.Contract.Maestro
{
    public interface IMaestroService
    {
        MaestroSolicitudResponse ObtenerMaestroSolicitud(int idUsuario);
        ListaProyectoDto ListarProyectoPorUsuario(int idUsuario, int idCompania);
    }
}
