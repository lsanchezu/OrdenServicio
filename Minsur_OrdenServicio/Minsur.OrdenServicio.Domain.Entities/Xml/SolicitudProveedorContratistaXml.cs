using System;
using System.Collections.Generic;
using System.Text;

namespace Minsur.OrdenServicio.Domain.Entities.Xml
{
    public class SolicitudProveedorContratistaXml
    {
        public int IdPais { get; set; }
        public string DenominacionSocial { get; set; }
        public string Documento { get; set; }
    }

    public class ListaSolicitudProveedorContratistaXml : List<SolicitudProveedorContratistaXml> { }
}
