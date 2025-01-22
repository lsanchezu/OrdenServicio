using System;
using System.Collections.Generic;
using System.Text;

namespace Minsur.OrdenServicio.DTO
{
    public class TipoDto
    {
        public int IdTipo { get; set; }
        public string Descripcion { get; set; }
    }
    public class ListaTipoDto : List<TipoDto> { }
}
