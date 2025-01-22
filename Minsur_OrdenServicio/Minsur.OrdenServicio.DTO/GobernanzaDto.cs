using System;
using System.Collections.Generic;
using System.Text;

namespace Minsur.OrdenServicio.DTO
{
    public class GobernanzaDto
    {
        public int IdGobernanza { get; set; }
        public string Descripcion { get; set; }
        public bool FlagApruebaSolicitud { get; set; }
        public int Orden { get; set; }
    }
    public class ListaGobernanzaDto : List<GobernanzaDto> { }

}
