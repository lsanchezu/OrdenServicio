using System;
using System.Collections.Generic;
using System.Text;

namespace Minsur.OrdenServicio.DTO
{
    public class PaisDto
    {
        public int IdPais { get; set; }
        public string Descripcion { get; set; }
    }

    public class ListaPaisDto : List<PaisDto> { }
}
