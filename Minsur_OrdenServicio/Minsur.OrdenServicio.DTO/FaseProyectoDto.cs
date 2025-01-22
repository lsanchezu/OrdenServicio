using System;
using System.Collections.Generic;
using System.Text;

namespace Minsur.OrdenServicio.DTO
{
    public class FaseProyectoDto
    {
        public int IdFaseProyecto { get; set; }
        public string Descripcion { get; set; }
    }

    public class ListaFaseProyectoDto : List<FaseProyectoDto> { }
}
