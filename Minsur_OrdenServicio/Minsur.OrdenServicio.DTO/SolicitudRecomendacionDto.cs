using System;
using System.Collections.Generic;
using System.Text;

namespace Minsur.OrdenServicio.DTO
{
    public class SolicitudRecomendacionDto
    {
        public int IdSolicitudOrdenServicio { get; set; }
        public UsuarioDto UsuarioDto { get; set; }
        public string Estado { get; set; }
        public string Comentario { get; set; }
        public string FechaRegistro { get; set; }
        public bool FlagRecomendado { get; set; }
    }
}
