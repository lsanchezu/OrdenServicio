using System;
using System.Collections.Generic;
using System.Text;

namespace Minsur.OrdenServicio.Domain.Entities
{
    public class SolicitudValidacion
    {
        public int IdSolicitudOrdenServicio { get; set; }
        public Usuario Usuario { get; set; }
        public bool FlagExistePresupuesto { get; set; }
        public string Grafo { get; set; }
        public string Comentario { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public bool FlagValidado { get; set; }
    }
}
