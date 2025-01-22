using System;
using System.Collections.Generic;
using System.Text;

namespace Minsur.OrdenServicio.DTO
{
    public class FuenteContratoDto
    {
        public int IdFuenteContrato { get; set; }
        public string Descripcion { get; set; }
    }

    public class ListaFuenteContratoDto : List<FuenteContratoDto> { }
}
