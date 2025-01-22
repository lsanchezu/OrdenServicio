using System;
using System.Collections.Generic;
using System.Text;

namespace Minsur.OrdenServicio.Domain.Entities
{
    public class Pais
    {
        public int IdPais { get; set; }
        public string Descripcion { get; set; }
    }

    public class ListaPais : List<Pais> { }
}
