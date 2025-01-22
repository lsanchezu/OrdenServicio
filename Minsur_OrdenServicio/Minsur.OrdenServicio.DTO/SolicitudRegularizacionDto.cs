using System;
using System.Collections.Generic;
using System.Text;

namespace Minsur.OrdenServicio.DTO
{
    public class SolicitudRegularizacionDto
    {
        public int Anio { get; set; }
        public int Mes { get; set; }
        public decimal ValorRegularizacion { get; set; }
        public decimal ValorNormal { get; set; }
    }

    public class ListaSolicitudRegularizacionDto : List<SolicitudRegularizacionDto> { }
}
