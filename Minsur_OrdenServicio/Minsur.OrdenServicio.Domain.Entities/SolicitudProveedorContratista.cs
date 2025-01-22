using System;
using System.Collections.Generic;
using System.Text;

namespace Minsur.OrdenServicio.Domain.Entities
{
    public class SolicitudProveedorContratista
    {
        public int IdSolicitudProveedorContratista { get; set; }
        public Pais Pais { get; set; }
        public string DenominacionSocial { get; set; }
        public string Documento { get; set; }
    }

    public class ListaSolicitudProveedorContratista : List<SolicitudProveedorContratista> { }
}
