using System;
using System.Collections.Generic;
using System.Text;

namespace Minsur.OrdenServicio.DTO
{
    public class SolicitudOrdenServicioDashboardDto
    {
        public int TotalPedienteAprobacion { get; set; }
        public int TotalRegularizacion { get; set; }
        public int TotalFuenteLicitacionConcurso { get; set; }
        public int TotalFuentePreferente { get; set; }
        public int TotalFuenteSoleSource { get; set; }
    }
}
