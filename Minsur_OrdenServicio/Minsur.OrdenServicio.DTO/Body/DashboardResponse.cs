using System;
using System.Collections.Generic;
using System.Text;

namespace Minsur.OrdenServicio.DTO.Body
{
    public class DashboardResponse
    {
        public SolicitudOrdenServicioDashboardDto SolicitudOrdenServicioDashboardDto { get; set; }
        public ListaSolicitudRegularizacionDto ListaSolicitudRegularizacionDto { get; set; }
    }
}
