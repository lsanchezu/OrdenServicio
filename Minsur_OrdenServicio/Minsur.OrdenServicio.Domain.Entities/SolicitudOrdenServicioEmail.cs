using System;
using System.Collections.Generic;
using System.Text;

namespace Minsur.OrdenServicio.Domain.Entities
{
    public class SolicitudOrdenServicioEmail
    {
        public int IdSolicitudOrdenServicio { get; set; }
        public int IdUsuario { get; set; }
        public string Para { get; set; }
        public string Asunto { get; set; }
        public string Contenido { get; set; }
        public bool FlagEnviado { get; set; }
        public string MensajeError { get; set; }
    }
}
