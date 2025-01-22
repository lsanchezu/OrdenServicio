using System;
using System.Collections.Generic;
using System.Text;

namespace Minsur.OrdenServicio.DTO
{
    public class ConfiguracionGobernanzaDto
    {
        public int IdConfiguracionGobernanza { get; set; }
        public int IdEstado { get; set; }
        public bool FlagApruebaSolicitud { get; set; }
        public GobernanzaDto GobernanzaDto { get; set; }
    }
    public class ListaConfiguracionGobernanzaDto : List<ConfiguracionGobernanzaDto> { }

}
