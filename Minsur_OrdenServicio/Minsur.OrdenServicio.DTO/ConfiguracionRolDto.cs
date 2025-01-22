using System;
using System.Collections.Generic;
using System.Text;

namespace Minsur.OrdenServicio.DTO
{
    public class ConfiguracionRolDto
    {
        public UsuarioDto UsuarioDto { get; set; }
        public ListaRolGobernanzaDto ListaRolGobernanzaDto { get; set; }
        public ListaRolDisciplinaDto ListaRolDisciplinaDto { get; set; }

    }
    public class ListaConfiguracionRolDto : List<ConfiguracionRolDto> { }
}
