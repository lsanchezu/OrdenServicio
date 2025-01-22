using System;
using System.Collections.Generic;
using System.Text;

namespace Minsur.OrdenServicio.Domain.Entities
{
    public class Tipo
    {
        public int IdTipo { get; set; }
        public string Descripcion { get; set; }
    }
    public class ListaTipo : List<Tipo> {}
}
