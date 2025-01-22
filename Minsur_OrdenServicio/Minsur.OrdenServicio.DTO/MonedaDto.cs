using System;
using System.Collections.Generic;
using System.Text;

namespace Minsur.OrdenServicio.DTO
{
    public class MonedaDto
    {
        public int IdMoneda { get; set; }
        public string Descripcion { get; set; }
    }

    public class ListaMonedaDto : List<MonedaDto> { }
}
