using System;
using System.Collections.Generic;
using System.Text;

namespace Minsur.OrdenServicio.Domain.Entities
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string NombreUsuario { get; set; }
        public string NombreApellido { get; set; }
        public string NombreCargo { get; set; }
        public int IdCargo { get; set; }
        public int IdRol { get; set; }
        public string Sexo { get; set; }
        public string Correo { get; set; }
    }
}
