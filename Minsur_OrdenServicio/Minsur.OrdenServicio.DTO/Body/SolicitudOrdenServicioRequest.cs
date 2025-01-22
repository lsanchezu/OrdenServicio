using System;
using System.Collections.Generic;
using System.Text;

namespace Minsur.OrdenServicio.DTO.Body
{
    public class SolicitudOrdenServicioRequest
    {
        public int IdSolicitudOrdenServicio { get; set; }
        public UsuarioDto UsuarioDto { get; set; }
    }
}
