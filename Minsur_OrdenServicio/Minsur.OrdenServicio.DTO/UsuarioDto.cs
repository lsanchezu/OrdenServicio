using System;
using System.Collections.Generic;
using System.Text;

namespace Minsur.OrdenServicio.DTO
{
    public class UsuarioDto
    {
        public int IdUsuario { get; set; }
        public string NombreUsuario { get; set; }
        public string NombreApellido { get; set; }
        public int IdCargo { get; set; }
        public string NombreCargo { get; set; }
        public RolDto RolDto { get; set; }
    }
}
