using System;
using System.Collections.Generic;
using System.Text;

namespace Minsur.OrdenServicio.DTO
{
    public class AreaFuncionalDto
    {
        public int IdAreaFuncional { get; set; }
        public string Descripcion { get; set; }
    }

    public class ListaAreaFuncionalDto : List<AreaFuncionalDto> { }
}
