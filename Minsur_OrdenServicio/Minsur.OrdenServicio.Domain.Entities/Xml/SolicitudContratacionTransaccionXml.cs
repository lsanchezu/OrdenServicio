using System;
using System.Collections.Generic;
using System.Text;

namespace Minsur.OrdenServicio.Domain.Entities.Xml
{
    public class SolicitudOrdenServicioTransaccionXml
    {
        public SolicitudOrdenServicioXml SolicitudOrdenServicioXml { get; set; }
        public ListaSolicitudProveedorContratistaXml ListaSolicitudProveedorContratistaXml { get; set; }
        public ListaSolicitudDocumentoXml ListaSolicitudDocumentoXml { get; set; }
    }
}
