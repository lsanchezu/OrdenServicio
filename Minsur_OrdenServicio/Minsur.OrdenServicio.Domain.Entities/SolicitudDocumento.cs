using System;
using System.Collections.Generic;
using System.Text;

namespace Minsur.OrdenServicio.Domain.Entities
{
    public class SolicitudDocumento
    {
        public int IdSolicitudDocumento { get; set; }
        public int IdSolicitudOrdenServicio { get; set; }
        public TipoDocumento TipoDocumento { get; set; }
        public ListaSolicitudArchivoAdjunto ListaSolicitudArchivoAdjunto { get; set; }

        public SolicitudDocumento()
        {
            ListaSolicitudArchivoAdjunto = new ListaSolicitudArchivoAdjunto();
        }
    }

    public class ListaSolicitudDocumento : List<SolicitudDocumento> { }
}
