using System;
using System.Collections.Generic;
using System.Text;

namespace Minsur.OrdenServicio.Domain.Entities
{
    public class AreaFuncional
    {
        public int IdAreaFuncional { get; set; }
        public string Descripcion { get; set; }
    }

    public class ListaAreaFuncional: List<AreaFuncional> {}
}
