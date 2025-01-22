using System;
using System.Collections.Generic;
using System.Text;

namespace Minsur.OrdenServicio.Domain.Entities
{
    public class TipoDocumento
    {
        public int IdTipoDocumento { get; set; }
        public string Descripcion { get; set; }
    }

    public class ListaTipoDocumento : List<TipoDocumento> { }
}
