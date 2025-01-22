using System;
using System.Collections.Generic;
using System.Text;

namespace Minsur.OrdenServicio.Domain.Entities
{
    public class EmailParametro
    {
        public int IdEmailParametro { get; set; }
        public string Descripcion { get; set; }
        public string Asunto { get; set; }
        public string Para { get; set; }
        public string ConCopia { get; set; }
        public string Plantilla { get; set; }
    }
}
