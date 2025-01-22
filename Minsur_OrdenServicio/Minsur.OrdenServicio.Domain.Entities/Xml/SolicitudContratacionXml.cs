using System;
using System.Collections.Generic;
using System.Text;

namespace Minsur.OrdenServicio.Domain.Entities.Xml
{
    public class SolicitudOrdenServicioXml
    {
        public int IdUsuarioSolicitante { get; set; }
        public int IdCompania { get; set; }
        public int IdFuenteContrato { get; set; }
        public int IdProyecto { get; set; }
        public int IdFaseProyecto { get; set; }
        public int IdAreaFuncional { get; set; }
        public int IdCategoria { get; set; }
        public int IdMoneda { get; set; }
        public int IdTipo { get; set; }
        public string DescripcionMoneda { get; set; }
        public DateTime FechaSolicitud { get; set; }
        public string FechaSolicitudCorto { get; set; }
        public decimal MontoEstimado { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaTermino { get; set; }
        public int DiasCalendario { get; set; }
        public string DenominacionServicio { get; set; }
        public string DescripcionServicio { get; set; }
        public string UbicacionServicio	 { get; set; }
        public string JustificacionSoleSource { get; set; }
        public int IdEstado { get; set; }
    }
}
