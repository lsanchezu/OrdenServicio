using System;
using System.Collections.Generic;
using System.Text;

namespace Minsur.OrdenServicio.Domain.Entities
{
    public class SolicitudRecomendacion
    {
        public int IdSolicitudOrdenServicio { get; set; }
        public Usuario Usuario { get; set; }
        public string Comentario { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public bool FlagRecomendado { get; set; }
    }
}
