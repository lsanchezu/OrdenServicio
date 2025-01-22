using System;
using System.Collections.Generic;
using System.Text;

namespace Minsur.OrdenServicio.Seguridad.Domain.Entities
{
    public class Rol
    {
        public int IdRol { get; set; }
        public string Nombre { get; set; }
    }
    public class ListaRol : List<Rol> { }
}
