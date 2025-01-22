using Minsur.OrdenServicio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Minsur.OrdenServicio.Domain.DomainContract
{
    public interface ISolicitudServicioDomainService
    {
        SolicitudOrdenServicio ObtenerNuevaSolicitud();

        SolicitudOrdenServicio ObtenerSolicitudOrdenServicioPorId(int idSolicitudOrdenServicio, Usuario oUsuario);
        ListaSolicitudAutorizacion ObteneListaSolicitudAutorizacionAsignadaPorUsuarioYProyecto(SolicitudOrdenServicio oSolicitudOrdenServicio, SolicitudAutorizacion oSolicitudAutorizacion);
    }
}
