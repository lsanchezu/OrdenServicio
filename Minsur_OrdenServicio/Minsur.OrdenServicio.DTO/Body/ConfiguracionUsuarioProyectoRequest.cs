using System;
using System.Collections.Generic;
using System.Text;

namespace Minsur.OrdenServicio.DTO.Body
{
    public class ConfiguracionUsuarioProyectoRequest
    {
        public ListaConfiguracionUsuarioProyectoDto ListaConfiguracionUsuarioProyectoDto { get; set; }
        public int IdUsuario { get; set; }
        public int IdRol { get; set; }
        public int IdEstado { get; set; }
    }
}
