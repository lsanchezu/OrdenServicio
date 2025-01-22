using System;
using System.Collections.Generic;
using System.Text;

namespace Minsur.OrdenServicio.Domain.Entities.Xml
{
    public class SolicitudDocumentoXml
    {
        public int IdTipoDocumento { get; set; }
        public ListaSolicitudArchivoAdjuntoXml ListaSolicitudArchivoAdjuntoXml { get; set; }
    }

    public class ListaSolicitudDocumentoXml : List<SolicitudDocumentoXml> { }
}
