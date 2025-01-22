using System;
using System.Collections.Generic;
using System.Text;

namespace Minsur.OrdenServicio.Domain.Entities
{
    public class Estado
    {
        public int IdEstado { get; set; }
        public string Nombre { get; set; }
    }

    public class ListaEstado : List<Estado> { }
}
