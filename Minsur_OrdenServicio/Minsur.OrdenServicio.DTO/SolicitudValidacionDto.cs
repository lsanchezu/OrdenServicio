using System;
using System.Collections.Generic;
using System.Text;

namespace Minsur.OrdenServicio.DTO
{
    public class SolicitudValidacionDto
    {
        public int IdSolicitudOrdenServicio { get; set; }
        public UsuarioDto UsuarioDto { get; set; }
        public bool FlagExistePresupuesto { get; set; }
        public string Grafo { get; set; }
        public string Comentario { get; set; }
        public string FechaRegistro { get; set;}
        public string Estado { get; set; }
        public bool FlagValidado { get; set; }
        public int IdFuenteContrato { get; set; }
    }
}
