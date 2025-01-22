using System;
using System.Collections.Generic;
using System.Text;

namespace Minsur.OrdenServicio.DTO
{
    public class RolGobernanzaDto
    {
        public int IdRolGobernanza { get; set; }
        public string Descripcion { get; set; }
        public int Orden { get; set; }
        public bool FlagTipoProcura { get; set; }
        public int IdEstado { get; set; }
        public int IdUsuario { get; set; }
        public int IdConfiguracionDestino { get; set; }
        public int IdProyecto { get; set; }
        public bool FlagProcuraContrato { get; set; }


    }
    public class ListaRolGobernanzaDto : List<RolGobernanzaDto> { }

}
