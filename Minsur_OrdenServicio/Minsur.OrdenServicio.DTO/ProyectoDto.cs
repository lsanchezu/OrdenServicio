using System;
using System.Collections.Generic;
using System.Text;

namespace Minsur.OrdenServicio.DTO
{
    public class ProyectoDto
    {
        public int IdProyecto { get; set; }
        public string Descripcion { get; set; }
        public int IdEstado { get; set; }
        public string Estado { get; set; }
        public int IdCompania { get; set; }
    }

    public class ListaProyectoDto : List<ProyectoDto> { }
}
