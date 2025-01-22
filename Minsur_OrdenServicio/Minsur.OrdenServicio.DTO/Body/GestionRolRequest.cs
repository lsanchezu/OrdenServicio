using System;
using System.Collections.Generic;
using System.Text;

namespace Minsur.OrdenServicio.DTO.Body
{
    public class GestionRolRequest
    {
        public ListaRolGobernanzaDto ListaRoles { get; set; }
        public ListaRolDisciplinaDto ListaDisciplinas { get; set; }
        public ListaConfiguracionRolDto ListaConfiguracionRolDto { get; set; }
        public int IdProyecto { get; set; }

    }
}
