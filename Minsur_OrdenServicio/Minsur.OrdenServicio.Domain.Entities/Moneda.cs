using System;
using System.Collections.Generic;
using System.Text;

namespace Minsur.OrdenServicio.Domain.Entities
{
    public class Moneda
    {
        public int IdMoneda { get; set; }
        public string Descripcion { get; set; }
    }

    public class ListaMoneda : List<Moneda> { }
}
