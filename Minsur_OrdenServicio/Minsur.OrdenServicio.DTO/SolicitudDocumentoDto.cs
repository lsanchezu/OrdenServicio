using System;
using System.Collections.Generic;
using System.Text;

namespace Minsur.OrdenServicio.DTO
{
    public class SolicitudDocumentoDto
    {
        public int IdSolicitudDocumento { get; set; }
        public TipoDocumentoDto TipoDocumentoDto { get; set; }
        public ListaSolicitudArchivoAdjuntoDto ListaSolicitudArchivoAdjuntoDto { get; set; }
    }

    public class ListaSolicitudDocumentoDto : List<SolicitudDocumentoDto> {}
}
