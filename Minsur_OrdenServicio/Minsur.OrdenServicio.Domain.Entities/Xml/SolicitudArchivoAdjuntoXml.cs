using System;
using System.Collections.Generic;
using System.Text;

namespace Minsur.OrdenServicio.Domain.Entities.Xml
{
    public class SolicitudArchivoAdjuntoXml
    {
        public string Directorio { get; set; }
        public string NombreArchivo { get; set; }
        public string Extension { get; set; }
        public string TipoContenido { get; set; }
        public int Tamanio { get; set; }
    }

    public class ListaSolicitudArchivoAdjuntoXml : List<SolicitudArchivoAdjuntoXml> { }
}
