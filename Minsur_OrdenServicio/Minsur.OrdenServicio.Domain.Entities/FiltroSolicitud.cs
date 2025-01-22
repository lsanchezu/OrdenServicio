using System;
using System.Collections.Generic;
using System.Text;

namespace Minsur.OrdenServicio.Domain.Entities
{
    public class FiltroSolicitud
    {
        public int IdFuenteContrato { get; set; }
        public int IdProyecto { get; set; }
        public int IdCompania { get; set; }
        public int IdEstado { get; set; }
        public int IdAreaFuncional { get; set; }
        public int IdFaseProyecto { get; set; }
        public string FechaInicio { get; set; }
        public string FechaFin { get; set; }
        public int IdUsuario { get; set; }
    }
}
