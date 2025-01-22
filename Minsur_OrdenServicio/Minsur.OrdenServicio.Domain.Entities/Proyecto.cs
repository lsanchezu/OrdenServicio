using System;
using System.Collections.Generic;
using System.Text;

namespace Minsur.OrdenServicio.Domain.Entities
{
    public class Proyecto
    {
        public int IdProyecto { get; set; }
        public string Descripcion { get; set; }
        public int IdEstado { get; set; }
        public string Estado { get; set; }
        public int IdCompania { get; set; }
    }

    public class ListaProyecto : List<Proyecto> { }
}
