using Minsur.OrdenServicio.Common.Enumeracion;
using System;
using System.Collections.Generic;
using System.Text;

namespace Minsur.OrdenServicio.Domain.Entities
{
    public class SolicitudAutorizacion
    {
        public int IdSolicitudOrdenServicio { get; set; }
        public Gobernanza Gobernanza { get; set; }
        public Usuario Usuario { get; set; }
        public string Comentario { get; set; }
        public DateTime FechaRegistro { get; set; }
        public bool FlagAprobado { get; set; }
    }

    public class ListaSolicitudAutorizacion : List<SolicitudAutorizacion> { }
}
