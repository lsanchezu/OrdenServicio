using System;
using System.Collections.Generic;
using System.Text;

namespace Minsur.OrdenServicio.Domain.Entities
{
    public class ConfiguracionRol
    {
        public Usuario Usuario { get; set; }
        public ListaRolGobernanza ListaRolGobernanza { get; set; }
        public ListaRolDisciplina ListaRolDisciplina { get; set; }

    }
    public class ListaConfiguracionRol : List<ConfiguracionRol> { }

}
