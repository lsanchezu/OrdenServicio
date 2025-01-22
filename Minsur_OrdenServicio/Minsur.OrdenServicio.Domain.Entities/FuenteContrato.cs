using System;
using System.Collections.Generic;
using System.Text;

namespace Minsur.OrdenServicio.Domain.Entities
{
    public class FuenteContrato
    {
        public int IdFuenteContrato { get; set; }
        public string Descripcion { get; set; }
    }

    public class ListaFuenteContrato : List<FuenteContrato> { }
}
