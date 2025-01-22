using System;
using System.Collections.Generic;
using System.Text;

namespace Minsur.OrdenServicio.DTO
{
    public class SolicitudProveedorContratistaDto
    {
        public int IdSolicitudProveedorContratista { get; set; }
        public PaisDto PaisDto { get; set; }
        public string DenominacionSocial { get; set; }
        public string Documento { get; set; }
    }

    public class ListaSolicitudProveedorContratistaDto : List<SolicitudProveedorContratistaDto> { }
}
