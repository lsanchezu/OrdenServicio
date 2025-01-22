using System;
using System.Collections.Generic;
using System.Text;

namespace Minsur.OrdenServicio.DTO.Body
{
    public class GobernanzaRequest
    {
        public ListaConfiguracionGobernanzaDto ListaConfiguracionGobernanzaDto { get; set; }
        public int IdProyecto { get; set; }
    }
}
