using System;
using System.Collections.Generic;
using System.Text;

namespace Minsur.OrdenServicio.DTO
{
    public class CategoriaDto
    {
        public int IdCategoria { get; set; }
        public string Descripcion { get; set; }
    }

    public class ListaCategoriaDto : List<CategoriaDto> { }
}
