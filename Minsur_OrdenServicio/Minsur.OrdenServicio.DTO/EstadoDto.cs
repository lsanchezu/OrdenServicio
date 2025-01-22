using System;
using System.Collections.Generic;
using System.Text;

namespace Minsur.OrdenServicio.DTO
{
    public class EstadoDto
    {
        public int IdEstado { get; set; }
        public string Nombre { get; set; }
    }

    public class ListaEstadoDto : List<EstadoDto> { }
}
