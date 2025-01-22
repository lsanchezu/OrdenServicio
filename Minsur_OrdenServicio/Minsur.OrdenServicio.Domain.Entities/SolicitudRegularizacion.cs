using System;
using System.Collections.Generic;
using System.Text;

namespace Minsur.OrdenServicio.Domain.Entities
{
    public class SolicitudRegularizacion
    {
        public int Anio { get; set; }
        public int Mes { get; set; }
        public decimal ValorRegularizacion { get; set; }
        public decimal ValorNormal { get; set; }
    }

    public class ListaSolicitudRegularizacion : List<SolicitudRegularizacion> { }
}
