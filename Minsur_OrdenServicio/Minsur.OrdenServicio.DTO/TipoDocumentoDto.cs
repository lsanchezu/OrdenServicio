using System;
using System.Collections.Generic;
using System.Text;

namespace Minsur.OrdenServicio.DTO
{
    public class TipoDocumentoDto
    {
        public int IdTipoDocumento { get; set; }
        public string Descripcion { get; set; }
    }

    public class ListaTipoDocumentoDto : List<TipoDocumentoDto> { }
}
