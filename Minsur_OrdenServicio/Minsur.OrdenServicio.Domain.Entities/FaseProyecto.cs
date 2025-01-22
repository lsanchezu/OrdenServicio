using System;
using System.Collections.Generic;
using System.Text;

namespace Minsur.OrdenServicio.Domain.Entities
{
    public class FaseProyecto
    {
        public int IdFaseProyecto { get; set; }
        public string Descripcion { get; set; }
    }

    public class ListaFaseProyecto : List<FaseProyecto> { }
}
